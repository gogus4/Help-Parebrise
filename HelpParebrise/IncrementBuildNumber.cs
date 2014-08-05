using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace FirstFloor.ModernUI.App
{
    public class IncrementBuildNumber
    {
        long buildNumber;     // Build number  : égal au mois en cours (4 pour Avril par exemple)
        long revisionNumber;  // Revision number : incrémenté de 1 à partir de 0 à chaque build. Et est remis à zéro quand on change de mois ou d'année
        long minorVersion;  // Minor Version : année en cours avec les deux derniers chiffres uniquement

        public long BuildNumber
        {
            get { return buildNumber; }
            set { buildNumber = value; }
        }

        public long RevisionNumber
        {
            get { return revisionNumber; }
            set { revisionNumber = value; }
        }

        public long MinorVersion
        {
            get { return minorVersion; }
            set { minorVersion = value; }
        }

        public static string Version;

        public IncrementBuildNumber()
        {
            try
            {
                Increment();
            }
            catch (Exception E) { }
        }

        private void Increment()
        {
            minorVersion = 0;
            buildNumber = 0;

            // Default build revision to 0
            revisionNumber = 0;

            string previousBuild = ConfigurationManager.AppSettings["Version"];
            string[] previousNumbers = previousBuild.Split('.');

            MessageBoxResult result = MessageBox.Show("Voulez-vous incrémenter le numéro de version ?", "Incrémenter le numéro de version ?", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                if ((minorVersion == long.Parse(previousNumbers[1])) && (buildNumber == long.Parse(previousNumbers[2])))
                    revisionNumber = long.Parse(previousNumbers[3]) + 1;
                else
                    revisionNumber = 1;

                string version = string.Format("{0}.{1}.{2}", minorVersion, buildNumber, revisionNumber);
                Version = "1." + version;

                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string configFile = System.IO.Path.Combine(appPath, "HelpParebrise.exe.config");
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = configFile;
                System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

                config.AppSettings.Settings["Version"].Value = Version.ToString();
                config.Save(); 
            }
            else
            {
                revisionNumber = long.Parse(previousNumbers[3]);

                string version = string.Format("{0}.{1}.{2}", minorVersion, buildNumber, revisionNumber);
                Version = "1." + version;
            }
        }
    }
}
