<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 527px;
        }
        .auto-style2 {
            width: 60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 236px; width: 602px; margin-top: 47px">
        <asp:Label ID="lebel1" runat="server"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search Page" style="margin-left: 0px" Width="105px" />
        <table style="width: 640px; margin-left: 2px; margin-right: 19px">
            <tr>
                <td class="auto-style2">Id :</td>
                <td class="auto-style1"><asp:TextBox runat="server" id="TextId" Width="165px" /> </td>
            </tr>
            <tr>
                <td class="auto-style2">Name :</td>
                <td class="auto-style1"><asp:TextBox runat="server" id="TextName" Placeholder="enter name" Width="165px" />    
                    <asp:RequiredFieldValidator ID="rfValidator1" runat="server" ControlToValidate="TextName" 
                        ForeColor="Red" ErrorMessage="This field is required" ValidationGroup="vgAdd">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reValidator1" runat="server" ControlToValidate="TextName" 
                        ValidationExpression="^[A-Za-z. ]*" ForeColor="Red" ErrorMessage="Name Format not matched" ValidationGroup="vgAdd">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Age :</td>
                <td class="auto-style1"><asp:TextBox runat="server" id="TextAge" Placeholder="enter age" Width="165px" />
                    <asp:RequiredFieldValidator ID="rfValidator2" runat="server" ControlToValidate="TextAge" 
                        ForeColor="Red" ErrorMessage="This field is required" ValidationGroup="vgAdd">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reValidator2" runat="server" ControlToValidate="TextAge" 
                        ValidationExpression="^[0-9]*$" ForeColor="Red" ErrorMessage="Number" ValidationGroup="vgAdd">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"><asp:Button runat="server" id="InsertButton" text="Insert" OnClick="InsertButton_Click" ValidationGroup="vgAdd"/></td>
                <td class="auto-style1"><asp:Button runat="server" id="UpdateButton" text="Update" OnClick="UpdateButton_Click" ValidationGroup="vgAdd"/></td>
            </tr>
        </table>
        <br /><br />

        <asp:GridView ID="GridView1" DataKeyNames="Id" runat="server" Width="600px" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="#f5f5f5" />
            <Columns>
                <asp:TemplateField HeaderText="Id" HeaderStyle-BackColor="#d8d8d8">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" HeaderStyle-BackColor="#d8d8d8">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age" HeaderStyle-BackColor="#d8d8d8">
                    <ItemTemplate>
                        <asp:Label ID="lblAge" runat="server" Text='<%#Eval("Age") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="Default.aspx?id=<%# Eval("Id") %>&act=upd">update</a>
                        <a href="Default.aspx?id=<%# Eval("Id") %>&act=del">delete</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
    </div>
        
    </form>
</body>
</html>
