<%@ Page Title="Đăng nhập" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="BienBaDong.DangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="max-width: 400px; margin: 50px auto; padding: 20px; border: 1px solid #ccc; border-radius: 10px;">
        <h2>Đăng nhập</h2>

<asp:Label ID="lblThongBao" runat="server" ForeColor="Green" CssClass="text-success" Font-Bold="true"></asp:Label>

        <div>
            <asp:Label runat="server" Text="Tên đăng nhập:" AssociatedControlID="txtUsername" /><br />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" required="required"></asp:TextBox>
        </div>

        <div style="margin-top:10px;">
            <asp:Label runat="server" Text="Mật khẩu:" AssociatedControlID="txtPassword" /><br />
            <div class="input-group">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" required="required"></asp:TextBox>
                <span class="input-group-btn">
                    <button type="button" class="btn btn-default" onclick="togglePassword()" tabindex="-1">
                        <i id="eyeIcon" class="glyphicon glyphicon-eye-open"></i>
                    </button>
                </span>
            </div>
        </div>

        <div style="margin-top:15px;">
            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
        </div>
    </div>

    <script type="text/javascript">
        function togglePassword() {
            var pwd = document.getElementById('<%= txtPassword.ClientID %>');
            var icon = document.getElementById('eyeIcon');
            if (pwd.type === "password") {
                pwd.type = "text";
                icon.className = "glyphicon glyphicon-eye-close";
            } else {
                pwd.type = "password";
                icon.className = "glyphicon glyphicon-eye-open";
            }
        }
    </script>
</asp:Content>

