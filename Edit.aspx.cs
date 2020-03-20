using System;

using System.Collections.Generic;



using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;



using System.Data;

using System.Data.SqlClient;

using System.Configuration;

using System.IO;


public partial class Edit : System.Web.UI.Page
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

        else
        {
            LabelID.Text = Session["sid"].ToString();
        }

     
        if (!IsPostBack)
        {

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
                //들어온 세션아이디랑 기존에 불러온 아이디랑 같은지 비교
                var sid = Session["sid"].ToString();
                string rid = reader["id"].ToString();

                if (sid != rid)
                {

                    string script = "<script type='text/javascript'>alert('권한이 없습니다.');location.href='List.aspx';</script>";

                    Response.Write(script);

                    Response.End();

                }
                //글작성할때 들어갔던 id불러옴
                LabelID.Text = reader["id"].ToString();
                //첨부파일 처리
                if (reader["filename"].ToString() != null)
                {
                    LabelFile.Text = string.Format("{0}", reader["filename"].ToString());

                }
                else
                {
                    LabelFile.Text = "첨부 파일 없음";

                }
                //출력
                TextBoxSubject.Text = reader["subject"].ToString();
                //글내용
                TextBoxContent.Text = reader["content"].ToString();

            }

            reader.Close();
            con.Close();

        }
      

    }


    protected void BackButton_Click(object sender, EventArgs e)
    {
        string script = null;
        script = @"<script type='text/javascript'>

                                        history.go(-2);

                                    </script>";

        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "edit", script);
    }

    protected void EditButton_Click(object sender, EventArgs e)
    {

        //수정하기
        //2. 수정 or 취소
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString);

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = con;

        cmd.CommandText = "Select Count(*) From boards Where seq=@seq";

        cmd.Parameters.Add("@seq", SqlDbType.Int);

        cmd.Parameters["@seq"].Value = Request.QueryString["seq"];

        
        con.Open();


        int result = (int)cmd.ExecuteScalar();

        string script = "";

        if (result == 1)
        {

            string filename = "";

            //기존 첨부 파일의 유무
            if (FileUpload1.HasFile == true)
            {

                FileInfo file = new FileInfo(Server.MapPath("files/"));

                //기존 첨부파일 삭제
                System.IO.File.Delete("files/");

                //새로운 첨부파일을 추가
                filename = Path.GetFileName(FileUpload1.FileName);

                FileUpload1.PostedFile.SaveAs(Server.MapPath("files/") + filename);


            }
            //게시물 Update
            cmd.CommandText = @"Update boards Set subject=@subject, content=@content, filename=@filename,regDate=getdate()  where seq=@seq";

            //매개변수
            cmd.Parameters.Add("@subject", SqlDbType.NVarChar, 100);

            cmd.Parameters.Add("@content", SqlDbType.NVarChar, 3000);

            cmd.Parameters.Add("@filename", SqlDbType.VarChar, 100);


            //값
            cmd.Parameters["@subject"].Value = TextBoxSubject.Text;

            cmd.Parameters["@content"].Value = TextBoxContent.Text;

            cmd.Parameters["@filename"].Value = filename;


            cmd.ExecuteNonQuery();//update

            script = @"<script type='text/javascript'> alert('수정 되었습니다');  location.href='List.aspx'; </script>";

        }
        else
        {
            script = @"<script type='text/javascript'> alert('수정 되었습니다');  location.href='List.aspx'; </script>";
        }

        //if (FileUpload1.HasFile == false)
        //{

           
        //}

            con.Close();

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "edit", script);

        }

    protected void FileDelButton_Click(object sender, EventArgs e)
    {

        //파일삭제 버튼 클릭 시, 파일명 보이지 않음
        this.LabelFile.Visible = false;

        //DB호출
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString);

        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "Update boards Set filename=@filename";

        cmd.Parameters.Add("@filename", SqlDbType.VarChar, 100);

        cmd.Parameters["@filename"].Value = TextBoxContent.Text;

        con.Open();

        cmd.CommandType = CommandType.Text;

        cmd.Connection = con;

        cmd.ExecuteNonQuery();

        //파일이름을 기존에 올렸던 경로에서 가져와서 filename으로 설정 후 삭제해줄 경로도 따로 가져와 파일존재유무 확인하고 삭제
        //수정하면서 view에서 보이는 파일만 삭제, 폴더 내에 있는건 삭제X
        //string filename = Path.GetFileName(FileUpload1.FileName);

        //string path = Server.MapPath("files/" + filename);

        //string script = "";

        //if (File.Exists(path) == true)
        //{
        //    FileInfo file = new FileInfo(Server.MapPath(path));
        //    System.IO.File.Delete(path);

        //}
        FileInfo file = new FileInfo(Server.MapPath("files/"));
        System.IO.File.Delete("files/");

        string script = "";
        script = @"<script type='text/javascript'> alert('수정 되었습니다');  location.href='List.aspx'; </script>";

        con.Close();
    }
}

