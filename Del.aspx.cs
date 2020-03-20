using System;

using System.Collections.Generic;


using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;



using System.Data;

using System.Data.SqlClient;

using System.Configuration;



public partial class Del : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //비회원이 해당 주소를 알아내서 직접 접속했을때..
        if (Session["sid"] == null)
        {

            string script = "<script type='text/javascript'>alert('권한이 없습니다.');location.href='List.aspx';</script>";

            Response.Write(script);

            Response.End();

        }


        if (!IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer;//뷰스테이트에서 전에 페이지URL저장

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString);

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandText = "Select * From boards Where seq=@seq";


            cmd.Parameters.Add("@seq", SqlDbType.Int);

            cmd.Parameters["@seq"].Value = Request.QueryString["seq"];


            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                //로그인한 세션id값이랑 기존 글에 저장되어있던 아이디를 비교
                var sid = Session["sid"].ToString();
                string rid = reader["id"].ToString();

                if (sid != rid)
                {

                    string script = "<script type='text/javascript'>alert('권한이 없습니다.');location.href='List.aspx';</script>";

                    Response.Write(script);

                    Response.End();

                }

            }

            reader.Close();
            con.Close();

        }

    }

    protected void Deletebutton_Click(object sender, EventArgs e)
    {  
        //1. 암호가 일치?
        //2. 삭제 or 취소
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString);

        con1.Open();
       //원글에 seq를 idk에 넣고 삭제 시 다르면 삭제불가
        SqlCommand cmd2 = new SqlCommand("Select Count(*) From boards Where @seq=idk", con1);
        
        cmd2.Connection = con1;
   
        cmd2.Parameters.Add("@seq", SqlDbType.Int);

        cmd2.Parameters["@seq"].Value = Request.QueryString["seq"];
        
        int result = (int)cmd2.ExecuteScalar();

        string script = "";

        if (result == 1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString);

            con.Open();

            SqlCommand cmd = new SqlCommand("DeleteRep", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@seq", Request["seq"]);
            //삭제처리 
            cmd.ExecuteNonQuery();

            script = @"<script type='text/javascript'> alert('답글이 있으면 삭제 불가합니다.');  location.href='List.aspx'; </script>";
           

            
        }
        else
        {

            cmd2.CommandText = @"Delete From boards Where seq=@seq";

            cmd2.ExecuteNonQuery();//delete

            script = @"<script type='text/javascript'> alert('삭제 했습니다.');  location.href='List.aspx'; </script>";

        }

        con1.Close();

        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "del", script);
    }

        //else
        //{
        //    string script = "";
        //    script = @"<script type='text/javascript'> alert('답글이 있으면 삭제 불가합니다.');  location.href='List.aspx'; </script>";
        
        //    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "del", script);
        //}

    
    protected void Backbutton_Click(object sender, EventArgs e)
    {
        //전에 URL을 가지고 있다면,
        if (ViewState["PreviousPage"] != null)	 
        {
            // 뷰스트레이트로 부터 전페이지 URL 로 가기
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }

    }
}



