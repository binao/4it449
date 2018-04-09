<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HomeWork8.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="LoadOrdersButton">
        <div>
            <asp:Label ID="CustomerIdLabel" runat="server" Text="Customer ID:"></asp:Label>
            <asp:TextBox ID="CustomerIdTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="LoadOrdersButton" runat="server" Text="Load Orders" OnClick="LoadOrdersButton_Click" />
            <asp:GridView ID="OrderDataView" runat="server"  AutoGenerateColumns="false" >
                 <Columns>
                    <asp:BoundField
                        DataField="OrderID"
                        HeaderText="Order ID"></asp:BoundField>

                    <asp:BoundField
                        DataFormatString="{0:dd.M.yyyy}"
                        DataField="OrderDate"
                        HeaderText="Order Date" ></asp:BoundField>

                    <asp:BoundField
                        DataField="EmployeeLastName"
                        HeaderText="Employee"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <p>
                <asp:Label ID="NoDataLabel" runat="server" Text="" Visible="False"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
