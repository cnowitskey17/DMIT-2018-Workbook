<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAddresses.aspx.cs" Inherits="WebAppCRUD.Admin.View_Addresses" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>View Addresses</h1>

   <%-- Drag this from "UserControls" folder--%>
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:ListView ID="AddressListView" runat="server" DataSourceID="AddressDataSource" InsertItemPosition="LastItem" ItemType="WestWindSystem.Entities.Address" DataKeyNames="AddressID">


        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>
                <td>
                    <asp:Label Text='<%# Eval("AddressID") %>' runat="server" ID="AddressIDLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Address1") %>' runat="server" ID="Address1Label" /></td>
                <td>
                    <asp:Label Text='<%# Eval("City") %>' runat="server" ID="CityLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Region") %>' runat="server" ID="RegionLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("PostalCode") %>' runat="server" ID="PostalCodeLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Country") %>' runat="server" ID="CountryLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Customers") %>' runat="server" ID="CustomersLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Employees") %>' runat="server" ID="EmployeesLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Orders") %>' runat="server" ID="OrdersLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Suppliers") %>' runat="server" ID="SuppliersLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("FullAddress") %>' runat="server" ID="FullAddressLabel" /></td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("AddressID") %>' runat="server" ID="AddressIDTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Address1") %>' runat="server" ID="Address1TextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("City") %>' runat="server" ID="CityTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Region") %>' runat="server" ID="RegionTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("PostalCode") %>' runat="server" ID="PostalCodeTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Country") %>' runat="server" ID="CountryTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Customers") %>' runat="server" ID="CustomersTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Employees") %>' runat="server" ID="EmployeesTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Orders") %>' runat="server" ID="OrdersTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Suppliers") %>' runat="server" ID="SuppliersTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("FullAddress") %>' runat="server" ID="FullAddressTextBox" /></td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("AddressID") %>' runat="server" ID="AddressIDTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Address1") %>' runat="server" ID="Address1TextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("City") %>' runat="server" ID="CityTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Region") %>' runat="server" ID="RegionTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("PostalCode") %>' runat="server" ID="PostalCodeTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Country") %>' runat="server" ID="CountryTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Customers") %>' runat="server" ID="CustomersTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Employees") %>' runat="server" ID="EmployeesTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Orders") %>' runat="server" ID="OrdersTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Suppliers") %>' runat="server" ID="SuppliersTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("FullAddress") %>' runat="server" ID="FullAddressTextBox" /></td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>
                <td>
                    <asp:Label Text='<%# Eval("AddressID") %>' runat="server" ID="AddressIDLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Address1") %>' runat="server" ID="Address1Label" /></td>
                <td>
                    <asp:Label Text='<%# Eval("City") %>' runat="server" ID="CityLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Region") %>' runat="server" ID="RegionLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("PostalCode") %>' runat="server" ID="PostalCodeLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Country") %>' runat="server" ID="CountryLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Customers") %>' runat="server" ID="CustomersLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Employees") %>' runat="server" ID="EmployeesLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Orders") %>' runat="server" ID="OrdersLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Suppliers") %>' runat="server" ID="SuppliersLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("FullAddress") %>' runat="server" ID="FullAddressLabel" /></td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                            <tr runat="server" style="">
                                <th runat="server"></th>
                                <th runat="server">AddressID</th>
                                <th runat="server">Address1</th>
                                <th runat="server">City</th>
                                <th runat="server">Region</th>
                                <th runat="server">PostalCode</th>
                                <th runat="server">Country</th>
                                <th runat="server">Customers</th>
                                <th runat="server">Employees</th>
                                <th runat="server">Orders</th>
                                <th runat="server">Suppliers</th>
                                <th runat="server">FullAddress</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager runat="server" ID="DataPager1">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                <asp:NumericPagerField></asp:NumericPagerField>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>
                <td>
                    <asp:Label Text='<%# Eval("AddressID") %>' runat="server" ID="AddressIDLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Address1") %>' runat="server" ID="Address1Label" /></td>
                <td>
                    <asp:Label Text='<%# Eval("City") %>' runat="server" ID="CityLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Region") %>' runat="server" ID="RegionLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("PostalCode") %>' runat="server" ID="PostalCodeLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Country") %>' runat="server" ID="CountryLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Customers") %>' runat="server" ID="CustomersLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Employees") %>' runat="server" ID="EmployeesLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Orders") %>' runat="server" ID="OrdersLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Suppliers") %>' runat="server" ID="SuppliersLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("FullAddress") %>' runat="server" ID="FullAddressLabel" /></td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>

    <asp:ObjectDataSource ID="AddressDataSource" runat="server" DataObjectTypeName="WestWindSystem.Entities.Address" 
        DeleteMethod="DeleteAddress" InsertMethod="AddAddress" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="ListAddresses" TypeName="WestWindSystem.BLL.CRUDController" UpdateMethod="UpdateAddress"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="RegionDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListRegions" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>