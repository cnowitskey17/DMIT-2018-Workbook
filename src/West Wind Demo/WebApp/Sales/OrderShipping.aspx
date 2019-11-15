﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderShipping.aspx.cs" Inherits="WebApp.Sales.OrderShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Order Shipping</h1>

    <div class="row">
        <div class="col-md-12">
            <p>
                <asp:Literal ID="SupplierInfo" runat="server" />
            </p>
            <asp:ListView ID="CurrentOrders" runat="server" DataSourceID="SupplierOrdersDataSource" ItemType="WestWindSystem.DataModels.OutstandingOrder">

                <EditItemTemplate>
                    <tr style="">
                        <td>
                            (<asp:Label Text='<%#Item.OrderId %>' runat="server" ID="OrderIdLabel" />)
                            <asp:Label Text='<%# Item.ShipToName %>' runat="server" ID="ShipToNameLabel" />

                        </td>
                        <td>
                            <asp:Label Text='<%# Item.OrderDate.ToString("MMM dd, yyyy") %>' runat="server" ID="OrderDateLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Item.RequiredBy.ToString("MMM dd, yyyy") %>' runat="server" ID="RequiredByLabel" />
                            - in <%# Item.DaysRemaining %> days
                        </td>
                        <td>
                            <asp:LinkButton ID="EditOrder" runat="server" CommandName="Cancel" CssClass="btn btn-default">
                                Close
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="OrderComments" runat="server" Text="<%# Item.Comments %>"/>
                            <asp:DropDownList ID="ShipperDropDown" runat="server"></asp:DropDownList>
                            <asp:GridView ID="ProdictsGridView" runat="server" DataSource="<%# Item.OutstandingItems %>" ItemType="WestWindSystem.DataModels.OrderItem"
                                CssClass="Table table-hover table-condensed">

                            </asp:GridView>
                            <asp:Label ID="ShippingAddress" runat="server" Text="<%# Item.FullShippingAddress %>"/>
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            (<asp:Label Text='<%#Item.OrderId %>' runat="server" ID="OrderIdLabel" />)
                            <asp:Label Text='<%# Item.ShipToName %>' runat="server" ID="ShipToNameLabel" />

                        </td>
                        <td>
                            <asp:Label Text='<%# Item.OrderDate.ToString("MMM dd, yyyy") %>' runat="server" ID="OrderDateLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Item.RequiredBy.ToString("MMM dd, yyyy") %>' runat="server" ID="RequiredByLabel" />
                            - in <%# Item.DaysRemaining %> days
                        </td>
                        <td>
                            <asp:LinkButton ID="EditOrder" runat="server" CommandName="Edit" CssClass="btn btn-default">
                                Order Details
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" class="table table-hover">
                                    <tr runat="server" style="">
                                        <th runat="server">Ship To</th>
                                        <th runat="server">Ordered On</th>
                                        <th runat="server">Required By</th>
                                        <th runat="server"><!-- Select/Expand --></th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style=""></td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>

            <asp:ObjectDataSource ID="SupplierOrdersDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadOrders" TypeName="WestWindSystem.BLL.OrderProcessingController">
                <SelectParameters>
                    <asp:Parameter DefaultValue="2" Name="supplierId" Type="Int32"></asp:Parameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
