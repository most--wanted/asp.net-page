<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="lab5._Default" MasterPageFile="~/Ship.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1"
runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="false"
                ShowFooter="true" ShowHeader="true"
                AllowPaging="true"
                onrowdeleting="GridView1_RowDeleting" Font-Size="14pt"
                onrowediting="GridView1_RowEditing"
                onrowcancelingedit="GridView1_RowCancelingEdit"
                onpageindexchanging="GridView1_PageIndexChanging"
                HorizontalAlign="Center"
                onrowupdating="GridView1_RowUpdating"
                onrowcommand="GridView1_RowCommand" Height="308px" Width="918px">
    <Columns>
        <asp:TemplateField HeaderText="Номер каюты">
            <ItemTemplate>
                <asp:Label id="myLabel1" runat="server" Text='<%# Bind("number")%>' />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="myTextBox1" runat="server" Width="200" Text='<%# Bind("number") %>'/>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="myFooterTextBox1" runat="server" Width="200" Text='<%# Bind("number") %>' />
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Описание">
            <ItemTemplate>
                <asp:Label id="myLabel2" runat="server" Text='<%# Bind("opisanie")%>' />
            </ItemTemplate>
           <EditItemTemplate>
                <asp:TextBox ID="myTextBox2" runat="server" Width="300" Text='<%# Bind("opisanie") %>'/>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:TextBox ID="myFooterTextBox2" runat="server" Width="300" Text='<%# Bind("opisanie") %>' />
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Команды"  FooterStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:ImageButton ID="ibEdit" runat="server" CommandName="Edit" Text="Edit" ImageUrl="~/img/3.png" />
                <asp:ImageButton ID="ibDelete" runat="server" CommandName="Delete" Text="Delete" ImageUrl="~/img/2.png" />
                <asp:ImageButton ID="lbSelect" runat="server" CommandName="Select" ImageUrl="~/img/6.png" CommandArgument='<%# Container.DataItemIndex %>'/>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:ImageButton ID="ibUpdate" runat="server" CommandName="Update" Text="Update" ImageUrl="~/img/8.png" />
                <asp:ImageButton ID="ibCancel" runat="server" CommandName="Cancel" Text="Cancel" ImageUrl="~/img/7.png" />
            </EditItemTemplate>
            <FooterTemplate>
                <asp:ImageButton ID="ibInsert" runat="server" CommandName="Insert" OnClick="ibInsert_Click" ImageUrl="~/img/1.png" />
              </FooterTemplate>

            <FooterStyle HorizontalAlign="Center"></FooterStyle>
        </asp:TemplateField>
       </Columns>
        <EmptyDataTemplate>
                        <table border="1" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="250" align="center">
                                   Номер каюты
                                </td>
                                <td width="250" align="center">
                                    Описание
                               </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="emptyGroupNameTextBox" runat="server" Width="250"/>
                                </td>
                                <td>
                                    <asp:TextBox ID="emptyCuratorNameTextBox" runat="server" Width="250"/>
                                </td>
                                 <td align="center">
                                 <asp:ImageButton ID="emptyImageButton" runat="server" ImageUrl="~/img/9.png" OnClick="ibInsertInEmpty_Click"/>
                                 </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
