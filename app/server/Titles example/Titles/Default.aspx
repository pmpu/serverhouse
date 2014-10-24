<%@ Page Language="C#" Inherits="Titles.Default" %>
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

		.title {
			font-size: 17px;
			text-align: left;
		}

		.title a{
			color: orange;
			text-decoration: none;
		}
		
	</style>
</head>
<body>
	<h1>Titles Manager</h1>
	<div id="container">
		<form id="addForm" runat="server">
			<asp:TextBox id="firstName" placeholder="First Name" runat="server" /><br>
			<asp:TextBox id="lastName" placeholder="Last Name" runat="server" /><br>
			<asp:Button id="submitButton" runat="server" Text="Add" OnClick="submitForm" />
		</form>

		<div id="titles">

		<%foreach(SHTitle t in titlesArray){ %>
			<div class="title"><%=t.firstName%>  <%=t.lastName%> <a href="?delete=<%=t.Id%>">delete</a> </div>
		<% } %>

		</div>
	</div>
</body>
</html>

