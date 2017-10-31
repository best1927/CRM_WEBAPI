using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Summary description for RequestData
/// </summary>
namespace AuthModels
{
    [DataContract]
    public class RequestData
    {
        [DataMember]
        public string usname { get; set; }
        [DataMember]
        public string pwd { get; set; }
    }
}