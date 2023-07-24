using System.Text.RegularExpressions;
using SwitchGiftDataManager.Core;
using Enums;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SwitchGiftDataManager.WinForm;

public partial class MainWindow : Form
{
    private Games CurrentGame = Games.None;
    private BCATManager PackageLGPE = new(Games.LGPE);
    private BCATManager PackageSWSH = new(Games.SWSH);
    private BCATManager PackageBDSP = new(Games.BDSP);
    private BCATManager PackagePLA = new(Games.PLA);
    private BCATManager PackageSCVI = new(Games.SCVI);
    private List<ushort> Duplicated = new List<ushort>();

    public MainWindow()
    {
        Task.Run(TryUpdate).Wait();
        InitializeComponent();
        Text += BCATManager.Version;
    }

    private static async Task TryUpdate()
    {
        if (await GitHubUtil.IsUpdateAvailable())
        {
            var result = MessageBox.Show("A program update is available. Do you want to download the latest release?", "Update available", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Process.Start(new ProcessStartInfo { FileName = @"https://github.com/Manu098vm/Switch-Gift-Data-Manager/releases", UseShellExecute = true });
        }
    }

    private void ChangeGame(Games game)
    {
        GrpBCAT.Enabled = true;
        CurrentGame = game;
        RestoreMenu();
        EditFileFilter();
        EditGameButton();
        UpdateWCList();
        ListBoxWC.SelectedIndex = -1;
        DisableContent();
    }

    private void RestoreMenu()
    {
        BtnLGPE.Enabled = true;
        BtnSWSH.Enabled = true;
        BtnBDSP.Enabled = true;
        BtnPLA.Enabled = true;
        BtnSCVI.Enabled = true;

        BtnLGPE.Font = new Font(BtnLGPE.Font.Name, BtnLGPE.Font.Size, FontStyle.Regular);
        BtnSWSH.Font = new Font(BtnSWSH.Font.Name, BtnSWSH.Font.Size, FontStyle.Regular);
        BtnBDSP.Font = new Font(BtnBDSP.Font.Name, BtnBDSP.Font.Size, FontStyle.Regular);
        BtnPLA.Font = new Font(BtnPLA.Font.Name, BtnPLA.Font.Size, FontStyle.Regular);
        BtnSCVI.Font = new Font(BtnSCVI.Font.Name, BtnSCVI.Font.Size, FontStyle.Regular);
    }

    private void EditFileFilter()
    {
        OpenFileDialogWC.Filter = CurrentGame switch
        {
            Games.LGPE => "wb7full files (*.wb7full)|*.wb7full|All files (*.*)|*.*",
            Games.SWSH => "wc8 files (*.wc8)|*.wc8|All files (*.*)|*.*",
            Games.BDSP => "wb8 files (*.wb8)|*.wb8|All files (*.*)|*.*",
            Games.PLA => "wa8 files (*.wa8)|*.wa8|All files (*.*)|*.*",
            Games.SCVI => "wc9 files (*.wc9)|*.wc9|All files (*.*)|*.*",
            _ => "All files (*.*)|*.*",
        };
    }

    private void EditGameButton()
    {
        Button btn = CurrentGame switch
        {
            Games.LGPE => BtnLGPE,
            Games.SWSH => BtnSWSH,
            Games.BDSP => BtnBDSP,
            Games.PLA => BtnPLA,
            Games.SCVI => BtnSCVI,
            _ => throw new ArgumentOutOfRangeException(),
        };
        EditSelectedButton(btn);
    }

    private void EditSelectedButton(Button btn)
    {
        btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
        btn.Enabled = false;
    }

    private void UpdateWCList()
    {
        if (ListBoxWC.Items.Count > 0)
            ListBoxWC.Items.Clear();

        var list = CurrentGame switch
        {
            Games.LGPE => PackageLGPE.GetListNames(),
            Games.SWSH => PackageSWSH.GetListNames(),
            Games.BDSP => PackageBDSP.GetListNames(),
            Games.PLA => PackagePLA.GetListNames(),
            Games.SCVI => PackageSCVI.GetListNames(),
            _ => throw new ArgumentOutOfRangeException(),
        };

        UpdateDuplicatedList();

        foreach (var el in list)
            ListBoxWC.Items.Add(el);

        if (ListBoxWC.Items.Count > 0)
            BtnSave.Enabled = true;
        else
            BtnSave.Enabled = false;
    }

    private void UpdateDuplicatedList()
    {
        var list = GetCurrentList().GetDuplicatedWCID();
        if (list != null)
            Duplicated = list;
        else
            Duplicated = new List<ushort> { 0 };
    }

    private BCATManager GetCurrentList()
    {
        return CurrentGame switch
        {
            Games.LGPE => PackageLGPE,
            Games.SWSH => PackageSWSH,
            Games.BDSP => PackageBDSP,
            Games.PLA => PackagePLA,
            Games.SCVI => PackageSCVI,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    private void LoadLocalFiles(string[] files)
    {
        DisableContent();
        var list = GetCurrentList();
        var errList = new List<string>();
        foreach (var path in files)
        {
            var data = File.ReadAllBytes(path);
            var success = list.TryAddWondercards(data.AsSpan());
            if (!success)
            {
                if (errList.Count == 0)
                    if (CurrentGame is Games.LGPE && list.Count() >= 1)
                        errList.Add("LGPE only supports one (1) wondercard at a time. Aborted file(s):\n");
                    else
                        errList.Add($"Attempted to load invalid files. Aborted file(s):\n");
                errList.Add($"- {Path.GetFileName(path)}");
            }
        }

        if (errList.Count > 0)
        {
            var msg = "";
            foreach (var err in errList)
                msg = $"{msg}\n{err}";
            MessageBox.Show(msg);
        }

        list.Sort();
        UpdateWCList();
    }

    private void BtnLGPE_Click(object sender, EventArgs e) => ChangeGame(Games.LGPE);

    private void BtnSWSH_Click(object sender, EventArgs e) => ChangeGame(Games.SWSH);

    private void BtnBDSP_Click(object sender, EventArgs e) => ChangeGame(Games.BDSP);

    private void BtnPLA_Click(object sender, EventArgs e) => ChangeGame(Games.PLA);

    private void BtnSCVI_Click(object sender, EventArgs e) => ChangeGame(Games.SCVI);

    private void BtnSave_Click(object sender, EventArgs e)
    {
        this.Enabled = false;
        var saveForm = new SaveWindow(GetCurrentList(), CurrentGame);
        saveForm.FormClosed += (s, e) => this.Enabled = true;
        saveForm.Location = this.Location;
        saveForm.Show();
    }

    private void BtnApply_Click(object sender, EventArgs e)
    {
        var list = GetCurrentList();
        var wcid = UInt16.Parse(TxtWCID.Text);
        var repeatable = ChkRepeatable.Checked;

        if (wcid != list.GetWCID(ListBoxWC.SelectedIndex))
        {
            var index = list.GetIndex(wcid);
            if (index == -1)
            {
                list.SetWCID(ListBoxWC.SelectedIndex, wcid);
                list.Sort();
                UpdateWCList();
                ListBoxWC.SelectedIndex = list.GetIndex(wcid);
                BtnApply.Enabled = false;
            }
            else
            {
                MessageBox.Show($"WCID {wcid} already exists.");
                return;
            }
        }

        if (repeatable != list.GetIsRepeatable(ListBoxWC.SelectedIndex))
        {
            list.SetIsRepeatable(ListBoxWC.SelectedIndex, repeatable);
            BtnApply.Enabled = false;
        }
    }

    private void BtnRemove_Click(object sender, EventArgs e)
    {
        var list = GetCurrentList();
        list.RemoveWC(ListBoxWC.SelectedIndex);
        ListBoxWC.SelectedIndex = -1;
        DisableContent();
        UpdateWCList();
    }

    private void BtnRemoveAll_Click(object sender, EventArgs e)
    {
        var list = GetCurrentList();
        list.Reset();
        ListBoxWC.SelectedIndex = -1;
        DisableContent();
        UpdateWCList();
    }

    private void BtnOpen_Click(object sender, EventArgs e)
    {
        if (OpenFileDialogWC.ShowDialog() == DialogResult.OK)
            LoadLocalFiles(OpenFileDialogWC.FileNames);
    }

    void FileDragEnter(object sender, DragEventArgs e)
    {
        if (e.Data is not null && CurrentGame is not Games.None)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
    }

    void FileDragDrop(object sender, DragEventArgs e)
    {
        if (e.Data is not null && CurrentGame is not Games.None)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop)!;
            LoadLocalFiles(files);
        }
    }

    private void TxtWCID_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            e.Handled = true;
    }

