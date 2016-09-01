<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Uye.aspx.cs" Inherits="Uye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="White" Font-Names="Arial" Font-Size="X-Large" ForeColor="#333333" Height="449px" Width="434px">
        <ContinueButtonStyle CssClass="button" />
        <CreateUserButtonStyle CssClass="button"/>
        <TitleTextStyle BackColor="#F15A23" Font-Bold="True" ForeColor="White" />
        <TextBoxStyle Width="250px"/>
        <LabelStyle Font-Bold="true" />
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
        <HeaderStyle BackColor="#F15A23" BorderColor="#F15A23" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="14px" ForeColor="White" HorizontalAlign="Center" />
    </asp:CreateUserWizard>
</asp:Content>