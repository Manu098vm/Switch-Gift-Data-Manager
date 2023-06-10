using System.Buffers.Binary;
using Enums;

namespace SwitchGiftDataManager.Core;

public class WC8 : Wondercard
{
    private const int WondercardIDOffset = 0x08;
    private const int FlagOffset = 0x10;
    private const int GiftTypeOffset = 0x11;
    private const int ItemOffset = 0x20;
    private const int QuantityOffset = 0x22;
    private const int ClothingOffset = 0x24;
    private const int TIDOffset = 0x20;
    private const int SIDOffset = 0x22;
    private const int PIDOffset = 0x2C;
    private const int SpeciesOffset = 0x240;
    private const int ShinyTypeOffset = 0x248;
    private const int ChecksumOffset = 0x2CC;

    public WC8(ReadOnlySpan<byte> data) : base(data)
    {
        WCID = BinaryPrimitives.ReadUInt16LittleEndian(data[WondercardIDOffset..]);
        IsRepeatable = (Data![FlagOffset] & 1) == 0;
        Type = (GiftType8)Data![GiftTypeOffset];
        Content = Type switch
        {
            GiftType8.Pokemon => GetPokemon(),
            _ => GetItems(),
        };
    }

    private PokemonGift GetPokemon()
    {
        var species = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(SpeciesOffset));
        var pid = BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(PIDOffset));
        var tid = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(TIDOffset));
        var sid = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(SIDOffset));
        var test = (ShinyType8)Data![ShinyTypeOffset];
        var pidtype = (ShinyType8)Data![ShinyTypeOffset] switch
        {
            ShinyType8.ShinyLocked => PIDType.RandomPID,
            ShinyType8.ShinyRandom => PIDType.RandomPID,
            ShinyType8.ShinyStar => PIDType.FixedPID,
            ShinyType8.ShinySquare => PIDType.FixedPID,
            ShinyType8.Fixed => PIDType.FixedPID,
            _ => throw new ArgumentOutOfRangeException(),
        };
        var shinytype = (ShinyType8)Data![ShinyTypeOffset] switch
        {
            ShinyType8.ShinyLocked => ShinyType.ShinyLocked,
            ShinyType8.ShinyRandom => ShinyType.ShinyPossible,
            ShinyType8.ShinyStar or ShinyType8.ShinySquare => ShinyType.ShinyForced,
            ShinyType8.Fixed => PokemonGift.IsShiny(pid, tid, sid) ? ShinyType.ShinyForced :
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
            ushort quantity = 0;
            ushort opt = 0;
            var type = (GiftType8)Type!;

            if (type is GiftType8.Clothing)
            {
                item = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(ItemOffset + (0x08 * i)));
                opt = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(ClothingOffset + (0x08 * i)));
            }
            else
            {
                item = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(ItemOffset + (0x04 * i)));
                quantity = type is GiftType8.BP or GiftType8.Money ? item : BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(QuantityOffset + (0x04 * i)));
            }

            var gift = new OtherGift
            {
                Type = type,
                Item = item,
                Quantity = quantity,
                Opt = opt,
            };

            if (gift.Item != ushort.MinValue && opt != ushort.MaxValue)
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