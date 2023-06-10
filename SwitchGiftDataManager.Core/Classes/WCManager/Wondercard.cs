using Enums;
using System.Buffers.Binary;

namespace SwitchGiftDataManager.Core;

public abstract class Wondercard
{
    public static int GenOffset = 0x0F;  
    protected const int MaxItemCount = 6;

    public Games Game { get; }
    public ushort WCID { get; protected set; }
    public bool IsRepeatable { get; protected set; }
    public object? Type { get; protected set; }
    public object? Content { get; protected set; }
    public byte[]? Data { get; protected set; }

    public Wondercard(ReadOnlySpan<byte> data)
    {
        Game = (WondercardSize)data.Length switch
        {
            WondercardSize.WB7 => Games.LGPE,
            WondercardSize.WC8 => Games.SWSH,
            WondercardSize.WB8 => Games.BDSP,
            WondercardSize.WA8 when data[GenOffset] != 0 => Games.PLA,
            WondercardSize.WC9 when data[GenOffset] == 0 => Games.SCVI,
            _ => Games.None,
        };
        Data = data.ToArray();
    }

    public bool IsValid()
    {
        if (WCID <= 0)
            return false;

        if (Content is null)
            return false;

#if DEBUG
        if (!IsChecksumValid())
            UpdateChecksum();
#endif

        if (!IsChecksumValid())
            return false;

        return true;
    }

    public ReadOnlySpan<byte> CalcMetaChecksum() => ChecksumCalculator.CalcReverseMD5(Data!);

    public abstract bool IsChecksumValid();

    public abstract void UpdateChecksum();

    public abstract void SetID(ushort wcid);

    public abstract void SetRepeatable(bool repeatable);

    public static WondercardSize GetSize(Games game)
    {
        return game switch
        {
            Games.LGPE => WondercardSize.WB7,
            Games.SWSH => WondercardSize.WC8,
            Games.BDSP => WondercardSize.WB8,
            Games.PLA => WondercardSize.WA8,
            Games.SCVI => WondercardSize.WC9,
            _ => throw new ArgumentOutOfRangeException(nameof(game)),
        };
    }
}