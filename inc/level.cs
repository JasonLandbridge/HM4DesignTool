using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataNameSpace;
using NLua;

namespace LevelData
{

    struct DesignToolData
    {
        public float DifficultyLevel;
        public LevelType levelType;

        private const String startDesignToolDataText = "--[[HM4DesignToolData:";
        private const String DifficultyLevelText = "DifficultyLevel:";
        private const String LevelTypeText = "LevelType:";
        private const String endDesignToolDataText = "--]]";


        public DesignToolData(float difficultyLevel = 0, LevelType levelType = LevelType.Unknown)
        {
            this.DifficultyLevel = difficultyLevel;
            this.levelType = levelType;
        }

        public void ParseDesignData(String designToolData)
        {
            designToolData = designToolData.Replace("\t", "").Replace("\r", "").Replace(" ", "");
            designToolData.Replace(startDesignToolDataText, "").Replace(endDesignToolDataText, "");
            String[] delimiter = { "\n" };
            List<String> designToolList = designToolData.Split(delimiter, StringSplitOptions.None).ToList<String>();

            foreach(String entry in designToolList)
            {
                String textItem = entry;
                if (textItem.Contains(DifficultyLevelText))
                {
                    textItem = textItem.Replace(DifficultyLevelText, "");
                    DifficultyLevel = (float) Convert.ToDouble(textItem);
                }
                if (textItem.Contains(LevelTypeText))
                {
                    textItem = textItem.Replace(LevelTypeText, "");
                    switch (textItem)
                    {
                        case "Bonus":
                            levelType = LevelType.Bonus;
                            break;
                        case "Story":
                            levelType = LevelType.Story;
                            break;
                        case "MiniGame":
                            levelType = LevelType.MiniGame;
                            break;
                        case "TimeTrial":
                            levelType = LevelType.TimeTrial;
                            break;
                        case "Oliver":
                            levelType = LevelType.OliverOne;
                            break;
                        case "OliverOne":
                            levelType = LevelType.OliverOne;
                            break;
                        case "OliverAll":
                            levelType = LevelType.OliverAll;
                            break;
                        default:
                            levelType = LevelType.Unknown;
                            break;
                    }
                }

            }



        }

        public override string ToString()
        {
            String output = startDesignToolDataText + Environment.NewLine;

            if (DifficultyLevel > 0)
            {
                output += DifficultyLevelText + " \t" + DifficultyLevel.ToString() + Environment.NewLine;
            }

            if (levelType > 0)
            {
                output += LevelTypeText + " \t" + levelType.ToString() + Environment.NewLine;
            }

            output += endDesignToolDataText + Environment.NewLine;
            return output;
        }
    }

    public class Level
    {
        String LevelName = null;

        private Dictionary<int, Patient> patientDatabase = new Dictionary<int, Patient>();
        private Dictionary<String, float> patientChancesDict = new Dictionary<String, float>();
        private DesignToolData designToolData = new DesignToolData();

        public Level()
        {


        }

        public Level(string levelName)
        {
            LevelName = levelName;
            ParseRawText(levelName);

        }

        public String GetCurrentLevelScript()
        {
            return Data.ReadLevelText(LevelName);

        }

        public String GetLevelScript()
        {
            string output = "";

            output += designToolData.ToString();
            output += Environment.NewLine;
            //Output the patient chances
            if (patientChancesDict.Count > 0)
            {
                output += "levelDesc.patientChances = " + Environment.NewLine;
                output += "{" + Environment.NewLine;
                int i = 0;
                foreach (KeyValuePair<string, float> patientChance in patientChancesDict)
                {
                    output += "\t" + patientChance.Key + " \t= \t" + patientChance.Value;
                    if (i < patientChancesDict.Count - 1)
                    {
                        output += ","; 
                    }
                    i++;
                    output += Environment.NewLine;

                }
                output += "}" + Environment.NewLine;
            }
            output += Environment.NewLine;
            //Output the patient treatments
            if (patientDatabase.Count() > 0)
            {
                output += "levelDesc.triggers = " + Environment.NewLine;
                output += "{" + Environment.NewLine;
                foreach (Patient patient in patientDatabase.Values)
                {
                    output += patient.ToString();
                }
                output += "}" + Environment.NewLine;

            }
            return output;
        }

