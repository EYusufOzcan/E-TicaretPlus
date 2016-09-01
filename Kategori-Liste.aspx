<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Kategori-Liste.aspx.cs" Inherits="Kategori_Liste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <!--Breadcrumb Part Start-->
        <div class="breadcrumb"></div>
        <!--Breadcrumb Part End-->
            <div class="box">
        <div class="box-heading">Ürünler</div>
        <div class="product-filter">
            <div class="display"><b>Display:</b> <a href="Kategori.aspx" class="list-icon" title="Grid View">Grid</a><span class="grid1-icon" title="List View">List</span></div>
            <%--<div class="limit">
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
        <div class="product-list">
            <asp:Repeater ID="rpUrun" runat="server">
                <ItemTemplate>
                    <div>
                        <div class="right">
                            <div class="cart">
                                <asp:LinkButton ID="btnSepet" CommandName="sepet" CssClass="button" CommandArgument='<%#Eval("UrunID") %>' OnCommand="btnSepet_Command" runat="server">Sepete Ekle</asp:LinkButton>
                            </div>
                        </div>
                        <div class="left">
                            <div class="image">
                                <a href="UrunDetay.aspx?id=<%#Eval("UrunID") %>">
                                    <img src="resimler/62/<%#Eval("FotoYol") %>" alt="<%#Eval("UrunAd") %>" /></a>
                            </div>
                            <div class="price">₺<%#Eval("SonFiyat") %></div>
                            <div class="name"><a href="UrunDetay.aspx?id=<%#Eval("UrunID") %>"><%#Eval("UrunAd") %></a></div>
                            <div class="rating">
                                <img src="resimler/<%#Eval("PuanOrtalama") %>.png" />
                            </div>
                            <div class="description"><%#Eval("Detay") %></div>
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
        </div>
</asp:Content>

