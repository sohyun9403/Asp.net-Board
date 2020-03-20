<%@ Page Title="" Language="C#" MasterPageFile="~/Board.master" AutoEventWireup="true" CodeFile="Del.aspx.cs" Inherits="Del" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <table class="table" style="width:300px;" align="center">

             </table>

       <div style="text-align:center;margin:10px;" >

             <asp:button ID="Backbutton" runat="server" Text="뒤로가기"

                onclick="Backbutton_Click"  BackColor="#FFBF00" style="color:White; border-style:none"  />

&nbsp;<asp:button ID="Deletebutton" runat="server" Text="삭제하기"

                    onclick="Deletebutton_Click" BackColor="#FFBF00" style="color:White; border-style:none"  />
                  
&nbsp;</div>

</asp:Content>

 