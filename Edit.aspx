<%@ Page Title="" Language="C#" MasterPageFile="~/Board.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" ValidateRequest="false" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" >
    $(document).ready(function() {
       $("#form1").validate({
            rules: {
                <%=TextBoxSubject.UniqueID %> : { required: true},
                <%=TextBoxContent.UniqueID %> : { required: true }
            }, messages : {
             <%=TextBoxSubject.UniqueID %> : "제목을 입력하세요.",
              <%=TextBoxContent.UniqueID %> : "내용을 입력하세요."
 
           }
        });
    });

    </script>
       <table class="table1" style="width:600px;">

       
       <tr>
                <td  style="text-align:center; height:50%; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;">
         아이디</td>
          <td>
                           &nbsp;<asp:Label ID="LabelID" runat="server"  Width="200px" ></asp:Label>

                           &nbsp;</td>

                           </tr>

             <tr>

                     <td  style="text-align:center; height:50%; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;">

                           제목</td>

                    <td width="450">

                           &nbsp;<asp:TextBox ID="TextBoxSubject" runat="server" CssClass="txt" Width="96%"></asp:TextBox>

                           &nbsp;</td>

             </tr>

             <tr>

                     <td  style="text-align:center; height:50%; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;">

                           내용</td>

                    <td width="450">

                           &nbsp;<asp:TextBox ID="TextBoxContent" runat="server" CssClass="txt" Height="150px"

                                 TextMode="MultiLine" Width="95%"></asp:TextBox>

                           &nbsp;</td>


             </tr>

             <tr>

             <td  style="text-align:center; height:50%; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;">

                           첨부파일</td>

             <td width="450" style="text-align:left">

                           &nbsp;&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" formnovalidate/>
                                 
                                 <br />

                           &nbsp;&nbsp;<asp:Label ID="LabelFile" runat="server" Text="LabelFile"></asp:Label>
                                    
                                      <asp:Button ID="FileDeltButton" runat="server" Text="파일삭제"

                    onclick="FileDelButton_Click"  Causesvalidation="false"  formnovalidate/>

             </td>


             

             </table>

          <div style="text-align:center;margin:10px;">

             <asp:Button ID="BackButton" runat="server" Text="뒤로가기"

                    onclick="BackButton_Click"  BackColor="#FFBF00" style="color:White; border-style:none" formnovalidate/>

            <asp:Button ID="EditButton" runat="server" Text="수정하기"

                    onclick="EditButton_Click" BackColor="#FFBF00" style="color:White; border-style:none" />

       </div>

</asp:Content>

 