using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;


using System.Data;

using System.Data.SqlClient;

using System.Configuration;

using System.Web.Security;//



public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        

    }

    protected void ListButton_Click(object sender, EventArgs e)
    {

        //게시판으로 이동하기
        Response.Redirect("List.aspx");

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {

        //로그인

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString);

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = con;

        cmd.CommandText = "Select * From members Where id=@id And pwd=@pwd";



        cmd.Parameters.Add("@id", SqlDbType.VarChar, 20);

        cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 20);



        cmd.Parameters["@id"].Value = TextBoxID.Text;

        cmd.Parameters["@pwd"].Value = TextBoxPwd.Text;



        con.Open();



        string script = "";

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {

            //인증
            Session["sid"] = (string)TextBoxID.Text;
           
            //추가 정보 기억

            //Response.Cookies["name"].Value = reader["name"].ToString();

            //Response.Cookies["email"].Value = reader["email"].ToString();

            script = "<script type='text/javascript'>alert('로그인 성공했습니다.\\r\\n게시판으로 이동합니다.'); location.href='List.aspx';</script>";

        }

        else
        {

            script = "<script type='text/javascript'>alert('로그인 실패했습니다.');</script>";

        }


        reader.Close();

        con.Close();


        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", script);

    }

    protected void SignUpButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx");
    }

}

