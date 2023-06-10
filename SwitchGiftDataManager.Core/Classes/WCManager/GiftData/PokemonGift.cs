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

    public bool IsShiny()
    {
        if (ShinyType is ShinyType.ShinyForced)
            return true;
        else if (ShinyType is ShinyType.ShinyPossible && PID != 0 && TID != 0 && SID != 0)
            return IsShiny(PID, TID, SID);

        return false;
    }

    public static string GetSpeciesName(uint species) => Properties.Resources.Species.Split(new string[] { "\n" }, StringSplitOptions.None)[species].Replace(",", "");

    public static bool IsShiny(uint pid, uint tid, uint sid) => sid != 0 || tid != 0 ? (sid ^ tid ^ (pid >> 16) ^ (pid & 0xFFFF)) < 16 : false;

    public static bool IsTIDAbusePossible(uint tid, uint sid, PIDType type)
    {
        if (type is PIDType.FixedPID)
            if (tid == 0)
                if (sid == 0)
                    return true;
        return false;
    }
}