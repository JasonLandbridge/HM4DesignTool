using nucs.JsonSettings;

namespace SettingsNamespace
{   //https://github.com/Nucs/JsonSettings
    //Step 1: create a class and inherit JsonSettings
    public class Settings
    {

        private PersonalSettings pSettings = new PersonalSettings();
        private GlobalSettings gSettings = new GlobalSettings();

        #region Settings

        public string ProjectDirectoryPath
        {
            get
            {
                return pSettings.ProjectDirectoryPath;
            }
            set
            {
                pSettings.ProjectDirectoryPath = value;
            }
        }

        #endregion

        public Settings()
        {
            pSettings.Load();
            gSettings.Load();

        }

        public void Save()
        {
            pSettings.Save();
            gSettings.Save();
        }

    }

    public class PersonalSettings : JsonSettings
    {
        public override string FileName { get; set; } = "personal.json"; //for loading and saving.

        public string ProjectDirectoryPath { get; set; } = "notLoaded";

        public PersonalSettings() { }
        public PersonalSettings(string fileName) : base(fileName) { }



    }

    public class GlobalSettings : JsonSettings
    {
        public override string FileName { get; set; } = "global.json"; //for loading and saving.

        public GlobalSettings() { }
        public GlobalSettings(string fileName) : base(fileName) { }



    }
}

