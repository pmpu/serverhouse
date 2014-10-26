using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;

namespace Titles
{
	
	public partial class Default : System.Web.UI.Page
	{

		Db db;
		public string title;
		public List<SHTitle> titlesArray;

		public Default(){
			db = new Db();
		}

		public void Page_Load () {
			title = "Manage Titles";


			var deleteId = (string)Request.QueryString["delete"];
			if (deleteId != null) {
				Console.WriteLine ("DELETE {0}", deleteId);
				db.removeTitleById (deleteId);
				Response.Redirect ("/");
			}

			titlesArray = db.getAllTitles ();
		}

		public void submitForm (object sender, EventArgs args){
			if (firstName.Text != "" && lastName.Text != "" && position.Text != "") {
				db.addTitle (firstName.Text, lastName.Text, position.Text);
				firstName.Text = "";
				lastName.Text = "";
				position.Text = "";
				titlesArray = db.getAllTitles ();
			}

		}

		public void delete (object sender, EventArgs args){

		}

	}
}

