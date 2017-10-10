using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Authen_Lib;
using SessionFactory;

public partial class MaintainOrg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AuthenController ctrl = new AuthenController();
            MAS_PROGRAMSerializeProperties obj = ctrl.GetProgramByPrimaryKey("TRORG", MySession.Current.Schema);
        
            if (MySession.Current.MyLanuage == LanguageType.Eng)
                lblPageHeader.Text = obj.DESC_ENG;
            else
                lblPageHeader.Text = obj.DESC_LOC;
        }
    }
}