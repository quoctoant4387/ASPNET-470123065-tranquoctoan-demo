<%@ Page Title="Tất Cả Bài Viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="BaiVietAll.aspx.cs" Inherits="BienBaDong.BaiVietAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="max-width:1000px; margin:40px auto;">
        <h2>Danh sách bài viết</h2>
        <asp:Button ID="btnThemMoi" runat="server" Text="Thêm bài viết mới" CssClass="btn btn-success" OnClick="btnThemMoi_Click" />
        <br /><br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        <asp:GridView ID="gvBaiViet" runat="server" AutoGenerateColumns="False"
            CssClass="table table-bordered"
            DataKeyNames="MaBaiViet"
            OnRowCommand="gvBaiViet_RowCommand">
            <Columns>
                <asp:HyperLinkField 
                    DataTextField="TenBaiViet" 
                    HeaderText="Tên bài viết"
                    DataNavigateUrlFields="MaBaiViet" 
                    DataNavigateUrlFormatString="BaiViet.aspx?iMaBaiViet={0}" />
                <asp:TemplateField HeaderText="Trạng thái">
                    <ItemTemplate>
                        <%# (Eval("An").ToString() == "0" ? "Hiển thị" : "Ẩn") %>
                        <asp:Button ID="btnTrangThai" runat="server"
                            Text='<%# (Eval("An").ToString() == "0" ? "Ẩn" : "Hiển thị") %>'
                            CommandName="DoiTrangThai"
                            CommandArgument='<%# Eval("MaBaiViet") %>'
                            CssClass="btn btn-info btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NgayDang" HeaderText="Ngày đăng" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="Sửa">
                    <ItemTemplate>
                        <asp:Button ID="btnSua" runat="server" Text="Sửa"
                            CommandName="Sua"
                            CommandArgument='<%# Eval("MaBaiViet") %>' CssClass="btn btn-warning btn-sm"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Xóa">
                    <ItemTemplate>
                        <asp:Button ID="btnXoa" runat="server" Text="Xóa"
                            CommandName="Xoa"
                            CommandArgument='<%# Eval("MaBaiViet") %>'
                            CssClass="btn btn-danger btn-sm"
                            OnClientClick="return confirm('Bạn có chắc muốn xóa bài viết này không?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>