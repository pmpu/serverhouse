<%@ Page Language="C#" Inherits="Titles.auth" %>
<%@ Import namespace="Titles" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title><%=title%></title>
	<style>

		body{
			font-family: "helvetica";
		}

		h1{
			text-align: center;
		}
		#container {
		margin: 0 auto;
			width: 400px;

			text-align: center;
		}
		#addForm {
			position: relative;
			display: block;
			margin: 30px auto;
		}

		#addForm input[type="text"]{
			margin-top: 10px;
			font-family: "Helvetica";
			font-size: 23px;
		}

		#addForm input[type="submit"]{
			margin-top: 20px;
			font-size: 23px;
		}

		
	</style>
</head>
<body>
	<%if(first_name != "" && last_name != "") {%>
	<h1>Set position</h1>
	<div id="container">
		<form id="addForm" runat="server" accept-charset="UTF-8">
			<asp:TextBox id="firstName" placeholder="First Name" runat="server" /><br>
			<asp:TextBox id="lastName" placeholder="Last Name" runat="server" /><br>
			<asp:TextBox id="position" placeholder="Position" runat="server" /><br>
			<asp:Button id="submitButton" runat="server" Text="Add" OnClick="submitForm" />
		</form>
	</div>
	<%}%>
</body>
</html>

