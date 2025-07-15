<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBaiViet.ascx.cs" Inherits="BienBaDong.ucBaiViet" %>

<asp:Repeater ID="rptBaiViet" runat="server" OnItemDataBound="rptBaiViet_ItemDataBound">
    <ItemTemplate>
        <div class="list-group-item" style="margin-bottom: 15px;">
            <h4 class="list-group-item-heading"><%# Eval("TieuDe") %></h4>
            <p class="list-group-item-text"><%# Eval("NoiDung") %></p>

            <asp:Panel ID="pnlAdmin" runat="server">
                <a href='<%# "SuaBai.aspx?id=" + Eval("ID") %>' class="btn btn-warning btn-sm">Sửa</a>
                <a href='<%# "XoaBai.aspx?id=" + Eval("ID") %>' class="btn btn-danger btn-sm"
                   onclick="return confirm('Bạn có chắc muốn xóa bài này?');">Xóa</a>
            </asp:Panel>
        </div>
    </ItemTemplate>
</asp:Repeater>
