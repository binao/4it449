<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JC_HomeWork8.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="NameLabel" runat="server" Text="Customer ID (GODOS, SUPRD):"></asp:Label>
            <asp:TextBox ID="ContentTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="LoadButton" runat="server" Text="Load" OnClick="LoadButton_Click"/>
            <%-- Connection table with data about Orders--%>
            <asp:GridView ID="OrderDataView" runat="server"  AutoGenerateColumns="false" OnSelectedIndexChanged="OrderDataView_SelectedIndexChanged">
                 <Columns>
                    <asp:BoundField
                        DataField="orderID"
                        HeaderText="Order ID"></asp:BoundField>

                    <asp:BoundField
                        DataFormatString="{0:dd.M.yyyy}"
                        DataField="orderDate"
                        HeaderText="Order Date" ></asp:BoundField>

                    <asp:BoundField
                        DataField="lastName"
                        HeaderText="Last Name of Employee"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <p>
            <asp:Label ID="DataLabel" runat="server" Text="No data" Visible="False" Width="40%"></asp:Label>
        </p>
    </form>
</body>
</html>
