<%@ Page Title="" Language="C#" MasterPageFile="~/management/MNGMaster.master" AutoEventWireup="true" CodeFile="UrunListesi.aspx.cs" Inherits="management_UrunListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="tablo">
        <asp:GridView ID="gvUrunler" CssClass="grid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  runat="server" AllowPaging="True" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UrunAd" HeaderText="Ürün Adı" />
                <asp:BoundField DataField="KategoriAd" HeaderText="Kategori Adı"/>
                <asp:BoundField DataField="MarkaAd" HeaderText="Marka Adı"/>
                <asp:BoundField DataField="Stok" HeaderText="Stok"/>
                <asp:BoundField DataField="Fiyat" HeaderText="Fiyat" />
                <asp:BoundField DataField="IndirimOrani" HeaderText="İndirim Oranı"/>
                <asp:BoundField DataField="SonFiyat" HeaderText="Son Fiyat"/>
                <asp:HyperLinkField DataNavigateUrlFields="UrunID" DataNavigateUrlFormatString="ResimEkle.aspx?id={0}" Text="Resim Ekle" />
            </Columns>

<HeaderStyle CssClass="header"></HeaderStyle>

<PagerStyle CssClass="pager"></PagerStyle>

<RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>

