using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace SOR4SoundReplacer
{
    public partial class MainWindow : Form
    {
        public Assembly imageAssembly = Assembly.GetExecutingAssembly();
        Library classlib = new Library();

        public Point lastLocation;

        string sourcedir;
        string extractdir;
        string corePath;
        string genericPath;
        int currentRepackPosition;
        List<string> messageList = new List<string>();

        public OutputLog outputWindow;

        public MainWindow()
        {
            InitializeComponent();

            labelBackups.Text = "Please set your Game Folder.";
            labelBackups.ForeColor = Color.Crimson;
            outputWindow = new OutputLog(this);

            Stream thumbStream = imageAssembly.GetManifestResourceStream("SOR4SoundReplacer.img.bmc.png");
            Bitmap thumbBitmap = new Bitmap(thumbStream);
            imgBMCSupport.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4SoundReplacer.img.sflogo.png");
            thumbBitmap = new Bitmap(thumbStream);
            imgSF.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4SoundReplacer.img.youtube.png");
            thumbBitmap = new Bitmap(thumbStream);
            imgYoutube.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4SoundReplacer.img.twitch.png");
            thumbBitmap = new Bitmap(thumbStream);
            imgTwitch.Image = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4SoundReplacer.img.exit.png");
            thumbBitmap = new Bitmap(thumbStream);
            btnClose.BackgroundImage = thumbBitmap;

            thumbStream = imageAssembly.GetManifestResourceStream("SOR4SoundReplacer.img.min.png");
            thumbBitmap = new Bitmap(thumbStream);
            btnMinimize.BackgroundImage = thumbBitmap;

            if ((Properties.Settings.Default.sourcedir != "") && Directory.Exists(Properties.Settings.Default.sourcedir))
            {
                sourcedir = Properties.Settings.Default.sourcedir;
                txtGameDir.Text = sourcedir;
            }
            if ((Properties.Settings.Default.extractdir != "") && Directory.Exists(Properties.Settings.Default.extractdir))
            {
                extractdir = Properties.Settings.Default.extractdir;
                txtExtractDir.Text = extractdir;
            }

            CheckSettings();
        }




        // window movement stuff
        public void MoveWindow(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - lastLocation.X;
                int dy = e.Location.Y - lastLocation.Y;
                Location = new Point(Location.X + dx, Location.Y + dy);
            }
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void labelVersion_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void labelVersion_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void labelAuthor_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void labelAuthor_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void progressBar_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void progressBar_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void labelBackups_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void labelBackups_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void labelDestFolderMissing_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void labelDestFolderMissing_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void txtGameDir_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void txtGameDir_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void txtExtractDir_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void txtExtractDir_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exitAsk = MessageBox.Show("Are you sure you want to sell your soul to this Exit button?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (exitAsk == DialogResult.No);
        }

        private async void btnExtract_Click(object sender, EventArgs e)
        {
            // disabled buttons temporarily
            bool overwrite = radioOverwrite.Checked;
            DisableControls(overwrite);

            string filename = "Core";

            // Core
            CheckBackup(filename);
            progressCore.Visible = true;
            progressCore.Style = ProgressBarStyle.Marquee;
            await Task.Run(() => ExtractStuff(filename));
            progressCore.Style = ProgressBarStyle.Blocks;

            filename = "Generic";

            // Core
            CheckBackup(filename);
            progressGeneric.Visible = true;
            progressGeneric.Style = ProgressBarStyle.Marquee;
            await Task.Run(() => ExtractStuff(filename));
            progressGeneric.Style = ProgressBarStyle.Blocks;

            // re-enable temporarily disabled buttons
            btnBrowseDestination.Enabled = true;
            btnBrowseSource.Enabled = true;

            CheckSettings();
            if (overwrite && radioOverwrite.Enabled)
            {
                radioOverwrite.Checked = true;
            }
            else
            {
                radioSeparate.Checked = true;
            }

            btnToggleCommandLog.Visible = false;

            MessageBox.Show("Done extracting BNK into WEM files!");

            progressCore.Visible = false;
            progressGeneric.Visible = false;
        }

        private async void btnRepack_Click(object sender, EventArgs e)
        {
            // disabled buttons temporarily
            bool overwrite = radioOverwrite.Checked;
            DisableControls(overwrite);
            btnToggleCommandLog.Visible = true;

            string filename = "Core";

            // Core
            CheckBackup(filename);
            Library.BNK bnkfile = ReadBNK(filename + ".backup");
            int wemCount = await Task.Run(() => classlib.CountMedia(bnkfile, Path.Combine(extractdir, filename)));

            progressCore.Visible = true;
            progressCore.Maximum = wemCount;
            progressCore.Step = 1;
            Progress<int> progress = new Progress<int>(v =>
            {
                progressCore.Value = v;
            });
            await Task.Run(() => RepackStuff(filename, bnkfile, progress));

            filename = "Generic";

            // Core
            CheckBackup(filename);
            bnkfile = ReadBNK(filename + ".backup");
            wemCount = classlib.CountMedia(bnkfile, Path.Combine(extractdir, filename));

            progressGeneric.Visible = true;
            progressGeneric.Maximum = wemCount;
            progressGeneric.Step = 1;
            progress = new Progress<int>(v =>
            {
                progressGeneric.Value = v;
            });
            await Task.Run(() => RepackStuff(filename, bnkfile, progress));

            // re-enable temporarily disabled buttons
            btnBrowseDestination.Enabled = true;
            btnBrowseSource.Enabled = true;

            CheckSettings();
            if (overwrite && radioOverwrite.Enabled)
            {
                radioOverwrite.Checked = true;
            }
            else
            {
                radioSeparate.Checked = true;
            }
            btnToggleCommandLog.Visible = false;

            MessageBox.Show("Done repacking Core.bnk and Generic.bnk!");

            progressCore.Visible = false;
            progressGeneric.Visible = false;
        }


        private void btnToggleCommandLog_Click(object sender, EventArgs e)
        {
            if (outputWindow.Visible)
            {
                outputWindow.Visible = false;
                btnToggleCommandLog.Text = "Show Output Log";
            }
            else
            {
                outputWindow.Visible = true;
                btnToggleCommandLog.Text = "Hide Output Log";
            }
        }

        private bool CheckSettings()
        {
            btnExtract.Enabled = false;
            btnRepack.Enabled = false;
            radioOverwrite.Enabled = false;
            radioSeparate.Enabled = false;
            labelDestFolderMissing.Visible = true;

            bool initBNKFound = false;
            bool backupFound = false;
            string backupText = "";

            if (sourcedir != null)
            {
                if (CheckFiles("Core") > -1)
                {
                    corePath = Path.Combine(sourcedir, "Core.bnk");
                    initBNKFound = true;
                    txtGameDir.Text = sourcedir;
                    if (CheckBackup("Core"))
                    {
                        backupFound = true;
                        backupText = "Core.bnk";
                    }
                }
                if (CheckFiles("Generic") > -1)
                {
                    genericPath = Path.Combine(sourcedir, "Generic.bnk");
                    initBNKFound = true;
                    txtGameDir.Text = sourcedir;
                    if (CheckBackup("Generic"))
                    {
                        backupFound = true;
                        if (backupFound) backupText += " and ";
                        backupText += "Generic.bnk";
                    }
                }
                if (backupFound == true)
                {
                    labelBackups.Text = "Backup of " + backupText + " exist.";
                    labelBackups.ForeColor = Color.ForestGreen;
                }
                else
                {
                    labelBackups.Text = "Backups of Core.bnk and Generic.bnk not found. Succesfully created backups now.";
                    labelBackups.ForeColor = Color.Crimson;
                }

                if (initBNKFound == false)
                {
                    sourcedir = "";
                    txtGameDir.Text = "location of your Core.bnk and Generic.bnk files";
                }
            }

            if ((extractdir != null) && Directory.Exists(extractdir)) labelDestFolderMissing.Visible = false;

            if ((corePath != null) && (extractdir != null) && Directory.Exists(extractdir))
            {
                btnExtractCore.Enabled = true;
                if (CheckOutputDirectory("Core"))
                {
                    btnRepackCore.Enabled = true;
                    radioOverwrite.Enabled = true;
                    radioSeparate.Enabled = true;
                }
            }
            if ((genericPath != null) && (extractdir != null) && Directory.Exists(extractdir))
            {
                btnExtractGeneric.Enabled = true;
                if (CheckOutputDirectory("Generic"))
                {
                    btnRepackGeneric.Enabled = true;
                    radioOverwrite.Enabled = true;
                    radioSeparate.Enabled = true;
                }
            }

            if (btnExtractCore.Enabled && btnExtractGeneric.Enabled) btnExtract.Enabled = true;
            if (btnRepackCore.Enabled && btnRepackGeneric.Enabled) btnRepack.Enabled = true;

            if (Properties.Settings.Default.overwritefiles == true) radioOverwrite.Checked = true;

            return true;
        }

        private bool CheckBackup(string filename)
        {
            if (File.Exists(Path.Combine(sourcedir, filename + ".backup.bnk")))
            {
                return true;
            }
            else
            {
                CreateBackup(filename);
                return false;
            }
        }

        private void CreateBackup(string filename)
        {
            File.Copy(Path.Combine(sourcedir, filename + ".bnk"), Path.Combine(sourcedir, filename + ".backup.bnk"));
            CheckBackup(filename);
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = sourcedir;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    sourcedir = fbd.SelectedPath;

                    string exists = "The Core.bnk and Generic.bnk files were not found in the specified folder.";
                    string coreExists = "";
                    int existFiles = -1;

                    existFiles = CheckFiles("Core");
                    if (existFiles > -1)
                    {
                        coreExists = "Core.bnk file exists (" + String.Format("{0:n0}", existFiles.ToString()) + " bytes)\n";
                        exists = coreExists;

                        Properties.Settings.Default.sourcedir = sourcedir;
                        Properties.Settings.Default.Save();
                    }

                    existFiles = CheckFiles("Generic");
                    if (existFiles > -1)
                    {
                        if (coreExists != "")
                        {
                            exists += "Generic.bnk file exists (" + String.Format("{0:n0}", existFiles.ToString()) + " bytes)\n";
                        }
                        else
                        {
                            exists = "Generic.bnk file exists (" + String.Format("{0:n0}", existFiles.ToString()) + " bytes)\n";
                        }
                        Properties.Settings.Default.sourcedir = sourcedir;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            CheckSettings();
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = extractdir;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    extractdir = fbd.SelectedPath;

                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    bool wemFilesFound = false;

                    labelDestFolderMissing.Visible = false;
                    if (CheckOutputDirectory("Core"))
                    {
                        btnRepackCore.Enabled = true;
                        radioOverwrite.Enabled = true;
                        radioSeparate.Enabled = true;
                        wemFilesFound = true;
                    }
                    if (CheckOutputDirectory("Generic"))
                    {
                        btnRepackGeneric.Enabled = true;
                        radioOverwrite.Enabled = true;
                        radioSeparate.Enabled = true;
                        if (wemFilesFound) btnRepack.Enabled = true;
                    }
                    extractdir = fbd.SelectedPath;
                    Properties.Settings.Default.extractdir = extractdir;
                    Properties.Settings.Default.Save();
                    txtExtractDir.Text = fbd.SelectedPath;
                }
            }
            CheckSettings();
        }

        private int CheckFiles(string filename)
        {
            string checkpath = Path.Combine(sourcedir, filename + ".bnk");
            if (File.Exists(checkpath))
            {
                FileInfo fileinfo = GetBNKInfo(checkpath);
                return (int)fileinfo.Length;
            }
            return -1;
        }

        private bool CheckOutputDirectory(string filename)
        {
            string checkpath = Path.Combine(extractdir, filename);
            if (Directory.Exists(checkpath))
            {
                return Directory.EnumerateFileSystemEntries(checkpath).Any();
            }
            return false;
        }

        private void WriteToLog(string toWrite)
        {
            string newMessage = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + toWrite;
            messageList.Add(newMessage);
            if (messageList.Count() > 3000) messageList.Remove(messageList[0]);

            if (this.outputWindow.txtChatLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(WriteToLog);
                this.Invoke(d, new object[] { toWrite });
            }
            else
            {
                outputWindow.txtChatLog.AppendText(newMessage + Environment.NewLine);
            }
        }

        delegate void SetTextCallback(string text);














        private FileInfo GetBNKInfo(string path)
        {
            FileInfo fi = new FileInfo(path);
            return fi;
        }

        private Library.BNK ReadBNK(string filename)
        {
            filename += ".bnk";
            string filepath = Path.Combine(sourcedir, filename);
            WriteToLog(Environment.NewLine + "Opening " + filepath);

            Library.BNK bnk = new Library.BNK
            {
                fileName = Path.GetFileName(filepath),
                chunkList = new List<Library.Chunk>(),
                chunkIndex = new List<string>()
            };
            using (Stream input = File.OpenRead(filepath))
            {
                using (BinaryReader br = new BinaryReader(input, Encoding.Unicode))
                {
                    WriteToLog("Reading " + filename + "...");
                    while (br.PeekChar() != -1)
                    {
                        bnk.chunkList.Add(ReadBNKChunk(br));
                        bnk.chunkIndex.Add(bnk.chunkList[bnk.chunkList.Count - 1].dwTag);
                    }
                    //Console.WriteLine("Finished reading " + dirname + " BNK.");
                    WriteToLog(Environment.NewLine + "Finished reading " + filename + ".");
                }
            }

            return bnk;
        }

        private void WriteBNK(Library.BNK bnk, string outputPath)
        {
            using (Stream output = File.Open(outputPath, FileMode.Create))
            {
                WriteToLog(Environment.NewLine + "Started building " + outputPath);
                BinaryWriter bw = new BinaryWriter(output, Encoding.Unicode);
                foreach (Library.Chunk chunk in bnk.chunkList)
                {
                    WriteBNKChunk(ref bw, chunk);
                }
                WriteToLog(Environment.NewLine + "BNK saved to " + outputPath);
                bw.Close();
                output.Close();
            }
        }

        private void ExtractWEMs(Library.BNK bnk, string outputPath)
        {
            if (bnk.chunkIndex.Contains("DIDX") && bnk.chunkIndex.Contains("DATA"))
            {
                if (!Directory.Exists(outputPath)) Directory.CreateDirectory(outputPath);

                int chunkMediaIndex = bnk.chunkIndex.IndexOf("DIDX");
                int chunkDataIndex = bnk.chunkIndex.IndexOf("DATA");

                foreach (Library.MediaHeader mediaEntry in bnk.chunkList[chunkMediaIndex].pLoadedMedia)
                {
                    using (Stream output = File.OpenWrite(Path.Combine(outputPath, mediaEntry.id + ".wem")))
                    {
                        using (BinaryWriter bw = new BinaryWriter(output, Encoding.Unicode))
                        {
                            byte[] newbytes = new byte[mediaEntry.uSize];
                            Buffer.BlockCopy(bnk.chunkList[chunkDataIndex].pData, mediaEntry.uOffset, newbytes, 0, mediaEntry.uSize);
                            bw.Write(newbytes);
                        }

                    }
                }

            }
        }

        //Reads wems if their ID matches ones in bnk
        public static List<Library.WEM> ReadNewWEMs(List<Library.MediaHeader> pLoadedMedia, string sourcePath)
        {
            List<Library.WEM> newWEMList = new List<Library.WEM>();
            string[] files = Directory.GetFiles(sourcePath, "*.wem");
            if (files.Length > 0)
            {
                Console.WriteLine(files.Length);
                int ctr = 1;
                foreach (string file in files)
                {
                    try
                    {
                        int file_id = Int32.Parse(Path.ChangeExtension(Path.GetFileName(file), null));
                        foreach (Library.MediaHeader MediaHeader in pLoadedMedia)
                        {
                            if (MediaHeader.id == file_id)
                            {
                                FileInfo fi = new FileInfo(file);
                                BinaryReader br = new BinaryReader(File.OpenRead(file), Encoding.Unicode);
                                Library.WEM newWEM = new Library.WEM();
                                newWEM.id = file_id;
                                newWEM.data = br.ReadBytes((int)fi.Length);
                                newWEMList.Add(newWEM);
                                Console.WriteLine(ctr++);
                                br.Close();
                            }
                        }
                    }
                    catch
                    {

                    }

                }
            }
            return newWEMList;
        }

        private void ReplaceWEMs(Library.MediaHeader mediaHeader, ref byte[] pData, Library.WEM WEM)
        {
            int newWEMSize = WEM.data.Length;
            int newWEMPadding = classlib.GetPadding(newWEMSize, 16);
            //RemoveByteSection(ref pData, mediaHeader.uOffset, mediaHeader.uSize + GetPadding(mediaHeader.uSize, 16));
            //InsertByteSection(ref pData, mediaHeader.uOffset, WEM.data);
            pData = classlib.ReplaceBytes(pData, mediaHeader.uOffset, mediaHeader.uSize + classlib.GetPadding(mediaHeader.uSize, 16), WEM.data);
        }

        private void ReplaceBNKWEMs(Library.BNK bnk, string outputPath, IProgress<int> progress)
        {
            if (bnk.chunkIndex.Contains("DIDX") && bnk.chunkIndex.Contains("DATA"))
            {
                int chunkMediaIndex = bnk.chunkIndex.IndexOf("DIDX");
                int chunkDataIndex = bnk.chunkIndex.IndexOf("DATA");

                List<Library.WEM> newWemList = ReadNewWEMs(bnk.chunkList[chunkMediaIndex].pLoadedMedia, outputPath); //Passes list of wems in bnk
                if (newWemList.Count > 0)
                {
                    int ctr = 0;
                    int total = newWemList.Count;
                    foreach (Library.WEM WEM in newWemList)
                    {
                        //Console.WriteLine("Replacing WEM " + WEM.id.ToString() + " in BNK (" + ++ctr + " / " + total + ")");
                        WriteToLog("Replacing WEM " + WEM.id.ToString() + " in BNK (" + ++ctr + " / " + total + ")");
                        currentRepackPosition++;
                        Dictionary<int, int> wemIDDict = classlib.CreateIndexDict(bnk.chunkList[chunkMediaIndex].pLoadedMedia, "id");
                        int wemIndex = wemIDDict[WEM.id];
                        int oldDataSize = bnk.chunkList[chunkDataIndex].pData.Length;
                        byte[] pData = bnk.chunkList[chunkDataIndex].pData;
                        ReplaceWEMs(bnk.chunkList[chunkMediaIndex].pLoadedMedia[wemIndex], ref pData, WEM); //Passes MediaHeader entry for specific wem
                        bnk.chunkList[chunkDataIndex].pData = pData;
                        int newDataSize = bnk.chunkList[chunkDataIndex].pData.Length;
                        int sizeDifference = newDataSize - oldDataSize;
                        //if (sizeDifference != 0) Console.WriteLine("WEM " + WEM.id.ToString() + " size difference: " + sizeDifference.ToString());
                        bnk.chunkList[chunkMediaIndex].pLoadedMedia[wemIndex].uSize = WEM.data.Length; //Updates current WEM's size, not including padding
                        // Update WEM Offsets
                        for (int i = wemIndex + 1; i < bnk.chunkList[chunkMediaIndex].pLoadedMedia.Count; i++)
                        {
                            bnk.chunkList[chunkMediaIndex].pLoadedMedia[i].uOffset += sizeDifference;
                        }
                        progress.Report(currentRepackPosition);
                    }

                    bnk.chunkList[chunkDataIndex].dwChunkSize = (uint)bnk.chunkList[chunkDataIndex].pData.Length;
                }
                else
                {
                    MessageBox.Show("No WEM files were found in the " + outputPath + " folder.");
                }
            }

        }

        private void ExtractStuff(string filename)
        {
            Library.BNK bnk;
            bnk = ReadBNK(filename);
            WriteToLog(Environment.NewLine + "Started extracting " + filename + " WEM files.");
            ExtractWEMs(bnk, Path.Combine(extractdir, filename));
            WriteToLog(Environment.NewLine + "Done extracting " + filename + " WEM files to " + Path.Combine(extractdir, filename));
        }

        private void RepackStuff(string filename, Library.BNK bnkfile, IProgress<int> progress)
        {
            string writepath = "";

            if (radioOverwrite.Checked == true)
            {
                writepath = Path.Combine(sourcedir, filename + ".bnk");
            }
            else
            {
                writepath = Path.Combine(extractdir, filename + ".bnk");
            }

            currentRepackPosition = 0;
            WriteToLog(Environment.NewLine + "Started repacking " + filename + "...");
            ReplaceBNKWEMs(bnkfile, Path.Combine(extractdir, filename), progress);
            WriteToLog(Environment.NewLine + "Done repacking " + filename + "!");
            WriteBNK(bnkfile, writepath);
        }

        private Library.Chunk ReadBNKChunk(BinaryReader br)
        {
            Library.Chunk chunk = new Library.Chunk();

            string type = Encoding.UTF8.GetString(br.ReadBytes(4));
            switch (type)
            {
                case "BKHD":
                    chunk = ReadBKHD(br);
                    break;
                case "DIDX":
                    chunk = ReadDIDX(br);
                    break;
                case "DATA":
                    chunk = ReadDATA(br);
                    break;
                case "HIRC":
                    chunk = ReadHIRC(br);
                    break;
            }
            return chunk;
        }

        private void WriteBNKChunk(ref BinaryWriter bw, Library.Chunk chunk)
        {
            string type = chunk.dwTag;
            switch (type)
            {
                case "BKHD":
                    WriteBKHD(ref bw, chunk);
                    break;
                case "DIDX":
                    WriteDIDX(ref bw, chunk);
                    break;
                case "DATA":
                    WriteDATA(ref bw, chunk);
                    break;
                case "HIRC":
                    WriteHIRC(ref bw, chunk);
                    break;
            }
        }







        private Library.Chunk ReadBKHD(BinaryReader br)
        {
            Library.Chunk bkhd = new Library.Chunk();
            bkhd.dwTag = "BKHD";
            bkhd.dwChunkSize = br.ReadUInt32();
            bkhd.dwBankGeneratorVersion = br.ReadUInt32();
            bkhd.dwSoundBankID = br.ReadUInt32();
            bkhd.dwLanguageID = br.ReadUInt32();
            bkhd.bUnused = br.ReadUInt16();
            bkhd.bDeviceAllocated = br.ReadUInt16();
            bkhd.dwProjectID = br.ReadUInt32();
            bkhd.padding = br.ReadBytes((int)(bkhd.dwChunkSize - 20));
            return bkhd;
        }

        private Library.Chunk ReadDIDX(BinaryReader br)
        {
            //Dictionary<string, dynamic> didx = new Dictionary<string, dynamic>();
            Library.Chunk didx = new Library.Chunk();
            didx.dwTag = "DIDX";
            didx.dwChunkSize = br.ReadUInt32();
            didx.pLoadedMedia = new List<Library.MediaHeader>();
            for (int i = 0; i < didx.dwChunkSize / 12; i++)
            {
                //Dictionary<string, int> mediaHeader = new Dictionary<string, int>();
                Library.MediaHeader mediaHeader = new Library.MediaHeader();
                mediaHeader.id = br.ReadInt32();
                mediaHeader.uOffset = br.ReadInt32();
                mediaHeader.uSize = br.ReadInt32();
                didx.pLoadedMedia.Add(mediaHeader);
            }
            return didx;
        }

        private Library.Chunk ReadDATA(BinaryReader br)
        {
            //Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            Library.Chunk data = new Library.Chunk();
            data.dwTag = "DATA";
            data.dwChunkSize = br.ReadUInt32();
            data.pData = br.ReadBytes((int)data.dwChunkSize);
            return data;
        }

        private Library.Chunk ReadHIRC(BinaryReader br)
        {
            //Dictionary<string, dynamic> hirc = new Dictionary<string, dynamic>();
            Library.Chunk hirc = new Library.Chunk();
            hirc.dwTag = "HIRC";
            hirc.dwChunkSize = br.ReadUInt32();
            hirc.hircdata = br.ReadBytes((int)hirc.dwChunkSize);
            return hirc;
        }

        private void WriteBKHD(ref BinaryWriter bw, Library.Chunk bkhd)
        {
            //Console.WriteLine("Writing Bank Header...");
            WriteToLog("Writing Bank Header...");
            bw.Write(Encoding.UTF8.GetBytes(bkhd.dwTag));
            bw.Write(bkhd.dwChunkSize);
            bw.Write(bkhd.dwBankGeneratorVersion);
            bw.Write(bkhd.dwSoundBankID);
            bw.Write(bkhd.dwLanguageID);
            bw.Write(bkhd.bUnused);
            bw.Write(bkhd.bDeviceAllocated);
            bw.Write(bkhd.dwProjectID);
            bw.Write(bkhd.padding);
        }

        private void WriteDIDX(ref BinaryWriter bw, Library.Chunk didx)
        {
            //Console.WriteLine("Writing Media Index...");
            WriteToLog("Writing Media Index...");
            bw.Write(Encoding.UTF8.GetBytes(didx.dwTag));
            bw.Write(didx.dwChunkSize);
            foreach (Library.MediaHeader mediaHeader in didx.pLoadedMedia)
            {
                bw.Write(mediaHeader.id);
                bw.Write(mediaHeader.uOffset);
                bw.Write(mediaHeader.uSize);
            }
        }

        private void WriteDATA(ref BinaryWriter bw, Library.Chunk data)
        {
            //Console.WriteLine("Writing WEM Data...");
            WriteToLog("Writing WEM Data...");
            bw.Write(Encoding.Default.GetBytes(data.dwTag));
            bw.Write(data.dwChunkSize);
            bw.Write(data.pData);
        }

        private void WriteHIRC(ref BinaryWriter bw, Library.Chunk hirc)
        {
            //Console.WriteLine("Writing Hierarchy...");
            WriteToLog("Writing Hierarchy...");
            bw.Write(Encoding.Default.GetBytes(hirc.dwTag));
            bw.Write(hirc.dwChunkSize);
            bw.Write(hirc.hircdata);
        }


        private async void btnExtractCore_Click(object sender, EventArgs e)
        {
            // disabled buttons temporarily
            bool overwrite = radioOverwrite.Checked;
            DisableControls(overwrite);
            btnToggleCommandLog.Visible = true;

            string filename = "Core";

            progressCore.Visible = true;
            progressCore.Style = ProgressBarStyle.Marquee;
            await Task.Run(() => ExtractStuff(filename));
            progressCore.Style = ProgressBarStyle.Blocks;

            // re-enable temporarily disabled buttons
            btnBrowseDestination.Enabled = true;
            btnBrowseSource.Enabled = true;

            CheckSettings();
            if (overwrite && radioOverwrite.Enabled)
            {
                radioOverwrite.Checked = true;
            }
            else
            {
                radioSeparate.Checked = true;
            }
            btnToggleCommandLog.Visible = false;

            MessageBox.Show("Done extracting " + filename + ".bnk into WEM files!");

            progressCore.Visible = false;
            progressGeneric.Visible = false;
        }

        private async void btnExtractGeneric_Click(object sender, EventArgs e)
        {
            // disabled buttons temporarily
            bool overwrite = radioOverwrite.Checked;
            DisableControls(overwrite);
            btnToggleCommandLog.Visible = true;

            string filename = "Generic";

            progressGeneric.Visible = true;
            progressGeneric.Style = ProgressBarStyle.Marquee;
            await Task.Run(() => ExtractStuff(filename));
            progressGeneric.Style = ProgressBarStyle.Blocks;

            // re-enable temporarily disabled buttons
            btnBrowseDestination.Enabled = true;
            btnBrowseSource.Enabled = true;

            CheckSettings();
            if (overwrite && radioOverwrite.Enabled)
            {
                radioOverwrite.Checked = true;
            }
            else
            {
                radioSeparate.Checked = true;
            }
            btnToggleCommandLog.Visible = false;

            MessageBox.Show("Done extracting " + filename + ".bnk into WEM files!");

            progressCore.Visible = false;
            progressGeneric.Visible = false;
        }

        private async void btnRepackCore_Click(object sender, EventArgs e)
        {
            // disabled buttons temporarily
            bool overwrite = radioOverwrite.Checked;
            DisableControls(overwrite);
            btnToggleCommandLog.Visible = true;

            string filename = "Core";

            // Core
            CheckBackup(filename);
            Library.BNK bnkfile = ReadBNK(filename);
            Console.WriteLine("reading");
            int wemCount = await Task.Run(() => classlib.CountMedia(bnkfile, Path.Combine(extractdir, filename)));
            Console.WriteLine("done reading");

            progressCore.Visible = true;
            progressCore.Maximum = wemCount;
            progressCore.Step = 1;
            Progress<int> progress = new Progress<int>(v =>
            {
                progressCore.Value = v;
            });
            await Task.Run(() => RepackStuff(filename, bnkfile, progress));

            // re-enable temporarily disabled buttons
            btnBrowseDestination.Enabled = true;
            btnBrowseSource.Enabled = true;

            CheckSettings();
            if (overwrite && radioOverwrite.Enabled)
            {
                radioOverwrite.Checked = true;
            }
            else
            {
                radioSeparate.Checked = true;
            }
            btnToggleCommandLog.Visible = false;

            MessageBox.Show("Done repacking Core.bnk!");

            progressCore.Visible = false;
            progressGeneric.Visible = false;
        }

        private async void btnRepackGeneric_Click(object sender, EventArgs e)
        {
            // disabled buttons temporarily
            bool overwrite = radioOverwrite.Checked;
            DisableControls(overwrite);
            btnToggleCommandLog.Visible = true;

            string filename = "Generic";

            // Core
            CheckBackup(filename);
            Library.BNK bnkfile = ReadBNK(filename);
            int wemCount = await Task.Run(() => classlib.CountMedia(bnkfile, Path.Combine(extractdir, filename)));

            progressGeneric.Visible = true;
            progressGeneric.Maximum = wemCount;
            progressGeneric.Step = 1;
            Progress<int> progress = new Progress<int>(v =>
            {
                progressGeneric.Value = v;
            });
            await Task.Run(() => RepackStuff(filename, bnkfile, progress));

            // re-enable temporarily disabled buttons
            btnBrowseDestination.Enabled = true;
            btnBrowseSource.Enabled = true;
            CheckSettings();
            if (overwrite && radioOverwrite.Enabled)
            {
                radioOverwrite.Checked = true;
            }
            else
            {
                radioSeparate.Checked = true;
            }
            btnToggleCommandLog.Visible = false;

            MessageBox.Show("Done repacking Generic.bnk!");

            progressCore.Visible = false;
            progressGeneric.Visible = false;
        }

        private void DisableControls(bool overwrite)
        {
            btnBrowseDestination.Enabled = false;
            btnBrowseSource.Enabled = false;
            btnExtract.Enabled = false;
            btnRepack.Enabled = false;
            btnExtractCore.Enabled = false;
            btnExtractGeneric.Enabled = false;
            btnRepackCore.Enabled = false;
            btnRepackGeneric.Enabled = false;
            btnToggleCommandLog.Visible = true;
            if (overwrite)
            {
                radioSeparate.Enabled = false;
                radioOverwrite.Enabled = false;
            }
            else
            {
                radioOverwrite.Enabled = false;
                radioSeparate.Enabled = false;
            }
        }

        private void radioSeparate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSeparate.Checked)
            {
                Properties.Settings.Default.overwritefiles = false;
                Properties.Settings.Default.Save();
            }
        }

        private void radioOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            if (radioOverwrite.Checked)
            {
                Properties.Settings.Default.overwritefiles = true;
                Properties.Settings.Default.Save();
            }
        }

        private void imgBMCSupport_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://buymeacoffee.com/honganqi");
        }

        private void imgYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://youtube.com/honganqi");
        }

        private void imgTwitch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitch.tv/honganqi");
        }

        private void imgSF_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/sor4-sound-replacer/");
        }
    }
}
