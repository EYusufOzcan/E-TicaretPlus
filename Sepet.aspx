<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Sepet.aspx.cs" Inherits="Sepet" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <!--Breadcrumb Part Start-->
        <div class="breadcrumb"></div>
        <!--Breadcrumb Part End-->
        <div class="box">
            <div class="box-heading">Sepet</div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="cart-info">
                        <table>
                            <thead>
                                <tr>
                                    <td class="image">Resim</td>
                                    <td class="name">Ürün Adı</td>
                                    <td class="quantity">Adet</td>
                                    <td class="price">Birim Fiyat</td>
                                    <td class="total">Tutar</td>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpSepet" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="image"><a href="#">
                                                <img title="<%#Eval("urunAd") %>" alt="<%#Eval("urunAd") %>" src="resimler/62/<%#Eval("fotoYol") %>"></a></td>
                                            <td class="name"><a href="#"><%#Eval("urunAd") %></a></td>
                                            <td class="quantity">
                                                <input id="quantity" name="adet" type="text" size="1" value="<%#Eval("adet") %>" name="<%#Eval("id") %>" class="w30">
                                                &nbsp;
                                                <asp:ImageButton ID="btnGuncelle" runat="server" CommandName="guncelle" CommandArgument='<%#Eval("id") %>' OnCommand="btnGuncelle_Command" ImageUrl="~/image/update.png" />
                                                &nbsp;
                                                <asp:ImageButton ID="btnSil" runat="server" CommandName="sil" CommandArgument='<%#Eval("id") %>' OnCommand="btnSil_Command" ImageUrl="~/image/remove.png" />
                                            <td class="price">₺<%#Eval("fiyat") %></td>
                                            <td class="total">₺<%#Eval("tutar") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="cart-total">
                        <table id="total">
                            <tbody>
                                <tr>
                                    <td class="right"></td>
                                    <td class="right"></td>
                                </tr>
                                <tr>
                                    <td class="right"><b>Total:</b></td>
                                    <td class="right">
                                        <asp:Label ID="lblToplam" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
              <div class="buttons">
                      <asp:LoginView runat="server">
                      <AnonymousTemplate>
                          <div class="right"><a class="button" href="Login.aspx">Siparişi Onaylamak İçin Giriş Yapın</a></div>
                      </AnonymousTemplate>
                 <LoggedInTemplate>
                <div class="right"><a class="button" href="Checkout.aspx">Hesap Ödeme</a></div>
                     </LoggedInTemplate>
                       </asp:LoginView>
                <div class="center"><a class="button" href="Default.aspx">Alışverişe Devam Et</a></div>
            </div>
        </div>
</asp:Content>
