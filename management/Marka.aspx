<%@ Page Title="" Language="C#" MasterPageFile="~/management/MNGMaster.master" AutoEventWireup="true" CodeFile="Marka.aspx.cs" Inherits="management_Marka" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 500px">
        <tr>
            <td>Marka Adı:</td>
            <td>
                <asp:TextBox ID="txtMarkaAd" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Marka girmelisiniz." CssClass="validation" ControlToValidate="txtMarkaAd"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
                <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" Visible="false" OnClick="btnGuncelle_Click" />
            </td>
        </tr>
    </table>
        <div class="clear"></div>
         <div class="tablo">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upMarkalar" runat="server">
        <ContentTemplate>
        <asp:GridView ID="gvMarkalar" CssClass="grid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MarkaAd" HeaderText="Marka Adı" />
                <asp:HyperLinkField DataNavigateUrlFields="MarkaID" DataNavigateUrlFormatString="Marka.aspx?id={0}" Text="Güncelle" />
            </Columns>

        </asp:GridView>
            </ContentTemplate>
    </asp:UpdatePanel>
             </div>
</asp:Content>

