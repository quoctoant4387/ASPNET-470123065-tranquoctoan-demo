<%@ Page Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="BaiViet.aspx.cs" Inherits="BienBaDong.BaiViet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Chi tiết bài viết</title>
    <style>
        .container { max-width: 900px; margin: 30px auto; font-family: Arial; }
        .article h2 { font-size: 28px; margin-bottom: 10px; }
        .article img { width: 100%; height: auto; margin-bottom: 15px; }
        .article-content { font-size: 18px; line-height: 1.6; margin-bottom: 30px; }
        .btn-back { background-color: #007bff; color: white; padding: 8px 16px; text-decoration: none; border-radius: 4px; display: inline-block; margin-bottom: 30px; }
        .related-posts h3 { margin-top: 40px; font-size: 22px; }
        .related-posts a { display: block; margin-bottom: 8px; color: #333; text-decoration: none; }
        .related-posts a:hover { text-decoration: underline; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <a class="btn-back" href="DanhSachBaiViet.aspx">← Quay lại danh sách</a>

        <div class="article">
            <h2><asp:Label ID="lblTieuDe" runat="server" /></h2>
            <asp:Image ID="imgHinh" runat="server" />
            <div class="article-content">
                <asp:Literal ID="ltrNoiDung" runat="server" />
            </div>
        </div>

        <div class="related-posts">
            <h3>Bài viết liên quan</h3>
            <asp:Repeater ID="rptLienQuan" runat="server">
                <ItemTemplate>
                    <a href='<%# ResolveUrl("/BaiViet.aspx") + "?iMaBaiViet=" + Eval("MaBaiViet") %>'>
                        <%# Eval("TenBaiViet") %>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
