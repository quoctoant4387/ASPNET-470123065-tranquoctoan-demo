<%@ Page Title="Đăng ký" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="BienBaDong.DangKy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .register-form {
            max-width: 600px;
            margin: 0 auto;
            padding: 25px;
            background-color: #f9f9f9;
            border-radius: 10px;
            border: 1px solid #ccc;
        }

        .register-form h2 {
            text-align: center;
            color: #007BFF;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="register-form">
        <h2>Đăng ký tài khoản</h2>

        <div class="form-group">
            <label>Họ và tên:</label>
            <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvHoTen" runat="server" ControlToValidate="txtHoTen" ErrorMessage="* Bắt buộc" ForeColor="Red" Display="Dynamic" />
        </div>

        <div class="form-group">
            <label>Tên đăng nhập:</label>
            <asp:TextBox ID="txtTenDangNhap" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvTenDN" runat="server" ControlToValidate="txtTenDangNhap" ErrorMessage="* Bắt buộc" ForeColor="Red" Display="Dynamic" />
        </div>

        <div class="form-group">
            <label>Mật khẩu:</label>
            <asp:TextBox ID="txtMatKhau" runat="server" CssClass="form-control" TextMode="Password" />
            <asp:RequiredFieldValidator ID="rfvMatKhau" runat="server" ControlToValidate="txtMatKhau" ErrorMessage="* Bắt buộc" ForeColor="Red" Display="Dynamic" />
        </div>

        <div class="form-group">
            <label>Xác nhận mật khẩu:</label>
            <asp:TextBox ID="txtXacNhan" runat="server" CssClass="form-control" TextMode="Password" />
            <asp:CompareValidator ID="cvMatKhau" runat="server" ControlToValidate="txtXacNhan" ControlToCompare="txtMatKhau" ErrorMessage="* Mật khẩu không khớp" ForeColor="Red" Display="Dynamic" />
        </div>

        <div class="form-group">
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="* Bắt buộc" ForeColor="Red" Display="Dynamic" />
        </div>

        <div class="form-group">
            <label>Giới tính:</label><br />
            <asp:RadioButtonList ID="rblGioiTinh" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Nam" Value="Nam" Selected="True" />
                <asp:ListItem Text="Nữ" Value="Nữ" />
            </asp:RadioButtonList>
        </div>

        <div class="form-group">
            <label>Ngày sinh:</label>
            <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="form-group text-center">
            <asp:Button ID="btnDangKy" runat="server" Text="Đăng ký" OnClick="btnDangKy_Click" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