        private void AddPatient(String patientData, int index = -1)
        {
            if (index == -1)
            {
                index = patientDatabase.Count();
            }
            Patient patientObject = new Patient(patientData);
            if (patientDatabase.ContainsKey(index))
            {
                patientDatabase.Remove(index);
            }
            patientDatabase.Add(index, patientObject);
        }

        private void ParseRawText(String levelName)
        {
            String rawLevelText = GetCurrentLevelScript();
            // Clean up the text by removing tabs, enters and spaces and special characters.
            rawLevelText = rawLevelText.Replace("\t", "").Replace("\r", "").Replace("{\n", "{").Replace(" ", "").Replace("\n\n", "");



            // Parse DesignToolData embeded in file.
            String startDesignToolData = "--[[HM4DesignToolData:";
            String endDesignToolData = "--]]";
            String designToolDataText;
            if (rawLevelText.Contains(startDesignToolData) && rawLevelText.Contains(endDesignToolData))
            {
                int startDesignToolDataIndex = rawLevelText.IndexOf(startDesignToolData);
                int endDesignToolDataIndex = rawLevelText.IndexOf(endDesignToolData) + endDesignToolData.Length;

                if (startDesignToolDataIndex > -1 && endDesignToolDataIndex - endDesignToolData.Length > -1 && startDesignToolDataIndex < endDesignToolDataIndex)
                {
                    designToolDataText = rawLevelText.Substring(startDesignToolDataIndex, endDesignToolDataIndex - startDesignToolDataIndex);
                    designToolData.ParseDesignData(designToolDataText);
                    rawLevelText = rawLevelText.Replace(designToolDataText, "");

                }

            }

            // Parse the PatientChances section.
            String startPatientChancesText = "levelDesc.patientChances=";
            String endPatientChancesText = "}";
            String patientsChancesRawText;
            if (rawLevelText.Contains(startPatientChancesText) && rawLevelText.Contains(endPatientChancesText))
            {
                int startPatientChancesIndex = rawLevelText.IndexOf(startPatientChancesText);
                int endPatientChancesIndex = rawLevelText.IndexOf(endPatientChancesText) + endPatientChancesText.Length;

                if (startPatientChancesIndex > -1 && endPatientChancesIndex - endPatientChancesText.Length > -1 && startPatientChancesIndex < endPatientChancesIndex)
                {
                    // Do some extra formatting and cleaning up.
                    patientsChancesRawText = rawLevelText.Substring(startPatientChancesIndex, endPatientChancesIndex - startPatientChancesIndex);
                    rawLevelText = rawLevelText.Remove(startPatientChancesIndex, endPatientChancesIndex);

                    patientsChancesRawText = patientsChancesRawText.Replace("levelDesc.patientChances=", "").Replace(",}", "}");
                    patientsChancesRawText = patientsChancesRawText.Trim(' ').Replace("=", ":");

                    patientChancesDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<String, float>>(patientsChancesRawText);
                }


            }

            // Parse the PatientList with treatments
            String startPatientTriggerText = "levelDesc.triggers=";
            String endPatientTriggerText = "},\n}";
            String patientsTriggersRawText;
            if (rawLevelText.Contains(startPatientTriggerText) && rawLevelText.Contains(endPatientTriggerText))
            {
                int startPatientTriggerIndex = rawLevelText.IndexOf(startPatientTriggerText);
                int endPatientTriggerIndex = rawLevelText.IndexOf(endPatientTriggerText) + endPatientTriggerText.Length;

                if (startPatientTriggerIndex > -1 && endPatientTriggerIndex - endPatientChancesText.Length > -1 && startPatientTriggerIndex < endPatientTriggerIndex)
                {

                    patientsTriggersRawText = rawLevelText.Substring(startPatientTriggerIndex, endPatientTriggerIndex - startPatientTriggerIndex);
                    rawLevelText = rawLevelText.Remove(startPatientTriggerIndex, endPatientTriggerIndex);

                    patientsTriggersRawText = patientsTriggersRawText.Replace(startPatientTriggerText + "\n{", "").TrimEnd('}');

                    String[] delimiter = { "},\n" };
                    List<String> patientTriggers = patientsTriggersRawText.Split(delimiter, StringSplitOptions.None).ToList<String>();

                    foreach (String patientTrigger in patientTriggers)
                    {
                        AddPatient(patientTrigger);
                    }

                }
            }

            // Isolate any previous comments at the start of the text
            String startComments;
            if (rawLevelText.Contains(startDesignToolData))
            {
                int startDesignToolDataIndex = rawLevelText.IndexOf(startPatientChancesText);
                if (startDesignToolDataIndex > 0)
                {
                    startComments = rawLevelText.Substring(0, startDesignToolDataIndex);
                }
            }
            else if (rawLevelText.Contains(startDesignToolData))
            {
                int startPatientChancesIndex = rawLevelText.IndexOf(startPatientChancesText);
                if (startPatientChancesIndex > 0)
                {
                    startComments = rawLevelText.Substring(0, startPatientChancesIndex);
                }
            }
            else if (rawLevelText.Contains(startPatientTriggerText))
            {
                int startPatientTriggerIndex = rawLevelText.IndexOf(startPatientTriggerText);
                if (startPatientTriggerIndex > 0)
                {
                    startComments = rawLevelText.Substring(0, startPatientTriggerIndex);

                }

            }


        }
    }

