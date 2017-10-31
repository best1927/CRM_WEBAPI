using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
/// <summary>
/// Summary description for ResponseData
/// </summary>
/// 
namespace AuthModels
{
 
        [DataContract]
        public class ResponseData
        {
            [DataMember(Order = 0)]
            public string token { get; set; }
            [DataMember(Order = 1)]
            public bool authenticated { get; set; }
            [DataMember(Order = 2)]
            public string employeeId { get; set; }
            [DataMember(Order = 3)]
            public string firstname { get; set; }

            [DataMember(Order = 8)]
            public DateTime timestamp { get; set; }
            [DataMember(Order = 9)]
            public string userName { get; set; }
        
    }
}