<%@ Page Title="Danh sách bài viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="TheLoaiBaiViet.aspx.cs" Inherits="BienBaDong.TheLoaiBaiViet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-heading" id="top">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="inner-content">
                        <h2>
                            Danh Mục: <asp:Label ID="lblTenTheLoai" runat="server" />
                        </h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ***** Products Area Starts ***** -->
    <section class="section" id="products">
        <div class="container">
            <div class="row">
                <asp:Repeater ID="rptBaiViet" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4">
                            <div class="item">
                                <div class="thumb">
                                    <div class="hover-content">
                                        <ul>
                                            <li>
                                                <a href='<%# Eval("MaBaiViet", "~/BaiViet/XemChiTiet?iMaBaiViet={0}") %>'>
                                                    <i class="fa fa-eye"></i>
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <img style="height:300px;width:350px;"
                                         src='<%# Eval("AnhBia", "~/Assets/images/{0}") %>' alt="">
                                </div>
                                <div class="down-content">
                                    <a href='<%# Eval("MaBaiViet", "~/BaiViet/XemChiTiet?iMaBaiViet={0}") %>'>
                                        <h4><%# Eval("TenBaiViet") %></h4>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>
