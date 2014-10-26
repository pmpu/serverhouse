using System;
using System.Web;
using System.Web.UI;

using System.Net;
using System.IO;
using SimpleJson;


namespace Titles
{
	
	public partial class auth : System.Web.UI.Page
	{
		public const long APP_ID = 4606669;
		public const string APP_SECRET = "mxPo1sXzmDCfEFs7yjjV";
		public const double API_VER = 5.25;
		Db db;

		public string first_name, last_name, title;

		public auth (){
			db = new Db();
		}

		public void Page_Load (){
			if (Request.QueryString ["code"] != null) {
				var code = Request.QueryString ["code"];
				Console.WriteLine ("Code received " + code);
				// get access token now
				string act_url = "https://oauth.vk.com/access_token?client_id=" + APP_ID + "" +
				                 "&redirect_uri=http://localhost:8080/auth.aspx" +
				                 "&client_secret=" + APP_SECRET + "" +
				                 "&code=" + code;

				/*Response.Redirect (act_url);
				return;*/
				var json_resp = GET (act_url);
				Console.WriteLine (json_resp);

				JsonObject jsobject = (SimpleJson.JsonObject)SimpleJson.SimpleJson.DeserializeObject (json_resp);
				object error = "";
				if (!jsobject.TryGetValue ("error", out error)) {
					var access_token = jsobject ["access_token"].ToString ();
					var user_id = jsobject ["user_id"].ToString ();
					Console.WriteLine (access_token);
					Console.WriteLine (user_id);

					// get first and last name
					string get_names_url = "https://api.vk.com/method/getProfiles?uid=" + user_id + "&access_token=" + access_token;
					var names_json_resp = GET (get_names_url);
					JsonObject resp = (SimpleJson.JsonObject)SimpleJson.SimpleJson.DeserializeObject (names_json_resp);
					JsonArray response = (JsonArray)resp ["response"];
					JsonObject profile_info = (JsonObject)response [0];
					var first_name = profile_info ["first_name"].ToString ();
					var last_name = profile_info ["last_name"].ToString ();
					Console.WriteLine (first_name);
					Console.WriteLine (last_name);
					Response.Redirect ("/auth.aspx?fist_name=" + first_name + "&last_name=" + last_name);
				} else {
					Console.WriteLine ("Error: " + jsobject ["error"].ToString () + " " + jsobject ["error_description"].ToString ());
				}

			} else if (Request.QueryString ["fist_name"] != null && Request.QueryString ["last_name"] != null) {
				first_name = Request.QueryString ["fist_name"];
				last_name = Request.QueryString ["last_name"];
				firstName.Text = first_name;
				lastName.Text = last_name;
				title = "Set position";
			} else {
				Response.Redirect ("https://oauth.vk.com/authorize?client_id="+APP_ID +
					"&redirect_uri=http://localhost:8080/auth.aspx" +
					"&response_type=code&revoke=1" +
					"&v="+API_VER);
			}
		}

		public void submitForm (object sender, EventArgs args){
			if (firstName.Text != "" && lastName.Text != "" && position.Text != "") {
				db.addTitle (firstName.Text, lastName.Text, position.Text);
				firstName.Text = "";
				lastName.Text = "";
				position.Text = "";
				Response.Redirect ("/");
			}

		}

		private string GET(string url)
		{
			WebRequest req = WebRequest.Create(url);
			WebResponse resp = req.GetResponse();
			Stream stream = resp.GetResponseStream();
			StreamReader sr = new StreamReader(stream);
			string Out = sr.ReadToEnd();
			sr.Close();
			return Out;
		}
	}
}

