using System;

using SimpleJson;

namespace JSONExample
{
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

			Console.WriteLine (jsonString);

		}
	}
}
