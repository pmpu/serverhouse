using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using SimpleJson;
using MongoDB.Bson.Serialization;

namespace serverhouse_web.Models.PropertyValue
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(TextPropertyValue))]
    public class PropertyValue: object
    {

        public string type { get; set; }

        public PropertyValue() {
            type = "unknown_property_value_type";
        }

        public static PropertyValue constructPropertyValue(JsonObject propertyValue) {
            switch (propertyValue["type"].ToString()) {
                case "text":
                    return new TextPropertyValue(propertyValue["text"].ToString());                    
                default:
                    throw new Exception("Unknown property value type");                    
            }
        }
    }
}