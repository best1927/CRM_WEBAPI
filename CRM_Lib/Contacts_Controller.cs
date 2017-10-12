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
    class Contacts_Controller : IContacts_Controller
    {
        public GuResult<string> SaveContacts(MCrmContacts Obj, string user, string flag)
        {
            GuResult<string> ret = new GuResult<string>();
            if (flag == "N")
            {
                InsertContacts(Obj, user, ref ret);
            }
            else
            {
                UpdateContacts(Obj, user, ref ret);
            }


            return ret;
        }



        public GuResult<string> DeleteContacts(MCrmContacts Obj, string user, string flag)
        {
            GuResult<string> ret = new GuResult<string>();

            StringBuilder sb = new StringBuilder();
            IDbCommand cmd1 = null;
            sb.Append("UPDATE CRM_CONTACTS SET CONTACT_ST = 'I',MODIFYUSER = :USER, MODIFYDATE = :MDATE,PROGRAMCODE = :PROGRAMCODE WHERE CONTACT_ID = :CONID");

            try
            {
                Database database = CRM_Controller.GetDB();
                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    cmd1.Connection = conn;
                    cmd1.CommandText = sb.ToString();
                    cmd1.Parameters.Clear();

                }
            }
            catch (Exception ex)
            {

                ret.result = null;
                ret.IsComplete = false;
                ret.MsgText = ex.Message;
                throw ex;
            }
            return ret;
        }


        //public GuResult<List<MSearchContacts>> ContactsSearch(string txtStr, string filter,  string user , string[] tagstr)
        //{
        //    GuResult<List<MSearchContacts>> ret = new GuResult<List<MSearchContacts>>();

        //    StringBuilder sb = new StringBuilder();
        //    IDbCommand cmd1 = null;
        //    sb.Append("SELECT C.CONTACT_ID, C.NAME_LOC, C.NAME_OTH, C.ORGANIZE_ID, O.DESCR_LOC, O.DESCR_OTH FROM CRM_CONTACTS C LEFT OUTER JOIN CRM_ORGANIZATION O ON C.ORGANIZE_ID = O.ORGANIZE_ID LEFT OUTER JOIN CRM_ACTIVITIES_TAG T ON T.ACTIVITY_CAT = 'ACCATCONT' AND T.A_ID = C.CONTACT_ID");

        //    try
        //    {
        //        Database database = CRM_Controller.GetDB();
        //        using (IDbConnection conn = database.CreateOpenConnection())
        //        {
        //            cmd1.Connection = conn;
        //            cmd1.CommandText = sb.ToString();
        //            cmd1.Parameters.Clear();

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        ret.result = null;
        //        ret.IsComplete = false;
        //        ret.MsgText = ex.Message;
        //        throw ex;
        //    }
        //    return ret;
        //}

        public GuResult<MSearchContacts> SearchContacts(string Alphabetfilter, string Combofilter, string txtFilter, string userid, string lang, string local, string tagstr, Int64 curpage)
        {
            GuResult<MSearchContacts > ret = new GuResult<MSearchContacts>();
            ret.result = new MSearchContacts();


            ret.result.MContactsList  = new List<MContacts>();
            ret.result.TagList = new List<CrmActivitiesTag>();
            IDbSimplyTransaction trn = null;
            CRM_Controller crmlib = new CRM_Controller();
            string VisibleStr = crmlib.GetVisibilityString("C", userid);

            //   decimal cnt = 0;

            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LANG", lang);
            paramList.Add("LOCAL", local);
            string strfilter = GetStringFilter(Alphabetfilter, Combofilter, txtFilter, tagstr, ref paramList);

            string sqlstr = "SELECT * FROM (SELECT C.CONTACT_ID,C.ORGANIZE_ID, C.A_ID,CASE WHEN :LANG <> :LOCAL THEN NVL(C.NAME_OTH,C.NAME_LOC) ELSE C.NAME_LOC END AS CONTACT_NAME, CASE WHEN :LANG <> :LOCAL THEN NVL(O.DESCR_OTH,O.DESCR_LOC) ELSE O.DESCR_LOC END AS ORGANIZE_NAME , C.PHOTO_URL, C.CREATEUSER, C.CREATEDATE, C.VISIBILE_TYPE, C.VISIBILE_CD FROM CRM_CONTACTS C LEFT OUTER JOIN Crm_Organization O ON C.ORGANIZE_ID = O.ORGANIZE_ID WHERE {0}  ORDER BY C.NAME_LOC,C.NAME_OTH,O.DESCR_LOC, O.DESCR_OTH) M WHERE 1= 1 {1} ";

            string sqlcntstr = String.Format("SELECT COUNT(*) FROM ( {0} )", string.Format(sqlstr, VisibleStr, strfilter));
            string sqlSearchstr = string.Format(sqlstr, VisibleStr, strfilter) + " ORDER BY CONTACT_NAME, ORGANIZE_NAME ";
            //string sqlTags = string.Format("SELECT O.TAG_ID ,O.A_ID ,O.ACTIVITY_CAT ,O.ACTIVITY_ID ,O.TAG_LABEL ,O.VISIBILE_TYPE ,O.VISIBILE_CD FROM CRM_ACTIVITIES_TAG O WHERE {0} AND ACTIVITY_CAT = 'ACCATORG' ", VisibleStr);

            try
            {
                ret.result.totalRec = (int)crmlib.ExecuteScalar(sqlcntstr, paramList, trn);
                ret.result.currRec = (int)curpage;
                ret.result.maxRec = CRM_Controller.maxrows;
                if (ret.result.totalRec > 0)
                {
                    var dt = crmlib.DoQuery(sqlSearchstr, paramList, trn, (int)curpage, CRM_Controller.maxrows);
                    ret.result.MContactsList = (List<MContacts>)dt.GetDTOs<MContacts>();

 
                    ret.result.TagList = crmlib.GetTagList("ACCATCONT", "C", userid).result;

                    foreach (MContacts  d in ret.result.MContactsList)
                    { 
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

                    ret.result.TagList = crmlib.GetTagList("ACCATCONT", "C", userid).result;
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


        public GuResult<MCrmContacts> Contact_FindByCode(Int64 ContactId)
        {

            CRM_Controller crmlib = new CRM_Controller();
            GuResult<MCrmContacts> ret = new GuResult<MCrmContacts>();
            ret.result.ConLinklst = new List<CrmActivitiesLink>();
            ret.result.ConSociallst = new List<CrmContactsSocial >();
            ret.result.ConAnniversarylst  = new List<CrmContactsAnniversary >();
            ret.result.ConRelatelst  = new List<CrmContactsRelative >();

            string sqlStrg = " SELECT * FROM CRM_CONTACTS WHERE CONTACT_ID = " + (int)ContactId;
            string sqlStrSocial = "SELECT * FROM CRM_CONTACTS_SOCIAL WHERE CONTACT_ID = " + (int)ContactId + " ORDER BY SEQ ";
            string sqlStrAnn = "SELECT * FROM CRM_CONTACTS_ANNIVERSARY WHERE CONTACT_ID = " + (int)ContactId + " ORDER BY ANNI_DT ";
            string sqlStrRelate = "SELECT * FROM CRM_CONTACTS_RELATIVE WHERE CONTACT_ID = " + (int)ContactId + " ORDER BY SEQ ";
            try
            {
                var dt = crmlib.DoQuery(sqlStrg, null, null, 0, CRM_Controller.maxrows);
                List<MCrmContacts> tmp = (List<MCrmContacts>)dt.GetDTOs<MCrmContacts>();
                if (tmp != null && tmp.Count > 0)
                {
                    ret.result = tmp[0];
                    ret.result.ConLinklst = crmlib.GetActivityLinkByOwner(ret.result.ActivityCat, (long)ret.result.ContactId , 0).result;
                    var dt2 = crmlib.DoQuery(sqlStrSocial, null, null, 0, CRM_Controller.maxrows);
                    ret.result.ConSociallst = (List<CrmContactsSocial>)dt2.GetDTOs<CrmContactsSocial>();
                    var dt3 = crmlib.DoQuery(sqlStrAnn, null, null, 0, CRM_Controller.maxrows);
                    ret.result.ConAnniversarylst = (List<CrmContactsAnniversary>)dt3.GetDTOs<CrmContactsAnniversary>();
                    var dt4 = crmlib.DoQuery(sqlStrRelate, null, null, 0, CRM_Controller.maxrows);
                    ret.result.ConRelatelst = (List<CrmContactsRelative>)dt4.GetDTOs<CrmContactsRelative>();
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
                strfilter = " AND (M.CONTACT_ID LIKE '%' || :TXTFILTER || '%' OR  UPPER(M.CONTACT_NAME) LIKE UPPER('%' || :TXTFILTER || '%') OR UPPER(M.ORGANIZE_NAME) LIKE UPPER('%' || :TXTFILTER || '%') )";
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
                strfilter += "AND EXISTS(SELECT 1 FROM CRM_ACTIVITIES_TAG T WHERE  T.ACTIVITY_CAT = 'ACCATCONT' AND  T.ACTIVITY_ID = M.CONTACT_ID AND T.TAG_ID = :TAG_ID) ";
                paramList.Add("TAG_ID", tagstr);
            }

            if (!string.IsNullOrEmpty(Alphabetfilter))
            {
                if (Alphabetfilter != "#")
                {
                    strfilter += " AND  UPPER(M.CONTACT_NAME) LIKE  :ALPHABETFILTER || '%' ";
                    paramList.Add("ALPHABETFILTER", Alphabetfilter);

                }
                else
                {
                    strfilter += " AND REGEXP_LIKE(SUBSTR(M.CONTACT_NAME,1,1), '[^A-Za-z]') ";
                }

            }

            return strfilter;

        }

        private void InsertContacts(MCrmContacts Obj, string userid, ref GuResult<string> ret)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select SEQ_CRM_CONTACTS.nextval from dual");
            IDbCommand cmd = null;
            IDbCommand cmdAnn = null;
            IDbCommand cmdRelate = null;
            IDbCommand cmdSocial = null;
            IDbCommand cmdLink = null;
            IDbCommand cmdSeq = null;
            IDbTransaction trn = null;
            CRM_Controller crmlib = new CRM_Controller();
            DateTime _d = DateTime.Now;


            int seqAnn = 0;
            int seqSocial = 0;
            int seqLink = 0;
            int seqRelate = 0;

            try
            {
                Database database = CRM_Controller.GetDB();
                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    trn = conn.BeginTransaction();

                    //Get Seq. for CONTACT_ID
                    cmdSeq = conn.CreateCommand();
                    cmdSeq.CommandText = sb.ToString();
                    object tmp = cmdSeq.ExecuteScalar();
                    if (!(tmp is DBNull))
                    {
                        int id;
                        id = Convert.ToInt32(tmp);
                        Obj.ContactId = id;
                    }
                    //Get Seq. for CONTACT_ID  

                    //Insert CRM_CONTACTS
                    Obj.ActivityCat = "ACCATCONT";
                    Obj.AId = InsertActivity(conn, trn, Obj, userid, _d);
                    Obj.Createuser = userid;
                    Obj.Createdate = DateTime.Now;
                    cmd = Obj.InsertCommand(conn);
                    cmd.Transaction = trn;
                    cmd.ExecuteNonQuery();


                    //Insert CRM_CONTACTS_Ani
                    if (Obj.ConAnniversarylst != null && Obj.ConAnniversarylst.Count > 0)
                    {
                        seqAnn = 0;
                        foreach (CrmContactsAnniversary a in Obj.ConAnniversarylst)
                        {
                            seqAnn += 1;
                            a.ContactId = Obj.ContactId;
                            a.Seq = seqAnn;
                            a.Createuser = userid;
                            a.Createdate = _d;
                            cmdAnn = a.InsertCommand(conn);
                            cmdAnn.Transaction = trn;
                            cmdAnn.ExecuteNonQuery();

                        }
                    }

                    //Insert CRM_CONTACTS_Link 

                    if (Obj.ConLinklst != null && Obj.ConLinklst.Count > 0)
                    {
                        seqLink = 0;
                        foreach (CrmActivitiesLink b in Obj.ConLinklst)
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

                    //Insert CRM_CONTACTS_Relate
                    if (Obj.ConRelatelst != null && Obj.ConRelatelst.Count > 0)
                    {
                        seqRelate = 0;
                        foreach (CrmContactsRelative c in Obj.ConRelatelst)
                        {
                            seqRelate += 1;
                            c.Seq = seqRelate;
                            c.ContactId = Obj.ContactId;
                            c.Createuser = userid;
                            c.Createdate = DateTime.Now;
                            cmdRelate = c.InsertCommand(conn);
                            cmdRelate.Transaction = trn;
                            cmdRelate.ExecuteNonQuery();
                        }
                    }


                    //Insert CRM_CONTACTS_Social 
                    if (Obj.ConSociallst != null && Obj.ConSociallst.Count > 0)
                    {
                        seqSocial = 0;
                        foreach (CrmContactsSocial c in Obj.ConSociallst)
                        {
                            seqSocial += 1;
                            c.ContactId = Obj.ContactId;
                            c.Seq = seqSocial;
                            c.Createuser = userid;
                            c.Createdate = _d;
                            cmdSocial = c.InsertCommand(conn);
                            cmdSocial.Transaction = trn;
                            cmdSocial.ExecuteNonQuery();
                        }
                    }


                    trn.Commit();
                    cmd.Dispose();
                    cmdAnn.Dispose();
                    cmdRelate.Dispose();
                    cmdLink.Dispose();
                    cmdSocial.Dispose();
                    conn.Close();
                    ret.IsComplete = true;
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

        private void UpdateContacts(MCrmContacts Obj, string userid, ref GuResult<string> ret)
        {
            CRM_Controller crmlib = new CRM_Controller();
            StringBuilder sb = new StringBuilder();
            sb.Append("select SEQ_CRM_CONTACTS.nextval from dual");
            IDbCommand cmd = null;
            IDbCommand cmdAnn = null;
            IDbCommand cmdRelate = null;
            IDbCommand cmdSocial = null;
            IDbCommand cmdLink = null;
            IDbTransaction trn = null;

            int seqAnn = 0;
            int seqSocial = 0;
            int seqLink = 0;


            try
            {
                Database database = CRM_Controller.GetDB();
                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    trn = conn.BeginTransaction();


                    //Update CRM_CONTACTS
                    Obj.Modifyuser = userid;
                    Obj.Modifydate = DateTime.Now;
                    cmd = Obj.UpdateCommand(conn, "Createuser,Createdate");
                    cmd.Transaction = trn;
                    cmd.ExecuteNonQuery();

                    //Update CRM_CONTACTS_Ani

                    if (Obj.ConAnniversarylst != null && Obj.ConAnniversarylst.Count > 0)
                    {
                        seqAnn = GetMaxAnniversarySeqId(conn, (int)Obj.OrganizeId);
                        foreach (CrmContactsAnniversary a in Obj.ConAnniversarylst)
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
                    if (Obj.ConLinklst != null && Obj.ConLinklst.Count > 0)
                    {
                        seqLink = crmlib.GetMaxLinkSeqId(conn, (int)Obj.AId);
                        foreach (CrmActivitiesLink b in Obj.ConLinklst)
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

                    //Insert CRM_CONTACTS_Relate


                    if (Obj.ConRelatelst != null && Obj.ConRelatelst.Count > 0)
                    {
                        seqAnn = GetMaxAnniversarySeqId(conn, (int)Obj.ContactId);
                        foreach (CrmContactsRelative a in Obj.ConRelatelst )
                        {
                            seqAnn = GetMaxAnniversarySeqId(conn, (int)Obj.ContactId );
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


                    //Insert CRM_CONTACTS_Social 
                    if (Obj.ConSociallst != null && Obj.ConSociallst.Count > 0)
                    {
                        seqSocial = GetMaxSocialSeqId(conn, (int)Obj.ContactId);
                        foreach (CrmContactsSocial  d in Obj.ConSociallst)
                        {
                            if (d.EntityState == SsCommon.EntityStateLocal.Added)
                            {
                                seqSocial += 1;
                                d.Seq = seqSocial;
                                d.Createuser = userid;
                                d.Createdate = DateTime.Now;
                                cmdSocial = d.InsertCommand(conn);
                            }
                            else if (d.EntityState == SsCommon.EntityStateLocal.Modified)
                            {
                                d.Modifyuser = userid;
                                d.Modifydate = DateTime.Now;
                                cmdSocial = d.UpdateCommand(conn, "Createuser,Createdate");
                            }
                            else if (d.EntityState == SsCommon.EntityStateLocal.Deleted)
                            {

                                cmdSocial = d.DeleteCommand(conn);
                            }
                            cmdSocial.Transaction = trn;
                            cmdSocial.ExecuteNonQuery();
                        }
                    }
                    trn.Commit();
                    cmd.Dispose();
                    cmdAnn.Dispose();
                    cmdRelate.Dispose();
                    cmdSocial.Dispose();
                    cmdLink.Dispose(); 
                    conn.Close();
                    ret.IsComplete = true;
                    ret.result = CRMMessageEnum.MessageEnum.MessageDataResponse.SaveCompleted.ToString();
                    ret.MsgText  = CRMMessageEnum.MessageEnum.MessageDataResponse.SaveCompleted.ToString();
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

        private int InsertActivity(IDbConnection conn, IDbTransaction trn, MCrmContacts Obj, string userid, DateTime _d)
        {
            int ret = -1;

            CRM_Controller crmlib = new CRM_Controller();
            MCrmActivities crmact = new MCrmActivities();
            crmact.ActivityDate = _d;
            crmact.ActivityId = Obj.ContactId;
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


        public int GetMaxAnniversarySeqId(IDbConnection conn, int ContactId)
        {
            int ret = 0;
            IDbCommand cmdSeq = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("select max(SEQ) from CRM_CONTACTS_ANNIVERSARY WHERE CONTACT_ID = " + ContactId);
            cmdSeq = conn.CreateCommand();
            cmdSeq.CommandText = sb.ToString();
            object tmp = cmdSeq.ExecuteScalar();

            if (!(tmp is DBNull))
            {
                ret = Convert.ToInt32(tmp);
            }
            return ret;
        }
        public int GetMaxSocialSeqId(IDbConnection conn, int ContactId)
        {
            int ret = 0;
            IDbCommand cmdSeq = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("select max(SEQ) from CRM_CONTACTS_SOCIAL WHERE CONTACT_ID = " + ContactId);
            cmdSeq = conn.CreateCommand();
            cmdSeq.CommandText = sb.ToString();
            object tmp = cmdSeq.ExecuteScalar();

            if (!(tmp is DBNull))
            {
                ret = Convert.ToInt32(tmp);
            }
            return ret;
        }

        public int GetMaxRelateSeqId(IDbConnection conn, int ContactId)
        {
            int ret = 0;
            IDbCommand cmdSeq = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("select max(SEQ) from CRM_CONTACTS_RELATIVE WHERE CONTACT_ID = " + ContactId);
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
