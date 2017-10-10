using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using Newtonsoft.Json;
using SessionFactory;
//using CRMMasLib;
using System.Web.Script.Serialization;
using System.Web.Services.Protocols;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Runtime.Serialization.Json;
using System.Configuration;
using GuProxyService;
using GuProxyService.Model;
using GuProxyServiceLib;
using CRMDtoLib.DTO;
using CRM_Lib;
using Authen_Lib;


[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class GenericService
{
     [OperationContract]
    [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "GET")]
    public String  DoWorkWithWebGet()
    {
         NameValueCollection nvc = HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query);
        String classWithNs = "";
        String methodName = "";
        String paramStr = "";
        DataHeader h = null;

        classWithNs = nvc["classWithNs"];
        methodName = nvc["methodName"];



        string v = WebRestService.InvokeBpWithQueryParam (h,classWithNs,methodName,paramStr,nvc);
        //String v = WebRestService.InvokeBp(h, classWithNs, methodName, paramStr);
        return v;
    }


      [OperationContract]
    [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/DoWork")]
    public String  DoWork(DataHeader h, String classWithNs, String methodName, string paramStr)
      {
          try
          {
              String v = WebRestService.InvokeBp(h, classWithNs, methodName, paramStr);
              GuProxyService.Model.mServiceProxy res = JsonConvert.DeserializeObject<GuProxyService.Model.mServiceProxy>(v);
              if (!string.IsNullOrEmpty(res.ErrorMessage))
              {
                  throw new Exception(res.ErrorMessage);
              }
              return v;
          }
          catch (Exception)
          {
              throw;
          }
      }


    [OperationContract]
    //[WebInvoke(Method = "POST" ,   RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    //  [WebInvoke(Method = "POST", UriTemplate = "TestMsg?Name={Name}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/TestMsg")]
    public String TestMsg(String Name)
    {
        Person person1 = new Person(Name, 6); 

        return JsonConvert.SerializeObject(person1); 
       
    }

  

    //[OperationContract]
    //  public String GetMySession()
    //  {
    //      try
    //      {
    //          string v = JsonConvert.SerializeObject(MySession.Current);
    //          return v;
    //      }
    //      catch (Exception)
    //      {
    //          throw;
    //      }
    //  }

     

}


public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    } 
}

