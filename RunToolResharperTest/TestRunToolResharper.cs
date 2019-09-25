using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RunToolResharperTest
{
    [TestClass]
    public class TestRunToolResharper
    {
        [TestMethod]
        public void Check_Existence_Of_Report_When_ErrorTool_Is_Run()
        {
            RunToolResharper.Service1 resharperTool = new RunToolResharper.Service1();
            string repositoryName = "PractiseApp";
            resharperTool.RunResharperErrorTool(repositoryName);
            if(File.Exists(@"C:\Users\320050487\Downloads\ReSharper\PractiseAppReSharper.xml"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void Check_Existence_Of_Report_When_DuplicationTool_Is_Run()
        {
            RunToolResharper.Service1 resharperTool = new RunToolResharper.Service1();
            string repositoryName = "PractiseApp";
            resharperTool.RunResharperDuplicationTool(repositoryName);
            if (File.Exists(@"C:\Users\320050487\Downloads\ReSharper\practiseappresharperdupfinder.xml"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void Check_RunTool()
        {
            RunToolResharper.Service1 resharperTool = new RunToolResharper.Service1();
            string repositoryName = "PractiseApp";
            string actual = resharperTool.RunTool(repositoryName);
            string expected = "Resharper error and duplication tools succcessfully run";
            Assert.AreEqual(expected, actual);
        }


    }
}
