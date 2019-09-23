using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StaticAnalyserToolSchedular
{
    public class StaticAnalyserToolSchedular
    {
        private RunToolContract.IRunTool _toolName;
        private ParseReportContract.IParseReport _parseReport;
        public string totalNumberOfIssues;
        private string _repositoryName;
        public StaticAnalyserToolSchedular(RunToolContract.IRunTool toolName,ParseReportContract.IParseReport parseReport, string repositoryName)
        {
                this._toolName = toolName;
                this._parseReport = parseReport;
                this._repositoryName = repositoryName;
            ScheduleTool();
        }
        public void ScheduleTool()
        {
            
            Thread scheduleTool = new Thread(() => { _toolName.RunTool(_repositoryName); totalNumberOfIssues = _parseReport.ParseReport(_repositoryName); });
            scheduleTool.Start();
            scheduleTool.Join();
        }
    }
}
