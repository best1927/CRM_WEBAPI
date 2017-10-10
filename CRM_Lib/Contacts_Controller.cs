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

namespace CRM_Lib
{
    class Contacts_Controller :  IContacts_Controller
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

        private void InsertContacts(MCrmContacts Obj, string user, ref GuResult<string> ret)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select SEQ_CRM_CONTACTS.nextval from dual");
            IDbCommand cmd1 = null;
            IDbCommand cmd2 = null;
            IDbCommand cmd3 = null;
            IDbCommand cmd4 = null;
            IDbCommand cmd5 = null;
            IDbCommand cmd6 = null;
            IDbCommand cmdSeq = null;
            IDbTransaction trn = null;
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
                    Obj.Createuser = user;
                    Obj.Createdate = DateTime.Now;
                    cmd1 = Obj.InsertCommand(conn);
                    cmd1.Transaction = trn;
                    cmd1.ExecuteNonQuery();

                    //Insert CRM_CONTACTS_Ani
                    if (Obj.ConAnniversarylst != null && Obj.ConAnniversarylst.Count > 0)
                    {
                        foreach (CrmContactsAnniversary a in Obj.ConAnniversarylst)
                        {
                            a.ContactId = Obj.ContactId;
                            a.Createuser = user;
                            a.Createdate = DateTime.Now;
                            cmd2 = a.InsertCommand(conn);
                            cmd2.Transaction = trn;
                            cmd2.ExecuteNonQuery();

                        }
                    }

                    //Insert CRM_CONTACTS_Link
                    if (Obj.ConLinklst != null && Obj.ConLinklst.Count > 0)
                    {
                        foreach (CrmContactsLink b in Obj.ConLinklst)
                        {
                            b.ContactId = Obj.ContactId;
                            b.Createuser = user;
                            b.Createdate = DateTime.Now;
                            cmd3 = b.InsertCommand(conn);
                            cmd3.Transaction = trn;
                            cmd3.ExecuteNonQuery();
                        }
                    }

                    //Insert CRM_CONTACTS_Relate
                    if (Obj.ConRelatelst != null && Obj.ConRelatelst.Count > 0)
                    {
                        foreach (CrmContactsRelative c in Obj.ConRelatelst)
                        {
                            c.ContactId = Obj.ContactId;
                            c.Createuser = user;
                            c.Createdate = DateTime.Now;
                            cmd4 = c.InsertCommand(conn);
                            cmd4.Transaction = trn;
                            cmd4.ExecuteNonQuery();
                        }
                    }


                    //Insert CRM_CONTACTS_Social
                    if (Obj.ConSociallst != null && Obj.ConSociallst.Count > 0)
                    {
                        foreach (CrmContactsSocial d in Obj.ConSociallst)
                        {
                            d.ContactId = Obj.ContactId;
                            d.Createuser = user;
                            d.Createdate = DateTime.Now;
                            cmd5 = d.InsertCommand(conn);
                            cmd5.Transaction = trn;
                            cmd5.ExecuteNonQuery();
                        }
                    }

                    //Insert CRM_CONTACTS Visibility
                    if (Obj.ConVisiblelst != null && Obj.ConVisiblelst.Count > 0)
                    {
                        foreach (CrmContactsVisibility e in Obj.ConVisiblelst)
                        {
                            e.ContactId = Obj.ContactId;
                            e.Createuser = user;
                            e.Createdate = DateTime.Now;
                            cmd6 = e.InsertCommand(conn);
                            cmd6.Transaction = trn;
                            cmd6.ExecuteNonQuery();
                        }
                    }


                    trn.Commit();
                    cmd1.Dispose();
                    cmd2.Dispose();
                    cmd3.Dispose();
                    cmd4.Dispose();
                    cmd5.Dispose();
                    cmd6.Dispose();
                    conn.Close();
                    ret.result = CRMMessageEnum.MessageEnum.MessageDataResponse.SaveCompleted.ToString();
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

