<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Passenger.aspx.cs" Inherits="lab5.Passenger" MasterPageFile="~/Ship.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr align="center">
            <td>
                <asp:Label ID="Label4" runat="server" Text="Список пассажиров каюты" Font-Bold="True" Font-Size="20pt" ForeColor="Maroon">
                </asp:Label>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20pt" ForeColor="Maroon">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server"
                   AutoGenerateColumns="false"
                    ShowFooter="true" ShowHeader="true"
                    AllowPaging="true"
                    Font-Size="14pt" HorizontalAlign="Center"
                    onrowcancelingedit="GridView1_RowCancelingEdit"
                    onrowdeleting="GridView1_RowDeleting"
                    onrowediting="GridView1_RowEditing"
                    onrowupdating="GridView1_RowUpdating"
                    onpageindexchanging="GridView1_PageIndexChanging"
                    onrowcommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Фамилия пассажира" ItemStyle-Width="250">
                            <ItemTemplate>
                                <asp:Label id="myLabel1" runat="server" Text='<%# Bind("surName")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBox1" runat="server" Width="250" Text='<%# Bind("surName") %>'/>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="myFooterTextBox1" runat="server" Width="250" Text='<%# Bind("surName") %>' />
                            </FooterTemplate>
                            <ItemStyle Width="250px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Имя пассажира" ItemStyle-Width="250">
                            <ItemTemplate>
                                <asp:Label id="myLabel2" runat="server" Text='<%# Bind("Name")%>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="myTextBox2" runat="server" Width="250" Text='<%# Bind("Name") %>'/>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="myFooterTextBox2" runat="server" Width="250" Text='<%# Bind("Name") %>' />
                            </FooterTemplate>

<ItemStyle Width="250px"></ItemStyle>
                           </asp:TemplateField>
                        <asp:TemplateField HeaderText="Отчество пассажира" ItemStyle-Width="250">
                                <ItemTemplate>
                                    <asp:Label id="myLabel3" runat="server" Text='<%# Bind("LastName")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="myTextBox3" runat="server" Width="250" Text='<%# Bind("LastName") %>'/>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="myFooterTextBox3" runat="server" Width="250" Text='<%# Bind("LastName") %>' />
                                </FooterTemplate>

<ItemStyle Width="250px"></ItemStyle>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Возраст" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label id="myLabel4" runat="server" Text='<%# Bind("Year")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="myTextBox4" runat="server" Width="100" Text='<%# Bind("Year") %>'/>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="myFooterTextBox4" runat="server" Width="100" Text='<%# Bind("Year") %>' />
                                </FooterTemplate>

<ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Команды" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibEdit" runat="server" CommandName="Edit" Text="Edit" ImageUrl="~/img/3.png"/>
                                    <asp:ImageButton ID="ibDelete" runat="server" CommandName="Delete" Text="Delete" ImageUrl="~/img/2.png" />
                                    <asp:ImageButton ID="ibMod" runat="server" CommandName="Mod" Text="Mod" ImageUrl="~/img/5.png" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="ibUpdate" runat="server" CommandName="Update" Text="Update" ImageUrl="~/img/8.png" />
                                    <asp:ImageButton ID="ibCancel" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="~/img/7.png" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="ibInsert" runat="server" CommandName="Insert" OnClick="ibInsert_Click" ImageUrl="~/img/1.png" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table border="1" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="250" align="center">
                                    Фамилия пассажира
                                </td>
                                <td width="250" align="center">
                                    Имя пассажира
                               </td>
                                <td width="50" align="center">
                                   Отчество пассажира
                                </td>
                                <td width="100" align="center">
                                    Возраст
                                </td>
                                <td>
                                    Команды
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="emptyFirstNameTextBox" runat="server" Width="250"/>
                                </td>
                                <td>
                                    <asp:TextBox ID="emptyLastNameTextBox" runat="server" Width="250"/>
                                </td>
                                <td>
                                    <asp:TextBox ID="emptySexTextBox" runat="server" Width="250"/>
                                </td>
                                <td>
                                    <asp:TextBox ID="emptyYearTextBox" runat="server" Width="100"/>
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="emptyImageButton" runat="server" ImageUrl="~/img/9.png" OnClick="ibInsertInEmpty_Click"/>
                                 </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <PagerStyle HorizontalAlign ="Center" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
