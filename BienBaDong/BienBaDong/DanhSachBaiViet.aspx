<%@ Page Title="Danh sách bài viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="DanhSachBaiViet.aspx.cs" Inherits="BienBaDong.DanhSachBaiViet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .article {
            border-bottom: 1px solid #ccc;
            padding: 15px 0;
        }
        .article h3 a {
            color: darkblue;
            text-decoration: none;
        }
        .article img {
            max-width: 300px;
            height: auto;
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Repeater ID="rptBaiViet" runat="server">
            <ItemTemplate>
                <div class="article">
                    <h3>
                        <a href='BaiViet.aspx?iMaBaiViet=<%# Eval("MaBaiViet") %>'>
                            <%# Eval("TenBaiViet") %>
                        </a>
                    </h3>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>