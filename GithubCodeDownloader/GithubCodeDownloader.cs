using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeDownloaderContract;
namespace GithubCodeDownloader
{
    public class GithubCodeDownloader:ICodeDownloader
    {

        public void DownloadCode(string userName, string repositoryName)
        {
            string currentDirectory = "C:\\Users\\" + Environment.UserName + "\\Downloads";
            string stringCommandText = "/c git clone https://github.com/";
            stringCommandText += userName + "/";
            stringCommandText += repositoryName + ".git";
            System.Environment.CurrentDirectory = currentDirectory;
            System.Diagnostics.Process processToRunCommandPrompt = System.Diagnostics.Process.Start("CMD.exe", stringCommandText);
            processToRunCommandPrompt.WaitForExit();
            processToRunCommandPrompt.Close();
            


        }
    }
}
