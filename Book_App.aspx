<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book_App.aspx.cs" Inherits="web_book_app.Book_App" %>

<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">
      <title></title>
        </head>
        <body>
         <div style="background-color:darkkhaki; text-align:center ;margin:auto; height:50%; width:50%; border-radius:5px;padding:40px 0 0 0 "  >

            <form id="form1" runat="server">
            <div class="row" style="padding:10px">
                <div class="col-md-12 col-sm-12 col-xs-12">

               <label id="lblBookName"> Book  Name:</label>
                    
            <asp:TextBox ID="txtBookName" runat="server" ReadOnly = "false"></asp:TextBox>
                
                    <label id="lblPageCount"> Book Pages Count:</label>
                    
             <asp:TextBox ID="txtPageCount" runat="server" ReadOnly = "false"></asp:TextBox>
                                          
                      </div>
          <div class="row" style="padding:10px">
            <div class="col-md-12 col-sm-12 col-xs-12">
               <label id="lblWriter">Writer Name :</label>
              
            <asp:TextBox ID="txtWriter" runat="server"  ReadOnly = "false"></asp:TextBox>

              <label id="lblCategori">Categori :</label>
              
            <asp:TextBox ID="txtCategori" runat="server"  ReadOnly = "false"></asp:TextBox>
              </div>  
                 </div>  

       
                        <div class="row" style="padding:10px">

                                <asp:Button ID="Save_book" runat="server" OnClick="Save_Book" Text="Save Book" Width="125px" style="margin-left: 0px" />
                                 <asp:Button ID="Show_books" runat="server" OnClick="Show_book" Text="Show Book" Width="125px" style="margin-left: 0px" />

                                </div>
             
                      </div>
                    <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table cellspacing="0" rules="all" border="1">
                        <tr>
                            <th data-priority="1">ID </th>
                            <th data-priority="1">Book Name</th>
                            <th data-priority="1">Writer Name</th>
                            <th data-priority="1">Pages Count </th>
                            <th data-priority="1">Categoies</th>
                             <th data-priority="1">Update</th>
                             <th data-priority="1">Delete</th>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                             <th>
                            <asp:TextBox ID="id" runat="server" Width="30" Text='<%# Eval("id") %>' Visible="true" />
                           
                        </th>  
                            <th>
                            <asp:TextBox ID="txtbookName" runat="server" Width="200" Text='<%# Eval("BookName") %>' Visible="true" />
                           
                        </th>  
                            <th>
                            <asp:TextBox ID="txtWriter" runat="server" Width="200" Text='<%# Eval("WriterName") %>' Visible="true" />

                            </th>
                            <th>
                             <asp:TextBox ID="txtPageCount" runat="server" Width="50" Text='<%# Eval("PagesCount") %>' Visible="true" />

                            </th>
                            <th>
                            <asp:TextBox ID="txtCategories" runat="server" Width="75" Text='<%# Eval("Categories") %>' Visible="true" />

                            </th>
                           <th>
                            <asp:LinkButton ID="LinkButton" Text="Update" runat="server" Visible="true" OnClick="OnUpdate" />

                         </th>
                            <th>
                            <asp:LinkButton ID="LinkButton1" Text="Delete" runat="server" Visible="true" OnClick="OnDelete" />

                         </th>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
            </asp:Repeater>

           
            </form>
                </div>
            </body>
            </html>
