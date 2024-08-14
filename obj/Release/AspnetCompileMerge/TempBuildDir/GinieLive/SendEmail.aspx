<%@ Page Title="" Language="C#" MasterPageFile="~/GinieLive/GinieLive.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="GinieLive.GinieLive.SendEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <h1>Send Email</h1>
    <asp:Label ID="LabEmail" runat="server" Text="Email Address" CssClass="form-label" />
    <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" />
        <asp:Label ID="LabSubj" runat="server" Text="Subject" CssClass="form-label" />
    <asp:TextBox ID="txtSubj" runat="server" CssClass="form-control" />
            <asp:Label ID="LabMsg" runat="server" Text="Message" CssClass="form-label" />
    <asp:TextBox ID="txtMsg" runat="server" CssClass="form-control" TextMode="MultiLine" Rows=10/>
    <asp:Button ID="btnSend" runat="server" Text="Send Email" OnClick="btnSend_Click" />
    <asp:Button ID="btnHello" runat="server" Text="Check WebService" OnClick="btnHello_Click" />
    </asp:Content>
