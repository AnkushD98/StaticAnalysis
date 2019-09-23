using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseReportContract
{
    public interface IParseReport
    {
        string ParseReport(string repositoryName);
    }
}
