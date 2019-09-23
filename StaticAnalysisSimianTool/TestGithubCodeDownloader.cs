using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GithubCodeDownloader;
using System.IO;

namespace GitHubCodeDownloaderTest
{
    [TestClass]
    public class TestGithubCodeDownloader
    {
        [TestMethod]
        public void Check_The_Existance_Of_File_When_The_Function_Downloads_Code_From_Github()
        {
            GithubCodeDownloader.GithubCodeDownloader obj = new GithubCodeDownloader.GithubCodeDownloader();
            string user = "anirudhs08";
            string repository = "PractiseApp";
            string path = "C:\\Users\\320053936\\Downloads\\PractiseApp";


            string pathTest = path + "\\" + repository;
                
            obj.DownloadCode(user,repository);

            if (Directory.Exists(pathTest))
            {
                Assert.IsTrue(true);
                
            }
            else
            {
                Assert.IsTrue(false);
            } 
           
            

        }
    }
}
