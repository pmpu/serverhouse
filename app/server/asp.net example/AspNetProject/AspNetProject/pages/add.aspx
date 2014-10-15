<%@ Page Language="C#" Inherits="AspNetProject.add" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>add</title>
</head>
<body>
	<h1>Add person to db</h1>
	<form id="addPersonForm" runat="server">		
	<asp:TextBox id="name" runat="server" placeholder="name" /><br>
	<asp:TextBox id="surname" runat="server" placeholder="surname" /><br>
	<asp:Button OnClick="submit" runat="server" Text="Submit" />
	</form>
</body>
</html>

