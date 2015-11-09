using System.Collections.Generic;
using serverhouse_web.Models.PropertyValue;

namespace serverhouse_web.PropertyValueRepresentation {
    using Property = KeyValuePair<string, PropertyValue>;

    public class PropertyValueRepresentation : Controller {
        public static List<string> getAvailablePropertyValueTypes() {
            var derivedTypes = Helpers.FindAllDerivedTypes<PropertyValue>();
            var propertyValueTypes = new List<string>();
            foreach (var type in derivedTypes) {
                var shortName = type.Name.Replace("PropertyValue", "").ToLower();
                propertyValueTypes.Add(shortName);
            }

            return propertyValueTypes;
        }

        public static string getEditPartialViewName(string prop_value_type) {
            return "~/Views/PropertyValueRepresentation/Edit/_pvrepEdit_" + prop_value_type + ".cshtml";
        }

        public static string getViewPartialViewName(string prop_value_type) {
            return "~/Views/PropertyValueRepresentation/View/_pvrepView_" + prop_value_type + ".cshtml";
        }
    }
}