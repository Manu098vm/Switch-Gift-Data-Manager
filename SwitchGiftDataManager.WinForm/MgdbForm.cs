using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchGiftDataManager.WinForm;

public partial class MgdbForm : Form
{
    public MgdbForm()
    {
        InitializeComponent();
        this.Shown += (s, e) => Task.Run(async () => await DownloadRepoMGDB()).Wait();
    }

    private async Task DownloadRepoMGDB()
    {
        var url = "https://github.com/projectpokemon/EventsGallery/archive/refs/heads/master.zip";
        using (var client = new HttpClient())
        {
            var path = Path.Combine(Environment.CurrentDirectory, "tmp");
            var mgdbPath = Path.Combine(Environment.CurrentDirectory, "mgdb");

            //Delete old residual files if exist
            if (Directory.Exists(path))
                Directory.Delete(path, true);

            if (Directory.Exists(mgdbPath))
                Directory.Delete(mgdbPath, true);

            Directory.CreateDirectory(path);

            var zipPath = Path.Combine(path, "tmp.zip");
            using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                var totalBytes = response.Content.Headers.ContentLength ?? 0;
                using (var content = await response.Content.ReadAsStreamAsync())
                using (var stream = new FileStream(zipPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    var buffer = new byte[8192];
                    int bytesRead;
                    long totalRead = 0;
                    while ((bytesRead = await content.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await stream.WriteAsync(buffer, 0, bytesRead);
                        totalRead += bytesRead;
                        if (totalBytes > 0)
                        {
                            double progressPercentage = (double)totalRead / totalBytes * 100;
                            lblMessage.Text = $"Download progress: {progressPercentage:F2}%";
                        }
                    }
                }
            }

            lblMessage.Text = $"Extracting files...";
            ZipFile.ExtractToDirectory(zipPath, path);
            File.Delete(zipPath);

            var tmpMgbdPath = Path.Combine(path, "EventsGallery-master");

            lblMessage.Text = $"Cleaning up residual files...";
            File.Delete(Path.Combine(tmpMgbdPath, ".gitignore"));
            Directory.Delete(Path.Combine(tmpMgbdPath, "Extras"), true);
            Directory.Delete(Path.Combine(tmpMgbdPath, "Unreleased"), true);
            Directory.Delete(Path.Combine(tmpMgbdPath, "PKHeX Legality"), true);

            var genPath = Path.Combine(tmpMgbdPath, "Released");
            Directory.Delete(Path.Combine(genPath, "Gen 1"), true);
            Directory.Delete(Path.Combine(genPath, "Gen 2"), true);
            Directory.Delete(Path.Combine(genPath, "Gen 3"), true);
            Directory.Delete(Path.Combine(genPath, "Gen 4"), true);
            Directory.Delete(Path.Combine(genPath, "Gen 5"), true);
            Directory.Delete(Path.Combine(genPath, "Gen 6"), true);

            var gen7Path = Path.Combine(genPath, "Gen 7");
            Directory.Delete(Path.Combine(gen7Path, "3DS"), true);
            Directory.Delete(Path.Combine(Path.Combine(gen7Path, "Switch"), "Wondercard Records"), true);

            var swshPath = Path.Combine(Path.Combine(genPath, "Gen 8"), "SwSh");
            Directory.Delete(Path.Combine(swshPath, "Wild Area Events"), true);

            var gen9Path = Path.Combine(genPath, "Gen 9");
            Directory.Delete(Path.Combine(gen9Path, "Raid Events"), true);
            Directory.Delete(Path.Combine(gen9Path, "Outbreak Events"), true);

            Directory.Move(tmpMgbdPath, mgdbPath);
            Directory.Delete(path, true);

            this.FormClosed += (s, e) => MessageBox.Show($"The Mystery Gift Database has been downloaded in {mgdbPath}", "MGDB",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            this.Close();
        }
    }
}
