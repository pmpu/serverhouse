namespace serverhouse_web.Models.PropertyValue {
    public class TextPropertyValue : PropertyValue {
        public TextPropertyValue(string _text) {
            type = "text";
            text = _text;
        }

        public string text { get; set; }

        public override string ToString() {
            return text;
        }
    }
}