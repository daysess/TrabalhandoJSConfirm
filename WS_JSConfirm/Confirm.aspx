<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Confirm.aspx.cs" Inherits="Confirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script type="text/javascript">
        function myTestFunction()
        {
            if (confirm('Do you want to proceed ?'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="Button1" Text="Button" OnClick="Button1_Click1" />
            <br /><br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