    public class Patient
    {
        private int delay = -1;
        private int weight = -1;
        private List<String> treatmentList;
        private Dictionary<String, String> patientTraits;
        private bool weightEnabled = false;


        public Patient()
        {


        }

        public Patient(String patientData)
        {
            ParsePatientData(patientData);
        }

        public override string ToString()
        {
            String output = "";
            output += "\t{";

            if (delay > -1)
            {
                output += " delay = " + delay.ToString() + ",";
            }
            if (weightEnabled && weight > -1)
            {
                output += " weight = " + weight.ToString() + ",";
            }

            if (treatmentList != null && treatmentList.Count() > 0)
            {
                output += " todo = {";
                foreach (String treatment in treatmentList)
                {
                    output += "\"" + treatment + "\",";
                }
                output += "}," + Environment.NewLine;
            }

            if (patientTraits != null && patientTraits.Count() > 0)
            {
                foreach (KeyValuePair<string, string> trait in patientTraits)
                {
                    output += trait.Key + " = ";
                    if (trait.Value == "true")
                    {
                        output += trait.Value;
                    }
                    else
                    {
                        output += "\"" + trait.Value + "\"";
                    }
                }

            }

            return output;
        }

        private void ParsePatientData(String patientData)
        {
            // Clean up the patientData
            patientData = System.Text.RegularExpressions.Regex.Replace(patientData, @"\s+", "");
            //Parse the delay
            String delayText = "{delay=";
            if (patientData.Contains(delayText))
            {
                int startIndex = patientData.IndexOf(delayText) + delayText.Length;
                int endIndex = patientData.IndexOf(",");
                if (startIndex > -1 && endIndex > -1)
                {
                    String delayString = patientData.Substring(startIndex, endIndex - startIndex);
                    if (delayString != "None")
                    {
                        delay = Convert.ToInt32(delayString);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Level.ParsePatientData, delayString was none!");
                    }
                    patientData = patientData.Remove(startIndex - delayText.Length, endIndex);

                }
            }
            //Parse the weight
            String weightText = "weight=";
            if (patientData.Contains(weightText))
            {
                int startIndex = patientData.IndexOf(weightText) + weightText.Length;
                int endIndex = patientData.IndexOf(",");
                if (startIndex > -1 && endIndex > -1)
                {
                    weight = Convert.ToInt32(patientData.Substring(startIndex, endIndex-startIndex));
                    patientData = patientData.Remove(startIndex - weightText.Length, endIndex);
                    weightEnabled = true;
                }
            }
            //Parse the treatment list
            String treatmentText = "todo={";
            if (patientData.Contains(treatmentText))
            {
                int startIndex = patientData.IndexOf(treatmentText) + treatmentText.Length;
                int endIndex = patientData.IndexOf('}');
                if (startIndex > -1 && endIndex > -1)
                {
                    String rawTreatments = patientData.Substring(startIndex, endIndex - startIndex);
                    rawTreatments = rawTreatments.Replace("\"", "");
                    treatmentList = rawTreatments.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList<String>();
                    patientData = patientData.Remove(startIndex - treatmentText.Length, endIndex);

                }
            }
            // If there is remaining data then it is probably traits that have been added. 
            if (patientData.Length > 5)
            {
                patientTraits = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<String, String>>(patientData);
            }
        }

    }
}
