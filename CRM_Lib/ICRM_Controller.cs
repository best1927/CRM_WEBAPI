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

        GuResult<List<MGeneralType>> GetGdList(string lang, string GdList);
        GuResult<List<MLookupObj>> GetSubGdList(string MGdCode, string lang);

        List<MasErrorMessage> GetMessageList(string lang);


        #region "Activity"

        GuResult<List<CrmActivitiesTag>> GetTagList(string activity, string alias, string userid);
        #region "Find ActivitiesList"
        GuResult<MTimelineObjList> GetActivityByOwner(string ownercd, Int64 ownerid, string userid, Int64 curpage, string lang, string txtFilter , string activitiescd = "");

        GuResult<List<MCrmActivitiesLink>> GetActivityLinkByOwner(string ownercd, Int64 ownerid, Int64 curpage, string lang);
        #endregion
        #endregion

    }
}
