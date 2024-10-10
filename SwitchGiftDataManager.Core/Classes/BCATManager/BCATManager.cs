using System.Buffers.Binary;
using System.Globalization;
using System.Text;
using Enums;

namespace SwitchGiftDataManager.Core;

public class BCATManager
{
    public const string Version = "1.7.1";

    private const int FileNameOffset = 0x00;
    private const int UnkOffset = 0x20;
    private const int FileSizeOffset = 0x28;
    private const int ChecksumOffset = 0x30;
    private const int MaxFileNameLength = 0x1F;
    private const int WCMetaInfoLength = 0x80;
    private const int MetaHeaderLength = 0x04;

    private Games Game { get; set; }
    private List<Wondercard>? WCList { get; set; }

    public BCATManager(Games game)
    {
        Game = game;
        WCList = new();
    }

    private Wondercard CreateWondercard(ReadOnlySpan<byte> data)
    {
        return Game switch
        {
            Games.LGPE => new WB7(data),
            Games.SWSH => new WC8(data),
            Games.BDSP => new WB8(data),
            Games.PLA => new WA8(data),
            Games.SCVI => new WC9(data),
            _ => throw new ArgumentOutOfRangeException(nameof(Game)),
        };
    }

    public bool TryAddWondercards(ReadOnlySpan<byte> data, bool sort = false)
    {
        var success = false;
        if (Game is not Games.None && WCList is not null)
            if (Game is not Games.LGPE || (Game is Games.LGPE && WCList.Count == 0))
            {
                var game = GetCompatibleGamesFromWC(data);
                if (game == Game)
                {
                    var size = (int)Wondercard.GetSize(game);
                    var qty = data.Length / size;
                    for (int i = 0; i < qty; i++)
                    {
                        var wc = CreateWondercard(data[(i * size)..((i + 1) * size)]);
                        if (wc.IsValid())
                        {
                            WCList.Add(wc);
                            success = true;
                        }
                    }
                }
                if (sort)
                    Sort();
            }
        return success;
    }

    public void Sort() => WCList!.Sort((x, y) => x.WCID.CompareTo(y.WCID));

    public int Count()
    {
        if (WCList is not null)
            return WCList.Count;

        return 0;
    }

    public void RemoveWC(int index)
    {
        if (WCList is not null && WCList.Count > 0 && WCList.Count >= index - 1)
            WCList.RemoveAt(index);
    }

    public void Reset()
    {
        if(WCList is not null)
            WCList.Clear();
        else
            WCList = new List<Wondercard>();
    }

    public void SetWCID(int index, ushort wcid)
    {
        if (WCList is not null && WCList.Count > 0 && WCList.Count >= index - 1 && index >= 0)
        {
            var wc = WCList.ElementAt(index);
            wc.SetID(wcid);
        }
    }

    public ushort GetWCID(int index)
    {
        if (WCList is not null && WCList.Count > 0 && WCList.Count >= index - 1 && index >= 0)
            return WCList.ElementAt(index).WCID;
        return 0;
    }

    public void SetIsRepeatable(int index, bool repeatable)
    {
        if (WCList is not null && WCList.Count > 0 && WCList.Count >= index - 1 && index >= 0)
        {
            var wc = WCList.ElementAt(index);
            wc.SetRepeatable(repeatable);
        }
    }

    public bool GetIsRepeatable(int index)
    {
        if (WCList is not null && WCList.Count > 0 && WCList.Count >= index - 1 && index >= 0)
            return WCList.ElementAt(index).IsRepeatable;
        return false;
    }

    public bool GetRequiresMethodSelection(int index)
    {
        if (WCList is not null && WCList.Count > 0 && WCList.Count >= index - 1 && index >= 0)
            if (WCList.ElementAt(index) is WC9 wc9)
                return wc9.RequiresMethodSelection;
        return false;
    }

    public bool GetIsBefore201(int index)
    {
        if (WCList is not null && WCList.Count > 0 && WCList.Count >= index - 1 && index >= 0)
            if (WCList.ElementAt(index) is WC9 wc9)
                return wc9.IsBefore201;
        return false;
    }

    public void SetIsBefore201(int index, bool before201)
    {
        if (WCList is not null && WCList.Count > 0 && WCList.Count >= index - 1 && index >= 0)
            if (WCList.ElementAt(index) is WC9 wc9 && wc9.RequiresMethodSelection)
                if (before201)
                    wc9.UpdateOldToNewTIDSID();
                else
                    wc9.UpdateNewToOldTIDSID();
    }

