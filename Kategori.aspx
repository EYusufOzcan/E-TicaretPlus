<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Kategori.aspx.cs" Inherits="Kategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <!--Breadcrumb Part Start-->
        <div class="breadcrumb"><a href="index.html">Home</a> » <a href="#">Electronics</a></div>
        <!--Breadcrumb Part End-->
        <h1>Electronics</h1>
        <div class="product-filter">
            <div class="display"><b>Görüntüleme Tarzı:</b> <span class="list1-icon" title="Grid View">Grid</span><a href="Kategori-Liste.aspx" class="grid-icon" title="List View">List</a></div>
<%--            <div class="limit">
                <b>Show:</b>
                <select>
                    <option selected="selected" value="15">15</option>
                    <option value="25">25</option>
                    <option value="50">50</option>
                    <option value="75">75</option>
                    <option value="100">100</option>
                </select>
            </div>--%>
            <div class="sort">
                <b>Sıralama:</b>&nbsp;
                <asp:DropDownList ID="ddlSiralama" runat="server" CssClass="sort" OnSelectedIndexChanged="ddlSiralama_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Sıralama Tipi Seçin" Value="0"></asp:ListItem>
                    <asp:ListItem Text="İsme Göre (A - Z)" Value="1"></asp:ListItem>
                    <asp:ListItem Text="İsme Göre (Z - A)" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Fiyata Göre (Küçükten Büyüğe)" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Fiyata Göre (Büyükten Küçüğe)" Value="4"></asp:ListItem>
<%--                    <asp:ListItem Text="Yıldıza Göre (Yüksekten Düşüğe)" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Yıldıza Göre (Düşükten Yükseğe)" Value="6"></asp:ListItem>--%>
                </asp:DropDownList>
            </div>
        </div>
        <!--Product Grid Start-->
        <div class="product-grid">
            <asp:Repeater ID="rpUrun" runat="server">
                <ItemTemplate>
                    <div>
                        <div class="image">
                            <a href="UrunDetay.aspx?id=<%#Eval("UrunID") %>">
                                <img src="resimler/152/<%#Eval("FotoYol") %>" alt="<%#Eval("UrunAd") %>" /></a>
                        </div>
                        <div class="name"><a href="product.html"><%#Eval("UrunAd") %></a></div>
                        <div class="price">₺<%#Eval("SonFiyat") %> </div>
                        <div class="rating">
                            <img src="resimler/<%#Eval("PuanOrtalama") %>.png" />
                        </div>
                        <div class="cart">
                            <asp:LinkButton ID="btnSepet" CommandName="sepet" CssClass="button" CommandArgument='<%#Eval("UrunID") %>' OnCommand="btnSepet_Command" runat="server">Sepete Ekle</asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>


        <!--Product Grid End-->
        <!--Pagination Part Start-->
        <div class="pagination">
            <div class="links"><b>1</b> <a href="#">2</a> <a href="#">&gt;</a> <a href="#">&gt;|</a></div>
        </div>
        <!--Pagination Part End-->
    </div>
</asp:Content>

