<%@ Page Title="Trang quản trị" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="BienBaDong.AdminPage" %>
<%@ Register Src="~/ucBaiViet.ascx" TagPrefix="uc1" TagName="ucBaiViet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Chào <asp:Label ID="lblUser" runat="server" Font-Bold="true" ForeColor="Green" /> - Trang Quản trị</h2>

    <a href="ThemBai.aspx" class="btn btn-success" style="margin-bottom: 10px;">+ Thêm bài viết</a>

    <uc1:ucBaiViet ID="ucBaiViet1" runat="server" />
</asp:Content>