    public int GetIndex(ushort wcid)
    {
        if (WCList is not null && WCList.Count > 0)
            return WCList.FindIndex((x) => x.WCID == wcid);
        else
            throw new IndexOutOfRangeException();
    }

    public List<string> GetListNames()
    {
        List<string> list = new();
        if (WCList is not null && WCList.Count > 0)
            foreach (var wc in WCList)
            {
                var str = wc.Type!.ToString()!.Equals("Pokemon") ? ((PokemonGift)wc.Content!).GetSpeciesName().Replace("\r","") : wc.Type!.ToString()!;
                list.Add($"{Game} #{wc.WCID}: {str}");
            }
        return list;
    }

    public List<string> GetContentToString(int index)
    {
        var wcid = "";
        var el1 = "";
        var el2 = "";
        var el3 = "";
        var el4 = "";
        var el5 = "";
        var el6 = "";
        var el7 = "";

        if (WCList is not null && WCList.Count > 0 && WCList.Count >= index)
        {
            var wc = WCList.ElementAt(index);
            wcid = wc.WCID.ToString();
            var content = wc.Content;
            if (content!.GetType() == typeof(PokemonGift))
            {
                var c = (PokemonGift)content;
                el1 = GetShinyString(c.ShinyType);
                el2 = c.GetSpeciesName();
                el3 = GetPIDString(c.PIDType);
            }
            else if (content!.GetType() == typeof(List<OtherGift>))
            {
                foreach (var c in (List<OtherGift>)content)
                {
                    var item = c.GetItemName().Replace("\r","");
                    var qty = c.Quantity;
                    var str = $"{item.Replace("BP", "Battle Points").Replace("LP", "League Points")}";
                    if (qty != 0x0 && qty != ushort.MaxValue)
                        str = $"{str} x{qty}";
                    if (el1.Equals(""))
                        el1 = str;
                    else if (el2.Equals(""))
                        el2 = str;
                    else if (el3.Equals(""))
                        el3 = str;
                    else if (el4.Equals(""))
                        el4 = str;
                    else if (el5.Equals(""))
                        el5 = str;
                    else if (el6.Equals(""))
                        el6 = str;
                    else if (el7.Equals(""))
                        el7 = str;
                }
            }
        }
        return new List<string> { wcid, el1, el2, el3, el4, el5, el6, el7 };
    }

    public List<ushort>? GetDuplicatedWCID()
    {
        if (WCList is not null && WCList.Count > 1)
        {
            var l = WCList.GroupBy(x => x.WCID)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
            return l;
        }
        else
            return new List<ushort>();
    }

    public string GetDefaultBcatFolderName() => GetDefaultBcatFolderName(this.Game);
    public string GetDefaultBcatFileName() => GetDefaultBcatFileName(this.Game);

    public bool TrySaveAllWondercards(string path)
    {
        if (WCList is null || WCList.Count == 0)
            return false;

        for (int i = 0; i < WCList.Count; i++)
            if (!TrySaveWondercard(i, path))
                return false;

        return true;
    }

