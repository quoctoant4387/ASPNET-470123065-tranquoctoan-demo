<%@ Page Title="Sửa bài viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="SuaBai.aspx.cs" Inherits="BienBaDong.SuaBai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="max-width: 600px; margin-top: 30px;">
        <h2>Sửa bài viết</h2>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />

        <div class="form-group">
            <label for="txtTieuDe">Tiêu đề:</label>
            <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtNoiDung">Nội dung:</label>
            <asp:TextBox ID="txtNoiDung" runat="server" TextMode="MultiLine" Rows="6" CssClass="form-control" />
        </div>

        <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" CssClass="btn btn-warning" OnClick="btnCapNhat_Click" />
        <a href="AdminPage.aspx" class="btn btn-secondary">Quay lại</a>
    </div>
</asp:Content>
