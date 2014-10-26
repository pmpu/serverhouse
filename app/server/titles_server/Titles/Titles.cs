using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Titles
{

	public class SHTitle {
		public ObjectId Id { get; set;}
		public string firstName { get; set;} 
		public string lastName { get; set;}
		public string position { get; set;}
		public long timeRegistered { get; set;}
	}

	public class Db {

		public MongoCollection<SHTitle> dbCollection;

		public Db () {
			var client = new MongoClient("mongodb://localhost");
			var server = client.GetServer();
			var database = server.GetDatabase("titlesDB");
			dbCollection = database.GetCollection<SHTitle>("titles");
		}

		public List<SHTitle> getAllTitles () {
			List<SHTitle> titles = new List<SHTitle>();
			var cursor  = dbCollection.FindAll ();
			foreach (SHTitle title in cursor) {
				titles.Add (title);
			}

			return titles;
		}

		public string getAllTitlesJSON() {
			var cursor  = dbCollection.FindAll ();
			return cursor.ToJson ();
		}

		public void addTitle (string fName, string lName, string position) {
			var title = new SHTitle { firstName=fName, lastName=lName, position=position };
			Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
			title.timeRegistered = unixTimestamp;
			dbCollection.Insert(title);
			var id = title.Id;
		}

		public void removeTitleById (string id){
			var query = Query<SHTitle>.EQ(e => e.Id, new ObjectId(id));
			dbCollection.Remove (query);
		}
	}
}

