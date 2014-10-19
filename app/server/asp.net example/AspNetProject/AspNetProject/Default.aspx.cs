using System;
using System.Web;
using System.Web.UI;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace AspNetProject
{

	public class Entity
	{
		public ObjectId Id { get; set; }
		public string Name { get; set; }
	}
	
	public partial class Default : System.Web.UI.Page
	{

		public void Page_Load () {
			var connectionString = "mongodb://localhost";
			var client = new MongoClient(connectionString);
			var server = client.GetServer();
			var database = server.GetDatabase("test");
			var collection = database.GetCollection<Entity>("entities");

			var entity = new Entity { Name = "Tom" };
			collection.Insert(entity);
			var id = entity.Id;

			var query = Query<Entity>.EQ(e => e.Id, id);
			entity = collection.FindOne(query);

			entity.Name = "Dick";
			collection.Save(entity);

			var update = Update<Entity>.Set(e => e.Name, "Harry");
			collection.Update(query, update);

			//collection.Remove(query);
		}

		public void button1Clicked (object sender, EventArgs args)
		{
			button1.Text = "You clicked me!";
		}

		public void textChanged (object sender, EventArgs args){
			myTextBox.Text = "Hooray!";
		}
	}
}

