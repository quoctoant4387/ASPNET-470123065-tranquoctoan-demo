<%@ Page Title="Xem chi tiết bài viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="XemChiTiet.aspx.cs" Inherits="BienBaDong.XemChiTiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-heading about-page-heading" id="top">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="inner-content">
                        <h2 style="background-color: #0000007a;">Danh Lam Thắng Cảnh</h2>
                        <span style="background-color: #0000007a">
                            Thể loại: <asp:Label ID="lblTenTheLoai" runat="server" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Main Banner Area End -->
    <div class="about-us">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="right-content">
                        <h4><asp:Label ID="lblTenBaiViet" runat="server" /></h4>
                        <small>
                            <i class="fa fa-calendar"></i> Create:
                            <asp:Label ID="lblNgayDang" runat="server" />
                            &nbsp;&nbsp;&nbsp;
                        </small>
                        <small runat="server" id="smallNgayCapNhat" visible="false">
                            <i class="fa fa-calendar"></i> Update:
                            <asp:Label ID="lblNgayCapNhat" runat="server" />
                            &nbsp;&nbsp;&nbsp;
                        </small>
                        <small>
                            <i class="fa fa-user-o"></i> Author:
                            <asp:Label ID="lblTacGia" runat="server" />
                        </small>
                        <br /><br />
                        <span style="color:black!important">
                            <asp:Literal ID="ltrNoiDung" runat="server" />
                        </span>
                        <br /><br />
                        <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
                            <asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn btn-danger" OnClick="btnXoa_Click" />
                            <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" CssClass="btn btn-primary" OnClick="btnCapNhat_Click" />
                            <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" CssClass="btn btn-primary" OnClick="btnThemMoi_Click" />
                            <asp:Button ID="btnAnHien" runat="server" Text="" CssClass="btn btn-dark" OnClick="btnAnHien_Click" />
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
