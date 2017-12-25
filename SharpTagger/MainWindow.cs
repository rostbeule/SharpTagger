using System;
using System.IO;
using System.Windows.Forms;

namespace Tagger
{
    public partial class MainWindow : Form
    {   
        // namensraumweit gültig
        public string selectedFormat = "*.mp3"; // aktuell nur MP3 möglich

        // klassenweit gültig
        private Config Config = new Config();
        private Random r = new Random();
        private int action;

        public MainWindow()
        {
            InitializeComponent();
            // Zentrierte Darstellung des Hauptfensters
            StartPosition = FormStartPosition.CenterScreen;            
            // Konfiguration initialisieren
            Config.Initialize();            
        }

        // MainWindow wird geladen
        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            // Sortiere Elemente der TreeView alphabestisch
            TrvLibrary.TreeViewNodeSorter = new AlphabeticSorter();
            // Std.Backup-Verzeichnis erstellen, wenn gelöscht
            CreateBackupFolder();
            // Backup-Verzeichnis prüfen
            CheckBackupFolder();
            // Schaf soll zwinkern
            Timer.Tick += new EventHandler(TimerEventProcessor);
            Timer.Start();
        }
                
        // Erstellt Backup-Ordner (wenn Standard-Wert)
        private void CreateBackupFolder()
        {
            // Falls Benutzer Standard-Ordner für Backup gelöscht hat - erstelle neu
            if (Config.PathToBackup == Config.BackupPathStd)
            {
                if (!Directory.Exists(Config.PathToBackup))
                    Directory.CreateDirectory(Config.BackupPathStd);
            }
        }

        // Backup-Verzeichnis auf Vorhandensein prüfen
        private void CheckBackupFolder()
        {
            if (Config.PathToBackup != Config.BackupPathStd)
            {
                if (!Directory.Exists(Config.PathToBackup))
                {
                    MessageBox.Show("Der angegebene Pfad zum Backup-Ordner\nkonnte nicht gefunden werden");

                    Options Options = new Options(this);
                    Options.StartPosition = FormStartPosition.CenterParent;
                    Options.ShowDialog(this);

                    // Nach schließen des Unterdialogs Anzeige aktualisieren
                    Config.Initialize();
                    LoadTreeView();

                    // eventuell erneute Prüfung notwendig
                    CreateBackupFolder(); // falls nach Fehler geändert und noch nicht vorhanden
                    CheckBackupFolder();
                }
            }
        }

        // Beendet Programm
        private void MnuCmdDataClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Öffnet Unterdialog Options
        private void MnuCmdOptionsAdjustments_Click(object sender, EventArgs e)
        {
            Options Options = new Options(this);
            Options.StartPosition = FormStartPosition.CenterParent;
            Options.ShowDialog(this);

            // Nach schließen des Unterdialogs Anzeige aktualisieren
            Config.Initialize();
            LoadTreeView();
        }

        // Ändert Hintergrund        
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (action == 0)
            {
                action++;
                Timer.Interval = r.Next(100, 600);
                PanSheep.BackgroundImage = Properties.Resources.sheep_with_headphones_eyes_closed_640;
            }
            else
            {
                action--;
                Timer.Interval = r.Next(1000, 6000);
                PanSheep.BackgroundImage = Properties.Resources.sheep_with_headphones_640;
            }
        }

        // TreeView laden
        private void LoadTreeView()
        {
            TrvLibrary.Nodes.Clear();                           // TreeView alte Einträge entfernen
            TreeNode rootNode = new TreeNode(Config.PathToLib); // Wurzelknoten erzeugen
            TrvLibrary.Nodes.Add(rootNode);
            AddSubNodes(rootNode);                              // untergeordnete Ebene füllen und
            TrvLibrary.Nodes[0].Expand();                       // ... expandieren            
        }

        // fügt die Knoten der untergeordneten Verzeichnisebene hinzu:
        private void AddSubNodes(TreeNode dirNode)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirNode.FullPath);
                try
                {
                    foreach (DirectoryInfo dirItem in dir.GetDirectories())
                    {
                        TreeNode newNode = new TreeNode(dirItem.Name);  // Knoten für Unterverzeichnis hinzufügen:
                        dirNode.Nodes.Add(newNode);
                        newNode.Nodes.Add("*");                         // Child-Knoten erhält Platzhalterzeichen
                    }
                }
                catch (UnauthorizedAccessException err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
            catch
            {
                // Exception-Handling wenn angegebener Pfad in 'App.Config' nicht lesbar oder vorhanden
                if (MessageBox.Show("Der angegebene Pfad zur Musik-Bibliothek konnte nicht gelesen werden. " +
                                    "Soll der Standardwert wiederhergestellt werden?", "Initialisierungsfehler",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    Config.Update("PathToLib", @"C:\Users\Public\Music");
                    LoadTreeView();
                }
                else
                    return;
            }
        }

        // ein Knoten wurde expandiert:        
        private void TrvLibrary_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "*")    // falls es sich um einen Platzhalterknoten handelt
            {
                TrvLibrary.BeginUpdate();       // erneutes Zeichnen deaktivieren
                e.Node.Nodes.Clear();           // Platzhalterknoten löschen
                AddSubNodes(e.Node);          // alle untergeordneten Knoten hinzufügen
                TrvLibrary.EndUpdate();         // erneutes Zeichnen aktivieren
            }
        }

        // Doppelklick auf Knoten sucht nach Files im selektierten Ordner       
        private void TrvLibrary_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            bool containsMp3Files = false;

            // Durchsuche Ordner nach Audio-Files
            foreach (string fileName in Directory.GetFiles(e.Node.FullPath, selectedFormat))   
            {
                // Abbruchbedingung nach erstem Treffer -> liefert 'true'
                containsMp3Files = true;
                if (containsMp3Files)
                    break;
            }

            // Zeige Files wenn vorhanden
            if (containsMp3Files)
                ShowFiles(e.Node.FullPath);
        }

        // Aufruf des FileBrowsers (Pfandangabe als Übergabeparameter benötigt)
        private void ShowFiles(string pathToFolder)
        {
            FileBrowser Mp3Files = new FileBrowser(this, pathToFolder);
            Mp3Files.StartPosition = FormStartPosition.CenterParent;
            Mp3Files.ShowDialog(this);
        }

        // Lade einen einzelnen Ordner
        private void MnuCmdOpen_Click(object sender, EventArgs e)
        {
            // Standard-Dialog für Verzeichnis öffnen
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.Desktop,
                ShowNewFolderButton = false,
                Description = "Verzeichnis auswählen"
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                bool containsFiles = false;

                // Durchsuche Ordner nach Audio-Files
                foreach (string fileName in Directory.GetFiles(fbd.SelectedPath, selectedFormat))
                {
                    // Abbruchbedingung nach erstem Treffer -> liefert 'true'
                    containsFiles = true;
                    if (containsFiles)
                        break;
                }

                // Zeige Files wenn vorhanden
                if (containsFiles)
                    ShowFiles(fbd.SelectedPath);

                // Meldung, wenn keine 'verwertbaren' Dateien im Verzeichnis
                else
                    MessageBox.Show("Das angegebene Verzeichnis enthält keine Audio-Dateien.");
            }                
        }
    }
}
