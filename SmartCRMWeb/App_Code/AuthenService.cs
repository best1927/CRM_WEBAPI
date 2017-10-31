using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using Authen_Lib;
using System.Collections.Specialized;
using System.Web;
using SessionFactory;
using System.Configuration;

using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class AuthenService
{


    [OperationContract]
    [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "GET")]
    public string GetUser()
    {
        try
        {
            NameValueCollection nvc = HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query);

            var sEcho = nvc["sEcho"];
            var iDisplayStart = Convert.ToInt32(nvc["iDisplayStart"]);
            var iDisplayLength = Convert.ToInt32(nvc["iDisplayLength"]);
            var iSortCol = Convert.ToInt32(nvc["iSortCol_0"]);
            var isAsc = nvc["sSortDir_0"] == "asc";
            var sSearch = nvc["sSearch"];

            var PageIndex = iDisplayStart == 0 ? 1 : (iDisplayStart / iDisplayLength) + 1;
            var PageEnd = PageIndex * iDisplayLength;
            var PageStart = (PageEnd - iDisplayLength) + 1;

            AuthenController ctrl = new AuthenController();
            int RecordCount = ctrl.GetCountUser(sSearch);

            List<MAS_USERSerializeProperties> coll = ctrl.GetUserWithPaging(sSearch, PageStart, PageEnd);

            var ret = coll.Select(p => new
            {
                Code = p.USER_ID,
                NameEng = p.USER_NAME_ENG,
                NameLoc = p.USER_NAME_LOC,
                PhoneNo = p.PHONE_NO,
                Email = p.EMAIL,
                CCA = p.CCA,
                ServiceKey = p.CCA_SERVICEKEY,
                Signature = p.SIGNATURE,
                DepartmentName = p.DEPARTMENT_NAME
            }).ToList();

            var dtPage = new SysDataTablePager();
            dtPage.sEcho = sEcho;
            dtPage.iTotalRecords = RecordCount;
            dtPage.iTotalDisplayRecords = RecordCount;
            dtPage.aaData = ret.Select(c => (object)c).ToList();

            return JsonConvert.SerializeObject(dtPage);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool CheckDup(string userId)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            int ret = int.Parse(ctrl.CheckDup(userId));
            if (ret > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetUserByOrg(string ORG_CODE)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return JsonConvert.SerializeObject(ctrl.GetUserByOrg(ORG_CODE));
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetUserByPrimaryKey(string userId)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            MAS_USERSerializeProperties obj = ctrl.GetUserByPrimaryKey(userId);
            object ret = new
            {
                Code = obj.USER_ID,
                Pwd = obj.PASSWORD,
                NameEng = obj.USER_NAME_ENG,
                NameLoc = obj.USER_NAME_LOC,
                PhoneNo = obj.PHONE_NO == "" ? "N/A" : obj.PHONE_NO,
                Email = obj.EMAIL == "" ? "N/A" : obj.EMAIL,
                CCA = obj.CCA == "" ? "N/A" : obj.CCA,
                ServiceKey = obj.CCA_SERVICEKEY == "" ? "N/A" : obj.CCA_SERVICEKEY,
                CancelFlag = obj.CANCEL_FLAG == "" ? "N" : obj.CANCEL_FLAG,
                DepartmentName = obj.DEPARTMENT_NAME
            };
            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool AddNewUser(MAS_USERSerializeProperties values)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.AddNewUser(values, MySession.Current.LoginId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool UpdateUser(MAS_USERSerializeProperties values)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.UpdateUser(values, MySession.Current.LoginId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool DeleteUser(string userId)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.DeleteUser(userId, MySession.Current.ModuleCode);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "GET")]
    public string GetOrganization()
    {
        try
        {
            NameValueCollection nvc = HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query);

            var sEcho = nvc["sEcho"];
            var iDisplayStart = Convert.ToInt32(nvc["iDisplayStart"]);
            var iDisplayLength = Convert.ToInt32(nvc["iDisplayLength"]);
            var iSortCol = Convert.ToInt32(nvc["iSortCol_0"]);
            var isAsc = nvc["sSortDir_0"] == "asc";
            var sSearch = nvc["sSearch"];

            var PageIndex = iDisplayStart == 0 ? 1 : (iDisplayStart / iDisplayLength) + 1;
            var PageEnd = PageIndex * iDisplayLength;
            var PageStart = (PageEnd - iDisplayLength) + 1;

            AuthenController ctrl = new AuthenController();
            MAS_ORGSerializeProperties org = ctrl.GetOrgByPrimaryKey(MySession.Current.OrgCode);
            int RecordCount = ctrl.GetCountOrg(sSearch, MySession.Current.Schema, org.CENTER_ORG);
            List<MAS_ORGSerializeProperties> coll = ctrl.GetOrgWithPaging(sSearch, PageStart, PageEnd, MySession.Current.Schema, org.CENTER_ORG);

            var ret = coll.Select(p => new
            {

                OrgCode = p.ORG_CODE,
                OrgNameEng = p.ORG_NAME_ENG,
                OrgNameLoc = p.ORG_NAME_LOC,
                ShortNameEng = p.SHORT_NAME_ENG,
                ShortNameLoc = p.SHORT_NAME_LOC,
                Schema = p.SCHEMA,
                CenterOrg = p.CENTER_ORG
            }).ToList();

            var dtPage = new SysDataTablePager();
            dtPage.sEcho = sEcho;
            dtPage.iTotalRecords = RecordCount;
            dtPage.iTotalDisplayRecords = RecordCount;
            dtPage.aaData = ret.Select(c => (object)c).ToList();

            return JsonConvert.SerializeObject(dtPage);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetOrgByPrimaryKey(string ORG_CODE)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            MAS_ORGSerializeProperties obj = ctrl.GetOrgByPrimaryKey(ORG_CODE);
            object ret = new
            {
                OrgCode = obj.ORG_CODE,
                OrgNameEng = obj.ORG_NAME_ENG,
                OrgNameLoc = obj.ORG_NAME_LOC,
                ShortNameEng = obj.SHORT_NAME_ENG,
                ShortNameLoc = obj.SHORT_NAME_LOC,
                Schema = obj.SCHEMA,
                CenterOrg = obj.CENTER_ORG
            };
            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool CheckDupOrg(string ORG_CODE)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            int ret = ctrl.CheckDupOrg(ORG_CODE);
            if (ret > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool AddNewOrg(MAS_ORGSerializeProperties values)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.AddNewOrg(values);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool UpdateOrg(MAS_ORGSerializeProperties values)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.UpdateOrg(values);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool DeleteOrg(string ORG_CODE)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.DeleteOrg(ORG_CODE, MySession.Current.ModuleCode);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "GET")]
    public string GetGroup()
    {
        try
        {
            NameValueCollection nvc = HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query);

            var sEcho = nvc["sEcho"];
            var iDisplayStart = Convert.ToInt32(nvc["iDisplayStart"]);
            var iDisplayLength = Convert.ToInt32(nvc["iDisplayLength"]);
            var iSortCol = Convert.ToInt32(nvc["iSortCol_0"]);
            var isAsc = nvc["sSortDir_0"] == "asc";
            var sSearch = nvc["sSearch"];
            var OrgCode = nvc["OrgCode"];

            var PageIndex = iDisplayStart == 0 ? 1 : (iDisplayStart / iDisplayLength) + 1;
            var PageEnd = PageIndex * iDisplayLength;
            var PageStart = (PageEnd - iDisplayLength) + 1;

            AuthenController ctrl = new AuthenController();
            int RecordCount = ctrl.GetCountGroup(sSearch, OrgCode);

            List<MAS_GROUP_USERSerializeProperties> coll = ctrl.GetGroupWithPaging(sSearch, OrgCode, PageStart, PageEnd);

            var ret = coll.Select(p => new
            {
                OrgCode = p.ORG_CODE,
                Code = p.GROUP_USER,
                NameEng = p.DESC_ENG,
                NameLoc = p.DESC_LOC
            }).ToList();

            var dtPage = new SysDataTablePager();
            dtPage.sEcho = sEcho;
            dtPage.iTotalRecords = RecordCount;
            dtPage.iTotalDisplayRecords = RecordCount;
            dtPage.aaData = ret.Select(c => (object)c).ToList();

            return JsonConvert.SerializeObject(dtPage);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetOrgByOrgCode(string ORG_CODE)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            MAS_ORGSerializeProperties obj = ctrl.GetOrgByPrimaryKey(ORG_CODE);
            if (obj != null)
            {
                object ret = new
                {
                    OrgCode = obj.ORG_CODE,
                    OrgName = MySession.Current.MyLanuage == LanguageType.Eng ? obj.ORG_NAME_ENG : obj.ORG_NAME_LOC
                };
                return JsonConvert.SerializeObject(ret);
            }
            else return "";
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetGroupByPrimaryKey(string ORG_CODE, string GROUP_USER)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            MAS_GROUP_USERSerializeProperties obj = ctrl.GetGroupByPrimaryKey(ORG_CODE, GROUP_USER);
            object ret = new
            {
                OrgCode = obj.ORG_CODE,
                Code = obj.GROUP_USER,
                NameEng = obj.DESC_ENG,
                NameLoc = obj.DESC_LOC
            };
            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool CheckDupGroup(string ORG_CODE, string GROUP_USER)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            int ret = ctrl.CheckDupGroup(ORG_CODE, GROUP_USER);
            if (ret > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool AddNewGroup(MAS_GROUP_USERSerializeProperties values)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.AddNewGroup(values, MySession.Current.LoginId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool UpdateGroup(MAS_GROUP_USERSerializeProperties values)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.UpdateGroup(values, MySession.Current.LoginId);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool DeleteGroup(string ORG_CODE, string GROUP_USER)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.DeleteGroup(ORG_CODE, GROUP_USER);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetGroupDetailByPrimaryKey(string ORG_CODE, string GROUP_USER)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            MAS_GROUP_USERSerializeProperties obj = ctrl.GetGroupByPrimaryKey(ORG_CODE, GROUP_USER);
            string groupName = MySession.Current.MyLanuage == LanguageType.Eng ? obj.DESC_ENG : obj.DESC_LOC;
            MAS_ORGSerializeProperties objOrg = ctrl.GetOrgByPrimaryKey(ORG_CODE);
            string orgName = MySession.Current.MyLanuage == LanguageType.Eng ? objOrg.ORG_NAME_ENG : objOrg.ORG_NAME_LOC;

            object ret = new
            {
                GroupName = groupName,
                OrgName = orgName
            };
            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "GET")]
    public string GetGroupUser()
    {
        try
        {
            NameValueCollection nvc = HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query);

            var sEcho = nvc["sEcho"];
            var iDisplayStart = Convert.ToInt32(nvc["iDisplayStart"]);
            var iDisplayLength = Convert.ToInt32(nvc["iDisplayLength"]);
            var iSortCol = Convert.ToInt32(nvc["iSortCol_0"]);
            var isAsc = nvc["sSortDir_0"] == "asc";
            var sSearch = nvc["sSearch"];
            var OrgCode = nvc["OrgCode"];
            var GroupCode = nvc["GroupCode"];
            var iExisting = nvc["iExisting"];

            var PageIndex = iDisplayStart == 0 ? 1 : (iDisplayStart / iDisplayLength) + 1;
            var PageEnd = PageIndex * iDisplayLength;
            var PageStart = (PageEnd - iDisplayLength) + 1;

            AuthenController ctrl = new AuthenController();
            int RecordCount = ctrl.GetCountGroupUser(sSearch, OrgCode, GroupCode, iExisting);

            List<MAS_USERSerializeProperties> coll = ctrl.GetGroupUserWithPaging(sSearch, OrgCode, GroupCode, iExisting, PageStart, PageEnd);

            var ret = coll.Select(p => new
            {
                Code = p.USER_ID,
                NameEng = p.USER_NAME_ENG,
                NameLoc = p.USER_NAME_LOC
            }).ToList();

            var dtPage = new SysDataTablePager();
            dtPage.sEcho = sEcho;
            dtPage.iTotalRecords = RecordCount;
            dtPage.iTotalDisplayRecords = RecordCount;
            dtPage.aaData = ret.Select(c => (object)c).ToList();

            return JsonConvert.SerializeObject(dtPage);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetRootMenu()
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            List<MAS_PROGRAMSerializeProperties> ret = ctrl.GetRootMenu(MySession.Current.ModuleCode, MySession.Current.Schema);

            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetUserPermissionByGroup(string ORG_CODE, string GROUP_ID)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            List<MAS_PROGRAMSerializeProperties> ret = ctrl.GetUserPermissionByGroup(MySession.Current.ModuleCode, ORG_CODE, GROUP_ID, MySession.Current.Schema);

            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetUserPermissionByRoot(string ORG_CODE, string GROUP_ID, string PROGRAM_CODE)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            List<MAS_PROGRAMSerializeProperties> ret = ctrl.GetUserPermissionByRoot(MySession.Current.ModuleCode, ORG_CODE, GROUP_ID, PROGRAM_CODE, MySession.Current.Schema);

            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool AddUserToGroup(string ORG_CODE, string GROUP_USER, string USER_ID)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.AddUserToGroup(ORG_CODE, GROUP_USER, USER_ID, MySession.Current.LoginId, MySession.Current.ModuleCode);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool RemoveUserFromGroup(string ORG_CODE, string GROUP_USER, string USER_ID)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.RemoveUserFromGroup(ORG_CODE, GROUP_USER, USER_ID, MySession.Current.LoginId, MySession.Current.ModuleCode);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool AddGroupToPermission(string ORG_CODE, string GROUP_USER, string PROGRAM_CODE)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.AddGroupToPermission(ORG_CODE, GROUP_USER, PROGRAM_CODE, MySession.Current.LoginId, MySession.Current.ModuleCode, MySession.Current.Schema);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool RemoveGroupFromPermission(string ORG_CODE, string GROUP_USER, string PROGRAM_CODE)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.RemoveGroupFromPermission(ORG_CODE, GROUP_USER, PROGRAM_CODE, MySession.Current.ModuleCode, MySession.Current.Schema);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetMenu()
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            List<MAS_PROGRAMSerializeProperties> coll = ctrl.GetMenu(MySession.Current.ModuleCode, MySession.Current.Schema);

            var ret = coll.Select(p => new
            {
                p.PROGRAM_CODE,
                p.PARENT_PROGRAM_CODE,
                p.NODE_LEVEL,
                p.SEQ_NO,
                DESC_NAME = MySession.Current.MyLanuage == LanguageType.Eng ? p.DESC_ENG : p.DESC_LOC
            }).ToList();
            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string AddNewProgramAndMenu(MAS_PROGRAMSerializeProperties values)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            bool ret = ctrl.AddNewProgramAndMenu(MySession.Current.ModuleCode, MySession.Current.Schema, values);
            if (MySession.Current.MyLanuage == LanguageType.Eng)
                return values.DESC_ENG;
            else
                return values.DESC_LOC;
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetProgramByPrimaryKey(string PROGRAM_CODE)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            MAS_PROGRAMSerializeProperties ret = ctrl.GetProgramByPrimaryKey(PROGRAM_CODE, MySession.Current.Schema);

            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string UpdateProgram(MAS_PROGRAMSerializeProperties values)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            bool ret = ctrl.UpdateProgram(values, MySession.Current.Schema);
            if (MySession.Current.MyLanuage == LanguageType.Eng)
                return values.DESC_ENG;
            else
                return values.DESC_LOC;
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool UpdateMenu(List<MAS_PROGRAMSerializeProperties> values)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.UpdateMenu(MySession.Current.ModuleCode, MySession.Current.Schema, values);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool DeleteProgram(List<String> PROGRAM_CODE)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.DeleteProgram(MySession.Current.ModuleCode, PROGRAM_CODE, MySession.Current.Schema);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetProgramList()
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            MAS_ORGSerializeProperties org = ctrl.GetOrgByPrimaryKey(MySession.Current.OrgCode);
            List<MAS_PROGRAMSerializeProperties> coll = ctrl.GetProgramList(MySession.Current.Schema, org.CENTER_ORG);
            var ret = coll.Select(p => new
            {
                p.PROGRAM_CODE,
                p.PROGRAM_PATH,
                PROGRAM_NAME = MySession.Current.MyLanuage == LanguageType.Eng ? p.DESC_ENG : p.DESC_LOC
            }).ToList();
            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetLanguageList()
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            List<MAS_LANGUAGESerializeProperties> coll = ctrl.GetLanguage();
            var ret = coll.Select(p => new
            {
                p.LANGUAGE_CODE,
                LANGUAGE_NAME = MySession.Current.MyLanuage == LanguageType.Eng ? p.DESC_ENG : p.DESC_LOC
            }).ToList();
            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetScreenProfileByLang(string programCode, string langCode)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            List<MAS_SCREEN_PROFILESerializeProperties> ret = ctrl.GetScreenProfile(MySession.Current.ModuleCode, programCode, langCode);

            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetScreenProfile(string programCode)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            List<MAS_SCREEN_PROFILESerializeProperties> ret = ctrl.GetScreenProfile(MySession.Current.ModuleCode, programCode, MySession.Current.MyLanuageName);

            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool SetScreenProfile(List<MAS_SCREEN_PROFILESerializeProperties> values)
    {
        try
        {
            AuthenController ctrl = new AuthenController();
            return ctrl.SetScreenProfile(MySession.Current.ModuleCode, values);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public string GetModule()
    {
        try
        {
            string ModuleCode = ConfigurationManager.AppSettings["ModuleCode"].ToString();
            AuthenController ctrl = new AuthenController();
            List<MAS_MODULESerializeProperties> ret = ctrl.GetModule(ModuleCode);

            return JsonConvert.SerializeObject(ret);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool AddNewModule(MAS_MODULESerializeProperties values)
    {
        try
        {
            string schema = ConfigurationManager.AppSettings["stdSchema"].ToString();
            AuthenController ctrl = new AuthenController();
            return ctrl.AddNewModule(values, schema);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool AddNewUserOnRegister(MAS_USERSerializeProperties USER, string MODULE_CODE)
    {
        try
        {
            string schema = ConfigurationManager.AppSettings["stdSchema"].ToString();
            AuthenController ctrl = new AuthenController();
            return ctrl.AddNewUserOnRegister(USER, MODULE_CODE, schema);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [OperationContract]
    public bool CheckOrgRegister()
    {
        try
        {
            string schema = ConfigurationManager.AppSettings["stdSchema"].ToString();
            AuthenController ctrl = new AuthenController();
            return ctrl.CheckOrgRegister(schema);
        }
        catch (Exception)
        {
            throw;
        }
    }


}


