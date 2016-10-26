<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="NexaSearch.search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 279px; width: 665px; margin-top: 47px">
        <asp:Button ID="Button2" runat="server" Text="Home" style="margin-left: 4px" OnClick="Button2_Click" Width="386px" ValidationGroup="vgHome" />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Width="294px" Placeholder="search through database" style="margin-left: 4px" 
             OnClick="Button1_Click"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" Width="84px" ValidationGroup="vgAdd" />
        <br />
        <asp:RequiredFieldValidator ID="rfValidator1" runat="server" ControlToValidate="TextBox1" 
              ForeColor="Red" ErrorMessage="This field is required" ValidationGroup="vgAdd">
        </asp:RequiredFieldValidator>
        <br />
        &nbsp;<asp:Label ID="Label1" ForeColor="#009900" runat="server"></asp:Label>
        
        <br />
        <br />
        <asp:GridView ID="GridView1" DataKeyNames="Id" runat="server" Width="615px" AutoGenerateColumns="false" style="margin-right: 12px">
            <AlternatingRowStyle BackColor="#f5f5f5" />
            <Columns>
                <asp:TemplateField HeaderText="Id" HeaderStyle-BackColor="#d8d8d8">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" HeaderStyle-BackColor="#d8d8d8">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age" HeaderStyle-BackColor="#d8d8d8">
                    <ItemTemplate>
                        <asp:Label ID="lblAge" runat="server" Text='<%# Eval("Age") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Phone_no" HeaderStyle-BackColor="#d8d8d8">
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone_no") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender" HeaderStyle-BackColor="#d8d8d8">
                    <ItemTemplate>
                        <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country" HeaderStyle-BackColor="#d8d8d8">
                    <ItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("City") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
