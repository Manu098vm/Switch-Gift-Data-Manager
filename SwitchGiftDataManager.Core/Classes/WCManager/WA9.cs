using System.Buffers.Binary;
using Enums;

namespace SwitchGiftDataManager.Core;

public class WA9 : Wondercard
{
    private const int WondercardIDOffset = 0x08;
    private const int FlagOffset = 0x10;
    private const int GiftTypeOffset = 0x11;
    private const int ItemOffset = 0x18;
    private const int QuantityOffset = 0x1A;
    private const int TIDOffset = 0x18;
    private const int SIDOffset = 0x1A;
    private const int PIDOffset = 0x24;
    private const int FlagStringOffset = 0x28;
    private const int FlagItemOffset = 0x6C;
    private const int FlagItemQuantityOffset = 0x6E;
    private const int SpeciesOffset = 0x270;
    private const int ShinyTypeOffset = 0x278;
    private const int ChecksumOffset = 0x2C0;

    public WA9(ReadOnlySpan<byte> data) : base(data)
    {
        WCID = BinaryPrimitives.ReadUInt16LittleEndian(data[WondercardIDOffset..]);
        IsRepeatable = (Data![FlagOffset] & 1) == 0;
        Type = (GiftType9A)Data![GiftTypeOffset];
        Content = Type switch
        {
            GiftType9A.Pokemon => GetPokemon(),
            _ => GetItems(),
        };
    }

    private PokemonGift GetPokemon()
    {
        var species = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(SpeciesOffset));
        var pid = BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(PIDOffset));
        var tid = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(TIDOffset));
        var sid = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(SIDOffset));
        var pidtype = (ShinyType9)Data![ShinyTypeOffset] switch
        {
            ShinyType9.ShinyLocked => PIDType.RandomPID,
            ShinyType9.ShinyRandom => PIDType.RandomPID,
            ShinyType9.ShinyStar => PIDType.FixedPID,
            ShinyType9.ShinySquare => PIDType.FixedPID,
            ShinyType9.Fixed => PIDType.FixedPID,
            _ => throw new ArgumentOutOfRangeException(),
        };
        var shinytype = (ShinyType9)Data![ShinyTypeOffset] switch
        {
            ShinyType9.ShinyLocked => ShinyType.ShinyLocked,
            ShinyType9.ShinyRandom => ShinyType.ShinyPossible,
            ShinyType9.ShinyStar or ShinyType9.ShinySquare => ShinyType.ShinyForced,
            ShinyType9.Fixed => PokemonGift.IsShiny(pid, tid, sid) ? ShinyType.ShinyForced :
                PokemonGift.IsTIDAbusePossible(tid, sid, pidtype) ? ShinyType.ShinyTIDAbuse : ShinyType.ShinyLocked,
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
            ushort item = 0;
            uint quantity = 0;
            uint opt = 0;
            var type = (GiftType9A)Type!;

            if (type is GiftType9A.Clothing)
            {
                item = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(ItemOffset + (0x04 * i)));
                opt = BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(ItemOffset + (0x04 * i)));
            }
            else
            {
                item = type is GiftType9A.Flag ? BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(FlagItemOffset + (0x04 * i))) :
                    BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(ItemOffset + (0x04 * i)));
                quantity = type is GiftType9A.Flag ? BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(FlagItemQuantityOffset + (0x04 * i))) : 
                    BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(QuantityOffset + (0x04 * i)));
            }

            var gift = new OtherGift
            {
                Type = type,
                Item = item,
                Quantity = quantity,
                Opt = opt,
            };

            if ((type is not GiftType9A.Clothing && gift.Item != ushort.MinValue) || (type is GiftType9A.Clothing && item != ushort.MaxValue))
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