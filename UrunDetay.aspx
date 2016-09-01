<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="UrunDetay.aspx.cs" Inherits="UrunDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <asp:Repeater ID="rpUrun" runat="server" OnItemDataBound="rpUrun_ItemDataBound">
            <ItemTemplate>
                <div class="breadcrumb">&nbsp;</div>
                <div class="product-info">
                    <div class="left">
                        <div class="image">
                            <a href="resimler/600/<%#Eval("FotoYol") %>" class="cloud-zoom colorbox" id='zoom1' rel="adjustX: 0, adjustY:0, tint:'#000000',tintOpacity:0.2, zoomWidth:360, position:'inside', showTitle:false">
                                <img src="resimler/350/<%#Eval("FotoYol") %>" title="#" alt="#" id="image" /></a>
                        </div>

                        <div class="image-additional">
                            <asp:Repeater ID="rpResim" runat="server">
                                <ItemTemplate>
                                    <a href="resimler/600/<%#Eval("FotoYol") %>" title="#" class="cloud-zoom-gallery" rel="useZoom: 'zoom1', smallImage: 'resimler/350/<%#Eval("FotoYol") %>' ">
                                        <img src="resimler/62/<%#Eval("FotoYol") %>" width="62" title="#" alt="#" /></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="right">
                        <h1><%# Eval("UrunAd") %></h1>
                        <div class="description">
                            <span>Marka:</span> <a href="#"><%# Eval("MarkaAd") %></a><br>
                            <span>Stok Adedi:</span> <%# Eval("Stok") %>
                        </div>
                        <div class="price">
                            Fiyat: <span class="price-old"><%# string.Format("{0}", Eval("Fiyat"))  %></span><div class="price-tag">₺<%#Eval("SonFiyat") %></div>

                        </div>
                        <div class="cart">
                            <div>
                                <div class="qty">
<%--                                    <strong>Adet:</strong><input type="number" value="1" size="4" readonly="readonly" name="quantity" max="<%#Eval("Stok") %>" class="w30" id="adet">--%>
                                    <div class="clear"></div>
                                </div>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <div class="cart">
                                    <asp:LinkButton ID="btnSepet" CommandName="sepet" CssClass="button" CommandArgument='<%#Eval("UrunID") %>' OnCommand="btnSepet_Command" runat="server">Sepete Ekle</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="review">
                            <div>
                                <img src="resimler/<%#Eval("PuanOrtalama") %>.png">&nbsp;&nbsp;<a onclick="$('a[href=\'#tab-review\']').trigger('click');"><%#Eval("YorumSayisi") %> değerlendirme yapılmış</a>&nbsp;&nbsp;|&nbsp;&nbsp;
                                <a onclick="$('a[href=\'#tab-review\']').trigger('click');">Yorum Yap</a>
                            </div>
                        </div>
                        <div class="tags"><b>Etiketler:</b> <a href="Default.aspx?katid=<%# Eval("KategoriID") %>"><%# Eval("KategoriAd") %></a>, <a href="Default.aspx?marid=<%# Eval("MarkaID") %>"><%# Eval("MarkaAd") %></a> </div>
                    </div>
                </div>
                <div id="tabs" class="htabs"><a href="#tab-description">Özellikler</a> <a href="#tab-review">Yorumlar</a> </div>
                <div id="tab-description" class="tab-content">
                    <%#Eval("Detay") %>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="tab-content" id="tab-review">
            <asp:Repeater ID="rpYorumlar" runat="server">
                <ItemTemplate>
                    <div class="review-list">
                        <div class="author"><b><%#Eval("UserName") %></b>,  <%# string.Format("{0:dd/MM/yyy}", Eval("Tarih").ToString().Substring(0,10)) %> tarihinde</div>
                        <div class="rating">
                            <img src="resimler/<%#Eval("Puan") %>.png" id="resim">
                        </div>
                        <div class="text"><%#Eval("Yorum") %></div>
                        <br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:LoginView ID="LoginView1" runat="server">
                <AnonymousTemplate>
                    Yorum yapabilmek için
                                <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="giriş yapın." />
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <br>
                    <b>Yorumunuz:</b>
                    <asp:TextBox ID="txtYorum" runat="server" Style="width: 98%;" Rows="8" cols="40" name="text" TextMode="MultiLine"></asp:TextBox>
                    <br>
                    <br>
                    <b>Puanınız:</b>
                    &nbsp;
                             <asp:RadioButton ID="rb1" Text="1" GroupName="puan" runat="server" />
                    &nbsp;
                            <asp:RadioButton ID="rb2" Text="2" GroupName="puan" runat="server" />
                    &nbsp;
                            <asp:RadioButton ID="rb3" Text="3" GroupName="puan" runat="server" />
                    &nbsp;
                            <asp:RadioButton ID="rb4" Text="4" GroupName="puan" runat="server" />
                    &nbsp;
                           <asp:RadioButton ID="rb5" Text="5" GroupName="puan" runat="server" />
                    <br>
                    <br>
                    <div class="buttons">
                        <div class="right">
                            <div class="cart">
                                <asp:LinkButton ID="btnYorum" runat="server" CssClass="button" OnCommand="btnYorum_Command">Yorum Yap</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </LoggedInTemplate>
            </asp:LoginView>
        </div>
        <div class="box">
            <div class="box-heading">Benzer Ürünler</div>
            <div class="box-product">
                <asp:Repeater ID="rpBenzer" runat="server">
                    <ItemTemplate>
                        <div>
                            <div class="image">
                                <a href="UrunDetay.aspx?id=<%#Eval("UrunID") %>">
                                    <img src="resimler/152/<%#Eval("FotoYol") %>"></a>
                            </div>
                            <div class="name"><a href="UrunDetay.aspx?id=<%#Eval("UrunID") %>"><%#Eval("UrunAd") %></a></div>
                            <div class="price"><span class="price-old">₺<%#Eval("Fiyat") %></span>&nbsp;<span class="price-new">₺<%#Eval("SonFiyat") %></span></div>
                            <div class="name">
                                <asp:LinkButton ID="LinkButton1" CommandName="sepet" CommandArgument='<%#Eval("UrunID") %>' OnCommand="btnSepet_Command" runat="server">Sepete Ekle</asp:LinkButton>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>

