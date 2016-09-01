<%@ Page Title="" Language="C#" MasterPageFile="~/management/MNGMaster.master" AutoEventWireup="true" CodeFile="KategoriMarka.aspx.cs" Inherits="management_KategoriMarka" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table style="width: 600px">
            <tr>
                <td>Kategori Adı:</td>
                <td><asp:DropDownList ID="ddlKategori" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlKategori_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Marka Adı:</td>
                <td><asp:DropDownList ID="ddlMarka" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button ID="btnEsle" runat="server" Text="Eşle" OnClick="btnEsle_Click" /></td>
            </tr>
        </table>
        <div class="clear"></div>
        <div class="tablo">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager><!-- Update modelin çalışması için bu araç eklenmeli-->
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:GridView ID="gvKatMar" CssClass="grid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="KategoriAd" />
                        <asp:BoundField DataField="MarkaAd" />
                        <asp:HyperLinkField DataNavigateUrlFields="KategoriId,MarkaId" DataNavigateUrlFormatString="KategoriMarka.aspx?katid={0}&amp;marid={1}" Text="Sil" />
                    </Columns>
                    <HeaderStyle CssClass="header" />
                    <PagerStyle CssClass="pager" />
                    <RowStyle CssClass="rows" />
                </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>

