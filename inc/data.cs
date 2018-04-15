using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataNameSpace
{
    public class Data
    {
        private String[] levelList = new String[0];

        public Data()
        {

        }


        public String[] getLevelsFromDisk(bool reload = false)
        {
            if (levelList == null || levelList.Count() == 0 || reload)
            {
                String projectPath = "";
                levelList = System.IO.Directory.GetFiles(projectPath);
            }

            return levelList;
        }

    }
}
