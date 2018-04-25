using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SettingsNamespace;
using LevelData;
using Windows;
using System.Windows.Forms;
using NaturalSort.Extension;

namespace DataNameSpace
{

    public enum LevelType
    {
        Unknown = 0,
        Story = 1,
        Bonus = 2,
        TimeTrial = 3,
        MiniGame = 4,
        OliverOne = 5,
        OliverAll = 6
    }

    public static class Globals
    {
        public static Settings SettingsObject = new Settings();
        public static Data DataObject = new Data();
        public static GameValues GameValue = new GameValues();

        public static windowMain windowMainObject;
        public static List<String> roomCategories = new List<String> { "Room 1", "Room 2", "Room 3", "Room 4", "Room 5", "Room 6" };

        public static Double StringToDouble(String difficultyModifier = null)
        {
            if (difficultyModifier != null)
            {
                return double.Parse(difficultyModifier, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                return 0;
            }
        }


    }

    public class Data
    {


        private List<String> levelList = new List<String> { };
        private List<String> patientTypeList = new List<String> { };


        Dictionary<string, Level> levelData = new Dictionary<string, Level>();

        public Data()
        {
        }


        public List<String> GetLevelsFromDisk(bool reload = false, bool filterExtension = false)
        {
            if (levelList == null || levelList.Count() == 0 || reload)
            {
                String projectPath = Globals.SettingsObject.projectPathLevel;
                if (Directory.Exists(projectPath))
                {

                    List<String> rawLevelList = new List<String>(System.IO.Directory.GetFiles(projectPath));
                    List<String> tmpLevelList = new List<String> { };

                    foreach (String level in rawLevelList)
                    {
                        String levelName = Path.GetFileName(level);
                        if (filterExtension)
                        {
                            tmpLevelList.Add(levelName.Replace(".lua", ""));
                        }
                        else
                        {
                            tmpLevelList.Add(levelName);
                        }


                    }

                    levelList = tmpLevelList;
                }
            }

            return levelList;
        }

        public List<String> GetPatientTypesFromDisk(bool reload = false)
        {
            if (patientTypeList == null || patientTypeList.Count() == 0 || reload)
            {
                String projectPath = Globals.SettingsObject.projectPathImages + "patients\\";

                if (System.IO.Directory.Exists(projectPath))
                {
                    List<String> rawPatientTypeList = new List<String>(System.IO.Directory.GetDirectories(projectPath));
                    List<String> rawPatientList = new List<String> { };

                    foreach (String patientType in rawPatientTypeList)
                    {
                        rawPatientList.Add(patientType.Replace(projectPath, ""));
                    }

                    patientTypeList = rawPatientList;
                }

            }

            return patientTypeList;

        }

        public List<String> GetFilteredLevels(int roomIndex = 0, bool storyLevels = false, bool bonusLevels = false, bool unknownLevels = false)
        {
            List<String> rawLevelList = GetLevelsFromDisk(false, true);
            List<String> outputLevelList = new List<String> { };


            foreach (String level in rawLevelList)
            {

                if (storyLevels && level.StartsWith("level"))
                {
                    int levelIndex = Convert.ToInt16(level.Replace("level", ""));
                    int minIndex = (roomIndex - 1) * 10 + 1;
                    int maxIndex = (roomIndex * 10) + 1;

                    if (roomIndex == 0)
                    {
                        outputLevelList.Add(level);
                    }
                    else if (Enumerable.Range(minIndex, 10).Contains(levelIndex))
                    {
                        outputLevelList.Add(level);
                    }
                }
                // Ensure that the second character in the level name is a number as well to be in line with naming conventions.
                else if (bonusLevels && level.StartsWith("r") && int.TryParse(level[1].ToString(), out int n))
                {
                    if (roomIndex == 0)
                    {
                        outputLevelList.Add(level);
                    }
                    else if (level.StartsWith("r" + roomIndex.ToString() + "_"))
                    {
                        outputLevelList.Add(level);
                    }
                }
                else if (unknownLevels)
                {
                    outputLevelList.Add(level);
                }


            }

            return outputLevelList;

            /*
                returnList = natsorted(returnList)
                return returnList

                */

        }

        public static String ReadLevelText(String levelName)
        {
            if (!levelName.EndsWith(".lua"))
            {
                levelName += ".lua";
            }

            String levelPath = Globals.SettingsObject.projectPathLevel + levelName;

            if (File.Exists(levelPath))
            {
                string readContents;
                using (StreamReader streamReader = new StreamReader(levelPath, Encoding.UTF8))
                {
                    readContents = streamReader.ReadToEnd();
                    return readContents;
                }

            }
            else
            {
                Console.WriteLine("ERROR: Data.ReadLevelText, Could not find " + levelPath + "!");
                return null;
            }

        }

        public Level GetLevelByName(String levelName)
        {
            if (levelName.EndsWith(".lua"))
            {
                levelName = levelName.Replace(".lua", "");
            }


            if (levelData.ContainsKey(levelName))
            {
                return levelData[levelName];
            }
            else
            {
                return AddLevelByName(levelName);
            }

        }

