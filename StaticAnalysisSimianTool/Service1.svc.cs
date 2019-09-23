using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace RunToolResharper
{
    public class Service1 : IService1, RunToolContract.IRunTool
    {
        public void RunResharperErrorTool(string repositoryName)
        {
            string currentDirectory = "C:\\Users\\320053936\\Downloads\\ReSharper";
            string stringCommandText = "/C inspectcode.exe C:\\Users\\320053936\\Downloads\\" + repositoryName + "\\" + repositoryName + "\\" + repositoryName + ".sln --output=PractiseAppReSharper.xml";
            System.Environment.CurrentDirectory = currentDirectory;
            System.Diagnostics.Process processToRunCommandPrompt = System.Diagnostics.Process.Start("CMD.exe", stringCommandText);
            processToRunCommandPrompt.WaitForExit();
            processToRunCommandPrompt.Close();
        }
        public void RunResharperDuplicationTool(string repositoryName)
        {
            string currentDirectory = "C:\\Users\\320053936\\Downloads\\ReSharper";
            string stringCommandText = "/C dupfinder.exe C:\\Users\\320053936\\Downloads\\" + repositoryName + "\\" + repositoryName + "\\" + repositoryName + ".sln --output=practiseappresharperdupfinder.xml"; 
            System.Environment.CurrentDirectory = currentDirectory;
            System.Diagnostics.Process processToRunCommandPrompt = System.Diagnostics.Process.Start("CMD.exe", stringCommandText);
            processToRunCommandPrompt.WaitForExit();
            processToRunCommandPrompt.Close();
            
        }

        public string RunTool(string repositoryName)
        {
            Thread runToolThread = new Thread(() => { RunResharperErrorTool(repositoryName);  RunResharperDuplicationTool(repositoryName); });
            runToolThread.Start();
            runToolThread.Join();
            return "Resharper error and duplication tools succcessfully run";

        }

       
    }
}
