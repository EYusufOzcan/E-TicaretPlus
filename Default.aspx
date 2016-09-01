<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="box-heading">Ürünler</div>
        <div class="box-product">
            <asp:Repeater ID="rpUrunler" runat="server" OnItemCommand="rpUrunler_ItemCommand">
                <ItemTemplate>
                    <div>
                        <div class="image">
                            <a href="UrunDetay.aspx?id=<%#Eval("UrunID") %>">
                                <img src="/resimler/152/<%#Eval("FotoYol") %>" /></a>
                        </div>
                        <div class="name"><a href="UrunDetay.aspx?id=<%#Eval("UrunID") %>"><%#Eval("UrunAd") %></a></div>
                        <div class="price">₺<%#Eval("SonFiyat") %></div>
                        <div class="rating">
                            <img src="resimler/<%#Eval("PuanOrtalama") %>.png" />
                        </div>
                        <div class="cart">
                            <asp:LinkButton ID="LinkButton1" CommandName="sepet" CssClass="button"
                                CommandArgument='<%#Eval("UrunID") %>' runat="server">Sepete Ekle</asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