        private Level AddLevelByName(String levelName)
        {
            Level newLevel = new Level(levelName);
            if (levelData.ContainsKey(levelName))
            {
                levelData.Remove(levelName);
            }
            levelData.Add(levelName, newLevel);

            return newLevel;
        }
    }

    public class GameValues
    {
        // TODO Make sure to import the constant values from GSettings
        public int difficultyModifierTreatmentsBased = 11;
        public int startLevelDuration = 110000;
        public int timeIncreasePerLevel = 4500;

        public int initialTimeBetweenPatients = 11000;
        public int decreaseTimeBetweenPatients = 250;

        public int initialTimePerTreatment = 6000;
        public int decreaseTimePerTreatment = 250;
        public int checkoutPerPatient = 2000;
        public int treatmentMinimumTime = 1600;

        public GameValues()
        {

        }

        public Dictionary<String, Double> GetBalancingData(Double difficultyModifier)
        {
            Dictionary<String, Double> balancingData = new Dictionary<String, Double> { };

            if (difficultyModifier > 0.5)
            {
                balancingData.Add("averageEntryTimePerPatient", AverageEntryTimePerPatient(difficultyModifier));
                balancingData.Add("timeBetweenPatients", TimeBetweenPatients(difficultyModifier));
                balancingData.Add("numberOfPatients", NumberOfPatients(difficultyModifier));
                balancingData.Add("treatmentPerPatient", TreatmentPerPatient(difficultyModifier));
                balancingData.Add("timePerTreatment", TimePerTreatment(difficultyModifier));
                balancingData.Add("milliSecondsPerLevel", MilliSecondsPerLevel(difficultyModifier));
                balancingData.Add("minutesPerLevel", MinutesPerLevel(difficultyModifier));

                return balancingData;
            }
            else
            {
                return null;
            }

        }


        #region GameValues

        public Double TreatmentPerPatient(Double difficultyModifier)
        {
            if (Math.Round(difficultyModifier / difficultyModifierTreatmentsBased, 2) + 1 > 3.5)
            {
                return 3.5;
            }
            else
            {
                return Math.Round(difficultyModifier / difficultyModifierTreatmentsBased, 2) + 1;
            }
        }

        public Double TimePerTreatment(Double difficultyModifier)
        {
            Double x = initialTimePerTreatment - difficultyModifier * decreaseTimePerTreatment;

            if (x < treatmentMinimumTime)
            {
                return treatmentMinimumTime;
            }
            else
            {
                return x;
            }
        }

        public Double MilliSecondsPerLevel(Double difficultyModifier)
        {
            Double x = startLevelDuration + difficultyModifier * timeIncreasePerLevel;

            if (x > 400000)
            {
                return 400000;
            }
            else
            {
                return x;
            }
        }

        public Double MinutesPerLevel(Double difficultyModifier)
        {
            return MilliSecondsPerLevel(difficultyModifier) / 60000;

        }

        public Double TimeBetweenPatients(Double difficultyModifier)
        {
            return initialTimeBetweenPatients - difficultyModifier * decreaseTimeBetweenPatients;
        }

        public Double AverageEntryTimePerPatient(Double difficultyModifier)
        {
            Double x = TreatmentPerPatient(difficultyModifier) * TimePerTreatment(difficultyModifier);
            x += TimeBetweenPatients(difficultyModifier);
            x += checkoutPerPatient;

            return x;
        }

        public Double NumberOfPatients(Double difficultyModifier)
        {
            Double x = MilliSecondsPerLevel(difficultyModifier) / AverageEntryTimePerPatient(difficultyModifier);
            return Math.Ceiling(x); //TODO Check if similair to math.ceil in python
        }
        #endregion

        #region Overloads
        public Dictionary<String, Double> GetBalancingData(String difficultyModifier)
        {
            return GetBalancingData(Globals.StringToDouble(difficultyModifier));
        }
        public Double TreatmentPerPatient(String difficultyModifier)
        {
            return TreatmentPerPatient(Globals.StringToDouble(difficultyModifier));
        }
        public Double TimePerTreatment(String difficultyModifier)
        {
            return TimePerTreatment(Globals.StringToDouble(difficultyModifier));
        }
        public Double MilliSecondsPerLevel(String difficultyModifier)
        {
            return MilliSecondsPerLevel(Globals.StringToDouble(difficultyModifier));
        }
        public Double MinutesPerLevel(String difficultyModifier)
        {
            return MinutesPerLevel(Globals.StringToDouble(difficultyModifier));
        }
        public Double TimeBetweenPatients(String difficultyModifier)
        {
            return TimeBetweenPatients(Globals.StringToDouble(difficultyModifier));
        }
        public Double AverageEntryTimePerPatient(String difficultyModifier)
        {
            return AverageEntryTimePerPatient(Globals.StringToDouble(difficultyModifier));
        }
        public Double NumberOfPatients(String difficultyModifier)
        {
            return NumberOfPatients(Globals.StringToDouble(difficultyModifier));
        }

        #endregion




    }

}

