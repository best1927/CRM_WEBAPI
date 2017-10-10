using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainGroupDetail : System.Web.UI.Page
{
    private string _OrgCode;
    public string OrgCode
    {
        get { return _OrgCode; }
        set { _OrgCode = value; }
    }

    private string _GroupCode;
    public string GroupCode
    {
        get { return _GroupCode; }
        set { _GroupCode = value; }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        this.OrgCode = Request["org"].ToString();
        this.GroupCode = Request["id"].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}