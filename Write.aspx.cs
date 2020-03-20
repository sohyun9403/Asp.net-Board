using System;

using System.Collections.Generic;



using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;



using System.Data;

using System.Data.SqlClient;

using System.Configuration;



public partial class Write : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        //비회원이 해당 주소를 알아내서 직접 접속했을때
        if (Session["sid"] == null)
        {

            string script = "<script type='text/javascript'>alert('권한이 없습니다.');location.href='List.aspx';</script>";

            Response.Write(script);

            Response.End();

        }

        else
        {
            LabelID.Text = Session["sid"].ToString();
        }

      
    }

    protected void ListButton_Click(object sender, EventArgs e)
    {
        //List
        Response.Redirect("List.aspx");

    }

    protected void WriteButton_Click(object sender, EventArgs e)
    {

        string filename = "";


        if (FileUpload1.HasFile) //업로드파일이 존재하면
        {

            filename = System.IO.Path.GetFileName(FileUpload1.FileName); //파일네임은 경로를 따라가서 실제 파일이름

            FileUpload1.PostedFile.SaveAs(Server.MapPath("files/") + filename); //경로와 이름이 같이 저장됨

        }
        //Write
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString);


        SqlCommand cmd = new SqlCommand();

        cmd.Connection = con;

        cmd.CommandText = "Insert into boards (subject, content, filename, thread, depth, id) Values (@subject, @content, @filename, @thread, @depth, @id)";



        //매개변수
        cmd.Parameters.Add("@subject", SqlDbType.NVarChar, 100);

        cmd.Parameters.Add("@content", SqlDbType.NVarChar, 3000);

        cmd.Parameters.Add("@filename", filename);

        cmd.Parameters.Add("@id", SqlDbType.VarChar, 20);

        cmd.Parameters.Add("@thread", SqlDbType.Int);

        cmd.Parameters.Add("@depth", SqlDbType.Int);


        //값
        cmd.Parameters["@subject"].Value = TextBoxSubject.Text;

        cmd.Parameters["@content"].Value = TextBoxContent.Text;

        cmd.Parameters["@filename"].Value = filename;

        cmd.Parameters["@id"].Value = Session["sid"].ToString();

        cmd.Parameters["@thread"].Value = Request["thread"];

        cmd.Parameters["@depth"].Value = Request["depth"];

        con.Open();

        SqlCommand cmd2 = new SqlCommand();

        cmd2.Connection = con;

        if (Request["write"] != "y")
        {

            //새글

            //a. 현재 테이블에 존재하는 모든 thread값 중에서 가장 큰thread + 1000을 한 값을 새글의 thread로 대입
            cmd2.CommandText = "Select isnull(max(thread),0) + 1000 From boards";

            cmd.Parameters["@thread"].Value = (int)cmd2.ExecuteScalar();

            //b. 새글의 depth는 0을 대입
            cmd.Parameters["@depth"].Value = 0;

        }

        else
        {

            //답변글

            //부모글의 thread : Add.aspx?thread=1000&depth=0
            int parentThread = int.Parse(Request.QueryString["thread"]);

            int parentDepth = int.Parse(Request.QueryString["depth"]);

            //이전 새글의 thread
            int prevThread = (int)Math.Floor((parentThread - 1) / 1000D) * 1000;


            cmd2.CommandText = string.Format(@"Update boards Set thread = thread - 1 Where  thread < {0} AND thread > {1}", parentThread, prevThread);

            cmd2.ExecuteNonQuery();

            //b. 현재 답변글은 thread값을 부모글의 thread -1 대입
            cmd.Parameters["@thread"].Value = parentThread - 1;

            //c. 현재 답변글은 depth값을 부모글의 depth + 1 대입
            cmd.Parameters["@depth"].Value = parentDepth + 1;

        }
        cmd.ExecuteNonQuery();

        con.Close();



        string script = @"<script type='text/javascript'> alert('글이 작성되었습니다.'); location.href = 'List.aspx';  </script>";

        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "write", script);

    }

}