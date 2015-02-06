using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace serverhouse_web.Models.SHObject
{
    using serverhouse_web.Models.PropertyValue;

    public class SHObject
    {
        [BsonId]
        public string databaseId { get; set; }
        public long id { get; set; }
        public Dictionary<string, PropertyValue> properties { get; set; }        
        public bool ver_active { get; set; }
        public double ver_timestamp { get; set; }

        public SHObject() { 
            properties = new Dictionary<string, PropertyValue>();
            id = -1;
        }

        public void set(string key, PropertyValue value){
            if (properties.ContainsKey(key)){
                properties[key] = value;
            }else {
                properties.Add(key, value);
            }
        }

        public PropertyValue get(string key) { 
            if (properties.ContainsKey(key)){
                return properties[key];
            }

            return null;
        }

        public string getName() {
            if (properties.ContainsKey("name")) {
                if (properties["name"].ToString() != ""){
                    return properties["name"].ToString();
                }
            }

            return "#"+id.ToString();
        }
       

    }
}