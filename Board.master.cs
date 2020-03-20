using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sid"] != null)
        {
           
            HeadLoginName.Text = "환영합니다! " + Session["sid"].ToString() + "님" ;
            HeadLoginStatus.Visible = false;

        }
        else 
        {
            
            HeadLogoutStatus.Visible = false;
            
        }
    }
}
