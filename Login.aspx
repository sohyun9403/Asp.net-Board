<%@ Page Title="" Language="C#" MasterPageFile="~/Board.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

       </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <%--<table class="table" width="300" align="center">--%>

       <table class="table" style="width:auto;margin-top:20px;">

             <tr>

                    <td align="center" bgcolor="#424242" width="150" style="color:White;">

                           아이디</td>

                    <td width="150">
                    
                           &nbsp;&nbsp;<asp:TextBox ID="TextBoxID" runat="server" CssClass="txt" Width="140px" style="border-style:none"></asp:TextBox>

                    </td>

             </tr>

             <tr>

                    <td align="center" bgcolor="#424242" width="150" style="color:White;  ">

                           암호</td>

                    <td width="150">

                           &nbsp;&nbsp;<asp:TextBox ID="TextBoxPwd" runat="server" CssClass="txt"

                                 TextMode="password" Width="140px" style="border-style:none"></asp:TextBox>

                    </td>

             </tr>

       </table>

 
  <div style="text-align:center; margin-bottom:20px">

      <asp:Button ID="ListButton" runat="server" Text="리스트" onclick="ListButton_Click" BackColor="#FFBF00" style="color:White;border-style:solid"    />

      <asp:Button ID="SignUpButton" runat="server" Text="회원가입" onclick="SignUpButton_Click" BackColor="#FFBF00" style="color:White;border-style:solid"    />

      <asp:Button ID="LoginButton" runat="server" Text="로그인" onclick="LoginButton_Click" BackColor="#FFBF00" style="color:White;border-style:solid"    />



</div>

 

</asp:Content>

 