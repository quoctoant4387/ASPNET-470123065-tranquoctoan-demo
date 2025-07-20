<%@ Page Title="Danh sách bài viết" 
         Language="C#" 
         MasterPageFile="~/GiaoDien.Master" 
         AutoEventWireup="true" 
         CodeBehind="DanhSachBaiViet.aspx.cs" 
         Inherits="BienBaDong.DanhSachBaiViet" %>

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
        .article .meta {
            font-size: 0.9em;
            color: #555;
            margin-bottom: 8px;
        }
        .filter-box {
            margin-bottom: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <!-- Dropdown lọc thể loại -->
        <div class="filter-box">
            <label>Chọn thể loại:</label>
            <asp:DropDownList ID="ddlTheLoai" runat="server" CssClass="form-control"
                AutoPostBack="true" OnSelectedIndexChanged="ddlTheLoai_SelectedIndexChanged"
                Style="width:auto; display:inline-block; margin-left:8px;">
            </asp:DropDownList>
        </div>

        <!-- Danh sách bài viết -->
        <asp:Repeater ID="rptBaiViet" runat="server">
            <ItemTemplate>
                <div class="article">
                    <h3>
                        <a href='BaiViet.aspx?iMaBaiViet=<%# Eval("MaBaiViet") %>'>
                            <%# Eval("TenBaiViet") %>
                        </a>
                    </h3>
                    <div class="meta">
                        <span><strong>Thể loại:</strong> <%# Eval("TenTheLoai") %></span> |
                        <span><strong>Người đăng:</strong> <%# Eval("TenNguoiDang") %></span> |
                        <span><strong>Ngày đăng:</strong> <%# Eval("NgayDang", "{0:dd/MM/yyyy HH:mm}") %></span> |
                        <span><strong>Ngày cập nhật:</strong> <%# Eval("NgayCapNhat", "{0:dd/MM/yyyy HH:mm}") %></span>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
