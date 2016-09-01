<%@ Page Title="" Language="C#" MasterPageFile="~/management/MNGMaster.master" AutoEventWireup="true" CodeFile="ResimEkle.aspx.cs" Inherits="management_ResimEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 600px">
        <tr>
            <td>Ürün:</td>
            <td><asp:Label ID="lblUrunAd" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Vitrin:</td>
            <td>
                <asp:Label ID="lblVitrin" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Resim:</td>
            <td>
                <asp:FileUpload ID="fuResim" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Vitrin:</td>
            <td>
                <asp:CheckBox ID="cbVitrin" runat="server" />
            </td>
        </tr>
         <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblUyarı" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click"/>
                <asp:Button ID="btnGeri" runat="server" Text="Ürün Listesine Geri Dön" OnClick="btnGeri_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