        private void UpdateContacts(MCrmContacts Obj, string user, ref GuResult<string> ret)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select SEQ_CRM_CONTACTS.nextval from dual");
            IDbCommand cmd1 = null;
            IDbCommand cmd2 = null;
            IDbCommand cmd3 = null;
            IDbCommand cmd4 = null;
            IDbCommand cmd5 = null;
            IDbCommand cmd6 = null;
            IDbTransaction trn = null;
            try
            {
                Database database = CRM_Controller.GetDB();
                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    trn = conn.BeginTransaction();


                    //Update CRM_CONTACTS
                    Obj.Modifyuser = user;
                    Obj.Modifydate = DateTime.Now;
                    cmd1 = Obj.UpdateCommand(conn, "Createuser,Createdate");
                    cmd1.Transaction = trn;
                    cmd1.ExecuteNonQuery();

                    //Update CRM_CONTACTS_Ani
                    if (Obj.ConAnniversarylst != null && Obj.ConAnniversarylst.Count > 0)
                    {
                        foreach (CrmContactsAnniversary a in Obj.ConAnniversarylst)
                        {
                            if (a.EntityState == SsCommon.EntityStateLocal.Added)
                            {
                                a.Createuser = user;
                                a.Createdate = DateTime.Now;
                                cmd2 = a.InsertCommand(conn);
                            }
                            else if (a.EntityState == SsCommon.EntityStateLocal.Modified)
                            {
                                a.Modifyuser = user;
                                a.Modifydate = DateTime.Now;
                                cmd2 = a.UpdateCommand(conn, "Createuser,Createdate");
                            }
                            cmd2.Transaction = trn;
                            cmd2.ExecuteNonQuery();
                        }
                    }

                    //Insert CRM_CONTACTS_Link
                    if (Obj.ConLinklst != null && Obj.ConLinklst.Count > 0)
                    {
                        foreach (CrmContactsLink b in Obj.ConLinklst)
                        {
                            if (b.EntityState == SsCommon.EntityStateLocal.Added)
                            {
                                b.Createuser = user;
                                b.Createdate = DateTime.Now;
                                cmd3 = b.InsertCommand(conn);
                            }
                            else if (b.EntityState == SsCommon.EntityStateLocal.Modified)
                            {
                                b.Modifyuser = user;
                                b.Modifydate = DateTime.Now;
                                cmd3 = b.UpdateCommand(conn, "Createuser,Createdate");
                            }
                            cmd3.Transaction = trn;
                            cmd3.ExecuteNonQuery();
                        }
                    }

                    //Insert CRM_CONTACTS_Relate
                    if (Obj.ConRelatelst != null && Obj.ConRelatelst.Count > 0)
                    {
                        foreach (CrmContactsRelative c in Obj.ConRelatelst)
                        {
                            if (c.EntityState == SsCommon.EntityStateLocal.Added)
                            {
                                c.Createuser = user;
                                c.Createdate = DateTime.Now;
                                cmd4 = c.InsertCommand(conn);
                            }
                            else if (c.EntityState == SsCommon.EntityStateLocal.Modified)
                            {
                                c.Modifyuser = user;
                                c.Modifydate = DateTime.Now;
                                cmd4 = c.UpdateCommand(conn, "Createuser,Createdate");
                            }
                            cmd4.Transaction = trn;
                            cmd4.ExecuteNonQuery();
                        }

                    }


                    //Insert CRM_CONTACTS_Social
                    if (Obj.ConSociallst != null && Obj.ConSociallst.Count > 0)
                    {
                        foreach (CrmContactsSocial d in Obj.ConSociallst)
                        {
                            if (d.EntityState == SsCommon.EntityStateLocal.Added)
                            {
                                d.Createuser = user;
                                d.Createdate = DateTime.Now;
                                cmd5 = d.InsertCommand(conn);
                            }
                            else if (d.EntityState == SsCommon.EntityStateLocal.Modified)
                            {
                                d.Modifyuser = user;
                                d.Modifydate = DateTime.Now;
                                cmd5 = d.UpdateCommand(conn, "Createuser,Createdate");
                            }
                            cmd5.Transaction = trn;
                            cmd5.ExecuteNonQuery();
                        }
                    }

                    //Insert CRM_CONTACTS Visibility
                    if (Obj.ConVisiblelst != null && Obj.ConVisiblelst.Count > 0)
                    {
                        foreach (CrmContactsVisibility e in Obj.ConVisiblelst)
                        {
                            if (e.EntityState == SsCommon.EntityStateLocal.Added)
                            {
                                e.Createuser = user;
                                e.Createdate = DateTime.Now;
                                cmd6 = e.InsertCommand(conn);
                            }
                            else if (e.EntityState == SsCommon.EntityStateLocal.Modified)
                            {
                                e.Modifyuser = user;
                                e.Modifydate = DateTime.Now;
                                cmd6 = e.UpdateCommand(conn, "Createuser,Createdate");
                            }
                            cmd6.Transaction = trn;
                            cmd6.ExecuteNonQuery();
                        }
                    }


                    trn.Commit();
                    cmd1.Dispose();
                    cmd2.Dispose();
                    cmd3.Dispose();
                    cmd4.Dispose();
                    cmd5.Dispose();
                    cmd6.Dispose();
                    conn.Close();
                    ret.result = CRMMessageEnum.MessageEnum.MessageDataResponse.SaveCompleted.ToString();
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

        public GuResult<MSearchContacts> SearchContacts(string Alphabetfilter, string Combofilter, string txtFilter, string userid, string lang, string local, string tagstr, long curpage, long maxRec)
        {
            throw new NotImplementedException();
        }
    }
}
