using System;

using System.Collections.Generic;


using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Text;

using System.Data;

using System.Data.SqlClient;

using System.Configuration;



public partial class Download : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string file = Request.QueryString["file"];

        //Application/UnKnown : MIME(알수없는 형식)
        Response.ContentType = "Application/UnKnown";

        //다운로드 안치고 인식됨
        //Response.ContentType = "Image/GIF";
        //웹 서버 응답에 이 헤더를 포함하면 그 내용(보통 사진 등의 파일 데이터)을 
        //웹 브라우저로 바로 보거나 내려받도록 설정할 수 있다. 물론, 다운로드 시에 파일 이름을 지정할 수도 있다
        Response.AddHeader("Content-Disposition", "Attachment;filename=" + HttpUtility.UrlEncode(file, Encoding.UTF8).Replace("+", "%20"));

        //해당 파일을 임시 페이지(출력 스트림)에 직접 쓴다.
        //Response.WriteFile("files/" + file);

        //Response.End();

    }

}

