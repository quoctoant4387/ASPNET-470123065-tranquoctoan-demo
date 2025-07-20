<%@ Page Title="Bài Viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="BaiViet.aspx.cs" Inherits="BienBaDong.BaiViet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .article-detail {
            padding: 30px 20px;
            background: #f9f9f9;
            border-radius: 8px;
            margin: 20px auto;
            max-width: 700px;
        }
        .btn-back {
            display: inline-block;
            margin-top: 28px;
            padding: 8px 24px;
            background: #3578e5;
            color: #fff;
            border-radius: 6px;
            text-decoration: none;
            font-weight: bold;
        }
        .btn-back:hover {
            background: #2051a3;
        }
        .article-title {
            color: #003366;
            font-size: 28px;
            margin-bottom: 20px;
        }
        .article-content {
            font-size: 18px;
            color: #222;
        }
        .admin-tools {
            margin-top: 24px;
        }
        .admin-tools button {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="article-detail">
        <asp:Label ID="lblTenBaiViet" CssClass="article-title" runat="server" />
        <div class="article-content">
            <asp:Label ID="lblNoiDung" runat="server" />
        </div>
        <div class="admin-tools" runat="server" id="divAdminTools" visible="false">
            <asp:Button ID="btnSua" runat="server" Text="Sửa bài viết" CssClass="btn btn-warning"
                OnClick="btnSua_Click" />
            <asp:Button ID="btnXoa" runat="server" Text="Xóa bài viết" CssClass="btn btn-danger"
                OnClientClick="return confirm('Bạn có chắc muốn xóa bài viết này không?')" OnClick="btnXoa_Click" />
        </div>
        <asp:Panel ID="pnlAddPost" runat="server" Visible="false" style="margin-bottom: 16px;">
    <asp:Button ID="btnAddPost" runat="server" Text="Thêm bài viết mới" CssClass="btn btn-success" OnClick="btnAddPost_Click" />
</asp:Panel>
        <a href="javascript:history.back()" class="btn-back">← Quay lại</a>
        <div class="comment-section" style="max-width:700px; margin:24px auto 30px auto; background:#fff; border-radius:8px; padding:16px 24px;">
    <h3 style="color:#0056b3; margin-bottom:14px;">Bình luận</h3>
    <asp:Repeater ID="rptComments" runat="server">
        <ItemTemplate>
            <div style="margin-bottom:14px; border-bottom:1px solid #eee; padding-bottom:7px;">
                <b><%# Eval("HoTen") %>:</b>
                <span style="color:#666; font-size:12px;">(<%# Eval("NgayTao", "{0:dd/MM/yyyy HH:mm}") %>)</span>
                <div style="margin-left:18px; margin-top:2px; color:#222;"><%# Eval("NoiDung") %></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Panel ID="pnlAddComment" runat="server" Visible="true">
        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Nhập bình luận..." style="width:100%;height:80px;margin-bottom:8px;"></asp:TextBox>
        <asp:Button ID="btnComment" runat="server" Text="Gửi bình luận" CssClass="btn btn-primary" OnClick="btnComment_Click" />
        <asp:Label ID="lblCommentMsg" runat="server" ForeColor="Red" style="margin-left:16px;"></asp:Label>
    </asp:Panel>
</div>

    </div>
</asp:Content>
