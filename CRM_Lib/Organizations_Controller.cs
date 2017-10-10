using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using Newtonsoft;
using Newtonsoft.Json;
using GuCommon.Model;
using GuCommon.Model.Ext;
using DatabaseHelper;
using HelperWebLiteExt;
using System.DirectoryServices;
using CRMDtoLib.DTO;
using CRMDtoLib.Model;
using DatabaseFactoryManager.Interface;

namespace CRM_Lib
{
    class Organizations_Controller : IOrganizations_Controller
    {


        public GuResult<string> DeleteOrganization(MCrmOrganization Obj, string user, string flag)
        {
            throw new NotImplementedException();
        }

        public GuResult<string> SaveOrganization(MCrmOrganization Obj, string user, string flag)
        {
            throw new NotImplementedException();
        }

        public GuResult<MSearchOrganization> SearchOrganization(string Alphabetfilter, string Combofilter, string txtFilter, string userid, string lang, string local, string tagstr, Int64 curpage, Int64 maxRec)
        {
            GuResult<MSearchOrganization> ret = new GuResult<MSearchOrganization>();
            ret.result = new MSearchOrganization();
            ret.result.MOrganizationList = new List<MOrganization>();
            ret.result.TagList = new List<CrmActivitiesTag>();
            IDbSimplyTransaction trn = null;
            CRM_Controller crmlib = new CRM_Controller();
            string VisibleStr = crmlib.GetVisibilityString("O", userid);

            //   decimal cnt = 0;

            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LANG", lang);
            paramList.Add("LOCAL", local);
            string strfilter = GetStringFilter(Alphabetfilter, Combofilter, txtFilter, tagstr,ref paramList);

            string sqlstr = "SELECT * FROM (SELECT ORGANIZE_ID, CASE WHEN :LANG <> :LOCAL THEN NVL(DESCR_OTH,DESCR_LOC) ELSE DESCR_OTH END AS ORGANIZE_NAME, ADDRESS || ( CASE WHEN SUBDISTRICT IS NOT NULL THEN ' ' || SUBDISTRICT ELSE '' END) || ( CASE WHEN DISTRICT IS NOT NULL THEN ' ' || DISTRICT ELSE '' END) || ( CASE WHEN CITY IS NOT NULL THEN ' ' || CASE WHEN :LANG <> :LOCAL THEN NVL(CI.DESC2,CI.DESC1) ELSE CI.DESC1 END ELSE '' END) || ( CASE WHEN STATE IS NOT NULL THEN ' ' || CASE WHEN :LANG <> :LOCAL THEN NVL(PO.DESC2,PO.DESC1) ELSE PO.DESC1 END ELSE '' END) || ( CASE WHEN COUNTRY IS NOT NULL THEN ' ' || CASE WHEN :LANG <> :LOCAL THEN NVL(CO.DESC2,CO.DESC1) ELSE CO.DESC1 END ELSE '' END) || ( CASE WHEN POSTALCODE IS NOT NULL THEN ' ' || POSTALCODE ELSE '' END) AS FULL_ADDRESS, ORGANIZE_URL, PHONE_HOME, PHONE_MOBILE, PHONE_OFFICE, CASE WHEN PHONE_FAX IS NOT NULL THEN 'Fax.' || PHONE_FAX ELSE '' END AS PHONE_FAX, CREATEUSER, CREATEDATE FROM CRM_ORGANIZATION O LEFT OUTER JOIN GENERAL_DESC CI ON CI.GDTYPE = 'CITY' AND O.CITY   = CI.GDCODE LEFT OUTER JOIN GENERAL_DESC PO ON PO.GDTYPE = 'STATE' AND O.STATE  = PO.GDCODE LEFT OUTER JOIN GENERAL_DESC CO ON CO.GDTYPE  = 'COTRY' AND O.COUNTRY = CO.GDCODE WHERE {0}  ORDER BY DESCR_LOC, DESCR_OTH, ADDRESS) M WHERE 1= 1 {1} ";

            string sqlcntstr = String.Format("SELECT COUNT(*) FROM ( {0} )", string.Format(sqlstr, VisibleStr, strfilter));
            string sqlSearchstr = string.Format(sqlstr, VisibleStr, strfilter) + " ORDER BY ORGANIZE_NAME ";
            string sqlTags = string.Format("SELECT O.TAG_ID ,O.A_ID ,O.ACTIVITY_CAT ,O.ACTIVITY_ID ,O.TAG_LABEL ,O.VISIBILE_TYPE ,O.VISIBILE_CD FROM CRM_ACTIVITIES_TAG O WHERE {0} AND ACTIVITY_CAT = 'ACCATORG' ", VisibleStr);

            try
            {
                ret.result.totalRec = (int)crmlib.ExecuteScalar(sqlcntstr, paramList, trn);
                ret.result.currRec = (int)curpage;
                ret.result.maxRec = (int)maxRec;
                if (ret.result.totalRec > 0)
                {
                    var dt = crmlib.DoQuery(sqlSearchstr, paramList, trn, (int)curpage, (int)maxRec);
                    ret.result.MOrganizationList = (List<MOrganization>)dt.GetDTOs<MOrganization>();

                    var dt2 = crmlib.DoQuery(sqlTags, null, trn, 0, 99999999);
                    ret.result.TagList = (List<CrmActivitiesTag>)dt2.GetDTOs<CrmActivitiesTag>();

                    foreach (MOrganization d in ret.result.MOrganizationList)
                    {
                        if (!string.IsNullOrEmpty(d.PhoneOffice))
                        {
                            d.Phone = d.PhoneOffice;
                        }
                        if (!string.IsNullOrEmpty(d.PhoneMobile))
                        {
                            if (!string.IsNullOrEmpty(d.Phone))
                            {
                                d.Phone += ", " + d.PhoneMobile + " ";
                            }
                            else
                            {
                                d.Phone = d.PhoneMobile + " ";
                            }
                        }

                        if (!string.IsNullOrEmpty(d.PhoneFax))
                        {
                            d.Phone += d.PhoneFax;
                        }


                        if (ret.result.TagList != null)
                        {
                            var tmp = (from t in ret.result.TagList where t.ActivityId == d.OrganizeId select t).ToList<CrmActivitiesTag>();
                            string xx = string.Empty;
                            if (tmp != null && tmp.Count > 0)
                            {
                                foreach (CrmActivitiesTag tag in tmp)
                                {
                                    xx += "#" + tag.TagLabel + " ";
                                }
                                d.tagstr = xx;
                            }
                        }


                    }

                }
                else {

                    var dt2 = crmlib.DoQuery(sqlTags, null, trn, 0, 99999999);
                    ret.result.TagList = (List<CrmActivitiesTag>)dt2.GetDTOs<CrmActivitiesTag>();
                    ret.MsgText = CRMMessageEnum.MessageEnum.MessageDataResponse.DataDoesNotExisits.ToString(); }

                ret.IsComplete = true;

            }
            catch (Exception ex)
            {
                ret.IsComplete = false;
                ret.MsgText = ex.Message.ToString();
                throw ex;
            }

            ret.IsComplete = true;
            return ret;
        }


