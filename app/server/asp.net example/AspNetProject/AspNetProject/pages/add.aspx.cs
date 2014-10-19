using System;
using System.Web;
using System.Web.UI;



namespace AspNetProject
{
	
	public partial class add : System.Web.UI.Page
	{

		public void Page_Load () {

		}

		public void submit (object sender, EventArgs args) {	
			Console.WriteLine ("BUTTON CLICKED");
			Console.WriteLine ("name is {0} and surname is {1}", name.Text, surname.Text);
		}
	}
}

