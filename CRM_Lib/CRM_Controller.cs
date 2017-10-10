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
    class CRM_Controller :  ICRM_Controller, IDbExecutable, IDisposable
    {

        public static Database _DB = null;
        public static string schemaConnection = ConfigurationManager.AppSettings["schemaConnection"].ToString();
        public static string dbName = ConfigurationManager.AppSettings["dbName"].ToString();
        public static string dbConnection = ConfigurationManager.AppSettings["dbConnection"].ToString();
        public static string dbType = ConfigurationManager.AppSettings["dbTypeConnection"].ToString();
        public static string rowtxt = ConfigurationManager.AppSettings["DefaultGridRow"].ToString();



        public static int maxrows =   !string.IsNullOrEmpty(rowtxt) ? Int32.Parse( rowtxt) : 20 ;  
        


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
            //    pCon = db.CreateConnection();
            //}
            ret = db.ExecuteNonQuery( SQLString, Params, Transaction);
            return ret;
        }

        public decimal  ExecuteScalar(string SQLString, Dictionary<string, object> Params = null, IDbSimplyTransaction Transaction = null)
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
          
            ret = db.ExecuteScalar( SQLString, Params, Transaction);
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


        public GuResult<List<MGeneralType>> GetGdList(String GdList)
        {
            string[] GdlstTmp = GdList.Split(',');
            GuResult<List<MGeneralType>> ret = new GuResult<List<MGeneralType>>();
            ret.result = new List<MGeneralType>();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM GENERAL_DESC WHERE GDTYPE = :GDTYPE ORDER BY COND2,GDCODE ");
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
                            m.GdCodeLst = new List<GeneralDesc>();
                            command.Parameters.Clear();
                            command.Parameters.Add(database.CreateParameter("GDTYPE", Gd));
                            IDataReader rdr = command.ExecuteReader();
                            while (rdr.Read())
                            {
                                GeneralDesc n = new GeneralDesc();
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
            ret = "(" + alias + "VISIBILE_TYPE = 'ALL' OR LOWER(" + alias + "CREATEUSER) = '%" + userid.ToLower() + "%' OR LOWER(" + alias + "VISIBILE_CD) LIKE '%" + userid.ToLower() + ";%' OR EXISTS(SELECT 1 FROM CRM_MAS_TEAM TE WHERE LOWER(TE.TEAM_ID) = LOWER(" + alias + "VISIBILE_CD) AND LOWER(TE.USER_ID) = '" + userid.ToLower() + "') )";
            return ret;
        }

      
    }



}