    private void TxtWCID_TextChanged(object sender, EventArgs e)
    {
        if (!TxtWCID.Text.Equals(""))
        {
            var list = GetCurrentList();
            var newWcid = UInt16.Parse(TxtWCID.Text);
            var oldWcid = list.GetWCID(ListBoxWC.SelectedIndex);

            if (oldWcid > 0 && newWcid > 0 && newWcid != oldWcid)
                BtnApply.Enabled = true;
            else
                BtnApply.Enabled = false;
        }
    }

    private void ChkRepeatable_CheckedChanged(object sender, EventArgs e)
    {
        var list = GetCurrentList();
        var newBool = ChkRepeatable.Checked;
        var oldBool = list.GetIsRepeatable(ListBoxWC.SelectedIndex);

        if (newBool != oldBool)
            BtnApply.Enabled = true;
        else
            BtnApply.Enabled = false;
    }

    private void ToolTipWcid_Draw(object sender, DrawToolTipEventArgs e)
    {
        Point screenPosition = ListBox.MousePosition;
        Point listBoxClientAreaPosition = ListBoxWC.PointToClient(screenPosition);
        int hoveredIndex = ListBoxWC.IndexFromPoint(listBoxClientAreaPosition);
        if (hoveredIndex > -1)
        {
            var str = ListBoxWC.Items[hoveredIndex].ToString()!;
            if (str.Contains('\u26A0'))
            {
                var msg = "Wondercards with duplicated identifiers may not be detected correctly by the games.";
                e.DrawBackground();
                Graphics g = e.Graphics;
                g.DrawString(msg, e.Font!, new SolidBrush(Color.Black), new PointF(e.Bounds.X, e.Bounds.Y));
            }
            else if (str.Contains('\u2757'))
            {
                var msg = "Wondercard count is above the maximum allowed, or the WCID is over the maximum allowed.";
                e.DrawBackground();
                Graphics g = e.Graphics;
                g.DrawString(msg, e.Font!, new SolidBrush(Color.Black), new PointF(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                ToolTipWcid.Hide(ListBoxWC);
            }
        }
        else
            ToolTipWcid.Hide(ListBoxWC);
    }

    private void ListBoxWC_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var index = ListBoxWC.IndexFromPoint(e.X, e.Y);
            if (index >= 0)
            {
                ListBoxWC.SelectedIndex = index;
                ContextMenuStripWC.Show(Cursor.Position);
            }
        }
    }

