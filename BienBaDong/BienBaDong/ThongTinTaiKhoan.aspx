<%@ Page Title="Thông tin tài khoản" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="ThongTinTaiKhoan.aspx.cs" Inherits="BienBaDong.ThongTinTaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-group {
            margin-bottom: 15px;
        }
        .container {
            max-width: 600px;
            margin-top: 40px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3>Thông tin tài khoản</h3>
        <asp:Label ID="lblThongBao" runat="server" ForeColor="Red" />

        <div class="form-group">
            <label>Tên đăng nhập:</label>
            <asp:TextBox ID="txtTenDangNhap" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>

        <div class="form-group">
            <label>Mật khẩu:</label>
            <asp:TextBox ID="txtMatKhau" runat="server" Text="Password" CssClass="form-control" ReadOnly="true" />
        </div>

        <div class="form-group">
            <label>Họ và tên:</label>
            <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label>Giới tính:</label>
            <asp:DropDownList ID="ddlGioiTinh" runat="server" CssClass="form-control">
                <asp:ListItem Text="Nam" />
                <asp:ListItem Text="Nữ" />
                <asp:ListItem Text="Khác" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label>Ngày sinh:</label>
            <asp:TextBox ID="txtNgaySinh" runat="server" TextMode="Date" CssClass="form-control" />
        </div>

        <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" CssClass="btn btn-success" OnClick="btnCapNhat_Click" />
    </div>
</asp:Content>
