<%@ Page Title="Xóa bài viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="XoaBai.aspx.cs" Inherits="BienBaDong.XoaBai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 30px;">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red" />
        <br />
        <a href="AdminPage.aspx" class="btn btn-secondary">Quay lại</a>
    </div>
</asp:Content>
