using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainGroup : System.Web.UI.Page
{
    private string _OrgCode;
    public string OrgCode
    {
        get { return _OrgCode; }
        set { _OrgCode = value; }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        this.OrgCode = Request["id"].ToString();
    }

  

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}