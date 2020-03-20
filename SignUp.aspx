<%@ Page Language="C#"  MasterPageFile="~/Board.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

       </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" >
    $(document).ready(function() {
       $("#form1").validate({
            rules: {
                <%=TextBoxID.UniqueID %> : { required: true, minlength:5 },
                <%=TextBoxPwd.UniqueID %> : { required: true, minlength:8 },
                <%=TextBoxName.UniqueID %> : { required: true, minlength:1 },
                <%=TextBoxEmail.UniqueID %> : { required: true, email:true }
            }, messages : {
            <%=TextBoxID.UniqueID %> : {required:"아이디를 입력하세요", minlength:jQuery.format("{0}자 이상 입력해주세요")},
             <%=TextBoxPwd.UniqueID %> : {required:"패스워드를 입력하세요", minlength:jQuery.format("{0}자 이상 입력해주세요")},
              <%=TextBoxName.UniqueID %> : "이름을 입력하세요",
               <%=TextBoxEmail.UniqueID %> : "이메일형식으로 입력하세요"
           }
        });
    });

    </script>

       <table class="table"  table="table1" runat="server" style="width:250px;margin:50px auto; color:black; border-style:outset; border-color:#628bc8; ">

             <tr>

                    <td  class="td1" align="center" bgcolor="white" width="150" style="color:black">

                           아이디</td>

                    <td width="500">

                           &nbsp;&nbsp;
                           <asp:TextBox ID="TextBoxID" runat="server" CssClass="required" Width="200px" 
                           style="background-color:#E0F2F7; height:20px;margin:0 0 20px 0;  border-width:thin; display:inherit; " ></asp:TextBox>
                   
                    </td>

                 
                   
                   
             </tr>
        
                <tr>
              <td>
                    <asp:Button ID="IDTwoButton" runat="server" Text="아이디중복" onclick="IDTwoButton_Click" BackColor="#FFBF00" style="color:white;border-style:none" formnovalidate  />
                   </td>
                   <td>
                   <asp:Label ID="Labelmsg" runat="server" style="color:black;"></asp:Label>
                    </td>
                    </tr>
             <tr>

                    <td class="td2" align="center" bgcolor="white" width="150" style="color:black">

                           암호</td>

                    <td width="150">

                           &nbsp;&nbsp;<asp:TextBox ID="TextBoxPwd" runat="server" CssClass="required"

                                 TextMode="Password" Width="200px"  style="background-color:#E0F2F7; height:20px; margin:0 0 20px 0;  border-width:thin; display:inherit" ></asp:TextBox>

                    </td>

             </tr>
                 <tr>

                    <td class="td4" align="center" bgcolor="white" width="150" style="color:black">

                           이름</td>

                    <td width="150">

                           &nbsp;&nbsp;<asp:TextBox ID="TextBoxName" runat="server" CssClass="required" Width="200px" 
                            style="background-color:#E0F2F7; height:20px; margin:0 0 20px 0;  border-width:thin; display:inherit" ></asp:TextBox>

                    </td>

             </tr>

                 <tr>

                    <td class="td4" align="center" bgcolor="white" width="150" style="color:black">

                           이메일</td>

                    <td width="150">

                           &nbsp;&nbsp;<asp:TextBox ID="TextBoxEmail" runat="server" CssClass="required" Width="200px"
                            style="background-color:#E0F2F7; height:20px; margin:0 0 20px 0; border-width:thin; display:inherit" ></asp:TextBox>

                    </td>

             </tr>

       </table>

       <div style="text-align:center;margin:10px;">

    <asp:Button ID="SignUpButton" runat="server" Text="회원가입" onclick="SignUpButton_Click" BackColor="#FFBF00" style="color:White;border-style:none"    />

&nbsp;<asp:Button ID="ListButton" runat="server" Text="리스트" onclick="ListButton_Click" BackColor="#FFBF00" style="color:White;border-style:none"  formnovalidate  />

       </div>

 

</asp:Content>

 