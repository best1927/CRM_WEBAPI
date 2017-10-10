using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class HelperService
{
	// To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
	// To create an operation that returns XML,
	//     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
	//     and include the following line in the operation body:
	//         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
	[OperationContract]
	public void DoWork()
	{
		// Add your operation implementation here
		return;
	}
    [OperationContract()]
    public string GetDateFormat()
    {
        // Add your operation implementation here
       var res  = ConfigurationManager.AppSettings["DisplayDateFormat"].ToString();
        if (SessionFactory.MySession.Current.MyLanuageName == "THA")
        { res = res.Replace("Y", "B"); 
        }
     
        return res;
    } 
   

    [OperationContract()]
    public string GetDateTimeFormat()
    {
        // Add your operation implementation here

        var res = ConfigurationManager.AppSettings["DisplayDateTimeFormat"].ToString();
        if (SessionFactory.MySession.Current.MyLanuageName == "THA")
        {
            res = res.Replace("Y", "B");
        }
        return res;
    }

	// Add more operations here and mark them with [OperationContract]

    [OperationContract()]
    public int GetDefautRowDataGrid()
    {
        int ret = 10; 
        // Add your operation implementation here
        var str = ConfigurationManager.AppSettings["DefaultGridRow"].ToString();
        if (str !=null || !string.IsNullOrEmpty(str)) {
            ret = Int32.Parse(str);
        } 
        return ret;
    }


}
