using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogIssuesFileTest
{
    [TestClass]
    public class LogIssuesFileTest
    {
        [TestMethod]
        public void Check_Existence_Of_IssuesFile()
        {
            string repositoryName = "PractiseApp";
            LogIssuesFileLib.LogIssuesFile logIssuesFile = new LogIssuesFileLib.LogIssuesFile();
            string totalIssues = "162,11";
            logIssuesFile.WriteIssuesToFile(totalIssues, repositoryName);
            string Path = "C:\\Users\\320050487\\Desktop\\GatingMethod\\";
            string solnName = "History" + repositoryName;
            string filePath = Path + solnName + ".txt";
            if (File.Exists(filePath))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);

            

        }
        [TestMethod]
        public void Check_Existence_Of_ThresholdValueFile()
        {
            string repositoryName = "PractiseApp";
            LogIssuesFileLib.LogIssuesFile logIssuesFile = new LogIssuesFileLib.LogIssuesFile();
            int thresholdValue = 173;
            logIssuesFile.WriteThresholdValueToFile(thresholdValue, repositoryName);
            string Path = "C:\\Users\\320050487\\Desktop\\ThresholdCheck\\";
            string solnName = "Threshold" + repositoryName;
            string filePath = Path + solnName + ".txt";
            if (File.Exists(filePath))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);

        }
    }
}
