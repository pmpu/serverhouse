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
    [BsonKnownTypes(typeof(TextPropertyValue), typeof(ImagePropertyValue))]
    public class PropertyValue: object
    {

        public string type { get; set; }
        public Dictionary<string, int> order_data { get; set; }

        public PropertyValue() {
            type = "unknown_property_value_type";
        }

        public override string ToString()
        {
            return "UnknownPropertyValue";
        }

        public static PropertyValue constructPropertyValue(JsonObject propertyValue) {
            PropertyValue newPropVal;
            switch (propertyValue["type"].ToString()) {
                case "text":
                    newPropVal = new TextPropertyValue(propertyValue["text"].ToString());
                    break;
                case "image":
                    newPropVal = new ImagePropertyValue(propertyValue["url"].ToString());
                    break;
                default:
                    throw new Exception("Unknown property value type");                    
            }

            // add order data
            var order_data = (JsonObject)propertyValue["order_data"];

            newPropVal.order_data = new Dictionary<string, int>();
            newPropVal.order_data["row"] = int.Parse(order_data["row"].ToString());
            newPropVal.order_data["sizex"] = int.Parse(order_data["sizex"].ToString());
            newPropVal.order_data["sizey"] = int.Parse(order_data["sizey"].ToString());

            return newPropVal;
        }
    }
}