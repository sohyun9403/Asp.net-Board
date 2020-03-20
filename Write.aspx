<%@ Page Title="" Language="C#" MasterPageFile="~/Board.master" AutoEventWireup="true" CodeFile="Write.aspx.cs" Inherits="Write" ValidateRequest="false" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

       </asp:Content>

 

<asp:Content ID="Content2" runat="server"  contentplaceholderid="ContentPlaceHolder1">
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

                                 TextMode="MultiLine" Width="95%" 
                                 AcceptsReturn = "true" TextWrapping = "WrapWithOverflow"  Columns="10" Rows="15"></asp:TextBox>

                           &nbsp;</td>

             </tr>

             <tr>

                         <td  style="text-align:center; height:50%; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
           background-color:#424242; color:white;   ">
                        
                           첨부파일</td>

                    <td style="text-align:left">

                           &nbsp;&nbsp;<asp:FileUpload ID="FileUpload1"

                                 runat="server" Width="305px" style="text-align:left"/>

                    </td>

             </tr>

             </table>

   <div style="text-align:center;margin:100px; ">

             <asp:Button ID="ListButton" runat="server" Text="리스트"

                    onclick="ListButton_Click"  BackColor="#FFBF00" style="color:White; border-style:none"  formnovalidate/>

                          &nbsp;<asp:Button ID="WriteButton" runat="server" Text="저장"

                    onclick="WriteButton_Click"  BackColor="#FFBF00" style="color:White; border-style:none"/>
   
       </div>

</asp:Content>

 