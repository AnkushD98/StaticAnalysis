using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDownloaderContract
{
    interface ICodeDownloader
    {
        void DownloadCode(string userName, string repositoryName);
        
    }
}
