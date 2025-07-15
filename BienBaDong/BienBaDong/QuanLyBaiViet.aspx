<%@ Page Title="Quản lý bài viết" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="QuanLyBaiViet.aspx.cs" Inherits="BienBaDong.QuanLyBaiViet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            max-width: 900px;
            margin-top: 30px;
        }
        .btn-action {
            margin-right: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="lblThongBao" runat="server" ForeColor="Green" /><br />

        <asp:TextBox ID="txtTimKiem" runat="server" CssClass="form-control" Placeholder="Tìm theo tiêu đề..." />
        <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary" OnClick="btnTimKiem_Click" /><br /><br />

        <asp:GridView ID="gvBaiViet" runat="server" AutoGenerateColumns="False" DataKeyNames="MaBV"
            OnRowEditing="gvBaiViet_RowEditing" OnRowCancelingEdit="gvBaiViet_RowCancelingEdit"
            OnRowUpdating="gvBaiViet_RowUpdating" OnRowDeleting="gvBaiViet_RowDeleting"
            CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="MaBV" HeaderText="Mã" ReadOnly="true" />
                <asp:BoundField DataField="TieuDe" HeaderText="Tiêu đề" />
                <asp:BoundField DataField="NoiDung" HeaderText="Nội dung" />
                <asp:BoundField DataField="NguoiDang" HeaderText="Người đăng" />
                <asp:BoundField DataField="NgayDang" HeaderText="Ngày đăng" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <h3>Thêm bài viết mới</h3>
        <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control" Placeholder="Tiêu đề" />
        <asp:TextBox ID="txtNoiDung" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" Placeholder="Nội dung bài viết" />
        <asp:Button ID="btnThem" runat="server" Text="Thêm mới" CssClass="btn btn-success" OnClick="btnThem_Click" />
    </div>
</asp:Content>
