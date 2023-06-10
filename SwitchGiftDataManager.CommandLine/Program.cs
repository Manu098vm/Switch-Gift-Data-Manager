using SwitchGiftDataManager.Core;
using Enums;

namespace SwitchGiftDataManager.CommandLine;

public static class Program
{
    public static void Main()
    {
        var msg = $"Switch Gift Data Manager v{BCATManager.Version}";
        Log(msg);

        Task.Run(TryUpdate).Wait();

        msg = $"{Environment.NewLine}Select your game:{Environment.NewLine}{Environment.NewLine}" +
            $"1 - LGPE{Environment.NewLine}" +
            $"2 - SWSH{Environment.NewLine}" +
            $"3 - BDSP{Environment.NewLine}" +
            $"4 - PLA{Environment.NewLine}" +
            $"5 - SCVI";
        Log(msg);

        Games game = (Games)int.Parse(Console.ReadLine()!);
        if (game is Games.None || game > Games.SCVI)
        {
            Log("Invalid input. Aborted.");
            Console.ReadKey();
            return;
        }

        var bcat = new BCATManager(game);

        msg = $"{Environment.NewLine}Enter a valid input path.{Environment.NewLine}{Environment.NewLine}The path can be either:{Environment.NewLine}" +
            $"- A direct (full) path to a wondercard file{Environment.NewLine}" +
            $"- A (full) path to a folder containing wondercard files";
        Log(msg);

        var path = Console.ReadLine()!;
        if (File.Exists(path))
            bcat.TryAddWondercards(File.ReadAllBytes(path));
        else if (CheckValidPath(path))
            foreach (var file in Directory.GetFiles(path))
                if (!bcat.TryAddWondercards(File.ReadAllBytes(file)))
                    Log($"{file} could not be loaded.");

        if (bcat.Count() <= 0)
        {
            Log("No valid files have been loaded. Aborted.");
            Console.ReadKey();
            return;
        }

        bcat.Sort();
        Log($"{Environment.NewLine}Enter the source (full) path to your dumped BCAT:");
        var sourcepath = Console.ReadLine()!;
        if (!CheckValidBcatPath(sourcepath))
        {
            Log("Not a valid BCAT folder path. Aborted.");
            Console.ReadKey();
            return;
        }

        Log($"{Environment.NewLine}Enter a destination (full) path to save the forged BCAT:");
        var destpath = Console.ReadLine()!;
        if (!CheckValidPath(destpath))
        {
            Log("Not a valid path. Aborted.");
            Console.ReadKey();
            return;
        }

        if (game is not (Games.LGPE or Games.BDSP))
        {
            msg = $"{Environment.NewLine}Select a build option:{Environment.NewLine}{Environment.NewLine}" +
                $"1 - Merge as one file{Environment.NewLine}" +
                $"2 - Keep separate files";
            Log(msg);
        }

        var opt = game switch {
            Games.LGPE => 2,
            Games.BDSP => 1,
            _ => int.Parse(Console.ReadLine()!),
        };

        if(opt < 1 || opt > 2)
        {
            Log("Invalid input. Aborted.");
            Console.ReadKey();
            return;
        }

        destpath = Path.Combine(destpath, $"Forged_BCAT_{game}");
        CopyDirectory(sourcepath, destpath);

        if (opt == 1)
        {
            try
            {
                var wcdata = bcat.ConcatenateFiles();
                var metadata = bcat.ForgeMetaInfo(wcdata.ToArray());
                var metadatapath = Path.Combine(destpath, "directories");
                metadatapath = Path.Combine(metadatapath, bcat.GetDefaultBcatFolderName());
                var wcpath = Path.Combine(metadatapath, "files");

                if (Directory.Exists(metadatapath))
                    DeleteFilesAndDirectory(metadatapath);

                Directory.CreateDirectory(wcpath);
                File.WriteAllBytes(Path.Combine(metadatapath, "files.meta"), metadata.ToArray());
                File.WriteAllBytes(Path.Combine(wcpath, bcat.GetDefaultBcatFileName()), wcdata.ToArray());
                Log($"Saved in {path}{Environment.NewLine}BCAT forge was successful.{Environment.NewLine}Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Log("Internal Error. Press any key to exit...");
                Console.ReadKey();
            }
        }
        else
        {
            var metadata = bcat.ForgeMetaInfo();
            var metadatapath = Path.Combine(destpath, "directories");
            metadatapath = Path.Combine(metadatapath, bcat.GetDefaultBcatFolderName());
            var wcspath = Path.Combine(metadatapath, "files");

            if (Directory.Exists(metadatapath))
                DeleteFilesAndDirectory(metadatapath);

            Directory.CreateDirectory(wcspath);
            File.WriteAllBytes(Path.Combine(metadatapath, "files.meta"), metadata.ToArray());
            if (bcat.TrySaveAllWondercards(wcspath))
            {
                Log($"Saved in {path}{Environment.NewLine}BCAT forge was successful.{Environment.NewLine}Press any key to exit...");
                Console.ReadKey();
            }
            else
            {
                Log("Internal error. Press any key to exit...");
                Console.ReadKey();
            }
        }

        return;
    }

    private static bool CheckValidPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return false;

        if (!Directory.Exists(path))
            return false;

        return true;
    }

    private static bool CheckValidBcatPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return false;

        if (!Directory.Exists(Path.Combine(path, "directories")))
            return false;

        if (!File.Exists(Path.Combine(path, "directories.meta")))
            return false;

        if (!File.Exists(Path.Combine(path, "etag.bin")))
            return false;

        if (!File.Exists(Path.Combine(path, "list.msgpack")))
            return false;

        if (!File.Exists(Path.Combine(path, "na_required")))
            return false;

        if (!File.Exists(Path.Combine(path, "passphrase.bin")))
            return false;

        return true;
    }

    static void CopyDirectory(string source, string dest)
    {
        var dir = new DirectoryInfo(source);
        DirectoryInfo[] dirs = dir.GetDirectories();
        Directory.CreateDirectory(dest);

        foreach (FileInfo file in dir.GetFiles())
        {
            string targetFilePath = Path.Combine(dest, file.Name);
            if (!File.Exists(targetFilePath))
                file.CopyTo(targetFilePath);
        }

        foreach (DirectoryInfo subDir in dirs)
        {
            string newDestinationDir = Path.Combine(dest, subDir.Name);
            CopyDirectory(subDir.FullName, newDestinationDir);
        }
    }

    private static void DeleteFilesAndDirectory(string targetDir)
    {
        string[] files = Directory.GetFiles(targetDir);
        string[] dirs = Directory.GetDirectories(targetDir);

        foreach (string file in files)
        {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
        }

        foreach (string dir in dirs)
            DeleteFilesAndDirectory(dir);

        Directory.Delete(targetDir, false);
    }

    private static async Task TryUpdate()
    {
        if (await GitHubUtil.IsUpdateAvailable())
        {
            Log("A program update is available. Do you want to download the latest release?\n[Y\\n]:");
            var str = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(str) && (str.ToLower().Equals("y") || str.ToLower().Equals("yes")))
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = @"https://github.com/Manu098vm/Switch-Gift-Data-Manager/releases", UseShellExecute = true });
        }
    }

    private static void Log(string msg) => Console.WriteLine(msg);
}