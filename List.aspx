<%@ Page Title="" Language="C#" MasterPageFile="~/Board.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List"  %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"

             AutoGenerateColumns="False" CssClass="table" DataKeyNames="seq"

              onrowdatabound="GridView1_RowDataBound"

              Width="960px" Height="100px"  >

             <Columns>


                    <asp:BoundField DataField="Num" HeaderText="번호" InsertVisible="False"

                           ReadOnly="True" SortExpression="Num">

                    <ItemStyle HorizontalAlign="Center" Width="50px" />

                    </asp:BoundField>


                  <%--  <asp:BoundField DataField="seq" HeaderText="번호" InsertVisible="False"

                           ReadOnly="True" SortExpression="seq">

                    <ItemStyle HorizontalAlign="Center" Width="50px" />

                    </asp:BoundField>--%>


                    <asp:HyperLinkField DataNavigateUrlFields="seq"

                           DataNavigateUrlFormatString="View.aspx?seq={0}" DataTextField="subject"

                           HeaderText="제목">

                    <ItemStyle Width="340px" />

                    </asp:HyperLinkField>


                  <%--  <asp:BoundField DataField="name" HeaderText="이름" SortExpression="name">

                    <ItemStyle HorizontalAlign="Center" Width="80px" />

                    </asp:BoundField>--%>


                     <asp:BoundField DataField="id" HeaderText="아이디" SortExpression="name">

                    <ItemStyle HorizontalAlign="Center" Width="80px" />

                    </asp:BoundField>


                    <asp:BoundField DataField="regDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"

                           HeaderText="작성일" SortExpression="regDate">

                    <ItemStyle HorizontalAlign="Center" Width="80px" />

                    </asp:BoundField>


                    <asp:BoundField DataField="readCount" HeaderText="조회수"

                           SortExpression="readCount">

                    <ItemStyle HorizontalAlign="Center" Width="50px" />

                    </asp:BoundField>

             </Columns>

             <HeaderStyle BorderStyle="Solid" BorderWidth="1px" />



       </asp:GridView>

       <asp:SqlDataSource ID="SqlDataSource1" runat="server"

             ConnectionString="<%$ ConnectionStrings:boarddbConnectionString2 %>"

             SelectCommand="Select [seq], [subject], [readcount], [regdate], [email], b.id, boardname From [boards] as b inner join members as m on b.id = m.id Order by [seq] DESC">

       </asp:SqlDataSource>

        <div style="text-align:center; margin-bottom:20px; margin-top:30px">

       <asp:DropDownList ID="DropDownList1" runat="server" 
           onselectedindexchanged="DropDownList1_SelectedIndexChanged"  Width="65px">
           
           <asp:ListItem Value="subject" text="제목"></asp:ListItem>

           <asp:ListItem Value="b.id" Text="아이디"></asp:ListItem>

           <asp:ListItem Value="content" Text="내용"></asp:ListItem>

       </asp:DropDownList>

 
       <asp:TextBox ID="Textsearch" runat="server" 
           ontextchanged="Textsearch_TextChanged" HorizontalAlign="Center" width="200px"></asp:TextBox>

           <asp:Button ID="SearchButton" runat="server" Text="검색" onclick="SearchButton_Click" BackColor="#FFBF00" style="color:White; border-style:none"    />

           </div>
        <div>
      
       <asp:GridView ID="SearchList" runat="server" AutoGenerateColumns="false" onselectedindexchanged="SearchList_SelectedIndexChanged" >

          <Columns>

            <asp:HyperLinkField HeaderText="제목"

               DataNavigateUrlFields="subject"

               DataNavigateUrlFormatString="View.aspx?seq={0}"

               DataTextField="subject" ItemStyle-Width="350px" />

            <asp:BoundField HeaderText="아이디" DataField="b.id" />
      
            <asp:BoundField HeaderText="내용" DataField="content" />

           </Columns>

             </asp:GridView>


              <div style="text-align:right;margin:10px;">

                   <asp:Button ID="WriteButton" runat="server" Text="글쓰기"

                    onclick="WriteButton_Click" ValidationGroup="list" BackColor="#FFBF00" style="color:White; border-style:none" />
        </div>


</asp:Content>

 

 