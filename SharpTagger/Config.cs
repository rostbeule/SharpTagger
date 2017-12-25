using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Tagger
{
    public class Config
    {
        // Zugriff auf 'App.Config'

        // Zur Nutzung Verweis System.Configuration (im Projektmappen-Explorer) eintragen
        // Zur Nutzung using-Direktiven System.Configuration, ggf. System.Collections.Specialized (für kompl. Ausgabe)

        //
        internal string BackupPathStd { get; private set; }

        // Liste der Konfigurationsmöglichkeiten
        internal string PathToFile { get; private set; }
        internal string PathToLib { get; private set; }
        internal string PathToBackup { get; set; }
        internal string ChkBackup { get; set; }
        internal string Artists { get; private set; }
        internal string AlbumArtists { get; private set; }
        internal string Album { get; private set; }
        internal string Title { get; private set; }
        internal string Track { get; private set; }
        internal string Year { get; private set; }
        internal string Genres { get; private set; }
        internal string Cover { get; private set; }
        internal string AmazonId { get; private set; }
        internal string Comment { get; private set; }
        internal string Composers { get; private set; }
        internal string Disc { get; private set; }
        internal string DiscCount { get; private set; }


        /// <summary>
        /// Läd die aktuellen Einstellungen aus der Konfigurationsdatei 
        /// </summary>
        public void Initialize()
        {
            // neue Instanz vom Typ Configuration 
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


            // Konfigurations-Bezeichner auf Vorhandensein prüfen, sonst mit Standardwerten erzeugen                    

            // Standard-Pfadangabe für DatenBibliothek
            if (ConfigurationManager.AppSettings["PathToLib"] == null)
                config.AppSettings.Settings.Add("PathToLib", @"C:\Users\Public\Music");

            // Standard-Pfadangabe für Backup
            // Standard Backup-Pfad im Istallations-Verzeichnis /Temp festlegen
            string startupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string backupFolder = @"\Temp";
            BackupPathStd = startupPath + backupFolder; // außerhalb der Klasse erreichbar

            try
            {
                // Wenn Standard-Pfad nicht existiert - erstellen
                if (!Directory.Exists(BackupPathStd))
                    Directory.CreateDirectory(BackupPathStd);
            }
            catch
            {
                MessageBox.Show("Der Standard Backup-Ordner konnte nicht erstellt werden\n" +
                                "Bitte unter Optionen/Einstellungen Pfad-Angabe ändern");
            }

            if (ConfigurationManager.AppSettings["PathToBackup"] == null)
                config.AppSettings.Settings.Add("PathToBackup", BackupPathStd);

            // Standard-Einstellung für Option Backup
            if (ConfigurationManager.AppSettings["ChkBackup"] == null)
                config.AppSettings.Settings.Add("ChkBackup", "true");

            // Standard-Einstellungen für Optionen der Metadaten
            if (ConfigurationManager.AppSettings["Artists"] == null)
                config.AppSettings.Settings.Add("Artists", "true");
            if (ConfigurationManager.AppSettings["AlbumArtists"] == null)
                config.AppSettings.Settings.Add("AlbumArtists", "true");
            if (ConfigurationManager.AppSettings["Album"] == null)
                config.AppSettings.Settings.Add("Album", "true");
            if (ConfigurationManager.AppSettings["Title"] == null)
                config.AppSettings.Settings.Add("Title", "true");
            if (ConfigurationManager.AppSettings["Track"] == null)
                config.AppSettings.Settings.Add("Track", "true");
            if (ConfigurationManager.AppSettings["Year"] == null)
                config.AppSettings.Settings.Add("Year", "true");
            if (ConfigurationManager.AppSettings["Genre"] == null)
                config.AppSettings.Settings.Add("Genre", "true");
            if (ConfigurationManager.AppSettings["Cover"] == null)
                config.AppSettings.Settings.Add("Cover", "true");
            if (ConfigurationManager.AppSettings["AmazonId"] == null) 
                config.AppSettings.Settings.Add("AmazonId", "true");
            if (ConfigurationManager.AppSettings["Comment"] == null)
                config.AppSettings.Settings.Add("Comment", "true");
            if (ConfigurationManager.AppSettings["Composers"] == null)
                config.AppSettings.Settings.Add("Composers", "true");
            if (ConfigurationManager.AppSettings["Disc"] == null)
                config.AppSettings.Settings.Add("Disc", "true");
            if (ConfigurationManager.AppSettings["DiscCount"] == null)
                config.AppSettings.Settings.Add("DiscCount", "true");

            // Standard-Einstellung für Option Pfandangabe 
            if (ConfigurationManager.AppSettings["PathToFile"] == null)
                config.AppSettings.Settings.Add("PathToFile", "true");

            // Änderungen (Standardwerte) einpflegen
            config.Save(ConfigurationSaveMode.Modified);


            // Konfiguration aktualisieren und Wert übergeben
            ConfigurationManager.RefreshSection("appSettings");
            PathToLib = ConfigurationManager.AppSettings["PathToLib"];
            PathToBackup = ConfigurationManager.AppSettings["PathToBackup"];
            ChkBackup = ConfigurationManager.AppSettings["ChkBackup"];
            Artists = ConfigurationManager.AppSettings["Artists"];
            AlbumArtists = ConfigurationManager.AppSettings["AlbumArtists"];
            Album = ConfigurationManager.AppSettings["Album"];
            Title = ConfigurationManager.AppSettings["Title"];
            Track = ConfigurationManager.AppSettings["Track"];
            Year = ConfigurationManager.AppSettings["Year"];
            Genres = ConfigurationManager.AppSettings["Genre"];
            PathToFile = ConfigurationManager.AppSettings["PathToFile"];
            Cover = ConfigurationManager.AppSettings["Cover"];
            AmazonId = ConfigurationManager.AppSettings["AmazonId"];
            Comment = ConfigurationManager.AppSettings["Comment"];
            Composers = ConfigurationManager.AppSettings["Composers"];
            Disc = ConfigurationManager.AppSettings["Disc"];
            DiscCount = ConfigurationManager.AppSettings["DiscCount"];
        }


        /// <summary>
        /// Schreibt geänderte Einstellungs-Werte in die Konfigurationsdatei
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        internal void Update(string parameter, string value)
        {
            // neue Instanz vom Typ Configuration 
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Neuen Wert setzen
            config.AppSettings.Settings[parameter].Value = value;

            // Änderung einpflegen
            config.Save(ConfigurationSaveMode.Modified);

            // Konfigurationseinstellungen Aktualisieren
            Initialize();            
        }        
    }
}