        private string GetStringFilter(string Alphabetfilter, string Combofilter, string txtFilter, string tagstr, ref Dictionary<string, object> paramList)
        {
            string strfilter = string.Empty;
            if (!string.IsNullOrEmpty(txtFilter))
            {
                strfilter = " AND (M.ORGANIZE_ID LIKE '%' || :TXTFILTER || '%' OR  UPPER(M.ORGANIZE_NAME) LIKE UPPER('%' || :TXTFILTER || '%') OR UPPER(M.FULL_ADDRESS) LIKE UPPER('%' || :TXTFILTER || '%') )";
                paramList.Add("TXTFILTER", txtFilter);
            }
            if (!string.IsNullOrEmpty(Combofilter) && Combofilter != "FTORG_ALL")
            {
                string[] tmpType = Combofilter.Split('_');
                string t = tmpType[1].Substring(tmpType[1].Length - 1);
                int num = Convert.ToInt32(tmpType[1].Substring(0, tmpType[1].Length - 1));

                if (t == "H")
                {
                    strfilter += " AND  M.CREATEDATE >= SYSDATE - (1/24*" + num + ")  ";
                }
                else if (t == "D")
                {
                    strfilter += " AND  M.CREATEDATE >= SYSDATE - " + num + "  ";
                }
                else
                {
                    strfilter += " AND M.CREATEDATE >= ADD_MONTHS(sysdate," + (num * -1) + ")  ";
                }
            }

            if (!string.IsNullOrEmpty(tagstr)) {
                strfilter += "AND EXISTS(SELECT 1 FROM CRM_ACTIVITIES_TAG T WHERE  T.ACTIVITY_CAT = 'ACCATORG' AND  T.ACTIVITY_ID = M.ORGANIZE_ID AND T.TAG_ID = :TAG_ID) ";
                paramList.Add("TAG_ID", tagstr);
            }

            if (!string.IsNullOrEmpty(Alphabetfilter))
            {
                if (Alphabetfilter != "#") {
                    strfilter += " AND  UPPER(M.ORGANIZE_NAME) LIKE  :ALPHABETFILTER || '%' ";
                    paramList.Add("ALPHABETFILTER", Alphabetfilter);
                   
                } else {
                    strfilter += " AND REGEXP_LIKE(SUBSTR(M.ORGANIZE_NAME,1,1), '[^A-Za-z]') ";
                }
               
            }
 
            return strfilter;

        }

        //Dim ret As New DTO.PgFactory

        //  Dim sqlStr As String = "SELECT * FROM PG_FACTORY WHERE FACTORY_ID = :FACTORYID"
        //    Dim param As New Dictionary(Of String, Object)
        //    param.Add("FACTORYID", id)

        //    Dim dt = DoQuery(sqlStr, Nothing, Nothing, 0, 1)
        //    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        //        Dim tmp = dt.GetDTOs(Of DTO.PgFactory)()
        //        ret = tmp.FirstOrDefault
        //    End If

        //    Return ret

        //Dim sqlstr As String = _
        //     "SELECT COUNT(*) From PG_WEEKLY_ORDER PW WHERE PW.FACTORY_ID = :FACTORY_ID AND PW.PERIODYEAR = :PERIODYEAR"
        //    Dim ret As Decimal = 0
        //    Dim dt As DataTable = Nothing
        //    'To Do Init  FOR GEN  DTO PG_WEEKLY_ORDER
        //    Dim paramList As New Dictionary(Of String, Object)

        //    paramList.Add("PERIODYEAR", periodyear)
        //    paramList.Add("FACTORY_ID", factoryId)
        //    Try
        //        ret = ExecuteScalar(sqlstr, paramList, pgtrn)
        //    Catch ex As Exception
        //        Throw ex
        //    End Try

        #region "Private Function"







        #endregion

    }
}
