using System;

using System.Collections.Generic;


using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;



using System.Data;

using System.Data.SqlClient;

using System.Configuration;



public partial class View : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            //seq의 상세보기
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString);

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandText = "Update boards Set readCount = readCount + 1 Where seq=@seq;";

            cmd.Parameters.Add("@seq", SqlDbType.Int);

            cmd.Parameters["@seq"].Value = Request.QueryString["seq"];

            con.Open();

            //쿠키 확인 작업
            if (Request.Cookies["read"] == null || Request.Cookies["read"].Value == "n")
            {

                cmd.ExecuteNonQuery();//조회수 증가

                Response.Cookies["read"].Value = "y";

            }
            cmd.CommandText = "Select * From boards as b inner join members as m on b.id=m.id Where seq=@seq";

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                //출력
                LabelName.Text = reader["name"].ToString();
                LabelEmail.Text = reader["email"].ToString();
                LabelSubject.Text = reader["subject"].ToString();
                LabelFile.Text = string.Format("{0}", reader["filename"].ToString());
                
                //글내용
                string content = reader["content"].ToString();

                if (reader["fileName"].ToString() != "")
                {
                    //소문자로 변환해서 문자열의 복사본 반환 ToLower, 사용할 수 있는 확장자 명시 후 내용에 같이 보여줌
                    if ((System.IO.Path.GetExtension(reader["fileName"].ToString()).ToLower() == ".gif") || (System.IO.Path.GetExtension(reader["fileName"].ToString()).ToLower() == ".jpg") || (System.IO.Path.GetExtension(reader["fileName"].ToString()).ToLower() == ".jpeg") || (System.IO.Path.GetExtension(reader["fileName"].ToString()).ToLower() == ".png"))
                    {

                        string img = string.Format("<div style='margin:20px;text-align:center;'><img src='files/{0}' style='max-width:600px;max-height:600px;'/></div>", reader["fileName"].ToString());

                        content = img + content;

                    }

                }
                //첨부파일 다운로드
                if (reader["fileName"].ToString() != "")
                {

                    LabelFile.Text = string.Format("<a href='Download.aspx?seq={1}&file={0}'>{0}</a>", reader["fileName"].ToString(), Request.QueryString["seq"]);

                }

                else
                {

                    LabelFile.Text = "첨부파일 없음";

                }

                //글내용

                //string content = reader["content"].ToString();

                //<script> 무조건 적용안함
                content = content.Replace("<script", "&lt;script").Replace("</script>", "&lt/script>");

                //엔터값처리  -> <br />
                content = content.Replace("\r\n", "<br />");

                LabelContent.Text = content;

                LabelID.Text = reader["id"].ToString();
                //LabelID.Text = Session["sid"].ToString();

                LabelSeq.Text = reader["seq"].ToString();

                LabelReadCount.Text = reader["readCount"].ToString();

                LabelRegDate.Text = reader["regDate"].ToString();

                //포스트백이 일어날때만 상태유지.. ViewState는 기본적으로  상태유지역할
                ViewState["thread"] = reader["thread"].ToString();

                ViewState["depth"] = reader["depth"].ToString();

            }

            reader.Close();

            con.Close();

        }

    }

    protected void ListButton_Click(object sender, EventArgs e)
    {

        Response.Redirect("List.aspx");

    }

    protected void EditButton_Click(object sender, EventArgs e)
    {

        Response.Redirect("Edit.aspx?seq=" + Request.QueryString["seq"]);

    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {

        Response.Redirect("Del.aspx?seq=" + Request.QueryString["seq"]);
    }

    protected void ReplyButton_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("Reply.aspx?seq={0}&reply=y&thread={1}&depth={2}", Request["seq"], ViewState["thread"].ToString(), ViewState["depth"].ToString()));
        //Response.Redirect("Reply.aspx?seq={0}" + Request.QueryString["seq"]);
        //ViewState["thread"].ToString(), ViewState["depth"].ToString(
    }

}