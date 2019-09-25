using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParseReportResharperTest
{
    [TestClass]
    public class TestParseReportFromXml
    {
        [TestMethod]
        public void Check_Existence_Of_TextFile_When_ParseResharperErrorReport_Is_Run()
        {
            ParseReportResharper.Service1 parseErrorReport = new ParseReportResharper.Service1();
            parseErrorReport.ParseResharperErrorReport();
            if (File.Exists(@"C:\Users\320050487\Desktop\Reports\ToolErrorDuplicationReport.txt"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void Check_Existence_Of_TextFile_When_ParseResharperDuplicationReport_Is_Run()
        {
            ParseReportResharper.Service1 parseDuplicationReport = new ParseReportResharper.Service1();
            parseDuplicationReport.ParseResharperDuplicationReport();
            if (File.Exists(@"C:\Users\320050487\Desktop\Reports\ToolErrorDuplicationReport.txt"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void Check_ParseReport()
        {
            ParseReportResharper.Service1 parseDuplicationReport = new ParseReportResharper.Service1();
            string reponame = "PractiseApp";
            string actual = parseDuplicationReport.ParseReport(reponame);
            string expected = "161,11";
            Assert.AreEqual(expected, actual);
        }


    }
}
