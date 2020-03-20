<%@ Page Title="" Language="C#" MasterPageFile="~/Board.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="View" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <table class="table1" style="width:80%;">

             <tr>

                    <td  style="text-align:center; width:30px; height:30px; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;   ">

                           아이디</td>

                    <td width="450">

                           &nbsp;<asp:Label ID="LabelID" runat="server"></asp:Label>

                           &nbsp;</td>

             </tr>

             <tr>

                   <td  style="text-align:center; height:30px;font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;   ">

                           이름</td>

                    <td width="450">

                           &nbsp;<asp:Label ID="LabelName" runat="server"></asp:Label>

                           &nbsp;</td>

             </tr>


             <tr>

                    <td  style="text-align:center; height:30px; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;   ">

                           이메일</td>

                    <td width="450">

                           &nbsp;<asp:Label ID="LabelEmail" runat="server"></asp:Label>

                           &nbsp;</td>

             </tr>

             <tr>

                    <td  style="text-align:center; height:30px; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;   ">

                           제목</td>

                    <td width="450">

                           &nbsp;<asp:Label ID="LabelSubject" runat="server"></asp:Label>

                           &nbsp;</td>

             </tr>

             <tr>

                   <td  style="text-align:center; height:50%; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;   ">

                           내용</td>

                    <td width="450" style="padding:10px;">

                           <asp:Label ID="LabelContent" runat="server"
                           Width="95%"  Style="word-wrap: normal; word-break: break-all;"></asp:Label>

                    </td>

             </tr>

             <tr>

                    <td  style="text-align:center; height:30px; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;   ">

                           번호</td>

                    <td width="450">

                           &nbsp;<asp:Label ID="LabelSeq" runat="server"></asp:Label>

                           &nbsp;</td>

             </tr>

             <tr>

                    <td  style="text-align:center; height:30px; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;   ">

                           조회수</td>

                    <td width="450">

                           &nbsp;<asp:Label ID="LabelReadCount" runat="server"></asp:Label>

                           &nbsp;</td>

             </tr>

             <tr>

                      <td  style="text-align:center; height:30px; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;   ">

                           작성일</td>

                    <td width="450">

                           &nbsp;<asp:Label ID="LabelRegDate" runat="server"></asp:Label>

                           &nbsp;</td>

             </tr>
                 <tr>

                     <td  style="text-align:center; height:30px; font-weight:bold; font-size:14px; font-weight:bold; font-size:10px; 
         background-color:#424242; color:white;   ">

                           첨부파일</td>

                    <td width="450">

                           &nbsp;&nbsp;<asp:Label ID="LabelFile" runat="server"  ></asp:Label> <!--Text="LabelFile"-->

                    </td>

             </tr>
       </table>

          <div style="text-align:center; margin:20px 0 20px 0">

             <asp:Button ID="ListButton" runat="server" Text="리스트"

                    onclick="ListButton_Click" ValidationGroup="list" BackColor="#FFBF00" style="color:White; border-style:none" />

             <asp:Button ID="EditButton" runat="server" Text="수정하기"

                    onclick="EditButton_Click" BackColor="#FFBF00" style="color:White; border-style:none" />

             <asp:Button ID="DeleteButton" runat="server" Text="삭제하기"  

                    onclick="DeleteButton_Click" BackColor="#FFBF00" style="color:White; border-style:none" />

              <asp:Button ID="ReplyButton" runat="server" Text="답글달기"

                  onclick="ReplyButton_Click" BackColor="#FFBF00" style="color:White; border-style:none"/>

       </div>

</asp:Content>

 