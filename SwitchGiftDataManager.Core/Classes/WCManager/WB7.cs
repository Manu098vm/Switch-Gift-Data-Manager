using System.Buffers.Binary;
using Enums;

namespace SwitchGiftDataManager.Core;

public class WB7 : Wondercard
{
    private const int WondercardIDOffset = 0x208;
    private const int GiftTypeOffset = 0x259;
    private const int FlagOffset = 0x25A;
    private const int ItemOffset = 0x270;
    private const int QuantityOffset = 0x272;
    private const int TIDOffset = 0x270;
    private const int SIDOffset = 0x272;
    private const int SpeciesOffset = 0x28A;
    private const int ShinyTypeOffset = 0x2AB;
    private const int PIDOffset = 0xD4;
    private const int ChecksumOffset = 0x202;

    public WB7(ReadOnlySpan<byte> data) : base(data)
    {
        WCID = BinaryPrimitives.ReadUInt16LittleEndian(data[WondercardIDOffset..]);
        IsRepeatable = (Data![FlagOffset] & 1) == 0;
        Type = (GiftType7)Data![GiftTypeOffset];
        Content = Type switch
        {
            GiftType7.Pokemon => GetPokemon(),
            _ => GetItems(),
        };
    }

    private PokemonGift GetPokemon()
    {
        var species = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(SpeciesOffset));
        var pid = BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(PIDOffset));
        var tid = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(TIDOffset));
        var sid = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(SIDOffset));
        var pidtype = (ShinyType7)Data![ShinyTypeOffset] switch
        {
            ShinyType7.Fixed => PIDType.FixedPID,
            ShinyType7.ShinyRandom => PIDType.RandomPID,
            ShinyType7.Shiny => PIDType.RandomPID,
            ShinyType7.ShinyLocked => PIDType.RandomPID,
            _ => throw new ArgumentOutOfRangeException(),
        };
        var shinytype = (ShinyType7)Data![ShinyTypeOffset] switch
        {
            ShinyType7.Fixed => PokemonGift.IsShiny(pid, tid, sid) ? ShinyType.ShinyForced :
                PokemonGift.IsTIDAbusePossible(tid, sid, pidtype) ? ShinyType.ShinyTIDAbuse : ShinyType.ShinyLocked,
            ShinyType7.ShinyRandom => ShinyType.ShinyPossible,
            ShinyType7.Shiny => ShinyType.ShinyForced,
            ShinyType7.ShinyLocked => ShinyType.ShinyLocked,
            _ => throw new ArgumentOutOfRangeException(),
        };

        return new PokemonGift
        {
            Species = species,
            PID = pid,
            TID = tid,
            SID = sid,
            ShinyType = shinytype,
            PIDType = pidtype,
        };
    }

    private List<OtherGift> GetItems()
    {
        List<OtherGift> items = new();
        for (int i = 0; i < MaxItemCount; i++)
        {
            var type = (GiftType7)Type!;
            var item = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(ItemOffset + (0x04 * i)));
            var quantity = type is GiftType7.BP ? item : BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(QuantityOffset + (0x04 * i)));

            var gift = new OtherGift
            {
                Type = type,
                Item = item,
                Quantity = quantity,
            };

            if (gift.Item != ushort.MinValue)
                items.Add(gift);
        }
        return items;
    }

    public override bool IsChecksumValid()
    {
        if (Data is not null)
        {
            var oldChecksum = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(ChecksumOffset));
            var span = Data.ToArray().AsSpan();
            BinaryPrimitives.WriteUInt16LittleEndian(span[ChecksumOffset..], 0x0);
            var newchecksum = ChecksumCalculator.CalcCcittFalse(span);
            if (oldChecksum == newchecksum)
                return true;
        }
        return false;
    }

    public override void UpdateChecksum()
    {
        BinaryPrimitives.WriteUInt16LittleEndian(Data.AsSpan(ChecksumOffset), 0x0);
        var checksum = ChecksumCalculator.CalcCcittFalse(Data.AsSpan());
        BinaryPrimitives.WriteUInt16LittleEndian(Data.AsSpan(ChecksumOffset), checksum);
    }

    public override void SetID(ushort wcid)
    {
        BinaryPrimitives.WriteUInt16LittleEndian(Data.AsSpan(WondercardIDOffset), wcid);
        WCID = wcid;
        UpdateChecksum();
    }

    public override void SetRepeatable(bool repeatable)
    {
        Data![FlagOffset] = (byte)((Data![FlagOffset] & ~1) | (repeatable ? 0 : 1));
        IsRepeatable = repeatable;
        UpdateChecksum();
    }
}