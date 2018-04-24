using nucs.JsonSettings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SettingsNamespace
{   //Storing settings in JSON: https://github.com/Nucs/JsonSettings
    public class Settings
    {

        private PersonalSettings pSettings = new PersonalSettings();
        private GlobalSettings gSettings = new GlobalSettings();
        private Dictionary<String, List<String>> patientTypeCategoriesDict
        {
            get
            {
                if (gSettings.patientTypeCategories != null)
                {
                    return gSettings.patientTypeCategories;
                }
                else
                {
                    return new Dictionary<String, List<String>> { };
                }
            }
            set
            {
                gSettings.patientTypeCategories = value;
            }
        }  // Room[N] -> List with only checked patientTypes
        private Dictionary<String, List<String>> balancingCategoriesDict
        {
            get
            {
                if (gSettings.balancingCategoriesDict != null)
                {
                    return gSettings.balancingCategoriesDict;
                }
                else
                {
                    return new Dictionary<String, List<String>> { };
                }
            }
            set
            {
                gSettings.balancingCategoriesDict = value;
            }
        }  // Room[N] -> List with String difficulty Modifiers

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

        #region Getters


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
                    Console.WriteLine("ERROR: windowSettings.GetPatientTypes, patientTypeCategoriesDict does not contain key: " + categoryKey);
                }
                return filterdPatientTypeDict;

            }
            else
            {
                return patientTypeCategoriesDict;
            }
        }


        public Dictionary<String, List<String>> GetBalancingCategories(String categoryKey = null)
        {
            if (categoryKey != null)
            {
                Dictionary<String, List<String>> filterdBalancingCategory = new Dictionary<String, List<String>> { };  // Room[N] -> List with Difficulty modifiers in String

                if (balancingCategoriesDict.ContainsKey(categoryKey))
                {
                    filterdBalancingCategory.Add(categoryKey, balancingCategoriesDict[categoryKey]);
                }
                else
                {
                    Console.WriteLine("ERROR: windowSettings.GetBalancingCategories, balancingCategoriesDict does not contain key: " + categoryKey);
                }
                return filterdBalancingCategory;

            }
            else
            {
                return balancingCategoriesDict;
            }
        }

        #endregion

        #region Setters

        public void SetPatientTypes(Dictionary<String, List<String>> patientTypeCategoriesDict)
        {
            this.patientTypeCategoriesDict = patientTypeCategoriesDict;
        }

        public void SetBalancingCategories(Dictionary<String, List<String>> balancingCategoriesDict)
        {
            this.balancingCategoriesDict = balancingCategoriesDict;
        }

        #endregion

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

        public Dictionary<String, List<String>> patientTypeCategories { get; set; }
        public Dictionary<String, List<String>> balancingCategoriesDict { get; set; } 

        public GlobalSettings() { }
        public GlobalSettings(string fileName) : base(fileName) { }

        

    }
}

