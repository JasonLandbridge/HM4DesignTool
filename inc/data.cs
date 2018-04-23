using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SettingsNamespace;
using LevelData;
using Windows;

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
        public static windowMain windowMainObject;
        public static List<String> roomCategories = new List<String> { "Room 1", "Room 2", "Room 3", "Room 4", "Room 5", "Room 6" };

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

            return levelList;
        }

        public List<String> GetPatientTypesFromDisk(bool reload = false)
        {
            if (patientTypeList == null || patientTypeList.Count() == 0 || reload)
            {
                String projectPath = Globals.SettingsObject.projectPathImages + "patients\\";
                List<String> rawPatientTypeList = new List<String>(System.IO.Directory.GetDirectories(projectPath));
                List<String> rawPatientList = new List<String> { };

                foreach (String patientType in rawPatientTypeList)
                {
                    rawPatientList.Add(patientType.Replace(projectPath, ""));
                }

                patientTypeList = rawPatientList;

            }

            return patientTypeList;

        }

        public List<String> GetFilteredLevels(int roomIndex = 0, bool storyLevels = false, bool bonusLevels = false, bool unknownLevels = false)
        {
            List<String> rawLevelList = GetLevelsFromDisk(false, true);
            List<String> outputLevelList = new List<String> { }; 


            foreach(String level in rawLevelList)
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
                else if(unknownLevels)
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
}
