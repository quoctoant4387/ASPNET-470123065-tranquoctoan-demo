<%@ Page Title="Liên hệ" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="LienHe.aspx.cs" Inherits="BienBaDong.LienHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .contact-form {
            max-width: 600px;
            margin: 0 auto;
            text-align: left;
            padding: 20px;
        }

        .contact-form h2 {
            text-align: center;
            margin-bottom: 30px;
            color: #007BFF;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact-form">
        <h2>Liên hệ với chúng tôi</h2>

        <div class="form-group">
            <label for="txtHoTen">Họ và tên:</label>
            <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
        </div>

        <div class="form-group">
            <label for="txtDienThoai">Số điện thoại:</label>
            <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control" TextMode="Phone" />
        </div>

        <div class="form-group">
            <label for="ddlChuDe">Chủ đề liên hệ:</label>
            <asp:DropDownList ID="ddlChuDe" runat="server" CssClass="form-control">
                <asp:ListItem Text="Chọn chủ đề" Value="" />
                <asp:ListItem Text="Hỏi thông tin du lịch" Value="tour" />
                <asp:ListItem Text="Đóng góp ý kiến" Value="feedback" />
                <asp:ListItem Text="Hỗ trợ kỹ thuật" Value="support" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtNoiDung">Nội dung:</label>
            <asp:TextBox ID="txtNoiDung" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
        </div>

        <div class="form-group text-center">
            <asp:Button ID="btnSubmit" runat="server" Text="Gửi liên hệ" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
        </div>
        <div class="form-group text-center">
            <asp:Label ID="lblThongBao" runat="server" ForeColor="Green" Font-Bold="true" />
        </div>        
    </div>
</asp:Content>