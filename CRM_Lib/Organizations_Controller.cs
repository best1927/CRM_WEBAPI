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
            GuResult<string> ret = new GuResult<string>();
            IDbTransaction trn = null;
            DateTime _d = DateTime.Now;

            CRM_Controller crmlib = new CRM_Controller();
            IDbCommand cmd = null;

            try
            {
                Database database = CRM_Controller.GetDB();
                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    trn = conn.BeginTransaction();
                    trn.Commit();
                    cmd.Dispose();
                    conn.Close();
                    ret.IsComplete = true;
                    ret.result = CRMMessageEnum.MessageEnum.MessageDataResponse.DataDeleted.ToString();
                    ret.MsgText = CRMMessageEnum.MessageEnum.MessageDataResponse.DataDeleted.ToString();
                }
            }
            catch (Exception ex)
            {
                if (trn != null)
                {
                    trn.Rollback();
                }
                ret.result = null;
                ret.IsComplete = false;
                ret.MsgText = ex.Message;
                throw ex;
            }

            return ret;
        }

        public GuResult<string> SaveOrganization(MCrmOrganization Obj, string user, string flag)
        {

            GuResult<string> ret = new GuResult<string>();
            if (flag == "N")
            {
                InsertOrganization(Obj, user, ref ret);
            }
            else
            {
                UpdateOrganization(Obj, user, ref ret);
            }


            return ret;
        }

        public GuResult<MSearchOrganization> SearchOrganization(string Alphabetfilter, string Combofilter, string txtFilter, string userid, string lang, string tagstr, Int64 curpage)
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
            paramList.Add("LOCAL", CRM_Controller.DefaultLang);
            string strfilter = GetStringFilter(Alphabetfilter, Combofilter, txtFilter, tagstr, ref paramList);

            string sqlstr = "SELECT * FROM (SELECT ORGANIZE_ID,A_ID, CASE WHEN :LANG <> :LOCAL THEN NVL(DESCR_OTH,DESCR_LOC) ELSE DESCR_LOC END AS ORGANIZE_NAME, ADDRESS || ( CASE WHEN SUBDISTRICT IS NOT NULL THEN ' ' || SUBDISTRICT ELSE '' END) || ( CASE WHEN DISTRICT IS NOT NULL THEN ' ' || DISTRICT ELSE '' END) || ( CASE WHEN CITY IS NOT NULL THEN ' ' || CASE WHEN :LANG <> :LOCAL THEN NVL(CI.DESC2,CI.DESC1) ELSE CI.DESC1 END ELSE '' END) || ( CASE WHEN STATE IS NOT NULL THEN ' ' || CASE WHEN :LANG <> :LOCAL THEN NVL(PO.DESC2,PO.DESC1) ELSE PO.DESC1 END ELSE '' END) || ( CASE WHEN COUNTRY IS NOT NULL THEN ' ' || CASE WHEN :LANG <> :LOCAL THEN NVL(CO.DESC2,CO.DESC1) ELSE CO.DESC1 END ELSE '' END) || ( CASE WHEN POSTALCODE IS NOT NULL THEN ' ' || POSTALCODE ELSE '' END) AS FULL_ADDRESS, ORGANIZE_URL, PHONE_HOME, PHONE_MOBILE, PHONE_OFFICE, CASE WHEN PHONE_FAX IS NOT NULL THEN 'Fax.' || PHONE_FAX ELSE '' END AS PHONE_FAX, CREATEUSER, CREATEDATE FROM CRM_ORGANIZATION O LEFT OUTER JOIN GENERAL_DESC CI ON CI.GDTYPE = 'CITY' AND O.CITY   = CI.GDCODE LEFT OUTER JOIN GENERAL_DESC PO ON PO.GDTYPE = 'STATE' AND O.STATE  = PO.GDCODE LEFT OUTER JOIN GENERAL_DESC CO ON CO.GDTYPE  = 'COTRY' AND O.COUNTRY = CO.GDCODE WHERE {0}  ORDER BY DESCR_LOC, DESCR_OTH, ADDRESS) M WHERE 1= 1 {1} ";

            string sqlcntstr = String.Format("SELECT COUNT(*) FROM ( {0} )", string.Format(sqlstr, VisibleStr, strfilter));
            string sqlSearchstr = string.Format(sqlstr, VisibleStr, strfilter) + " ORDER BY ORGANIZE_NAME ";
            //string sqlTags = string.Format("SELECT O.TAG_ID ,O.A_ID ,O.ACTIVITY_CAT ,O.ACTIVITY_ID ,O.TAG_LABEL ,O.VISIBILE_TYPE ,O.VISIBILE_CD FROM CRM_ACTIVITIES_TAG O WHERE {0} AND ACTIVITY_CAT = 'ACCATORG' ", VisibleStr);

            try
            {
                ret.result.totalRec = (int)crmlib.ExecuteScalar(sqlcntstr, paramList, trn);
                ret.result.currRec = (int)curpage;
                ret.result.maxRec = CRM_Controller.maxrows;
                if (ret.result.totalRec > 0)
                {
                    var dt = crmlib.DoQuery(sqlSearchstr, paramList, trn, (int)curpage, CRM_Controller.maxrows);
                    ret.result.MOrganizationList = (List<MOrganization>)dt.GetDTOs<MOrganization>();


                    ret.result.TagList = crmlib.GetTagList("ACCATORG", "O", userid).result;

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
                else
                {

                    ret.result.TagList = crmlib.GetTagList("ACCATORG", "O", userid).result;
                    ret.MsgText = CRMMessageEnum.MessageEnum.MessageDataResponse.DataDoesNotExisits.ToString();
                }

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


        public GuResult<MCrmOrganization> Organization_FindByCode(Int64 OrgId,string lang)
        {

            CRM_Controller crmlib = new CRM_Controller();
            GuResult<MCrmOrganization> ret = new GuResult<MCrmOrganization>();
            ret.result = new MCrmOrganization();
            ret.result.OrgLinklst = new List<MCrmActivitiesLink>(); 
            ret.result.OrgAnniversarylst = new List<CrmOrganizationAnniversary>();
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LANG", lang);
            paramList.Add("LOCAL", CRM_Controller.DefaultLang);
            string sqlOrg = " SELECT O.*, ( CASE WHEN :LANG <> :LOCAL THEN NVL(O.DESCR_OTH,O.DESCR_LOC) ELSE O.DESCR_LOC END) AS ORG_NAME, (  CASE WHEN :LANG <> :LOCAL THEN NVL(ORTY.DESC2,ORTY.DESC1) ELSE ORTY.DESC1 END) AS ORG_TYPE_NAME,ADDRESS || ( CASE WHEN SUBDISTRICT IS NOT NULL THEN ' ' || SUBDISTRICT ELSE '' END) || ( CASE WHEN DISTRICT IS NOT NULL THEN ' ' || DISTRICT ELSE '' END) || ( CASE WHEN CITY IS NOT NULL THEN ' ' || CASE WHEN :LANG <> :LOCAL THEN NVL(CI.DESC2,CI.DESC1) ELSE CI.DESC1 END ELSE '' END) || ( CASE WHEN STATE IS NOT NULL THEN ' ' || CASE WHEN :LANG <> :LOCAL THEN NVL(PO.DESC2,PO.DESC1) ELSE PO.DESC1 END ELSE '' END) || ( CASE WHEN COUNTRY IS NOT NULL THEN ' ' || CASE WHEN :LANG <> :LOCAL THEN NVL(CO.DESC2,CO.DESC1) ELSE CO.DESC1 END ELSE '' END) || ( CASE WHEN POSTALCODE IS NOT NULL THEN ' ' || POSTALCODE ELSE '' END) AS FULL_ADDRESS  FROM CRM_ORGANIZATION O LEFT OUTER JOIN GENERAL_DESC ORTY ON ORTY.GDTYPE = 'ORGTY' AND  O.ORGANIZE_TYPE = ORTY.GDCODE LEFT OUTER JOIN GENERAL_DESC CI ON CI.GDTYPE = 'CITY' AND O.CITY   = CI.GDCODE LEFT OUTER JOIN GENERAL_DESC PO ON PO.GDTYPE = 'STATE' AND O.STATE  = PO.GDCODE LEFT OUTER JOIN GENERAL_DESC CO ON CO.GDTYPE  = 'COTRY' AND O.COUNTRY = CO.GDCODE WHERE ORGANIZE_ID = " + (int)OrgId;
            
            string sqlOrgAnn = "SELECT * FROM CRM_ORGANIZATION_ANNIVERSARY WHERE ORGANIZE_ID = " + (int)OrgId + " ORDER BY ANNI_DT ";
            try
            {
                var dt = crmlib.DoQuery(sqlOrg, paramList, null, 0, CRM_Controller.maxrows);
                List<MCrmOrganization> tmp = (List<MCrmOrganization>)dt.GetDTOs<MCrmOrganization>();
                if (tmp != null && tmp.Count > 0)
                {
                    ret.result = tmp[0];

                    if (!string.IsNullOrEmpty(ret.result.PhoneOffice))
                    {
                        ret.result.Phone = ret.result.PhoneOffice;
                    }
                    if (!string.IsNullOrEmpty(ret.result.PhoneMobile))
                    {
                        if (!string.IsNullOrEmpty(ret.result.Phone))
                        {
                            ret.result.Phone += ", " + ret.result.PhoneMobile + " ";
                        }
                        else
                        {
                            ret.result.Phone = ret.result.PhoneMobile + " ";
                        }
                    }

                    if (!string.IsNullOrEmpty(ret.result.PhoneFax))
                    {
                        ret.result.Phone += " Fax." + ret.result.PhoneFax;
                    }
                    ret.result.CreateDateStr = ret.result.Createdate.Value.ToString(CRM_Controller.DateStringformatAsp);
                    ret.result.OrgLinklst = crmlib.GetActivityLinkByOwner(ret.result.ActivityCat, (long)ret.result.OrganizeId, 0,lang).result;
                    
                    var dt3 = crmlib.DoQuery(sqlOrgAnn, null, null, 0, CRM_Controller.maxrows);
                    ret.result.OrgAnniversarylst = (List<CrmOrganizationAnniversary>)dt3.GetDTOs<CrmOrganizationAnniversary>();
                }
                else
                {
                    ret.MsgText = CRMMessageEnum.MessageEnum.MessageDataResponse.DataDoesNotExisits.ToString();
                }

                ret.IsComplete = true;
            }
            catch (Exception ex)
            {
                ret.IsComplete = false;
                ret.MsgText = ex.Message.ToString();
                throw ex;
            }
            return ret;
        }




        #region "Private Function"


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

            if (!string.IsNullOrEmpty(tagstr))
            {
                strfilter += "AND EXISTS(SELECT 1 FROM CRM_ACTIVITIES_TAG T WHERE  T.ACTIVITY_CAT = 'ACCATORG' AND  T.ACTIVITY_ID = M.ORGANIZE_ID AND T.TAG_ID = :TAG_ID) ";
                paramList.Add("TAG_ID", tagstr);
            }

            if (!string.IsNullOrEmpty(Alphabetfilter))
            {
                if (Alphabetfilter != "#")
                {
                    strfilter += " AND  UPPER(M.ORGANIZE_NAME) LIKE  :ALPHABETFILTER || '%' ";
                    paramList.Add("ALPHABETFILTER", Alphabetfilter);

                }
                else
                {
                    strfilter += " AND REGEXP_LIKE(SUBSTR(M.ORGANIZE_NAME,1,1), '[^A-Za-z]') ";
                }

            }

            return strfilter;

        }



        private void InsertOrganization(MCrmOrganization Obj, string userid, ref GuResult<string> ret)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select SEQ_CRM_ORGANIZATION.nextval from dual");
            IDbCommand cmd = null;
            IDbCommand cmdLink = null; 
            IDbCommand cmdAnn = null;
            IDbCommand cmdSeq = null;
            IDbTransaction trn = null;
            DateTime _d = DateTime.Now;

            int seqAnn = 0; 
            int seqLink = 0;

            try
            {
                Database database = CRM_Controller.GetDB();
                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    trn = conn.BeginTransaction();

                    //Get Seq. for OrganizeId
                    cmdSeq = conn.CreateCommand();
                    cmdSeq.CommandText = sb.ToString();
                    object tmp = cmdSeq.ExecuteScalar();
                    if (!(tmp is DBNull))
                    {
                        int id;
                        id = Convert.ToInt32(tmp);
                        Obj.OrganizeId = id;
                    }
                    //Get Seq. for CONTACT_ID   

                    //Insert OrganizeId
                    Obj.ActivityCat = "ACCATORG";
                    Obj.AId = InsertActivity(conn, trn, Obj, userid, _d);
                    Obj.Createuser = userid;
                    Obj.Createdate = _d;
                    cmd = Obj.InsertCommand(conn);
                    cmd.Transaction = trn;
                    cmd.ExecuteNonQuery();

                    //Insert OrgAnniversarylst
                    if (Obj.OrgAnniversarylst != null && Obj.OrgAnniversarylst.Count > 0)
                    {
                        seqAnn = 0;
                        foreach (CrmOrganizationAnniversary a in Obj.OrgAnniversarylst)
                        {
                            seqAnn += 1;
                            a.OrganizeId = Obj.OrganizeId;
                            a.Seq = seqAnn;
                            a.Createuser = userid;
                            a.Createdate = _d;
                            cmdAnn = a.InsertCommand(conn);
                            cmdAnn.Transaction = trn;
                            cmdAnn.ExecuteNonQuery();

                        }
                    }

                    //Insert OrgLinklst
                    if (Obj.OrgLinklst != null && Obj.OrgLinklst.Count > 0)
                    {
                        seqLink = 0;
                        foreach (CrmActivitiesLink b in Obj.OrgLinklst)
                        {
                            seqLink += 1;
                            b.AId = (int)Obj.AId;
                            b.ActivityId = Obj.OrganizeId;
                            b.ActivityCat = Obj.ActivityCat;
                            b.Seq = seqLink;
                            b.Createuser = userid;
                            b.Createdate = _d;
                            cmdLink = b.InsertCommand(conn);
                            cmdLink.Transaction = trn;
                            cmdLink.ExecuteNonQuery();
                        }
                    }

                  
                    trn.Commit();
                    cmd.Dispose(); 
                    cmdLink.Dispose();
                    cmdAnn.Dispose();
                    conn.Close();
                    ret.result = CRMMessageEnum.MessageEnum.MessageDataResponse.SaveCompleted.ToString();
                    ret.MsgText = CRMMessageEnum.MessageEnum.MessageDataResponse.SaveCompleted.ToString();
                }
            }
            catch (Exception ex)
            {
                if (trn != null)
                {
                    trn.Rollback();
                }
                ret.result = null;
                ret.IsComplete = false;
                ret.MsgText = ex.Message;
                throw ex;
            }

        }

        private void UpdateOrganization(MCrmOrganization Obj, string userid, ref GuResult<string> ret)
        {
            CRM_Controller crmlib = new CRM_Controller();
            StringBuilder sb = new StringBuilder();
            sb.Append("select SEQ_CRM_CONTACTS.nextval from dual");
            IDbCommand cmd = null;
            IDbCommand cmdLink = null; 
            IDbCommand cmdAnn = null; 
            IDbTransaction trn = null;
            DateTime _d = DateTime.Now;


            int seqAnn = 0; 
            int seqLink = 0;

            try
            {
                Database database = CRM_Controller.GetDB();
                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    trn = conn.BeginTransaction();


                    //Update CrmOrganization
                    Obj.Modifyuser = userid;
                    Obj.Modifydate = DateTime.Now;
                    cmd = Obj.UpdateCommand(conn, "Createuser,Createdate");
                    cmd.Transaction = trn;
                    cmd.ExecuteNonQuery();

                    //Update OrgAnniversarylst
                    if (Obj.OrgAnniversarylst != null && Obj.OrgAnniversarylst.Count > 0)
                    {
                        seqAnn = GetMaxAnniversarySeqId(conn, (int)Obj.OrganizeId);
                        foreach (CrmOrganizationAnniversary a in Obj.OrgAnniversarylst)
                        {
                            seqAnn = GetMaxAnniversarySeqId(conn, (int)Obj.OrganizeId);
                            if (a.EntityState == SsCommon.EntityStateLocal.Added)
                            {
                                seqAnn += 1;
                                a.Seq = seqAnn;
                                a.Createuser = userid;
                                a.Createdate = DateTime.Now;
                                cmdAnn = a.InsertCommand(conn);
                            }
                            else if (a.EntityState == SsCommon.EntityStateLocal.Modified)
                            {
                                a.Modifyuser = userid;
                                a.Modifydate = DateTime.Now;
                                cmdAnn = a.UpdateCommand(conn, "Createuser,Createdate");
                            }
                            else if (a.EntityState == SsCommon.EntityStateLocal.Deleted)
                            {
                                cmdAnn = a.DeleteCommand(conn);
                            }
                            cmdAnn.Transaction = trn;
                            cmdAnn.ExecuteNonQuery();
                        }
                    }

                    //Insert CRM_CONTACTS_Link
                    if (Obj.OrgLinklst != null && Obj.OrgLinklst.Count > 0)
                    {
                        seqLink = crmlib.GetMaxLinkSeqId(conn, (int)Obj.AId);
                        foreach (CrmActivitiesLink b in Obj.OrgLinklst)
                        {
                            if (b.EntityState == SsCommon.EntityStateLocal.Added)
                            {
                                seqLink += 1;
                                b.Seq = seqLink;
                                b.Createuser = userid;
                                b.Createdate = DateTime.Now;
                                cmdLink = b.InsertCommand(conn);
                            }
                            else if (b.EntityState == SsCommon.EntityStateLocal.Modified)
                            {
                                b.Modifyuser = userid;
                                b.Modifydate = DateTime.Now;
                                cmdLink = b.UpdateCommand(conn, "Createuser,Createdate");
                            }
                            else if (b.EntityState == SsCommon.EntityStateLocal.Deleted)
                            {
                                cmdLink = b.DeleteCommand(conn);
                            }
                            cmdLink.Transaction = trn;
                            cmdLink.ExecuteNonQuery();
                        }
                    }
                     


                    trn.Commit();
                    cmd.Dispose();
                    cmdLink.Dispose(); 
                    cmdAnn.Dispose();
                    conn.Close();
                    ret.result = CRMMessageEnum.MessageEnum.MessageDataResponse.SaveCompleted.ToString();
                    ret.MsgText = CRMMessageEnum.MessageEnum.MessageDataResponse.SaveCompleted.ToString();
                }
            }
            catch (Exception ex)
            {
                if (trn != null)
                {
                    trn.Rollback();
                }
                ret.result = null;
                ret.IsComplete = false;
                ret.MsgText = ex.Message;
                throw ex;
            }

        }

        private int InsertActivity(IDbConnection conn, IDbTransaction trn, MCrmOrganization Obj, string userid, DateTime _d)
        {
            int ret = -1;

            CRM_Controller crmlib = new CRM_Controller();
            MCrmActivities crmact = new MCrmActivities();
            crmact.ActivityDate = _d;
            crmact.ActivityId = Obj.OrganizeId;
            crmact.ActivityCat = Obj.ActivityCat;
            crmact.ActivityTime = _d.ToString("HH:mm:ss");
            crmact.OwnerCat = Obj.ActivityCat;
            crmact.OwnerId = Obj.OrganizeId;
            crmact.AssignCat = Obj.ActivityCat;
            crmact.AssignId = Obj.AssignId;
            crmact.Topic = CRMMessageEnum.MessageEnum.MessageDataResponse.CreateOrganization.ToString();
            crmact.VisibileCd = Obj.VisibileCd;
            crmact.VisibileType = Obj.VisibileType;
            crmact.Createdate = _d;
            crmact.Createuser = userid;
            ret = crmlib.InsertAcitvity(conn, trn, crmact, userid).result;

            return ret;
        }



        public int GetMaxAnniversarySeqId(IDbConnection conn, int OrgId)
        {
            int ret = 0;
            IDbCommand cmdSeq = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("select max(SEQ) from CRM_ORGANIZATION_ANNIVERSARY WHERE ORGANIZE_ID = " + OrgId);
            cmdSeq = conn.CreateCommand();
            cmdSeq.CommandText = sb.ToString();
            object tmp = cmdSeq.ExecuteScalar();

            if (!(tmp is DBNull))
            {
                ret = Convert.ToInt32(tmp);
            }
            return ret;
        }
        public int GetMaxSocialSeqId(IDbConnection conn, int OrgId)
        {
            int ret = 0;
            IDbCommand cmdSeq = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("select max(SEQ) from CRM_ORGANIZATION_SOCIAL WHERE ORGANIZE_ID = " + OrgId);
            cmdSeq = conn.CreateCommand();
            cmdSeq.CommandText = sb.ToString();
            object tmp = cmdSeq.ExecuteScalar();

            if (!(tmp is DBNull))
            {
                ret = Convert.ToInt32(tmp);
            }
            return ret;
        }

        #endregion

    }
}
