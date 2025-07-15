<%@ Page Title="Quản lý tài khoản" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="QuanLyTaiKhoan.aspx.cs" Inherits="BienBaDong.QuanLyTaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            max-width: 900px;
            margin-top: 30px;
        }
        .btn-action {
            margin-right: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3>Quản lý tài khoản người dùng</h3>
        <asp:Label ID="lblThongBao" runat="server" ForeColor="Green" />

        <asp:GridView ID="gvTaiKhoan" runat="server" AutoGenerateColumns="False" DataKeyNames="TenDangNhap"
            OnRowEditing="gvTaiKhoan_RowEditing" OnRowUpdating="gvTaiKhoan_RowUpdating"
            OnRowCancelingEdit="gvTaiKhoan_RowCancelingEdit" OnRowDeleting="gvTaiKhoan_RowDeleting"
            CssClass="table table-bordered table-hover" GridLines="None">

            <Columns>
                <asp:BoundField DataField="HoTen" HeaderText="Họ tên" />
                <asp:BoundField DataField="TenDangNhap" HeaderText="Tên đăng nhập" />
                <asp:BoundField DataField="MatKhau" HeaderText="Mật khẩu" />
                <asp:BoundField DataField="GioiTinh" HeaderText="Giới Tính" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" EditText="Sửa" DeleteText="Xóa" />
            </Columns>
        </asp:GridView>

       <asp:Panel ID="pnlThemMoi" runat="server">
           <h4>Thêm người dùng mới</h4>
        <div class="form-inline">
            <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" Placeholder="Họ tên"></asp:TextBox>
            <asp:TextBox ID="txtTenDangNhap" runat="server" CssClass="form-control" Placeholder="Tên đăng nhập"></asp:TextBox>
            <asp:TextBox ID="txtMatKhau" runat="server" CssClass="form-control" Placeholder="Mật khẩu"></asp:TextBox>
            <asp:RadioButtonList ID="rblGioiTinh" runat="server" RepeatDirection="Horizontal"><asp:ListItem Text="Nam" Value="Nam" Selected="True" /><asp:ListItem Text="Nữ" Value="Nữ" /></asp:RadioButtonList>            
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email"></asp:TextBox>
            <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="form-control" Placeholder="dd/MM/yyyy"></asp:TextBox>
            <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" CssClass="btn btn-success btn-action" OnClick="btnThemMoi_Click" />
        </div>
           </asp:Panel>
    </div>
</asp:Content>
            
