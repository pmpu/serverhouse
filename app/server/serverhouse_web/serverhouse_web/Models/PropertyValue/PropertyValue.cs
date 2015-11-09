using System;
using System.Collections.Generic;
using System.Linq;
using SimpleJson;

namespace serverhouse_web.Models.PropertyValue {
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof (TextPropertyValue), typeof (ImagePropertyValue))]
    public class PropertyValue : object {
        public PropertyValue() {
            type = "unknown_property_value_type";
        }

        public string type { get; set; }
        public Dictionary<string, int> order_data { get; set; }

        public override string ToString() {
            return "UnknownPropertyValue";
        }

        public static PropertyValue constructPropertyValue(JsonObject propertyValue) {
            PropertyValue newPropVal;
            switch (propertyValue["type"].ToString()) {
                case "text":
                    newPropVal = new TextPropertyValue(propertyValue["text"].ToString());
                    break;
                case "image":
                    newPropVal = new ImagePropertyValue(
                        (from o in (JsonArray) propertyValue["urls"]
                            select o.ToString()).ToList()
                        );
                    break;
                default:
                    throw new Exception("Unknown property value type");
            }

            // add order data
            var order_data = (JsonObject) propertyValue["order_data"];

            newPropVal.order_data = new Dictionary<string, int>();
            newPropVal.order_data["row"] = int.Parse(order_data["row"].ToString());
            newPropVal.order_data["sizex"] = int.Parse(order_data["sizex"].ToString());
            newPropVal.order_data["sizey"] = int.Parse(order_data["sizey"].ToString());

            return newPropVal;
        }
    }
}