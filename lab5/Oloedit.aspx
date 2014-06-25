<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Oloedit.aspx.cs" Inherits="lab5.Oloedit" MasterPageFile="~/Ship.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr align="center">
            <td>
                <asp:Label ID="Label4" runat="server" Text="Номер каюты" Font-Bold="True" Font-Size="20pt" ForeColor="Maroon">
                </asp:Label>
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20pt" ForeColor="Maroon">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="textBox1"  runat="server" Enabled=true Visible=true Text="123" />
                <asp:Button ID="button1" runat="server" Text="Применить" OnClick="button1_click" />
                    
                    <PagerStyle HorizontalAlign ="Center" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
