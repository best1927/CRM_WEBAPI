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


using AuthModels;
using Jose;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class AuthService
{
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

    [OperationContract] //service contract  
    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)] //Post Method for gtting data according to the parameter  
    public ResponseData Login(RequestData data) //Response class for retriving data  
    {
        //'GetUser'
      //  Authen_Lib.AuthenController ctrl = new AuthenController();
        ////Authenticate User 
    //   var User=  ctrl.GetUserByPrimaryKey(data.usname);


       var secureToken = JWTutil.GetJwt(data.usname, data.pwd);
        var response = new ResponseData
        {
            token = secureToken,
            authenticated = true,
            employeeId = "testEmp1"  ,
            firstname = "TestName",
            timestamp = DateTime.Now,
            userName = data.usname 
        };

        return response;
    }


    [OperationContract] //service contract  
    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)] //Post Method for gtting data according to the parameter  
    public string Authorize() //Response class for retriving data  
    {
        //'GetUser'
        //  Authen_Lib.AuthenController ctrl = new AuthenController();
        ////Authenticate User 
        //   var User=  ctrl.GetUserByPrimaryKey(data.usname);



        return "pass";
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
    #region "Private"

    #endregion

}


