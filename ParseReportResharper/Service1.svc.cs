using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace ParseReportResharper
{
    public class Service1 : IService1,ParseReportContract.IParseReport
    {
      
        public int ParseResharperErrorReport()
        {
            int totalNumberOfIssues = 0;
            FileStream fileStream;
            StreamWriter streamWriter;
            TextWriter textWriter = Console.Out;
            fileStream = new FileStream("C:" + "\\Users\\" + Environment.UserName + @"\Desktop\Reports\ToolErrorDuplicationReport.txt", FileMode.OpenOrCreate, FileAccess.Write);
            streamWriter = new StreamWriter(fileStream);
            Console.SetOut(streamWriter);
            
            XDocument Root = XDocument.Load("C:" + "\\Users\\" + Environment.UserName +@"\Downloads\ReSharper\PractiseAppReSharper.xml");

            Console.WriteLine("************************ReSharper Report*********************************");
            Console.WriteLine("ERROR REPORT");
            foreach (XElement childNode in Root.Descendants("Report"))
            {
                foreach (XElement categoryNode in childNode.Descendants("Issues"))
                {

                    foreach (XElement project in categoryNode.Descendants("Project"))
                    {
                        int numberOfIssues = 0;
                        int counter2 = 1;
                        foreach (XElement issue in project.Descendants("Issue"))
                        {


                            Console.WriteLine(counter2 + ".  " + issue.Attribute("File"));
                            Console.WriteLine(issue.Attribute("Line"));
                            Console.WriteLine(issue.Attribute("Message"));
                            counter2 = counter2 + 1;
                            Console.WriteLine("\n\n");
                            numberOfIssues = numberOfIssues + 1;
                        }
                        totalNumberOfIssues = totalNumberOfIssues + numberOfIssues;
                        
                    }
                }
            }
            Console.WriteLine("Total number of issues:" + totalNumberOfIssues);

            Console.SetOut(textWriter);
            streamWriter.Close();
            fileStream.Close();
            Console.WriteLine("ReSharper Output printed to text file successfully");
            
            return totalNumberOfIssues;
        }
        public int ParseResharperDuplicationReport()
        {
            int totalNumberOfDuplicates = 0;
            FileStream fileStream;
            StreamWriter streamWriter;
            TextWriter textWriter = Console.Out;
            fileStream = new FileStream("C:" + "\\Users\\" + Environment.UserName +@"\Desktop\Reports\ToolErrorDuplicationReport.txt",
                FileMode.OpenOrCreate, FileAccess.Write);
            streamWriter = new StreamWriter(fileStream);
            Console.SetOut(streamWriter);
            
            XDocument RootDuplicates = XDocument.Load("C:" + "\\Users\\" + Environment.UserName +@"\Downloads\ReSharper\PractiseAppReSharperDupFinder.xml");
            int countDuplicates = 0;
            int numberOfIssuesDuplicate = 0;
            Console.WriteLine("DUPLICATION REPORT");
            foreach (XElement childNode in RootDuplicates.Descendants("DuplicatesReport"))
            {
                foreach (XElement duplicateNode in childNode.Descendants("Duplicates"))
                {
                    foreach (XElement duplicate in duplicateNode.Descendants("Fragment"))
                    {
                        foreach (XElement lineRange in duplicate.Descendants("LineRange"))
                        {
                            countDuplicates = countDuplicates + 1;
                            Console.WriteLine(countDuplicates + ".DuplicateCode");
                            Console.Write("StartLine:" + lineRange.Attribute("Start").Value + " ----");
                            Console.Write("EndLine" + lineRange.Attribute("End").Value);
                            Console.WriteLine("\n");
                            numberOfIssuesDuplicate = numberOfIssuesDuplicate + 1;

                        }

                    }
                }
                totalNumberOfDuplicates = totalNumberOfDuplicates + numberOfIssuesDuplicate;
            }

            Console.WriteLine("Total number of duplicates:"+totalNumberOfDuplicates);
            Console.SetOut(textWriter);
            streamWriter.Close();
            fileStream.Close();
            Console.WriteLine("ReSharper Output printed to text file successfully");
            
            
            return totalNumberOfDuplicates;

        }
        public string ParseReport(string repositoryName)
        {
            var fileStream = new FileStream("C:" + "\\Users\\" + Environment.UserName +@"\Desktop\Reports\ToolErrorDuplicationReport.txt"
                , FileMode.OpenOrCreate, FileAccess.Write);
            fileStream.SetLength(0);
            fileStream.Close();
            int totalNumberOfErrors = 0;
            int totalNumberOfDuplicates = 0;
            totalNumberOfErrors = ParseResharperErrorReport();
                totalNumberOfDuplicates = ParseResharperDuplicationReport(); 
            string totalNumberOfIssues = totalNumberOfErrors + "," + totalNumberOfDuplicates;
            LogIssuesFileLib.LogIssuesFile logIssuesFile = new LogIssuesFileLib.LogIssuesFile();
            logIssuesFile.WriteIssuesToFile(totalNumberOfIssues,repositoryName);
            
            return totalNumberOfIssues;
        }
    }
}