    public bool TrySaveWondercard(int index, string path)
    {
        try
        {
            var wc = WCList!.ElementAt(index);
            File.WriteAllBytes(Path.Combine(path, ForgeWcFileName(wc)), wc.Data!);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public ReadOnlySpan<byte> ConcatenateFiles()
    {
        var size = (int)Wondercard.GetSize(Game);
        var data = new byte[size * WCList!.Count];
        foreach (var el in WCList!.Select((wc, i) => new { i, wc }))
            el.wc.Data!.CopyTo(data, el.i * size);
        return data.AsSpan();
    }

    public ReadOnlySpan<byte> ForgeMetaInfo(object? data = null)
    {
        if (data is not null && data.GetType() == typeof(byte[]))
        {
            var fileName = System.Text.Encoding.UTF8.GetBytes(GetDefaultBcatFileName());
            var fileSize = (uint)((byte[])data).Length;
            var checksum = ChecksumCalculator.CalcReverseMD5((byte[])data);
            var metainfo = new byte[WCMetaInfoLength];
            fileName.CopyTo(metainfo, FileNameOffset);
            BinaryPrimitives.WriteUInt32LittleEndian(metainfo.AsSpan(UnkOffset), uint.MaxValue);
            BinaryPrimitives.WriteUInt32LittleEndian(metainfo.AsSpan(FileSizeOffset), fileSize);
            checksum.ToArray().CopyTo(metainfo, ChecksumOffset);
            return ForgeMetaInfoHeader(metainfo);
        }
        else
        {
            var metainfo = new byte[WCMetaInfoLength * WCList!.Count];
            foreach (var el in WCList!.Select((wc, i) => new { i, wc }))
                ForgeWcMetaInfo(el.wc).ToArray().CopyTo(metainfo, el.i * WCMetaInfoLength);
            return ForgeMetaInfoHeader(metainfo);
        }
    }

    private static ReadOnlySpan<byte> ForgeWcMetaInfo(Wondercard wc)
    {
        var fileName = System.Text.Encoding.UTF8.GetBytes(ForgeWcFileName(wc));
        var fileSize = (uint)Wondercard.GetSize(wc.Game);
        var checksum = wc.CalcMetaChecksum();
        var data = new byte[WCMetaInfoLength];
        fileName.CopyTo(data, FileNameOffset);
        BinaryPrimitives.WriteUInt32LittleEndian(data.AsSpan(UnkOffset), uint.MaxValue);
        BinaryPrimitives.WriteUInt32LittleEndian(data.AsSpan(FileSizeOffset), fileSize);
        checksum.ToArray().CopyTo(data, ChecksumOffset);
        return data.AsSpan();
    }

    private static string ForgeWcFileName(Wondercard wc)
    {
        var type = wc.Type!.ToString()!;
        var content = type.Equals("Pokemon") ? $"{((PokemonGift)wc.Content!).GetSpeciesName().Replace("\r", "")}" : type;
        var str = $"{wc.WCID:0000}_{content}";
        var sb = new System.Text.StringBuilder();
        foreach (char c in str)
            if (c != '\\' && c != '/' && c != ':' && c != '*' && c != '?' && c != '"' && c != '<' && c != '>' && c != '|')
                sb.Append(c);
        var _sb = new System.Text.StringBuilder();
        foreach (char c in sb.ToString().Normalize(NormalizationForm.FormD))
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                _sb.Append(c);
        return _sb.ToString().ToLower();
    }

    private static ReadOnlySpan<byte> ForgeMetaInfoHeader(ReadOnlySpan<byte> data)
    {
        uint header = 0x1;
        byte[] filesDotMeta = new byte[data.Length + MetaHeaderLength];
        BinaryPrimitives.WriteUInt32LittleEndian(filesDotMeta.AsSpan(), header);
        data.ToArray().CopyTo(filesDotMeta, MetaHeaderLength);
        return filesDotMeta.AsSpan();
    }

    public static Games GetCompatibleGamesFromWC(ReadOnlySpan<byte> data)
    {
        if (data.Length % (int)Wondercard.GetSize(Games.LGPE) == 0)
            return Games.LGPE;
        else if (data.Length % (int)Wondercard.GetSize(Games.SWSH) == 0)
            return Games.SWSH;
        else if (data.Length % (int)Wondercard.GetSize(Games.BDSP) == 0)
            return Games.BDSP;
        else if (data.Length % (int)Wondercard.GetSize(Games.PLA) == 0 && data[Wondercard.GenOffset] != 0)
            return Games.PLA;
        else if (data.Length % (int)Wondercard.GetSize(Games.SCVI) == 0 && data[Wondercard.GenOffset] == 0)
            return Games.SCVI;
        else
            return Games.None;
    }

    public static string GetDefaultBcatFolderName(Games game)
    {
        return game switch
        {
            Games.LGPE => "normal",
            Games.SWSH => "normal",
            Games.BDSP => "99",
            Games.PLA => "normal",
            Games.SCVI => "normal",
            _ => throw new ArgumentOutOfRangeException(nameof(game)),
        };
    }

    public static string GetDefaultBcatFileName(Games game)
    {
        return game switch
        {
            Games.SWSH => "distribution_internet",
            Games.BDSP => "99",
            Games.PLA => "distribution_internet",
            Games.SCVI => "distribution_internet",
            _ => throw new ArgumentOutOfRangeException(nameof(game)),
        };
    }

    private static string GetShinyString(ShinyType type)
    {
        return type switch
        {
            ShinyType.ShinyLocked => "Shiny Locked",
            ShinyType.ShinyPossible => "Shiny Standard Odds",
            ShinyType.ShinyHighOdds => "Shiny High Odds",
            ShinyType.ShinyForced => "Shiny Forced",
            ShinyType.ShinyTIDAbuse => "Shiny Possible (TID Abuse)",
            _ => throw new IndexOutOfRangeException()
        };
    }

    private static string GetPIDString(PIDType type)
    {
        return type switch
        {
            PIDType.FixedPID => "Fixed PID",
            PIDType.RandomPID => "Random PID",
            _ => throw new IndexOutOfRangeException()
        };
    }
}