using System.Collections.Generic;

namespace serverhouse_web.Models.SHObject {
    public class SHObject {
        public SHObject() {
            properties = new Dictionary<string, PropertyValue.PropertyValue>();
            id = -1;
        }

        [BsonId]
        public string databaseId { get; set; }

        public long id { get; set; }
        public Dictionary<string, PropertyValue.PropertyValue> properties { get; set; }
        public bool ver_active { get; set; }
        public double ver_timestamp { get; set; }

        public void set(string key, PropertyValue.PropertyValue value) {
            if (properties.ContainsKey(key)) {
                properties[key] = value;
            }
            else {
                properties.Add(key, value);
            }
        }

        public PropertyValue.PropertyValue get(string key) {
            if (properties.ContainsKey(key)) {
                return properties[key];
            }

            return null;
        }

        public string getName() {
            if (properties.ContainsKey("name")) {
                if (properties["name"].ToString() != "") {
                    return properties["name"].ToString();
                }
            }

            return "#" + id;
        }
    }
}