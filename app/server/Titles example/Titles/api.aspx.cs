using System;
using System.Web;
using System.Web.UI;

namespace Titles
{
	public partial class api : System.Web.UI.Page
	{

		Db db;
		public string output;

		public api(){
			db = new Db();

		}

		public void Page_Load() {
			output = "";


			if (Request.QueryString ["getTitles"] != null) {
				output = db.getAllTitlesJSON ();
			}
		}
	}
}

