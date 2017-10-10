using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SessionFactory;

public partial class master_Site : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        // FOR DEBUG
//#if DEBUG
//            //MySession.Current.LoginId = "Tiwa.nak";
//            //MySession.Current.ModuleCode = "PACKAGE001";
//            //MySession.Current.OrgCode = "300399";
//            //MySession.Current.Schema = "FEED";
//            //MySession.Current.MyLanuageName = "THA";
//#endif

        if (MySession.Current.LoginId == null)
        {
            Response.Redirect("SessionExpired.aspx");
        }
        string programCode = Page.ToString().Replace("ASP.", "").Replace("_", ".").Replace(".aspx", "");
        if (!IsPostBack)
        {
            Authen_Lib.IAuthenticate aCtrl = new Authen_Lib.AuthenController();

            List<Authen_Lib.MAS_MODULESerializeProperties> mdl = aCtrl.GetModule(MySession.Current.ModuleCode);
            if (mdl.Count > 0)
            {
                lblBrand.Text = MySession.Current.MyLanuage == LanguageType.Eng ? mdl[0].DESC_ENG : mdl[0].DESC_LOC;
                Page.Title = lblBrand.Text;
            }


            Authen_Lib.MAS_ORGSerializeProperties org = aCtrl.GetOrgByPrimaryKey(MySession.Current.OrgCode);
            if (org != null)
            {
                lblUserIdTopBar.Text = org.ORG_CODE + "," + MySession.Current.LoginId.ToUpper();
                lblUserId.Text = MySession.Current.LoginId.ToUpper();
                lblUserGroup.Text = MySession.Current.MyLanuage == LanguageType.Eng ? org.SHORT_NAME_ENG : org.SHORT_NAME_LOC;
                sidebarMenu.InnerHtml = "";
                string html = "";
                //ถ้าเป็น OrgCenter จะเห็นเมนูหมด
                if (org.CENTER_ORG == "Y")
                {
                    List<Authen_Lib.MAS_PROGRAMSerializeProperties> parents = aCtrl.GetRootMenu(MySession.Current.ModuleCode, MySession.Current.Schema);
                    foreach (Authen_Lib.MAS_PROGRAMSerializeProperties parent in parents)
                    {
                        if (parent.CHILD_COUNT > 0)
                        {
                            html += "<li class=\"treeview\"><a href=\"#\">";
                            html += string.Format("<i class=\"{0}\"></i><span>{1}</span>", parent.PROGRAM_ICON, MySession.Current.MyLanuage == LanguageType.Eng ? parent.DESC_ENG : parent.DESC_LOC);
                            html += "<i class=\"fa fa-angle-left pull-right\"></i>";
                            html += "</a>";
                            html += "<ul class=\"treeview-menu\">";
                            List<Authen_Lib.MAS_PROGRAMSerializeProperties> childs = aCtrl.GetChildMenu(MySession.Current.ModuleCode, parent.PROGRAM_CODE, MySession.Current.Schema);
                            foreach (Authen_Lib.MAS_PROGRAMSerializeProperties child in childs)
                            {
                                string program_path = child.PROGRAM_EXTENSION == "" ? child.PROGRAM_PATH : child.PROGRAM_PATH + "?" + child.PROGRAM_EXTENSION;
                                html += string.Format("<li><a href='{0}'><span><i class='{1}'></i>{2}</span></a></li>", program_path, child.PROGRAM_ICON, MySession.Current.MyLanuage == LanguageType.Eng ? child.DESC_ENG : child.DESC_LOC);
                            }
                            html += "</ul>";
                        }
                        else
                        {
                            html += string.Format("<li><a href='{0}'><span><i class='{1}'></i>{2}</span></a></li>", parent.PROGRAM_PATH, parent.PROGRAM_ICON, MySession.Current.MyLanuage == LanguageType.Eng ? parent.DESC_ENG : parent.DESC_LOC);
                        }
                    }
                    sidebarMenu.InnerHtml = html;
                }
                else
                {
                    List<Authen_Lib.MAS_PROGRAMSerializeProperties> parents = aCtrl.GetRootMenuByUser(MySession.Current.ModuleCode, MySession.Current.OrgCode, MySession.Current.LoginId, MySession.Current.Schema);
                    foreach (Authen_Lib.MAS_PROGRAMSerializeProperties parent in parents)
                    {
                        if (parent.CHILD_COUNT > 0)
                        {
                            html += "<li class=\"treeview\"><a href=\"#\">";

                            html += string.Format("<i class=\"{0}\"></i><span>{1}</span>", parent.PROGRAM_ICON, MySession.Current.MyLanuage == LanguageType.Eng ? parent.DESC_ENG : parent.DESC_LOC);
                            html += "<i class=\"fa fa-angle-left pull-right\"></i>";
                            html += "</a>";
                            html += "<ul class=\"treeview-menu\">";
                            List<Authen_Lib.MAS_PROGRAMSerializeProperties> childs = aCtrl.GetChildMenuByUser(MySession.Current.ModuleCode, MySession.Current.OrgCode, MySession.Current.LoginId, parent.PROGRAM_CODE, MySession.Current.Schema);
                            foreach (Authen_Lib.MAS_PROGRAMSerializeProperties child in childs)
                            {
                                string program_path = child.PROGRAM_EXTENSION == "" ? child.PROGRAM_PATH : child.PROGRAM_PATH + "?" + child.PROGRAM_EXTENSION;
                                html += string.Format("<li><a href='{0}'><span><i class='{1}'></i>{2}</span></a></li>", program_path, child.PROGRAM_ICON, MySession.Current.MyLanuage == LanguageType.Eng ? child.DESC_ENG : child.DESC_LOC);
                            }
                            html += "</ul>";
                        }
                        else
                        {

                            if (!string.IsNullOrEmpty(parent.PROGRAM_PATH))
                            {
                                string program_path = parent.PROGRAM_EXTENSION == "" ? parent.PROGRAM_PATH : parent.PROGRAM_PATH + "?" + parent.PROGRAM_EXTENSION;
                                html += string.Format("<li><a href='{0}'><span><i class='{1}'></i>{2}</span></a></li>", program_path, parent.PROGRAM_ICON, MySession.Current.MyLanuage == LanguageType.Eng ? parent.DESC_ENG : parent.DESC_LOC);
                            }
                            else
                            {
                                html += string.Format("<li><a href='#'><span><i class='{0}'></i>{1}</span></a></li>", parent.PROGRAM_ICON, MySession.Current.MyLanuage == LanguageType.Eng ? parent.DESC_ENG : parent.DESC_LOC);
                            }
                        }
                    }
                    sidebarMenu.InnerHtml = html;
                }
            }
        }
    }
}
