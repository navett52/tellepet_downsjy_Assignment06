<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddLoyaltyNumbers" runat="server"></asp:DropDownList> <%-- No dependencies --%>
        <asp:Calendar ID="calDateOfTrans" runat="server"></asp:Calendar> 
        <asp:TextBox ID="txtTimeOfTrans" runat="server"></asp:TextBox> <%-- Use Regex to validate time format --%>
        <asp:DropDownList ID="ddTransType" runat="server" DataSourceID="LoyaltyID" DataTextField="LoyaltyNumber" DataValueField="LoyaltyID"></asp:DropDownList> <%-- No dependencies --%>
        <asp:SqlDataSource ID="LoyaltyID" runat="server" ConnectionString="<%$ ConnectionStrings:GroceryStoreSimulatorPopulator %>" SelectCommand="SELECT [LoyaltyID], [LoyaltyNumber] FROM [tLoyalty]"></asp:SqlDataSource>
        <asp:DropDownList ID="ddStores" runat="server"></asp:DropDownList> <%-- No dependencies --%>
        <asp:DropDownList ID="ddEmpl" runat="server"></asp:DropDownList> <%-- Dependencies: Stores --%>
        <asp:DropDownList ID="ddProduct" runat="server"></asp:DropDownList> <%-- Dependencies: Stores --%>
        <asp:TextBox ID="txtQty" runat="server"></asp:TextBox> <%-- Validate to only accept numbers --%>
        <asp:DropDownList ID="ddPricePerSellableUnitAsMarked" runat="server"></asp:DropDownList> <%-- Dependencies: Product --%>
        <asp:DropDownList ID="ddPricePerSellableUnitToCustomer" runat="server"></asp:DropDownList> <%-- Dependencies: Product --%>
        <asp:TextBox ID="txtTransComment" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtTransDetailComment" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtCouponDetailID" runat="server"></asp:TextBox> <%-- Validate to only accept numbers --%>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
