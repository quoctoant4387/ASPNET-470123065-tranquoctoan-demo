<%@ Page Title="Thêm mới bài viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="ThemBai.aspx.cs" Inherits="BienBaDong.ThemBai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="max-width: 800px; margin: 40px auto;">
        <h2>Thêm mới bài viết</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        <br />
        <div class="form-group">
            <label>Tên bài viết <span style="color:red">*</span></label>
            <asp:TextBox ID="txtTenBaiViet" runat="server" CssClass="form-control" required="required" />
        </div>
        <div class="form-group">
            <label>Thể loại <span style="color:red">*</span></label>
            <asp:DropDownList ID="ddlTheLoai" runat="server" CssClass="form-control" required="required" />
        </div>
        <div class="form-group">
            <label>Nội dung <span style="color:red">*</span></label>
            <asp:TextBox ID="txtNoiDung" runat="server" TextMode="MultiLine" Rows="8" CssClass="form-control" required="required" />
        </div>
        <asp:Button ID="btnLuu" runat="server" Text="Thêm mới" CssClass="btn btn-primary" OnClick="btnLuu_Click" />
        <a href="baiviet.aspx" class="btn btn-secondary">Quay lại</a>
    </div>
</asp:Content>
