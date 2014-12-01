using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace serverhouse_web.Models.SHObject
{
    public class SHObject
    {
        [BsonId]
        public string databaseId { get; set; }
        public long id { get; set; }
        public Dictionary<string, string> properties { get; set; }
        
        public bool ver_active { get; set; }
        public double ver_timestamp { get; set; }

        public SHObject() { 
            properties = new Dictionary<string,string>();
            id = -1;
        }

        public void setProperty(string key, string value){
            if (properties.ContainsKey(key)){
                properties[key] = value;
            }else {
                properties.Add(key, value);
            }
        }


        public string getName() {
            string[] possibleKeys = new string[] { "name", "имя", "название" };

            foreach(var nameKey in possibleKeys){
                if (properties.ContainsKey(nameKey)){
                    return properties[nameKey];
                }
            }

            return "Object"+id.ToString();
        }

    }
}