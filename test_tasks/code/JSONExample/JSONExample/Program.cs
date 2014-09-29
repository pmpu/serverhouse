using System;

using SimpleJson;
using System.Collections.Generic;
using System.Net;
using System.Drawing;
using System.IO;


namespace JSONExample
{

	struct XY
	{
		public int x;
		public int y;
	}

	class MainClass
	{
		public static void Main (string[] args)
		{

			JsonObject jsonObject = new JsonObject();


			JsonArray pointsArray = new JsonArray ();

			for (int i = 0; i < 5; i++) {
				for (int j = 0; j < 5; j++) {
					JsonObject point = new JsonObject ();
					point ["x"] = i;
					point ["y"] = j;
					pointsArray.Add (point);
				}
			}

			jsonObject ["objectsArray"] = pointsArray;
			jsonObject["name"] = "foo";
			jsonObject["num"] = 10;
			jsonObject["is_vip"] = true;
			jsonObject["nickname"] = null;

			string jsonString = jsonObject.ToString();

			JsonObject obj = (JsonObject)SimpleJson.SimpleJson.DeserializeObject (jsonString);

			jsonString = "foo=45&data=" + jsonString;

			jsonString = parsePost (jsonString)["data"];


			Console.WriteLine (jsonString);
			Console.WriteLine (obj["name"]);

			XY first = new XY();
			first.y = 21;

			Console.WriteLine (first.y);

			// image draw example
			Bitmap image = new Bitmap (200, 200);
			Graphics gr = Graphics.FromImage (image);
			gr.FillRectangle (Brushes.Orange, new RectangleF(0, 0, 50, 50));
			string path = System.IO.Path.Combine (
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				"Example.png"
			);

			image.Save (path);
		}

		private static Dictionary<string, string> parsePost (string postString) {
			Dictionary<string, string> postParams = new Dictionary<string, string>();
			string[] rawParams = postString.Split('&');
			foreach (string param in rawParams)
			{
				string[] kvPair = param.Split('=');
				string key = kvPair[0];
				string value = WebUtility.UrlDecode(kvPair[1]);
				postParams.Add(key, value);
			}

			return postParams;
		}
	}
}
