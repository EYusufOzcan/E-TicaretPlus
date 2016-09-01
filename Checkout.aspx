<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <!--Breadcrumb Part Start-->
        <div class="breadcrumb"></div>
        <!--Breadcrumb Part End-->
        <div class="box">
            <div class="box-heading">Hesap Ödeme</div>
             <style type="text/css">
                                    .label {
                                    }

                                    .text2 {
                                        padding-left: 150px;
                                        padding-top: -50px;
                                    }

                                    .checkbox {
                                        padding-left: 25px;
                                    }

                                    .validation2 {
                                        font-family: Arial;
                                        font-size: 12px;
                                        color: #F15A23;
                                        font-weight: bold;
                                        text-align: left;
                                    }
                                </style>
            <div class="checkout">
                <asp:LoginView ID="LoginView1" runat="server">
                    <AnonymousTemplate>
                        <div class="checkout-heading">Üyelik Seçenekleri</div>
                        <div class="checkout-content" style="display: block;">
                            <div class="left">
                                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="White" Font-Names="Arial" Font-Size="X-Large" ForeColor="#333333" Height="449px" Width="434px">
                                    <ContinueButtonStyle CssClass="button" />
                                    <CreateUserButtonStyle CssClass="button" />
                                    <TitleTextStyle BackColor="#F15A23" Font-Bold="True" ForeColor="White" />
                                    <TextBoxStyle Width="250px" />
                                    <LabelStyle Font-Bold="true" />
                                    <WizardSteps>
                                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                                        </asp:CreateUserWizardStep>
                                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                                        </asp:CompleteWizardStep>
                                    </WizardSteps>
                                    <HeaderStyle BackColor="#F15A23" BorderColor="#F15A23" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="14px" ForeColor="White" HorizontalAlign="Center" />
                                </asp:CreateUserWizard>
                            </div>
                            <div class="right" id="login">
                                <asp:Login ID="Login1" runat="server" BackColor="White" Font-Names="Arial"
                                    Font-Size="X-Large" ForeColor="#333333" Height="300px" TextLayout="TextOnTop" Width="369px" DestinationPageUrl="Checkout.aspx">
                                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" Font-Bold="true" />
                                    <LoginButtonStyle Font-Bold="true" CssClass="button" />
                                    <TextBoxStyle Font-Size="12px" Width="250px" CssClass="text2" />
                                    <LabelStyle Font-Bold="true" CssClass="label" />
                                    <CheckBoxStyle CssClass="checkbox" />
                                    <TitleTextStyle BackColor="#F15A23" Font-Bold="True" Font-Size="14px" ForeColor="White" />
                                </asp:Login>
                            </div>
                        </div>
                        </div>
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <div class="checkout">
                            <div class="checkout-heading">Adres Bilgileri</div>
                            <div class="checkout-content" style="display: block;">
                                <table class="form">
                                    <tbody>
                                        <tr>
                                            <td><span class="required">*</span> İsim/Soyisim:</td>
                                            <td>
                                                <asp:TextBox ID="txtAd" CssClass="large-field" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RV1" ControlToValidate="txtAd" runat="server" CssClass="validation2" ErrorMessage="İsim/Soyisim girmelisiniz."></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td><span class="required">*</span>Adres:</td>
                                            <td>
                                                <asp:TextBox ID="txtAdres" CssClass="large-field" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RV2" ControlToValidate="txtAdres" runat="server" CssClass="validation2" ErrorMessage="Adres bilgisi girmelisiniz."></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td><span class="required" id="payment-postcode-required">*</span> Posta Kodu:</td>
                                            <td>
                                                <asp:TextBox ID="txtPostaKodu" CssClass="large-field" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RV3" ControlToValidate="txtPostaKodu" runat="server" CssClass="validation2" ErrorMessage="Posta Kodu girmelisiniz."></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td><span class="required">*</span> İl:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlIller" CssClass="large-field" runat="server" OnSelectedIndexChanged="ddlIller_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RV4" ControlToValidate="ddlIller" runat="server" CssClass="validation2" ErrorMessage="İl seçmelisiniz"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td><span class="required">*</span> İlçe:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlIlceler" CssClass="large-field" runat="server" AutoPostBack="False">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RV5" ControlToValidate="ddlIlceler" runat="server" CssClass="validation2" ErrorMessage="İlçe seçmelisiniz"></asp:RequiredFieldValidator></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="checkout">
                            <div class="checkout-heading">Siparişi Onayla</div>
                            <div class="checkout-content">
                                <div class="checkout-product" style="display: block;">
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
                                                        <td class="image">
                                                            <img title="<%#Eval("urunAd") %>" src="resimler/62/<%#Eval("fotoYol") %>"></td>
                                                        <td class="name"><%#Eval("urunAd") %></td>
                                                        <td class="quantity"><%#Eval("adet") %></td>
                                                        <td class="price">₺<%#Eval("fiyat") %></td>
                                                        <td class="total">₺<%#Eval("tutar") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td class="price" colspan="4"><b>Toplam:</b></td>
                                                <td class="total">
                                                    <asp:Label ID="lblToplam" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                                <div class="buttons">
                                    <div class="right">
                                        <asp:Button ID="btnOnayla" runat="server" CssClass="button" OnClick="btnOnayla_Click" Text="Siparişi Onayla" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                    </LoggedInTemplate>
                </asp:LoginView>
            </div>
        </div>
    </div>
</asp:Content>


