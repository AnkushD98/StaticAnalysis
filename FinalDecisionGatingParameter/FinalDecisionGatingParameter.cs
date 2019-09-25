using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LogIssuesFileLib;

namespace FinalDecisionGatingParameter
{
    public class FinalDecisionGatingParameter
    {
        public bool MakeFinalDecisionAbsoluteParameter(int totalNumberOfIssues, int acceptedLevelErrors)
        {
            if (totalNumberOfIssues > acceptedLevelErrors)
                return false;
            return true;
        }
        public bool MakeFinalDecisionRelativeParameter(int totalNumberOfIssues,string repositoryName)
        {
            string Path = "C:" + "\\Users\\" + Environment.UserName +"\\Desktop\\ThresholdCheck\\";
            string solnName = "Threshold" + repositoryName;
            string filePath = Path + solnName + ".txt";
            PredefinedAcceptedLevelsAbsoluteGating.AcceptedLevels acceptedLevels = new PredefinedAcceptedLevelsAbsoluteGating.AcceptedLevels();
            LogIssuesFileLib.LogIssuesFile writeTheshold = new LogIssuesFileLib.LogIssuesFile();
            if (!File.Exists(filePath))
            {
                writeTheshold.WriteThresholdValueToFile(totalNumberOfIssues, repositoryName);
                if (totalNumberOfIssues > acceptedLevels.dictionaryLevels["Level5"])
                    return false;
                return true;

               

            }
            else
            {
                string linesThresholdFile = File.ReadAllText(filePath, Encoding.UTF8);
                int thresholdValue = Int32.Parse(linesThresholdFile.Substring(linesThresholdFile.IndexOf("=")+2));
                if (totalNumberOfIssues >= thresholdValue)
                    return false;
                writeTheshold.WriteThresholdValueToFile(totalNumberOfIssues, repositoryName);
                return true;

            }

            
        }
    }
}
