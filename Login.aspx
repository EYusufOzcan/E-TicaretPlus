<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:Login ID="Login1" runat="server" BackColor="White" Font-Names="Arial"
           Font-Size="X-Large" ForeColor="#333333" Height="300px" TextLayout="TextOnTop" Width="369px" DestinationPageUrl="~/management/Default.aspx">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" Font-Bold="true" />
            <LoginButtonStyle Font-Bold="true" CssClass="button"/>
            <TextBoxStyle Font-Size="12px" Width="250px" CssClass="text2" />
            <LabelStyle Font-Bold="true" CssClass="label"/>
            <CheckBoxStyle CssClass="checkbox"/>
            <TitleTextStyle BackColor="#F15A23" Font-Bold="True" Font-Size="14px" ForeColor="White" />
        </asp:Login>

    <style type="text/css">
        .label {
            
        }
        .text2 {
            padding-left:150px;
            padding-top: -50px;
        }
        .checkbox {
            padding-left:25px;
        }
    </style>
</asp:Content>
