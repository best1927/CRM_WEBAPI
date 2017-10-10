using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using SessionFactory;
using Authen_Lib;
using System.Web.Http;
public partial class LoginPage : System.Web.UI.Page
{
    private readonly string _ldapService = ConfigurationManager.AppSettings["LDAPService"];
    private readonly string _authenMode = ConfigurationManager.AppSettings["AuthenticationMode"].ToString();

    private readonly string _moduleCode = ConfigurationManager.AppSettings["ModuleCode"].ToString();
    private readonly string _defaultLanguage = ConfigurationManager.AppSettings["DefaultLanguage"].ToString();


    protected void Page_Load(object sender, EventArgs e)
    {
       
        lblErrorMessage.Visible = false;
        //Page.Title = @"SsF2F";
        txtUserId.Focus();

        if (IsPostBack) return;
        var sysLanguage = System.Globalization.CultureInfo.CurrentCulture.Name;
        MySession.Current.MyLanuage = sysLanguage.IndexOf("en", StringComparison.Ordinal) >= 0 ? LanguageType.Eng : LanguageType.Local;
        BindLanguage();
        rfvUserId.ErrorMessage = @"User Id is required!!!";
        rfvPassword.ErrorMessage = @"Password is required!!!";

        btnLoginAfterSelectOrg.Visible = false;
        btnCancel.Visible = false;
        pnlOrg.Visible = false;
        SessionFactory.MySession.Current.Schema = "";
    }

    public void BindLanguage()
    {
        switch (MySession.Current.MyLanuage)
        {
            case LanguageType.Local:
                ddlLanguage.DataTextField = "DESC_LOC";
                break;
            case LanguageType.Eng:
                ddlLanguage.DataTextField = "DESC_ENG";
                break;
            default:
                break;
        }

        ddlLanguage.DataValueField = "LANGUAGE_CODE";

        //var authen = new AuthenController();
        //ddlLanguage.DataSource = authen.GetLanguage();
        //ddlLanguage.DataBind();

        //ddlLanguage.SelectedValue = this._defaultLanguage;
    }

    private string LdapAuthen(string userId, string password)
    {
        try
        {
            if (!string.IsNullOrEmpty(_ldapService))
            {

                var adEntry = new DirectoryEntry
                {
                    Path = _ldapService,
                    Username = userId,
                    Password = password
                };
                var searcher = new DirectorySearcher(adEntry) { Filter = "(SAMAccountName=" + userId + ")" };

                var result = searcher.FindOne();

                if (result != null)
                {


                }

                return null;
            }
            else
            {
                return "LDAPService not specified in web.config";
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    #region Button_Click

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            var authenPass = false;
            var userId = txtUserId.Text.Trim();
            var password = txtPassword.Text.Trim();

            //var authen = new AuthenController();
            AuthenController  authen = null;
            if (_authenMode == "AD")
            {
                string err = null;
                err = this.LdapAuthen(userId, password);
                if (err == null)
                {
                    if (authen.CheckLocalUser(userId))
                    {
                        authenPass = true;
                    }
                    else
                    {
                        throw new Exception("Not found this user in system!");
                    }
                }
                else
                {
                    throw new Exception(err);
                }
            }
            else
            {
                if (authen.CheckLocalUser1(userId, password))
                {
                    authenPass = true;
                }
                else
                {
                    throw new Exception("User/Password incorrect!!!");
                }
            }

            if (!authenPass) return;
            MySession.Current.MyLanuageName = ddlLanguage.SelectedItem.Value;
            MySession.Current.MyLanuage = MySession.Current.MyLanuageName == "ENG" ? LanguageType.Eng : LanguageType.Local;

            switch (MySession.Current.MyLanuage)
            {
                case LanguageType.Local:
                    ddlOrgCode.DataTextField = "SHORT_NAME_LOC";
                    break;
                case LanguageType.Eng:
                    ddlOrgCode.DataTextField = "SHORT_NAME_ENG";
                    break;
            }

            ddlOrgCode.DataValueField = "ORG_CODE";


            var ctrl = new AuthenController();
            var list = ctrl.GetOrgByUser(_moduleCode, txtUserId.Text);
            ddlOrgCode.DataSource = list;
            ddlOrgCode.DataBind();

            switch (list.Count)
            {
                case 0:
                    throw new Exception("Not found Organization with this user!!!");
                case 1:
                    MySession.Current.ModuleCode = _moduleCode;
                    MySession.Current.LoginId = userId;
                    MySession.Current.OrgCode = ddlOrgCode.SelectedItem.Value;
                    MySession.Current.OrgName = ddlOrgCode.SelectedItem.Text;
                    MySession.Current.Schema = ctrl.GetOrgByPrimaryKey(MySession.Current.OrgCode).SCHEMA;
                    Response.Redirect("Default.aspx");
                    break;
                default:
                    if (list.Count > 1)
                    {
                        txtUserId.Enabled = false;
                        txtPassword.Enabled = false;
                        ddlLanguage.Enabled = false;
                        pnlOrg.Visible = true;
                        btnLogin.Visible = false;
                        btnLoginAfterSelectOrg.Visible = true;
                        btnCancel.Visible = true;
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message;
            lblErrorMessage.Visible = true;
        }
    }
    protected void btnLoginAfterSelectOrg_Click(object sender, EventArgs e)
    {
        try
        {
            var ctrl = new AuthenController();
            MySession.Current.ModuleCode = _moduleCode;
            MySession.Current.LoginId = txtUserId.Text.Trim();
            MySession.Current.OrgCode = ddlOrgCode.SelectedItem.Value;
            MySession.Current.OrgName = ddlOrgCode.SelectedItem.Text;
            MySession.Current.Schema = ctrl.GetOrgByPrimaryKey(MySession.Current.OrgCode).SCHEMA;
            Response.Redirect("Default.aspx");

        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message;
            lblErrorMessage.Visible = true;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlOrg.Visible = false;
        btnLogin.Visible = true;
        btnLoginAfterSelectOrg.Visible = false;
        btnCancel.Visible = false;
        txtUserId.Text = "";
        txtPassword.Text = "";

        txtUserId.Enabled = true;
        txtPassword.Enabled = true;
        ddlLanguage.Enabled = true;
        ddlOrgCode.Items.Clear();
    }

    #endregion
}