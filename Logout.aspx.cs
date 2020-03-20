using System;

using System.Collections.Generic;


using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;



public partial class Logout : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (Session["sid"] != null)
        {
            //세션삭제
            Session.Clear();

            Response.Redirect("Login.aspx");
        }


    }

//    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
//    {

//        string script = null;

//        script = @"<script type='text/javascript'>
//
//                                        alert('로그 아웃 합니다.');
//
//                                    </script>";



//        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "edit", script);



//        Response.Write("ddd");



//        //로그아웃!!

//        System.Web.Security.FormsAuthentication.SignOut();



//        //쿠키 해제

//        Response.Cookies["name"].Expires = DateTime.MinValue;

//        Response.Cookies["email"].Expires = DateTime.MinValue;



//        Response.Redirect("Login.aspx");

//    }

}