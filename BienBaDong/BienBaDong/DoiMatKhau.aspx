<%@ Page Title="" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="DoiMatKhau.aspx.cs" Inherits="BienBaDong.DoiMatKhau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="max-width: 400px; margin: 50px auto; padding: 20px; border: 1px solid #ccc; border-radius: 10px;">
            <h2>Đổi Mật Khẩu</h2>
<asp:Label ID="lblThongBao" runat="server" ForeColor="Red"></asp:Label><br />

<div style="margin-top:10px;">
<asp:Label runat="server" Text="Mật khẩu hiện tại:"></asp:Label><br />
    <div class="input-group">
    <asp:TextBox ID="txtMatKhauCu" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    <span class="input-group-btn">
        <button type="button" class="btn btn-default" onclick="togglePassword('<%= txtMatKhauCu.ClientID %>', 'eyeIconCu')">
            <i id="eyeIconCu" class="glyphicon glyphicon-eye-open"></i>
        </button>
    </span>
</div>

<div style="margin-top:10px;">
<asp:Label runat="server" Text="Mật khẩu mới:"></asp:Label><br />
    <div class="input-group">
    <asp:TextBox ID="txtMatKhauMoi" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    <span class="input-group-btn">
        <button type="button" class="btn btn-default" onclick="togglePassword('<%= txtMatKhauMoi.ClientID %>', 'eyeIconMoi')">
            <i id="eyeIconMoi" class="glyphicon glyphicon-eye-open"></i>
        </button>
    </span>
</div>

<div style="margin-top:10px;">
<asp:Label runat="server" Text="Xác nhận mật khẩu mới:"></asp:Label><br />
    <div class="input-group">
    <asp:TextBox ID="txtXacNhan" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    <span class="input-group-btn">
        <button type="button" class="btn btn-default" onclick="togglePassword('<%= txtXacNhan.ClientID %>', 'eyeIconXN')">
            <i id="eyeIconXN" class="glyphicon glyphicon-eye-open"></i>
        </button>
    </span>
</div>
</div>
</div>
</div>
</div>

<asp:Button ID="btnDoiMatKhau" runat="server" Text="Đổi mật khẩu" OnClick="btnDoiMatKhau_Click" CssClass="btn btn-primary" />
    <script type="text/javascript">
        function togglePassword(inputId, iconId)
        {
            var input = document.getElementById(inputId);
            var icon = document.getElementById(iconId);

            if (input.type === "password") {
                input.type = "text";
                icon.className = "glyphicon glyphicon-eye-close";
            } else {
                input.type = "password";
                icon.className = "glyphicon glyphicon-eye-open";
            }
        }
    </script>

</asp:Content>
