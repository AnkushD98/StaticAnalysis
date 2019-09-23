using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StaticAnalyserToolController
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/StaticAnalyserTool/Absolute/{userName}/{repositoryName}/{acceptanceLevel}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string StaticAnalyserToolControllerAbsolute(string userName,string repositoryName, string acceptanceLevel);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/StaticAnalyserTool/Relative/{userName}/{repositoryName}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string StaticAnalyserToolControllerRelative(string userName, string repositoryName);

        
    }


    
    
}
