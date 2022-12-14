using System.Buffers.Binary;
using Enums;

namespace SwitchGiftDataManager.Core
{
    internal class WC9 : Wondercard
    {
        private const int WondercardIDOffset = 0x08;
        private const int GiftTypeOffset = 0x11;
        private const int ItemOffset = 0x18;
        private const int QuantityOffset = 0x1A;
        private const int ClothingOffset = 0x1C;
        private const int TIDOffset = 0x18;
        private const int PIDOffset = 0x24;
        private const int SpeciesOffset = 0x238;
        private const int ShinyTypeOffset = 0x240;
        private const int ChecksumOffset = 0x2C4;

        public WC9(ReadOnlySpan<byte> data) : base(data)
        {
            WCID = BinaryPrimitives.ReadUInt16LittleEndian(data[WondercardIDOffset..]);
            Type = (GiftType9)Data![GiftTypeOffset];
            Content = Type switch
            {
                GiftType9.Pokemon => GetPokemon(),
                _ => GetItems(),
            };
        }

        private PokemonGift GetPokemon()
        {
            var species = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(SpeciesOffset));
            var pid = BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(PIDOffset));
            var tid = (ushort)((BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(TIDOffset)) - (0xF4240 * WCID)) & 0xFFFF);
            var sid = (ushort)((BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(TIDOffset)) - (0xF4240 * WCID)) >> 16 & 0xFFFF);
            var test = (ShinyType9)Data![ShinyTypeOffset];
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
                ushort opt = 0;
                var type = (GiftType9)Type!;

                if (type is GiftType9.Clothing)
                {
                    item = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(ItemOffset + (0x08 * i)));
                    opt = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(ClothingOffset + (0x08 * i)));
                }
                else
                {
                    item = BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(ItemOffset + (0x04 * i)));
                    quantity = type is GiftType9.LP ? BinaryPrimitives.ReadUInt32LittleEndian(Data.AsSpan(ItemOffset + (0x04 * i))) : 
                        BinaryPrimitives.ReadUInt16LittleEndian(Data.AsSpan(QuantityOffset + (0x04 * i)));
                }

                var gift = new OtherGift
                {
                    Type = type,
                    Item = item,
                    Quantity = quantity,
                    Opt = opt,
                };

                if ((type is not GiftType9.Clothing && gift.Item != 0x00) || (type is GiftType9.Clothing && opt != 0xFFFF))
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
    }
}
