using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIssuesFileLib
{
    
    public class LogIssuesFile
    {
       
        public void WriteIssuesToFile(string totalIssues,string repositoryName)
        {
            int totalNumberOfIssues, numberOfErrors, numberOfDuplicates;
            string[] issuesArray = totalIssues.Split(',');
            numberOfErrors = Int32.Parse(issuesArray[0]);
            numberOfDuplicates = Int32.Parse(issuesArray[1]);
            
                totalNumberOfIssues = numberOfErrors + numberOfDuplicates;
            string Path = "C:"+"\\Users\\" + Environment.UserName + "\\Desktop\\GatingMethod\\";
            string solnName = "History" + repositoryName;
            string filePath = Path +solnName+".txt" ;

            DateTime currentDateTime = DateTime.Now;
            File.AppendAllText(filePath, currentDateTime + Environment.NewLine +
                                         "Total Number Of Issues " + totalNumberOfIssues +
                                         Environment.NewLine + "Number Of Errors " + numberOfErrors +
                                         Environment.NewLine + "Number of Duplicates " + numberOfDuplicates +
                                         Environment.NewLine + Environment.NewLine);

        }
        public void WriteThresholdValueToFile(int thresholdValue,string repositoryName)
        {
            string Path = "C:" + "\\Users\\" + Environment.UserName + "\\Desktop\\ThresholdCheck\\";
            string solnName = "Threshold" + repositoryName;
            string filePath = Path + solnName + ".txt";
            File.WriteAllText(filePath, "Threshold Value is = " + thresholdValue);
        }
    }
}
