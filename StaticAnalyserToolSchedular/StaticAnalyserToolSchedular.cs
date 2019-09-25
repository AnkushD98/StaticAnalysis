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
        private readonly RunToolContract.IRunTool _toolName;
        private readonly ParseReportContract.IParseReport _parseReport;
        public string TotalNumberOfIssues { get; set; }
        private readonly string _repositoryName;
        public StaticAnalyserToolSchedular(RunToolContract.IRunTool toolName,ParseReportContract.IParseReport parseReport, string repositoryName)
        {
                this._toolName = toolName;
                this._parseReport = parseReport;
                this._repositoryName = repositoryName;
            ScheduleTool();
        }
        public void ScheduleTool()
        {
            
             _toolName.RunTool(_repositoryName);
            TotalNumberOfIssues = _parseReport.ParseReport(_repositoryName);
        }
    }
}
