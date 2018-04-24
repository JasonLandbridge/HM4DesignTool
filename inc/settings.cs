using nucs.JsonSettings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

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
        private Dictionary<String, List<Treatment>> treatmentCategoriesDict
        {
            get
            {
                if (gSettings.treatmentCategories != null)
                {
                    //Convert Dictionary<String, Dictionary<String, List<String>>> -> Dictionary<String, List<Treatment>>
                    Dictionary<String, List<Treatment>> convertedDict = new Dictionary<String, List<Treatment>> { };
                    //Loop over each room/category
                    foreach (KeyValuePair<String, Dictionary<String, String>> roomCategory in gSettings.treatmentCategories)
                    {
                        List<Treatment> treatmentList = new List<Treatment> { };
                        //Loop over each treatment
                        foreach (KeyValuePair<String, String> treatmentRow in roomCategory.Value)
                        {
                            Treatment treatmentStruct = new Treatment(treatmentRow.Key, treatmentRow.Value);

                            treatmentList.Add(treatmentStruct);
                        }
                        convertedDict.Add(roomCategory.Key, treatmentList);
                    }

                    return convertedDict;
                }
                else
                {
                    return new Dictionary<String, List<Treatment>> { };
                }
            }
            set
            {
                //Convert Dictionary<String, List<Treatment>> -> Dictionary<String, Dictionary<String, List<String>>>
                Dictionary<String, Dictionary<String, String>> convertedDict = new Dictionary<String, Dictionary<String, String>> { };
                //Loop over each room/category
                foreach (KeyValuePair<String, List<Treatment>> roomCategory in value)
                {
                    Dictionary <String, String> treatmentList = new Dictionary<String, String>{ };
                    //Loop over each treatment
                    foreach (Treatment treatmentRow in roomCategory.Value)
                    {
                        treatmentList.Add(treatmentRow.TreatmentName, treatmentRow.ToString());
                    }
                    convertedDict.Add(roomCategory.Key, treatmentList);
                }
                gSettings.treatmentCategories = convertedDict;
            }
        } //Room[N] -> List with Treatment Structs
        private Dictionary<String, List<String>> balancingCategoriesDict
        {
            get
            {
                if (gSettings.balancingCategories != null)
                {
                    return gSettings.balancingCategories;
                }
                else
                {
                    return new Dictionary<String, List<String>> { };
                }
            }
            set
            {
                gSettings.balancingCategories = value;
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
                    Console.WriteLine("ERROR: Settings.GetPatientTypes, patientTypeCategoriesDict does not contain key: " + categoryKey);
                }
                return filterdPatientTypeDict;

            }
            else
            {
                return patientTypeCategoriesDict;
            }
        }
        public Dictionary<String, List<Treatment>> GetTreatmentDictionary(String categoryKey = null)
        {
            if (categoryKey != null)
            {
                Dictionary<String, List<Treatment>> filterdTreatmentDict = new Dictionary<String, List<Treatment>> { };  // Room[N] -> List with Treatment Structs

                if (treatmentCategoriesDict.ContainsKey(categoryKey))
                {
                    filterdTreatmentDict.Add(categoryKey, treatmentCategoriesDict[categoryKey]);
                }
                else
                {
                    Console.WriteLine("ERROR: Settings.GetTreatmentDictionary, treatmentCategoriesDict does not contain key: " + categoryKey);
                }
                return filterdTreatmentDict;

            }
            else
            {
                return treatmentCategoriesDict;
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
                    Console.WriteLine("ERROR: Settings.GetBalancingCategories, balancingCategoriesDict does not contain key: " + categoryKey);
                }
                return filterdBalancingCategory;

            }
            else
            {
                return balancingCategoriesDict;
            }
        }

        public List<String> GetDifficultyModifierList(String categoryKey)
        {
            Dictionary<String, List<String>> balancingCategoriesDict = GetBalancingCategories(categoryKey);
            if (balancingCategoriesDict.ContainsKey(categoryKey))
            {
                return balancingCategoriesDict[categoryKey];
            }
            else
            {
                return new List < String >{ };
            }

        }
        public List<Treatment> GetTreatmentList(String categoryKey)
        {
            if (categoryKey != null)
            {
                Dictionary<String, List<Treatment>> treatmentDictionary = GetTreatmentDictionary(categoryKey);
                if (treatmentDictionary.ContainsKey(categoryKey))
                {
                    return treatmentDictionary[categoryKey];
                }
            }
            return new List<Treatment> { };

        }

        #endregion

        #region Setters

        public void SetPatientTypes(Dictionary<String, List<String>> patientTypeCategoriesDict)
        {
            this.patientTypeCategoriesDict = patientTypeCategoriesDict;
        }

        public void SetTreatmentCategories(Dictionary<String, List<Treatment>> treatmentDataDict)
        {
            this.treatmentCategoriesDict = treatmentDataDict;
            Dictionary<String, List<Treatment>> treatmentStoreDict = new Dictionary<String, List<Treatment>> { };

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
        public Dictionary<String, Dictionary<String, String>> treatmentCategories { get; set; }
        public Dictionary<String, List<String>> balancingCategories { get; set; }

        public GlobalSettings() { }
        public GlobalSettings(string fileName) : base(fileName) { }



    }


    public struct Treatment
    {
        public String TreatmentName;
        public Double DifficultyUnlocked;
        public int HeartsValue;
        public int Weight;
        public bool Gesture;
        public bool AlwaysLast;
        public Color ColorValue;

        public Treatment(String treatmentName = null, Double difficultyUnlocked = 0, int heartsValue = 0, int weight = 0, bool gesture = false, bool alwaysLast = false, Color color = new Color())
        {
            TreatmentName = treatmentName;
            DifficultyUnlocked = difficultyUnlocked;
            HeartsValue = heartsValue;
            Weight = weight;
            Gesture = gesture;
            AlwaysLast = alwaysLast;
            ColorValue = color;
        }

        #region Overloads
        public Treatment(DataGridViewRow dataRow)
        {
            DataGridViewCheckBoxCell cell = dataRow.Cells[0] as DataGridViewCheckBoxCell;

            //Get TreatmentName
            DataGridViewTextBoxCell tmpTreatmentName = dataRow.Cells[1] as DataGridViewTextBoxCell;
            if (tmpTreatmentName != null && tmpTreatmentName.Value != null)
            {
                TreatmentName = (String)tmpTreatmentName.Value;
            }
            else
            {
                TreatmentName = null;
            }

            //Get DifficultyUnlocked
            DataGridViewComboBoxCell tmpDifficultyUnlocked = dataRow.Cells[2] as DataGridViewComboBoxCell;
            if (tmpDifficultyUnlocked != null && tmpDifficultyUnlocked.Value != null)
            {
                DifficultyUnlocked = DataNameSpace.Globals.StringToDouble((String)tmpDifficultyUnlocked.Value);
            }
            else
            {
                DifficultyUnlocked = 0;
            }

            //Get HeartsValue
            DataGridViewTextBoxCell tmpHeartsValue = dataRow.Cells[3] as DataGridViewTextBoxCell;
            if (tmpHeartsValue != null && tmpHeartsValue.Value != null)
            {
                HeartsValue = int.Parse((String)tmpHeartsValue.Value);
            }
            else
            {
                HeartsValue = 0;
            }

            //Get Weight
            DataGridViewTextBoxCell tmpWeight = dataRow.Cells[4] as DataGridViewTextBoxCell;
            if (tmpWeight != null && tmpWeight.Value != null)
            {
                Weight = int.Parse((String)tmpWeight.Value);
            }
            else
            {
                Weight = 0;
            }

            //Get Gesture
            DataGridViewCheckBoxCell tmpGesture = dataRow.Cells[5] as DataGridViewCheckBoxCell;
            if (tmpGesture != null && tmpGesture.Value != null)
            {
                Gesture = (bool)tmpGesture.Value;
            }
            else
            {
                Gesture = false;
            }

            //Get AlwaysLast
            DataGridViewCheckBoxCell tmpAlwaysLast = dataRow.Cells[6] as DataGridViewCheckBoxCell;
            if (tmpAlwaysLast != null && tmpAlwaysLast.Value != null)
            {
                AlwaysLast = (bool)tmpAlwaysLast.Value;
            }
            else
            {
                AlwaysLast = false;
            }

            //Get Color
            DataGridViewTextBoxCell tmpColor = dataRow.Cells[7] as DataGridViewTextBoxCell;
            if (tmpColor != null && tmpColor.Value != null && false) //TODO Check for correct color to string conversion
            {
                ColorValue = (Color)tmpColor.Value;
            }
            else
            {
                ColorValue = new Color();
            }

        }

        public Treatment(String treatmentName, String treatmentDataString)
        {
            List<String> treatmentData = treatmentDataString.Split(',').ToList<String>();
            TreatmentName = treatmentName;
            DifficultyUnlocked = Convert.ToDouble(treatmentData[0]);
            HeartsValue = Convert.ToInt32(treatmentData[1]); 
            Weight = Convert.ToInt32(treatmentData[2]); 
            Gesture = Convert.ToBoolean(treatmentData[3]); 
            AlwaysLast = Convert.ToBoolean(treatmentData[4]); 
            ColorValue = Color.FromName(Convert.ToString(treatmentData[5])); 
        }
        #endregion


        public List<String> ToList(bool includeTreatmentName = false)
        {
            List<String> outputList = new List<String> { };
            if (includeTreatmentName)
            {
                outputList.Add(TreatmentName);
            }
            outputList.Add(DifficultyUnlocked.ToString());
            outputList.Add(HeartsValue.ToString());
            outputList.Add(Weight.ToString());
            outputList.Add(Gesture.ToString());
            outputList.Add(AlwaysLast.ToString());
            outputList.Add(ColorValue.ToString());
            return outputList;
        }

        public Dictionary<String, List<String>> ToDictionary()
        {
            Dictionary<String, List<String>> outputDict = new Dictionary<String, List<String>> { };
            outputDict.Add(TreatmentName, this.ToList());
            return outputDict;
        }

        public String ToString(bool includeTreatmentName = false)
        {
            return String.Join(",", ToList(includeTreatmentName));
        }

        public bool IsEmpty()
        {
            return TreatmentName == null || TreatmentName == "";
        }

        #region Operators
        public override bool Equals(Object obj)
        {
            return obj is Treatment && this == (Treatment)obj;
        }

        public override int GetHashCode()
        {
            var hashCode = 1917950600;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TreatmentName);
            hashCode = hashCode * -1521134295 + DifficultyUnlocked.GetHashCode();
            hashCode = hashCode * -1521134295 + HeartsValue.GetHashCode();
            hashCode = hashCode * -1521134295 + Weight.GetHashCode();
            hashCode = hashCode * -1521134295 + Gesture.GetHashCode();
            hashCode = hashCode * -1521134295 + AlwaysLast.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Color>.Default.GetHashCode(ColorValue);
            return hashCode;
        }

        public static bool operator ==(Treatment x, Treatment y)
        {
            return x == y && x == y;
        }
        public static bool operator !=(Treatment x, Treatment y)
        {
            return !(x == y);
        }
        #endregion
    }
}

