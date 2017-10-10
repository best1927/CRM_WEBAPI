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
using DatabaseFactoryManager.Interface;
using System.Configuration;
using DatabaseHelper;
using HelperWebLiteExt;
namespace CRM_Lib
{
    interface IOrganizations_Controller 
    {
        GuResult<String> SaveOrganization(MCrmOrganization  Obj, string user, string flag);

        GuResult<String> DeleteOrganization(MCrmOrganization Obj, string user, string flag);


        GuResult<MSearchOrganization> SearchOrganization(string Alphabetfilter, string Combofilter, string txtFilter, string userid, string lang, string local, string tagstr, Int64 curpage, Int64 maxRec);


       

    }
}
