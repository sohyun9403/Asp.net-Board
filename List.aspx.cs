using System;

using System.Collections.Generic;



using System.Linq;
using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Data;

using System.Configuration;

using System.Data.SqlClient;



public partial class List : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            //조회수 증가용 쿠키 할당
            Response.Cookies["read"].Value = "n";

        }

        BindData();

        //DataBind();


    }
    protected void BindData()
    {   //데이터연결
        string strConnection = ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnection);

        //db open
        con.Open();

        ////Write.cs에서 notice=1로 공지사항 체크한 bool값을 형변환하여 받아옴
        //string noti = Request.QueryString["notice"];

        //int notice = 0;
        ////문자열을 정수로 변환, 반환값은 성공여부 나타냄
        //Int32.TryParse(noti, out notice);

        //공지사항으로 맨 위에 3개만 고정하고 공지사항,작성일로 정렬
        //Union all로 중복을 제거하지 않고 테이블합친 후 작성일로 정렬(추후에 변경예정)
        SqlCommand cmd = new SqlCommand("Numbering", con);

        cmd.CommandType = CommandType.StoredProcedure;

        //sqlDataReader는 DB가 연결된 동안만 접근 가능,
        //sqlDataAdaptor는 DataSet에 복사해 두었기 때문에 DB가 연결을 끊어도 사용 가능
        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter(cmd);

        da.Fill(ds);

        GridView1.DataSource = ds;

        GridView1.DataBind();

        con.Close();

    }
    protected void WriteButton_Click(object sender, EventArgs e)
    {
        //글쓰기
        Response.Redirect("Write.aspx");

    }
    //검색버튼 메서드
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        //DB가져와서 DB의 메모리 가져와 adapter로 게시판과 연결 후 데이터넣기
        string connection = ConfigurationManager.ConnectionStrings["boarddbConnectionString2"].ConnectionString;

        SqlConnection con = new SqlConnection(connection);

        con.Open();

        SqlCommand cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;

        //드롭다운리스트에서 txt로 들어간 제목, 작성자, 내용으로 속성 값 선택 후 가져옴
        cmd.CommandText = ("Select Num = ROW_NUMBER() OVER(ORDER BY thread) , * From [boards] as b inner join members as m on b.id = m.id Where " + DropDownList1.SelectedValue + " like '%" + Textsearch.Text + "%' order by Num DESC");
        // Where " +  DropDownList1.SelectedValue + " like '%" + Textsearch.Text + "%'"),escape'''
       
        SqlDataAdapter da = new SqlDataAdapter(cmd);


        DataTable dt = new DataTable();

        da.Fill(dt);

        GridView1.DataSource = dt;

        GridView1.DataBind();

        con.Close();



    }

    

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //1. 제목이 길면.. 자르기

            //e.Row <- 한행(GridViewRow) x 5개
            //HyperLink subject = e.Row.Cells[1].Controls[0] as HyperLink;
            HyperLink subject = e.Row.Cells[1].Controls[0] as HyperLink;

            if (subject.Text.Length > 20)
            {

                subject.Text = subject.Text.Substring(0, 20) + "...";

            }


            //2. 글쓴지 일정시간이내면.. new.gif 표시

            // 30분이내

            //Response.Write(e.Row.Cells[3].Text + "<br />");



            //현재 바인딩되거나 바인딩된 데이터에 접근하는 방법

            //A. 출력된 결과값에 접근하는 방법(Cells을 사용)

            //Response.Write(e.Row.Cells[2].Text);



            //B. (출력과 상관없이)바인딩되는 원본에 접근하는 방법

            // 조건 : 데이터원본에는 있어야함(select의 대상)

            //데이터원본(seq, subject, name, regDate, readCount, email)

            DataRowView row = e.Row.DataItem as DataRowView;

            //Response.Write(row["email"].ToString());

            //Response.Write(row["regDate"].ToString());

            DateTime regDate = (DateTime)row["regDate"];



            TimeSpan gap = DateTime.Now - regDate;



            if (gap.TotalMinutes <= 30)
            {

                //30이내에 쓴글

                //e.Row.Cells[1]

                LiteralControl newart = new LiteralControl("..new");

                e.Row.Cells[1].Controls.Add(newart);

                //e.Row.Cells[1].Controls.AddAt(0, img);

            }
            //3. 답변글은 제목앞에 re.gif 붙이기

            int depth = (int)row["depth"];

            if (depth > 0)
            {

                LiteralControl img = new LiteralControl("<img src='files/arrow.png' alt='' style='margin-right:5px;margin-left:" + (depth * 15) + "px' />");

                e.Row.Cells[1].Controls.AddAt(0, img);

                //e.Row.Cells[0].Text = "";

            }
        }

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();

    }
    protected void Textsearch_TextChanged(object sender, EventArgs e)
    {

    }
    protected void SearchList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  

}