    private void ListBoxWC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBoxWC.SelectedIndex > -1)
        {
            var list = GetCurrentList();
            var index = ListBoxWC.SelectedIndex;
            var content = list.GetContentToString(index);
            var nItem = content.Count();
            if (nItem >= 1)
                LblInfo1.Text = content.ElementAt(1);
            if (nItem >= 2)
                LblInfo2.Text = content.ElementAt(2);
            if (nItem >= 3)
                LblInfo3.Text = content.ElementAt(3);
            if (nItem >= 4)
                LblInfo4.Text = content.ElementAt(4);
            if (nItem >= 5)
                LblInfo5.Text = content.ElementAt(5);
            if (nItem >= 6)
                LblInfo6.Text = content.ElementAt(6);
            if (nItem >= 7)
                LblInfo7.Text = content.ElementAt(7);

            TxtWCID.Text = content.ElementAt(0);
            ChkRepeatable.Checked = list.GetIsRepeatable(index);
            EnableContent();
        }
        else
            DisableContent();
    }

    private void ListBoxWC_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index > -1)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            var curr = ((ListBox)sender).Items[e.Index].ToString()!;
            var wcid = UInt16.Parse(Regex.Match(curr, @"(?<=\#)(.*?)(?=\:)").Groups[1].Value);
            var handled = false;
            if ((CurrentGame is Games.BDSP && wcid >= 2048) || (CurrentGame is Games.SWSH && e.Index >= 129))
            {
                if (!curr.Contains('\u2757'))
                    ((ListBox)sender).Items[e.Index] = $"{curr} \u2757";
                g.FillRectangle(new SolidBrush(Color.IndianRed), e.Bounds);
                g.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font!, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));
                handled = true;
            }
            foreach (var d in Duplicated)
            {
                if (d == wcid)
                {
                    if (!curr.Contains('\u26A0'))
                        ((ListBox)sender).Items[e.Index] = $"{curr} \u26A0";
                    g.FillRectangle(new SolidBrush(Color.Orange), e.Bounds);
                    g.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font!, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));
                    handled = true;
                }
            }
            if (!handled)
                g.DrawString(curr, e.Font!, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));
        }
    }

    private void LblInfo_SizeChanged(object sender, EventArgs e)
    {
        var lbl = (Label)sender;
        lbl.Left = (GrpContent.Width - lbl.Width) / 2;
    }

    private void EnableContent()
    {
        TxtWCID.Enabled = true;
        LblWCID.Enabled = true;
        LblInfo1.Visible = true;
        LblInfo2.Visible = true;
        LblInfo3.Visible = true;
        LblInfo4.Visible = true;
        LblInfo5.Visible = true;
        LblInfo6.Visible = true;
        LblInfo7.Visible = true;
        GrpContent.Enabled = true;
        ChkRepeatable.Enabled = true;
    }

    private void DisableContent()
    {
        TxtWCID.Text = "";
        TxtWCID.Enabled = false;
        LblWCID.Enabled = false;
        LblInfo1.Text = "";
        LblInfo1.Visible = false;
        LblInfo2.Text = "";
        LblInfo2.Visible = false;
        LblInfo3.Text = "";
        LblInfo3.Visible = false;
        LblInfo4.Text = "";
        LblInfo4.Visible = false;
        LblInfo5.Text = "";
        LblInfo5.Visible = false;
        LblInfo6.Text = "";
        LblInfo6.Visible = false;
        LblInfo7.Text = "";
        LblInfo7.Visible = false;
        BtnApply.Enabled = false;
        GrpContent.Enabled = false;
        ChkRepeatable.Checked = false;
        ChkRepeatable.Enabled = false;
    }

    private void MenuItemMGDB_Click(object sender, EventArgs e)
    {
        Task.Run(async () => await DownloadRepoMGDB()).Wait();
    }

    private static async Task DownloadRepoMGDB()
    {
        var url = "https://github.com/projectpokemon/EventsGallery/archive/refs/heads/master.zip";
        using (var client = new HttpClient())
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var mgdbPath = Path.Combine(path, "mgdb");

            if (Directory.Exists(mgdbPath))
                Directory.Delete(mgdbPath, true);

            var zipPath = Path.Combine(path, "repo.zip");
            using (var response = await client.GetAsync(url))
            {
                using (var content = await response.Content.ReadAsStreamAsync())
                {
                    using (var stream = new FileStream(zipPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await content.CopyToAsync(stream);
                    }
                }
            }

            ZipFile.ExtractToDirectory(zipPath, path);
            File.Delete(zipPath);
            Directory.Move(Path.Combine(path, "EventsGallery-master"), mgdbPath);

            File.Delete(Path.Combine(mgdbPath, ".gitignore"));
            Directory.Delete(Path.Combine(mgdbPath, "Extras"), true);
            Directory.Delete(Path.Combine(mgdbPath, "Unreleased"), true);

            var genPath = Path.Combine(mgdbPath, "Released");
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

            MessageBox.Show($"The Mystery Gift Database has been downloaded in {mgdbPath}", "MGDB", 
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }
    }
}