using nucs.JsonSettings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SettingsNamespace
{   //https://github.com/Nucs/JsonSettings
    //Step 1: create a class and inherit JsonSettings
    public class Settings
    {

        private PersonalSettings pSettings = new PersonalSettings();
        private GlobalSettings gSettings = new GlobalSettings();
        private Dictionary<String, List<String>> patientTypeCategoriesDict
        {
            get
            {
                return gSettings.patientTypeCategories;
            }
            set
            {
                gSettings.patientTypeCategories = value;
            }
        }  // Room[N] -> List with only checked patientTypes

        #region Settings

        public string projectPathData
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

        public string projectPathScript
        {
            get
            {
                return projectPathData + "\\script\\";
            }
        }

        public string projectPathLevel
        {
            get
            {
                return projectPathData + "\\script\\levels\\";
            }
        }
        public string projectPathImages
        {
            get
            {
                return projectPathData + "\\images\\";
            }
        }



        public Dictionary<String, List<String>> GetPatientTypes(String categoryKey = null)
        {
            if (categoryKey != null)
            {
                Dictionary<String, List<String>> filterdPatientTypeDict = new Dictionary<String, List<String>> { };  // Room[N] -> List with only checked patientTypes

                if (patientTypeCategoriesDict.ContainsKey(categoryKey))
                {
                    filterdPatientTypeDict.Add(categoryKey, patientTypeCategoriesDict[categoryKey]);
                }
                else
                {
                    Console.WriteLine("ERROR: windowSettings.StorePatientTypeCategory, patientTypeCategoriesDict does not contain key: " + categoryKey);
                }
                return filterdPatientTypeDict;

            }
            else
            {
                return patientTypeCategoriesDict;
            }
        }

        public void SetPatientTypes(Dictionary<String, List<String>> patientTypeCategoriesDict)
        {
            this.patientTypeCategoriesDict = patientTypeCategoriesDict;
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

        public Dictionary<String, List<String>> patientTypeCategories {
            get;
            set; 
        }

        public GlobalSettings() { }
        public GlobalSettings(string fileName) : base(fileName) { }

        

    }
}

