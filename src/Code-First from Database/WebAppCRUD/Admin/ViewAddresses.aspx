<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAddresses.aspx.cs" Inherits="WebAppCRUD.Admin.View_Addresses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>View Addresses</h1>

<%--    <!-- what is this -->
    <!--<my:messageusercontrol runat="server" id="MessageUserControl" /> -->--%>

    <asp:ListView ID="AddressListView" runat="server" DataSourceID="AddressDataSource" InsertItemPosition="FirstItem" ItemType="WestWindSystem.Entities.Address" DataKeyNames="AddressID">

        <LayoutTemplate>
            <table class="table table-hover table-condensed">
                <thead>
                    <tr>
                        <th>Address ID</th>
                        <th>Address</th>
                        <th>City</th>
                        <th>Region</th>
                        <th>Postal Code</th>
                        <th>Country</th>
                    </tr>
                </thead>
                <tbody>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>

                <InsertItemTemplate>
            <tr class="bg-success">
                <td>
                    <asp:LinkButton ID="AddAddress" runat="server" CssClass="btn btn-success glyphicon glyphicon-plus" CommandName="Insert">
                        Add
                    </asp:LinkButton>
                    <asp:LinkButton ID="Clear" runat="server" CssClass="btn btn-default" CommandName="Cancel">
                        Clear
                    </asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="AddressName" runat="server" Text="<%# BindItem.Address1 %>" placeholder="Enter Address"/>
                </td>
                <td>
                    <asp:TextBox ID="City" runat="server" Text="<%# BindItem.City %>" placeholder="City"/>
                    <asp:TextBox ID="Postal" runat="server" Text="<%# BindItem.PostalCode %>" placeholder="Postal Code"/>
                    <asp:TextBox ID="Country" runat="server" Text="<%# BindItem.Country %>" placeholder="Email"/>
                </td>
                <td>
                    <asp:DropDownList ID="RegionDropDown" runat="server" DataSourceID="" AppendDataBoundItems="true" DataTextField="FullRegion" DataValueField="RegionID"
                        SelectedValue="<%# BindItem.Region %>">
                        <asp:ListItem Value="">[Select region on file]</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </InsertItemTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <asp:LinkButton ID="EditSupplier" runat="server" CssClass="btn btn-info glyphicon glyphicon-pencil" CommandName="Edit">
                        Edit
                    </asp:LinkButton>
                    <asp:LinkButton ID="Delete" runat="server" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this address?')" CommandName="Delete">
                        Delete
                    </asp:LinkButton>
                </td>
                
                <td><%# Item.Address1 %></td>
                <td><%# Item.City %>
                    <%# Item.PostalCode %>
                </td>
                <br />
                <td><%# Item.Country %></td>
                <br />
                <td>
                     
                </td>

            </tr>
        </ItemTemplate>

    </asp:ListView>

    <asp:ObjectDataSource ID="AddressDataSource" runat="server" DataObjectTypeName="WestWindSystem.Entities.Address" 
        DeleteMethod="DeleteAddress" InsertMethod="AddAddress" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="ListAddresses" TypeName="WestWindSystem.BLL.CRUDController" UpdateMethod="UpdateAddress"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="RegionDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListRegions" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>