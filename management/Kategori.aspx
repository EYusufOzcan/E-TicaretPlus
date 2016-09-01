<%@ Page Title="" Language="C#" MasterPageFile="~/management/MNGMaster.master" AutoEventWireup="true" CodeFile="Kategori.aspx.cs" Inherits="management_Kategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 500px">
        <tr>
            <td>Kategori Adı:</td>
            <td><asp:TextBox ID="txtKategoriAd" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKategoriAd" CssClass="validation" ErrorMessage="Kategori girmelisiniz."></asp:RequiredFieldValidator>
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
    <asp:UpdatePanel ID="upKategoriler" runat="server">
        <ContentTemplate>
        <asp:GridView ID="gvKategoriler" runat="server" CssClass="grid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="KategoriAd" HeaderText="Kategori Adı" />
                <asp:HyperLinkField DataNavigateUrlFields="KategoriID" DataNavigateUrlFormatString="Kategori.aspx?id={0}" Text="Güncelle" />
            </Columns>
        </asp:GridView>
            </ContentTemplate>
    </asp:UpdatePanel>
             </div>
</asp:Content>



