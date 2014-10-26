using System;
using System.Web;
using System.Web.UI;
using SimpleJson;

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

			JsonArray titlesArray = new JsonArray ();

			if (Request.QueryString ["getTitles"] != null) {

				foreach (SHTitle t in db.getAllTitles()) {
					JsonObject title = new JsonObject ();
					title ["first_name"] = t.firstName;
					title ["last_name"] = t.lastName;
					title ["position"] = t.position;
					titlesArray.Add (title);
				}

				output = titlesArray.ToString ();
			}
		}
	}
}

