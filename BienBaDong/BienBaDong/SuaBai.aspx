<%@ Page Title="Cập nhật bài viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="SuaBai.aspx.cs" Inherits="BienBaDong.SuaBai" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="max-width: 800px; margin: 40px auto;">
        <h2>Cập nhật bài viết</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        <br />
        <div class="form-group">
            <label>Mã bài viết</label>
            <asp:TextBox ID="txtMaBaiViet" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>
        <div class="form-group">
            <label>Ẩn</label>
            <asp:DropDownList ID="ddlAn" runat="server" CssClass="form-control">
                <asp:ListItem Text="Hiển thị" Value="0" />
                <asp:ListItem Text="Ẩn" Value="1" />
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Tên bài viết</label>
            <asp:TextBox ID="txtTenBaiViet" runat="server" CssClass="form-control" required="required" />
        </div>
        <div class="form-group">
            <label>Thể loại</label>
            <asp:DropDownList ID="ddlTheLoai" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Nội dung</label>
            <asp:TextBox ID="txtNoiDung" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8" />
        </div>
        <asp:Button ID="btnLuu" runat="server" Text="Cập nhật" CssClass="btn btn-primary" OnClick="btnLuu_Click" />
        <a href="javascript:history.back()" class="btn btn-secondary">Quay lại</a>
    </div>
</asp:Content>
