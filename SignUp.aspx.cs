using System;

using System.Collections.Generic;


using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Data;

using System.Data.SqlClient;

using System.Configuration;

using System.Data.Sql;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SignUpButton_Click(object sender, EventArgs e)
    {
        //아이디중복 시 생기는 라벨메시지가 아무것도 없으면(아이디중복은안했다는뜻이니)
        if (this.Labelmsg.Text == "")
        {

            string script = "";

            script = "<script type='text/javascript'>alert('아이디 중복체크 후 재가입해주세요.'); </script>";

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "signup", script);
        }
        else
        {
        //아이디중복했으면 회원가입 가능
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString);

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = con;

        con.Open();

        cmd.Connection = con;

        cmd.CommandText = "Insert into members (id, pwd, name, email) values ('" + TextBoxID.Text + "', '" + TextBoxPwd.Text + "','" + TextBoxName.Text + "','" + TextBoxEmail.Text + "')";

        cmd.CommandType = CommandType.Text;

        cmd.ExecuteNonQuery();

        con.Close();

        Response.Redirect("Login.aspx");


        string script = "";

        script = "<script type='text/javascript'>alert('회원가입 성공!!\\r\\n로그인으로 이동합니다.'); location.href='List.aspx';</script>";
}
    }

    protected void ListButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("List.aspx");
    }


    protected void IDTwoButton_Click(object sender, EventArgs e)
    {
        
        //검사 버튼을 클릭했을때
        if (this.TextBoxID.Text.Length >= 5)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString);

            string sqlQuery = "Select Count(*) From members Where id='" + TextBoxID.Text + "'";

            SqlCommand cmd = new SqlCommand(sqlQuery, con1);

            con1.Open();

            int count = (int)cmd.ExecuteScalar();

            con1.Close();
            //아이디중복 확인 후 라벨로 보여주기
            if (count == 0)
            {
                this.Labelmsg.Text = this.TextBoxID.Text + "는 사용가능한 아이디 입니다.";
                //this.btnIDInput.Visible = true;
            }
            else
            {
                //아이디 중복시
                this.Labelmsg.Text = this.TextBoxID.Text + "는 이미 사용중 입니다.";
                //this.btnIDInput.Visible = false;

            }
        }
        else
        {
            //5자미만으로 아이디 설정했을 때
            this.Labelmsg.Text = this.TextBoxID.Text + "보다 길게 설정해주세요.";
        }

    }

}
     