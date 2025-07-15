<%@ Page Title="" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="BienBaDong.TrangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; padding: 0; margin: 0;font-family: 'Segoe UI'; font-size: 18px; line-height: 1.8; text-align: justify;">
        <div style="width: 100%; text-align: center;">
            <h1 style="width: 100%; text-align: center; font-size: 32px; color: #f9a825;">Biển Ba Động - điểm du lịch hấp dẫn bật nhất tại Trà Vinh</h1>
            <div style="margin-top: 20px;">
<asp:HyperLink ID="lnkXemThem" runat="server" CssClass="btn btn-primary" NavigateUrl="~/GioiThieu.aspx" Text="Xem Thêm"></asp:HyperLink>
            </div>
            <img style="width: 100%; height: 400px; margin-top: 20px;" src="Hinh/bien 1.jpg" />
        </div>

        <div style="width: 100%; padding: 0; margin: 0; font-family: 'Segoe UI'; font-size: 18px; line-height: 1.8; text-align: justify;">
            <h2 style="width: 100%; text-align: center; font-size: 32px; color: #007bff;">Biển Ba Động</h2>
            <p>Biển Ba Động là một trong những điểm du lịch được rất nhiều du khách lựa chọn khám phá. Vẻ đẹp hoang sơ, giao hòa giữa đất liền và biển cả cùng cái tình dân chân chất của người dân biển bản địa nơi đây luôn làm say lòng người lữ khách thập phương
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-primary" NavigateUrl="~/BaiViet.aspx" Text="Xem Thêm"></asp:HyperLink></p>
            </div>
            <img style="width: 100%; height: 400px; margin-top: 20px;" src="Hinh/bien 5.jpg" />
        </div>
</asp:Content>
