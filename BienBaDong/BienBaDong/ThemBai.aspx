<%@ Page Title="Thêm bài viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="ThemBai.aspx.cs" Inherits="BienBaDong.ThemBai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="max-width: 600px; margin-top: 30px;">
        <h2>Thêm bài viết mới</h2>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />

        <div class="form-group">
            <label for="txtTieuDe">Tiêu đề:</label>
            <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtNoiDung">Nội dung:</label>
            <asp:TextBox ID="txtNoiDung" runat="server" TextMode="MultiLine" Rows="6" CssClass="form-control" />
        </div>

        <asp:Button ID="btnLuu" runat="server" Text="Lưu bài viết" CssClass="btn btn-success" OnClick="btnLuu_Click" />
        <a href="AdminPage.aspx" class="btn btn-secondary">Quay lại</a>
    </div>
</asp:Content>
