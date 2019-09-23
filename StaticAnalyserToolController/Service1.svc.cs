using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using PredefinedAcceptedLevelsAbsoluteGating;
namespace StaticAnalyserToolController
{
    
    public class Service1 : IService1
    {
        public string StaticAnalyserToolControllerAbsolute(string userName, string repositoryName, string acceptanceLevel)
        {
            int numberOfLevelErrors, totalNumberOfIssues;
            bool toCheckValidity, GoOrNoGo;
            string totalNumberOfIssuesString;
            string[] issuesArray;
            PredefinedAcceptedLevelsAbsoluteGating.ValidityOfUserInput checkValidity = new PredefinedAcceptedLevelsAbsoluteGating.ValidityOfUserInput();
            toCheckValidity = checkValidity.CheckValidityOfUserInput(acceptanceLevel);
            if (!toCheckValidity)
                return "Invalid Acceptance Level.Acceptance Level is a string - Level1,Level2,..Level5";

            totalNumberOfIssuesString = StaticAnalyserToolController(userName,repositoryName);
           issuesArray = totalNumberOfIssuesString.Split(',');
           totalNumberOfIssues = Int32.Parse(issuesArray[0]) + Int32.Parse(issuesArray[1]);


            PredefinedAcceptedLevelsAbsoluteGating.AcceptedLevels acceptedLevels = new PredefinedAcceptedLevelsAbsoluteGating.AcceptedLevels();

            numberOfLevelErrors = acceptedLevels.dictionaryLevels[acceptanceLevel];

            FinalDecisionGatingParameter.FinalDecisionGatingParameter makeFinalDecision = new FinalDecisionGatingParameter.FinalDecisionGatingParameter();

           GoOrNoGo = makeFinalDecision.MakeFinalDecisionAbsoluteParameter(totalNumberOfIssues, numberOfLevelErrors);
            if (GoOrNoGo)
                return "Go";
            return "No Go";
            

        }

        public string StaticAnalyserToolControllerRelative(string userName, string repositoryName)
        {
            string[] issuesArray;
            bool GoOrNoGo;
            int totalNumberOfIssues;
            string totalNumberOfIssuesString = StaticAnalyserToolController(userName, repositoryName);
            FinalDecisionGatingParameter.FinalDecisionGatingParameter makeFinalDecision = new FinalDecisionGatingParameter.FinalDecisionGatingParameter();
            issuesArray = totalNumberOfIssuesString.Split(',');
            totalNumberOfIssues = Int32.Parse(issuesArray[0]) + Int32.Parse(issuesArray[1]);
            GoOrNoGo = makeFinalDecision.MakeFinalDecisionRelativeParameter(totalNumberOfIssues, repositoryName);
            if (GoOrNoGo)
                return "Go";
            return "No Go";
        }

        public string StaticAnalyserToolController(string userName, string repositoryName)
        {
            
                GithubCodeDownloader.GithubCodeDownloader githubDownload = new GithubCodeDownloader.GithubCodeDownloader();
                Thread thread = new Thread(() => { githubDownload.DownloadCode(userName, repositoryName); });
                thread.Start();
                thread.Join();
                StaticAnalyserToolSchedular.StaticAnalyserToolSchedular toolSchedular = new StaticAnalyserToolSchedular.StaticAnalyserToolSchedular(new RunToolResharper.Service1(),new ParseReportResharper.Service1(),repositoryName);
                return toolSchedular.totalNumberOfIssues;
            
            

        }
    }
}
