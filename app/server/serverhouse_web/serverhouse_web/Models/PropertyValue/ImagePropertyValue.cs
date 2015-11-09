using System.Collections.Generic;

namespace serverhouse_web.Models.PropertyValue {
    public class ImagePropertyValue : PropertyValue {
        public ImagePropertyValue() {
            type = "image";
            urls = new List<string>();
        }

        public ImagePropertyValue(List<string> _urls) {
            type = "image";
            urls = _urls;
        }

        public List<string> urls { get; set; }

        public override string ToString() {
            return "Images(" + string.Join(",", urls) + ")";
        }
    }
}