using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMDtoLib.DTO;
using CRMDtoLib.Model;
using SsCommon;
using GuCommon.Model;
using GuCommon.Model.Ext;

namespace CRM_Lib
{
    interface IContacts_Controller
    {
        GuResult<String> SaveContacts(MCrmContacts Obj, string user, string flag);

        GuResult<String> DeleteContacts(MCrmContacts Obj, string user, string flag); 

        GuResult<MSearchContacts > SearchContacts(string Alphabetfilter, string Combofilter, string txtFilter, string userid, string lang, string local, string tagstr, Int64 curpage, Int64 maxRec);


    }
}
