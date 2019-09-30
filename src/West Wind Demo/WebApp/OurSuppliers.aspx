<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OurSuppliers.aspx.cs" Inherits="WebApp.Our_Suppliers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Our Suppliers</h1>

    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="SupplierRepeater" runat="server" DataSourceID="SupplierDataSource" ItemType="WestWindSystem.DataModels.SupplierCategory">
                <ItemTemplate>
                    <h3><%# Item.CompanyName %></h3>
                    <p><%# Item.ContactName %></p>
                    <p><%# Item.Phone %></p>
                    <blockquote>
                        <asp:Repeater ID="ProductRepeater" runat="server" 
                            DataSource="<%# Item.Products %>" ItemType="WestWindSystem.DataModels.SupplierSummary">
                            <HeaderTemplate>
                                <table class="table table-hover table-condensed">
                            </HeaderTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                            <ItemTemplate>
                                <tr>
                                    <th class="col-md-3"><%# Item.Name %></th>
                                    <th class="col-md-3"><%# Item.Category %></th>
                                    <th class="col-md-3"><%# Item.Price %></th>
                                    <th class="col-md-3"><%# Item.Quantity %></th>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </blockquote>
                </ItemTemplate>
            </asp:Repeater>

            <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="ListSupplierProducts" TypeName="WestWindSystem.BLL.ProductManagementController"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
