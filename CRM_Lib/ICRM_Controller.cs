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
    interface ICRM_Controller
    {
        GuResult<String> TestMessage(String Name);

        string GetVisibilityString(string alis, string userid);


        System.DateTime convertDate(string txtDate, string DateFormat);

        string convertDatetostring(System.DateTime pDate, string DateFormat);

        GuResult<List<MGeneralType>> GetGdList(String GdList);

        List<MasErrorMessage> GetMessageList(string lang);


        #region "Activity"

        GuResult<List<CrmActivitiesTag>> GetTagList(string activity, string alias, string userid);


        #endregion

    }
}
