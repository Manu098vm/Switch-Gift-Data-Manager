using Enums;

namespace SwitchGiftDataManager.Core;

public class PokemonGift
{
    public ushort Species { get; set; }
    public uint PID { get; set; }
    public uint TID { get; set; }
    public uint SID { get; set; }
    public ShinyType ShinyType { get; set; }
    public PIDType PIDType { get; set; }

    public string GetSpeciesName() => GetSpeciesName(Species);

    public bool IsShiny() => ShinyType switch
    {
        ShinyType.ShinyForced => true,
        ShinyType.ShinyPossible => (PID != 0 && TID != 0 && SID != 0) && IsShiny(PID, TID, SID),
        _ => false,
    };

    public static string GetSpeciesName(uint species) => Properties.Resources.Species.Split(["\n"], StringSplitOptions.None)[species];

    public static bool IsShiny(uint pid, uint tid, uint sid) => (sid != 0 || tid != 0) && (sid ^ tid ^ (pid >> 16) ^ (pid & 0xFFFF)) < 16;

    public static bool IsTIDAbusePossible(uint tid, uint sid, PIDType type) => type switch
    {
        PIDType.FixedPID => tid == 0 && sid == 0,
        _ => false,
    };
}