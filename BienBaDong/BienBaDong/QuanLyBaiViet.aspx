<%@ Page Title="Quản lý bài viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="QuanLyBaiViet.aspx.cs" Inherits="BienBaDong.QuanLyBaiViet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="max-width:1000px; margin:40px auto;">
        <h2 style="margin-bottom:24px;">Quản lý bài viết</h2>
        <asp:Button ID="btnThemMoi" runat="server" Text="Thêm bài viết mới" CssClass="btn btn-success" OnClick="btnThemMoi_Click" />
        <br /><br />
        <asp:GridView ID="gvBaiViet" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            DataKeyNames="MaBaiViet" OnRowCommand="gvBaiViet_RowCommand">
            <Columns>
                <asp:HyperLinkField 
                    DataTextField="TenBaiViet" 
                    HeaderText="Tên bài viết"
                    DataNavigateUrlFields="MaBaiViet" 
                    DataNavigateUrlFormatString="BaiViet.aspx?iMaBaiViet={0}" />

                <asp:BoundField DataField="NgayDang" HeaderText="Ngày đăng" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                <asp:BoundField DataField="NgayCapNhat" HeaderText="Ngày cập nhật" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                <asp:BoundField DataField="MaNguoiDung" HeaderText="Người đăng" />

                <asp:TemplateField HeaderText="Chức năng" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnSua" runat="server" Text="Sửa" CssClass="btn btn-warning btn-sm"
                            CommandName="EditBaiViet" CommandArgument='<%# Eval("MaBaiViet") %>' />
                        <asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn btn-danger btn-sm"
                            OnClientClick="return confirm('Bạn có chắc muốn xóa bài viết này không?');"
                            CommandName="DeleteBaiViet" CommandArgument='<%# Eval("MaBaiViet") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
