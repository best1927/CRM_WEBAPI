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
    class CRM_Controller : ICRM_Controller, IDbExecutable, IDisposable
    {

        public static Database _DB = null;
        public static string schemaConnection = ConfigurationManager.AppSettings["schemaConnection"].ToString();
        public static string dbName = ConfigurationManager.AppSettings["dbName"].ToString();
        public static string dbConnection = ConfigurationManager.AppSettings["dbConnection"].ToString();
        public static string dbType = ConfigurationManager.AppSettings["dbTypeConnection"].ToString();
        public static string rowtxt = ConfigurationManager.AppSettings["DefaultGridRow"].ToString();
        public static string DefaultLang = ConfigurationManager.AppSettings["DefaultLanguage"].ToString();

        public static string DateTimeformatAsp = ConfigurationManager.AppSettings["DisplayDateTimeFormat_asp"].ToString();
        public static string DateformatAsp = ConfigurationManager.AppSettings["DisplayDateFormat_asp"].ToString();
        public static string DateStringformatAsp = ConfigurationManager.AppSettings["DisplayDateStringFormat_asp"].ToString();
        public static int maxrows = !string.IsNullOrEmpty(rowtxt) ? Int32.Parse(rowtxt) : 20;


        private static CRM_Controller _instant = new CRM_Controller();
        public static CRM_Controller Instant
        {
            get { return _instant; }
        }

        public static Database GetDB()
        {
            string TschemaConnection = ConfigurationManager.AppSettings["schemaConnection"].ToString();
            string TdbName = ConfigurationManager.AppSettings["dbName"].ToString();
            string TdbConnection = ConfigurationManager.AppSettings["dbConnection"].ToString();
            string TdbType = ConfigurationManager.AppSettings["dbTypeConnection"].ToString();
            if (TschemaConnection != schemaConnection || TdbName != dbName || TdbConnection != dbConnection || TdbType != dbType)
            {
                //Get DB
                _DB = DatabaseFactory.CreateDatabase(dbType, dbConnection, dbName, schemaConnection);
            }
            if (_DB == null)
            {
                _DB = DatabaseFactory.CreateDatabase();
            }
            return _DB;


        }



        #region"IDbExecutable"

        public double ExecuteNonQuery(string SQLString, Dictionary<string, object> Params = null, IDbSimplyTransaction Transaction = null)
        {
            double ret = 0;
            Database db = GetDB();

            ret = db.ExecuteNonQuery(SQLString, Params, Transaction);
            return ret;
        }

        public decimal ExecuteScalar(string SQLString, Dictionary<string, object> Params = null, IDbSimplyTransaction Transaction = null)
        {
            //decimal ret = 0;
            //Database db = GetDB();
            //IDbConnection pCon = null;
            //IDbTransaction trn = null;
            //DbSimplyTransaction simply = (DbSimplyTransaction)Transaction;
            //if (Transaction != null)
            //{
            //    pCon = simply.Connection;
            //    trn = simply.Transaction;
            //}
            //else
            //{
            //    pCon = db.CreateOpenConnection();
            //}
            //ret = db.ExecuteScalar(pCon, SQLString, Params, trn);
            //return ret;
            decimal ret = 0;
            Database db = GetDB();

            ret = db.ExecuteScalar(SQLString, Params, Transaction);
            return ret;
        }
        public int UpdateTable(DataTable dt, string TableName, IDbSimplyTransaction Transaction = null)
        {
            int ret = 0;
            Database db = GetDB();
            ret = db.UpdateTable(dt, TableName, (DbSimplyTransaction)Transaction);
            return ret;
        }


        public DataTable DoQuery(string SelectString, Dictionary<string, object> Params = null, IDbSimplyTransaction Transaction = null, int startRecord = -1, int maxRecord = -1)
        {

            DataTable ret = null;
            Database db = GetDB();
            IDbConnection pCon = null;
            IDbTransaction trn = null;
            DbSimplyTransaction simply = (DbSimplyTransaction)Transaction;
            if (Transaction != null)
            {
                pCon = simply.Connection;
                trn = simply.Transaction;
            }
            else
            {
                pCon = db.CreateConnection();
            }
            ret = db.DoQuery(pCon, SelectString, Params, trn, startRecord, maxRecord);

            return ret;
        }

        #endregion

        #region "IDisposable Support"

        private Boolean disposedValue;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    _instant = null;

                }
            }
            this.disposedValue = true;
        }


        #endregion

        public System.DateTime convertDate(string txtDate, string DateFormat)
        {
            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            if (DateFormat.Contains("mm/") || DateFormat.Contains("mm-"))
            {
                DateFormat = DateFormat.Replace("mm", "MM");
            }
            if (DateFormat.Contains("DD/") || DateFormat.Contains("DD-") || DateFormat.Contains("-DD"))
            {
                DateFormat = DateFormat.Replace("DD", "dd");
                DateFormat = DateFormat.Replace("YYYY", "yyyy");
            }
            dateInfo.ShortDatePattern = DateFormat;
            System.DateTime newDate = default(System.DateTime);

            string toDate = txtDate;
            newDate = Convert.ToDateTime(toDate, dateInfo);
            return newDate;
        }


        public GuResult<string> TestMessage(string Name)
        {
            GuResult<string> ret = new GuResult<string>();
            ret.result = "Hello " + Name + " !!!";

            return ret;
        }


        public GuResult<List<MGeneralType>> GetGdList(string lang,string GdList)
        {
            string[] GdlstTmp = GdList.Split(',');
            GuResult<List<MGeneralType>> ret = new GuResult<List<MGeneralType>>();
            ret.result = new List<MGeneralType>();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT G.*,(CASE WHEN :LANG <> :LOCAL THEN NVL(DESC2,DESC1) ELSE DESC1 END) AS DESCR FROM GENERAL_DESC G WHERE GDTYPE = :GDTYPE ORDER BY COND2,GDCODE ");
            try
            {

                Database database = GetDB();
                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    List<MGeneralType> Objects = new List<MGeneralType>();
                    IDbCommand command = database.CreateCommand(sb.ToString(), conn);
                    if (GdlstTmp != null && GdlstTmp.Length > 0)
                    {
                        foreach (string Gd in GdlstTmp)
                        {
                            MGeneralType m = new MGeneralType();
                            m.GdType = Gd;
                            m.GdCodeLst = new List<MGeneralDesc>();
                            command.Parameters.Clear();
                            command.Parameters.Add(database.CreateParameter("LANG", lang));
                            command.Parameters.Add(database.CreateParameter("LOCAL", DefaultLang));
                            command.Parameters.Add(database.CreateParameter("GDTYPE", Gd));
                            IDataReader rdr = command.ExecuteReader();
                            while (rdr.Read())
                            {
                                MGeneralDesc n = new MGeneralDesc();
                                n.RetrieveFromDataReader(rdr);
                                m.GdCodeLst.Add(n);
                            }
                            Objects.Add(m);
                        }
                    }
                    command.Dispose();
                    conn.Close();
                    ret.result = Objects;
                    ret.IsComplete = true;
                };
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


        public GuResult<List<MLookupObj>> GetSubGdList(string MGdCode, string lang)
        {
            GuResult<List<MLookupObj>> ret = new GuResult<List<MLookupObj>>();
            string filtersql = string.Empty;
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LANG", lang);
            paramList.Add("LOCAL", DefaultLang);
            paramList.Add("MGDCODE", MGdCode);
            string sqlstr = ("SELECT GDCODE AS CODE ,(CASE WHEN :LANG <> :LOCAL THEN NVL(DESC2,DESC1) ELSE DESC1 END) AS NAME FROM GENERAL_DESC WHERE DESC5 = :MGDCODE ORDER BY COND2,GDCODE ");
            try
            {
                var dt = this.DoQuery(sqlstr, paramList, null, 0, 999999);
                ret.result = (List<MLookupObj>)dt.GetDTOs<MLookupObj>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public string GetFwInitValue(string program, string keyname)
        {

            string ret = string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT VALUE FROM FW_INIT WHERE PROGRAM_ID = '" + program + "'  AND KEY_NAME = '" + keyname + "'");
            try
            {
                Database database = GetDB();
                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    List<MGeneralType> Objects = new List<MGeneralType>();
                    IDbCommand command = database.CreateCommand(sb.ToString(), conn);

                    command.Parameters.Clear();
                    object tmp = command.ExecuteScalar();

                    if (tmp != null)
                    {
                        ret = (string)tmp;
                    }

                    command.Dispose();
                    conn.Close();
                };
            }
            catch (Exception ex)
            {
                ret = "";
                throw ex;
            }

            return ret;
        }

        public string convertDatetostring(System.DateTime pDate, string DateFormat)
        {
            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            if (DateFormat.Contains("mm/") || DateFormat.Contains("mm-"))
            {
                DateFormat = DateFormat.Replace("mm", "MM");
            }
            if (DateFormat.Contains("DD/") || DateFormat.Contains("DD-") || DateFormat.Contains("-DD"))
            {
                DateFormat = DateFormat.Replace("DD", "dd");
                DateFormat = DateFormat.Replace("YYYY", "yyyy");
            }
            string newDateStr = "";
            if (pDate != DateTime.MinValue)
            {
                newDateStr = pDate.ToString(DateFormat);
            }
            else
            {
                newDateStr = null;
            }

            return newDateStr;
        }


        public List<MasErrorMessage> GetMessageList(string lang)
        {
            List<MasErrorMessage> ret = new List<MasErrorMessage>();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT MSG.* FROM MAS_ERROR_MESSAGE MSG WHERE LANGUAGE_CODE = :LANG AND ERROR_ID LIKE 'CRM%'");
            try
            {
                Database database = GetDB();
                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    IDbCommand command = database.CreateCommand(sb.ToString(), conn);
                    command.Parameters.Clear();
                    command.Parameters.Add(database.CreateParameter("LANG", lang));
                    IDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        MasErrorMessage m = new MasErrorMessage();
                        m.RetrieveFromDataReader(rdr);
                        ret.Add(m);
                    }
                    command.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public string GetVisibilityString(string alias, string userid)
        {
            string ret = string.Empty;
            if (!string.IsNullOrEmpty(alias))
            {
                alias += ".";
            }
            ret = " (" + alias + "VISIBILE_TYPE = 'ALL' OR LOWER(" + alias + "CREATEUSER) = '%" + userid.ToLower() + "%' OR LOWER(" + alias + "VISIBILE_CD) LIKE '%" + userid.ToLower() + ";%' OR EXISTS(SELECT 1 FROM CRM_MAS_TEAM TE WHERE LOWER(TE.TEAM_ID) = LOWER(" + alias + "VISIBILE_CD) AND LOWER(TE.USER_ID) = '" + userid.ToLower() + "') )";
            return ret;
        }

        #region"GetUserOrTeam"
        public GuResult<List<MLookupObj>> GetUserOrTeam(string infotype, string txtFilter, string lang)
        {
            GuResult<List<MLookupObj>> ret = new GuResult<List<MLookupObj>>();

            if (infotype == "ASSTY_P")
            {
                GetUserList(ref ret, txtFilter, lang);
            }
            else
            {
                GetTeamList(ref ret, txtFilter, lang);
            }

            return ret;
        }
        public void GetUserList(ref GuResult<List<MLookupObj>> ret, string txtFilter, string lang)
        {
            string filtersql = string.Empty;
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LANG", lang);
            paramList.Add("LOCAL", DefaultLang);
            if (!string.IsNullOrEmpty(txtFilter))
            {
                filtersql = " (UPPER(NAME_LOC) LIKE  :TXTFILTER || '%' OR  UPPER(NAME_OTH) LIKE   :TXTFILTER || '%' ) AND  "; 
                paramList.Add("TXTFILTER", txtFilter);
            }
            string sqlstr = string.Format("SELECT CONTACT_ID AS CODE ,(CASE WHEN :LANG <> :LOCAL THEN NVL(NAME_OTH,NAME_LOC) ELSE NAME_LOC END) AS NAME FROM CRM_CONTACTS WHERE {0} 1 = 1 ORDER BY NAME " , filtersql);
            try
            {
                var dt = this.DoQuery(sqlstr, paramList, null, 0, 999999);
                ret.result = (List<MLookupObj>)dt.GetDTOs<MLookupObj>();
            }
            catch (Exception ex)
            { 
                throw ex;
            }

        }
        public void GetTeamList(ref GuResult<List<MLookupObj>> ret, string txtFilter, string lang)
        {
            string filtersql = string.Empty;
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LANG", lang);
            paramList.Add("LOCAL", DefaultLang);
            if (!string.IsNullOrEmpty(txtFilter))
            { 
                filtersql = " (UPPER(DESCR_LOC) LIKE   :TXTFILTER || '%' OR  UPPER(DESCR_OTH) LIKE  :TXTFILTER || '%' ) AND  ";
                paramList.Add("TXTFILTER", txtFilter);
            }

            string sqlstr = string.Format("SELECT DISTINCT TEAM_ID AS CODE ,(CASE WHEN :LANG <> :LOCAL THEN NVL(DESCR_OTH,DESCR_LOC) ELSE DESCR_LOC END) AS NAME FROM CRM_MAS_TEAM WHERE {0} 1 = 1 ORDER BY NAME", filtersql);
            try
            {
                var dt = this.DoQuery(sqlstr, paramList, null, 0, 999999);
                ret.result = (List<MLookupObj>)dt.GetDTOs<MLookupObj>();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        #endregion

        #region "Activity"


        #region "Add Activity"
        public int GetActivityId(IDbConnection conn)
        {
            int ret = 0;
            IDbCommand cmdSeq = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("select SEQ_CRM_ACTIVITIES.nextval from dual");
            cmdSeq = conn.CreateCommand();
            cmdSeq.CommandText = sb.ToString();
            object tmp = cmdSeq.ExecuteScalar();

            if (!(tmp is DBNull))
            {
                ret = Convert.ToInt32(tmp);
            }
            return ret;
        }

        public int GetMaxLinkSeqId(IDbConnection conn, int aId)
        {
            int ret = 0;
            IDbCommand cmdSeq = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("select max(SEQ) from CRM_ACTIVITIES_LINK WHERE A_ID = " + aId);
            cmdSeq = conn.CreateCommand();
            cmdSeq.CommandText = sb.ToString();
            object tmp = cmdSeq.ExecuteScalar();

            if (!(tmp is DBNull))
            {
                ret = Convert.ToInt32(tmp);
            }
            return ret;
        }


        public int GetTagId(IDbConnection conn)
        {
            int ret = 0;
            IDbCommand cmdSeq = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("select SEQ_CRM_ACTIVITIES_TAG.nextval from dual");
            cmdSeq = conn.CreateCommand();
            cmdSeq.CommandText = sb.ToString();
            object tmp = cmdSeq.ExecuteScalar();

            if (!(tmp is DBNull))
            {
                ret = Convert.ToInt32(tmp);
            }
            return ret;
        }
        public GuResult<int> InsertAcitvity(IDbConnection conn, IDbTransaction trn, MCrmActivities Obj, string user)
        {
            GuResult<int> ret = new GuResult<int>();
            int aId;
            DateTime _d = DateTime.Now;
            IDbCommand cmdAct = null;


            try
            {
                using (conn)
                {
                    aId = GetActivityId(conn);

                    cmdAct = conn.CreateCommand();
                    Obj.AId = aId;
                    Obj.Createuser = user;
                    Obj.Createdate = _d;
                    cmdAct = Obj.InsertCommand(conn);
                    cmdAct.Transaction = trn;
                    cmdAct.ExecuteNonQuery();



                    //if (Obj.LinkList != null && Obj.LinkList.Count > 0)
                    //{

                    //    foreach (CrmActivitiesLink l in Obj.LinkList)
                    //    {
                    //        InsertAcitvityLink(conn, trn, Obj.LinkList, user, "Y", aId);
                    //    }
                    //}

                    if (Obj.TagList != null && Obj.TagList.Count > 0)
                    {
                        InsertAcitvityTag(conn, trn, Obj.TagList, user, aId);

                    }
                    ret.result = aId;
                    ret.IsComplete = true;
                }
            }
            catch (Exception ex)
            {
                if (trn != null)
                {
                    trn.Rollback();
                }
                ret.result = -1;
                ret.IsComplete = false;
                ret.MsgText = ex.Message;
                throw ex;
            }

            return ret;
        }
        public GuResult<String> InsertAcitvityLink(IDbConnection conn, IDbTransaction trn, List<MCrmActivitiesLink> Obj, string user, string flagNew = "N", int aId = -1)
        {
            GuResult<String> ret = new GuResult<string>();
            IDbCommand cmdActLink = null;
            DateTime _d = DateTime.Now;
            int seq = 0;

            cmdActLink = conn.CreateCommand();
            cmdActLink.Transaction = trn;
            foreach (MCrmActivitiesLink l in Obj)
            {

                if (aId > -1)
                {
                    l.AId = aId;
                }
                if (flagNew == "N")
                {
                    seq = GetMaxLinkSeqId(conn, Convert.ToInt32(l.AId)) + 1;
                }
                else
                {
                    seq += 1;
                }

                l.Seq = seq;
                l.Createuser = user;
                l.Createdate = _d;
                cmdActLink = l.InsertCommand(conn);
                cmdActLink.ExecuteNonQuery();
            }
            ret.IsComplete = true;
            return ret;
        }

        public GuResult<String> DeleteAcitvityLink(IDbConnection conn, IDbTransaction trn, List<MCrmActivitiesLink> Obj)
        {
            GuResult<String> ret = new GuResult<string>();
            IDbCommand cmdActLink = null;
            cmdActLink = conn.CreateCommand();
            cmdActLink.Transaction = trn;
            foreach (MCrmActivitiesLink l in Obj)
            {
                cmdActLink = l.DeleteCommand(conn);
                cmdActLink.ExecuteNonQuery();
            }
            ret.IsComplete = true;
            return ret;
        }

        public GuResult<String> InsertAcitvityTag(IDbConnection conn, IDbTransaction trn, List<CrmActivitiesTag> Obj, string user, int aId = -1)
        {
            GuResult<String> ret = new GuResult<string>();
            IDbCommand cmdActTag = null;
            DateTime _d = DateTime.Now;

            cmdActTag = conn.CreateCommand();
            cmdActTag.Transaction = trn;
            foreach (CrmActivitiesTag t in Obj)
            {

                if (aId > -1)
                {
                    t.AId = aId;
                }
                t.TagId = GetTagId(conn);
                t.Createuser = user;
                t.Createdate = _d;
                cmdActTag = t.InsertCommand(conn);
                cmdActTag.ExecuteNonQuery();
            }
            ret.IsComplete = true;
            return ret;
        }

        public GuResult<String> DeleteAcitvityTag(IDbConnection conn, IDbTransaction trn, List<CrmActivitiesTag> Obj)
        {
            GuResult<String> ret = new GuResult<string>();
            IDbCommand cmdActTag = null;
            cmdActTag = conn.CreateCommand();
            cmdActTag.Transaction = trn;
            foreach (CrmActivitiesTag t in Obj)
            {
                cmdActTag = t.DeleteCommand(conn);
                cmdActTag.ExecuteNonQuery();
            }
            ret.IsComplete = true;
            return ret;
        }

        #endregion
        public GuResult<List<CrmActivitiesTag>> GetTagList(string activity, string alias, string userid)
        {
            GuResult<List<CrmActivitiesTag>> ret = new GuResult<List<CrmActivitiesTag>>();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM GENERAL_DESC WHERE GDTYPE = :GDTYPE ORDER BY COND2,GDCODE ");
            string sqlTags = string.Format("SELECT " + alias + ".TAG_ID ," + alias + ".A_ID ," + alias + ".ACTIVITY_CAT ," + alias + ".ACTIVITY_ID ," + alias + ".TAG_LABEL ," + alias + ".VISIBILE_TYPE ," + alias + ".VISIBILE_CD FROM CRM_ACTIVITIES_TAG " + alias + " WHERE {0} AND ACTIVITY_CAT = '" + activity + "' ", this.GetVisibilityString(alias, userid));
            try
            {

                Database database = GetDB();
                var dt2 = this.DoQuery(sqlTags, null, null, 0, 99999999);
                ret.result = (List<CrmActivitiesTag>)dt2.GetDTOs<CrmActivitiesTag>();
                ret.IsComplete = true;
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

        #region "Find ActivitiesList"
        public GuResult<MTimelineObjList> GetActivityByOwner(string ownercd, Int64 ownerid, string userid, Int64 curpage, string lang, string txtFilter, string activitiescd = "")
        {

            GuResult<MTimelineObjList> ret = new GuResult<MTimelineObjList>();
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LANG", lang);
            paramList.Add("LOCAL", DefaultLang);
            ret.result = new MTimelineObjList();
            ret.result.TimeObjList = new List<MTimelineObj>();
            string VisibleStr = this.GetVisibilityString("A", userid);
            string actfilter = string.Empty;
            string filter = string.Empty;
            ret.result.currRec = (int)curpage;
            ret.result.maxRec = CRM_Controller.maxrows;

            if (!string.IsNullOrEmpty(activitiescd))
            {
                actfilter = " A.ACTIVITY_CAT = :ACTIVITY_CAT AND ";
                paramList.Add("ACTIVITY_CAT", activitiescd);
            }

            paramList.Add("OWNER_CAT", ownercd);
            paramList.Add("OWNER_ID", ownerid);

            if (!string.IsNullOrEmpty(txtFilter))
            {
                //filter = " (UPPER(GD.DESC2) LIKE '%' || :TXTFILTER || '%' OR  UPPER(GD.DESC1) LIKE '%' || :TXTFILTER || '%' OR UPPER(A.TOPIC) LIKE '%' || :TXTFILTER || '%' OR  UPPER(A.DESCR1) LIKE '%' || :TXTFILTER || '%' ) AND  ";
                filter = " (UPPER(A.TOPIC) LIKE '%' || :TXTFILTER || '%' OR  UPPER(A.DESCR1) LIKE '%' || :TXTFILTER || '%'  OR  UPPER(A.DESCR2) LIKE '%' || :TXTFILTER || '%'  OR  UPPER(A.CREATEUSER) LIKE '%' || :TXTFILTER || '%' ) AND  ";
                paramList.Add(":TXTFILTER", txtFilter.ToUpper());
            }

            string sqlstr = "SELECT DISTINCT GD.DESC3 AS ICON_EVENT ,A.*, (CASE WHEN :LANG <> :LOCAL THEN NVL(GD.DESC2,GD.DESC1) ELSE GD.DESC1 END ) AS EVENT_NAME FROM CRM_ACTIVITIES A LEFT OUTER JOIN CRM_ACTIVITIES_LINK AK ON A.A_ID = AK.A_ID LEFT OUTER JOIN GENERAL_DESC GD ON GD.GDTYPE = 'ACCAT' AND A.ACTIVITY_CAT = GD.GDCODE WHERE {0} {1} ((A.OWNER_CAT = :OWNER_CAT AND A.OWNER_ID = :OWNER_ID) OR (AK.CATEGORY = :OWNER_CAT AND AK.LINK_ID = :OWNER_ID)) AND {2} ";
            string sqlcntstr = string.Format("SELECT COUNT(*) FROM ({0})", string.Format(sqlstr, filter, actfilter, VisibleStr));
            string sqlsearchstr = string.Format(sqlstr, filter, actfilter, VisibleStr) + "  ORDER BY A.Activity_Date DESC";

            try
            {
                ret.result.totalRec = (int)this.ExecuteScalar(sqlcntstr, paramList, null);
                var dt = this.DoQuery(sqlsearchstr, paramList, null, (int)curpage, CRM_Controller.maxrows);
                ret.result.TimeObjList = (List<MTimelineObj>)dt.GetDTOs<MTimelineObj>();
                foreach (MTimelineObj t in ret.result.TimeObjList)
                {
                    t.ActivitiesDtStr = t.ActivityDate.Value.ToString(DateStringformatAsp);
                    if (t.Priority != null && !string.IsNullOrEmpty(t.Priority))
                    {
                        switch (t.Priority)
                        {
                            case "1":
                                t.PriorityStr = "!";
                                break;
                            case "2":
                                t.PriorityStr = "!!";
                                break;
                            case "3":
                                t.PriorityStr = "!!!";
                                break;
                        }
                    }

                }
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


        public GuResult<List<MCrmActivitiesLink>> GetActivityLinkByOwner(string ownercd, Int64 ownerid, Int64 curpage, string lang)
        {
            GuResult<List<MCrmActivitiesLink>> ret = new GuResult<List<MCrmActivitiesLink>>();
            try
            {
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("LANG", lang);
                paramList.Add("LOCAL", CRM_Controller.DefaultLang);
                string sqlstr = "SELECT L.*,(  CASE WHEN :LANG <> :LOCAL THEN NVL(GDL.DESC2,GDL.DESC1) ELSE GDL.DESC1 END) AS RELATE_NAME, GDL.DESC4 AS ICON_PIC, GDAC.DESC5 AS TB_NAME FROM CRM_ACTIVITIES_LINK L LEFT OUTER JOIN GENERAL_DESC GDL ON GDL.GDTYPE = 'ACTRT' AND L.RELATE_CD =  GDL.GDCODE LEFT OUTER JOIN GENERAL_DESC GDAC ON GDAC.GDTYPE = 'ACCAT' AND L.CATEGORY =  GDAC.GDCODE WHERE L.ACTIVITY_CAT = '" + ownercd + "' AND L.ACTIVITY_ID = " + ownerid + " ";
                var dt = this.DoQuery(sqlstr, paramList, null, (int)curpage, CRM_Controller.maxrows);
                ret.result = (List<MCrmActivitiesLink>)dt.GetDTOs<MCrmActivitiesLink>();

                if (ret.result != null && ret.result.Count > 0)
                {
                    foreach (MCrmActivitiesLink l in ret.result)
                    {
                        string sqlstrName = "SELECT {0} FROM " + l.TbName + " WHERE A_ID = " + l.AId;
                        string colstr = "";
                        if (l.Category == "ACCATORG")
                        {
                            colstr = "(CASE WHEN '" + lang + "' <> '" + DefaultLang + "' THEN NVL(DESCR_OTH,DESCR_LOC) ELSE DESCR_LOC END) AS  LKNAME ";

                        }
                        else if (l.Category == "ACCATCONT")
                        {
                            colstr = "(CASE WHEN '" + lang + "' <> '" + DefaultLang + "' THEN NVL(NAME_OTH,NAME_LOC) ELSE NAME_LOC END) AS  LKNAME ";

                        }
                        else
                        {
                            colstr = "DESCR AS LKNAME ";
                        }
                        sqlstrName = string.Format(sqlstrName, colstr);

                        Database database = GetDB();
                        using (IDbConnection conn = database.CreateOpenConnection())
                        {
                            IDbCommand command = database.CreateCommand(sqlstrName, conn);

                            object tmpName = command.ExecuteScalar();

                            if (tmpName != null)
                            {
                                l.LinkName = (string)tmpName;
                            }

                            command.Dispose();
                            conn.Close();
                        };


                    }

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

        #endregion

        #region "Find By ActivitiesList Id"

        #endregion


        #endregion


    }



}
