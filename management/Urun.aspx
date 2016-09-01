<%@ Page Title="" Language="C#" MasterPageFile="~/management/MNGMaster.master" AutoEventWireup="true" CodeFile="Urun.aspx.cs" Inherits="management_Urun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table style="width: 800px" class="text">
            <tr>
                <td>Ürün Adı:</td>
                <td><asp:TextBox ID="txtUrunAd" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ürün adı girmelisiniz." ControlToValidate="txtUrunAd" ToolTip="*" CssClass="validation"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 23px">Kategori Adı:</td>
                <td style="height: 23px"><asp:DropDownList ID="ddlKategori" runat="server" OnSelectedIndexChanged="ddlKategori_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td>Marka Adı:</td>
                <td><asp:DropDownList ID="ddlMarka" runat="server"></asp:DropDownList><br /></td>
            </tr>
            <tr>
                <td>Stoktaki Adedi:</td>
                <td>
                    <asp:TextBox ID="txtStok" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rvStok" runat="server" MinimumValue="0" CssClass="validation" ControlToValidate="txtStok" ErrorMessage="Stok adedi sıfırdan küçük olamaz." MaximumValue="2147483647"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td>Fiyatı:</td>
                <td><asp:TextBox ID="txtFiyat" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Fiyat girmelisiniz." ControlToValidate="txtFiyat" ToolTip="*" CssClass="validation"></asp:RequiredFieldValidator>
                    <%--<asp:RangeValidator ID="rvFiyat" runat="server" MinimumValue="0" ControlToValidate="txtFiyat" CssClass="validation" ErrorMessage="Ürün fiyatı sıfırdan küçük olamaz." MaximumValue="2147483647"></asp:RangeValidator>--%>
                </td>
            </tr>
            <tr>
                <td>İndirim Oranı:</td>
                <td><asp:TextBox ID="txtIndirim" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="İndirim oranı girmelisiniz." ControlToValidate="txtIndirim" ToolTip="*" CssClass="validation"></asp:RequiredFieldValidator>   
                    <%--<asp:RangeValidator ID="rvIndirim" runat="server" MinimumValue="0" ControlToValidate="txtIndirim" CssClass="validation" ErrorMessage="İndirim oranı sıfırdan küçük olamaz." MaximumValue="90"></asp:RangeValidator>--%>
                </td>
            </tr>
            <tr>
                <td>Detay</td>
                <td><asp:TextBox ID="txtDetay" runat="server" TextMode="MultiLine" BorderStyle="Inset" EnableTheming="True"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Detay girmelisiniz." ControlToValidate="txtDetay" ToolTip="*" CssClass="validation"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td>Aktif:</td>
                <td><asp:CheckBox ID="cbAktif" runat="server" /><br /></td>
            </tr>
            <tr>
                <td>Vitrin:</td>
                <td><asp:CheckBox ID="cbVitrin" runat="server" /><br /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" /></td>
            </tr>
        </table>
</asp:Content>

