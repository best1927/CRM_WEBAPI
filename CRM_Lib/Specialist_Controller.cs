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
    class Specialist_Controller : DataWorker, ISpecialist_Controller
    {


        public GuResult<string> TestMessage(string Name)
        {
            GuResult<string> ret = new GuResult<string>();
            ret.result = "Hello " + Name + " !!!";

            return ret;
        }

        public GuResult<List<CrmSpecialist>> GetLstOfSpeciallist(string lang, string local, string txtFilter)
        {
            GuResult<List<CrmSpecialist>> ret = new GuResult<List<CrmSpecialist>>();
            StringBuilder sb = new StringBuilder();
            try
            {
                List<CrmSpecialist> Objects = new List<CrmSpecialist>();
                sb.Append("SELECT C.CONTACT_ID , ( CASE WHEN :LANG <> :LOCAL THEN NVL(C.NAME_OTH,NAME_LOC) ELSE C.NAME_LOC END) AS CONTACTNAME, C.POSITION_DESC, C.DEPT_DESC, C.ORGANIZE_ID, ( CASE WHEN :LANG <> :LOCAL THEN NVL(O.DESCR_OTH,O.DESCR_LOC) ELSE O.DESCR_LOC END) AS ORGANIZENAME, C.SPECIALIST, C.EMAIL, C.PHONE_MOBILE || ' , ' || C.PHONE_OFFICE AS TEL FROM CRM_CONTACTS C INNER JOIN CRM_ORGANIZATION O ON C.ORGANIZE_ID   = O.ORGANIZE_ID WHERE C.CONTACT_ST = 'A' AND C.SUGGESTION   = 'Y'");

                using (IDbConnection conn = database.CreateOpenConnection())
                {
                    IDbCommand command = database.CreateCommand(sb.ToString(), conn);
                    command.Parameters.Add(database.CreateParameter("LANG", lang));
                    command.Parameters.Add(database.CreateParameter("LOCAL", local));

                    IDataReader rdr = command.ExecuteReader();
                    do
                    {
                        CrmSpecialist m = new CrmSpecialist();
                        m.RetrieveFromDataReader(rdr);
                        Objects.Add(m);
                        command.Dispose();
                        conn.Close();

                    } while (rdr.Read());

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
        

    }
}
