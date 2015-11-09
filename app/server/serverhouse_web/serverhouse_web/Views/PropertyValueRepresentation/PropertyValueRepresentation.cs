using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;

using serverhouse_web.Models.SHObject;
using serverhouse_web.Models.PropertyValue;

namespace serverhouse_web.PropertyValueRepresentation
{
    using Property = KeyValuePair<string, PropertyValue>;
    using System.Text;
    using System.IO;
    using System.Web.UI;
    using System.Web.Routing;

    public class PropertyValueRepresentation:Controller
    {

        public static List<string> getAvailablePropertyValueTypes() {
            var derivedTypes = Helpers.FindAllDerivedTypes<PropertyValue>();
            List<string> propertyValueTypes = new List<string>();
            foreach (var type in derivedTypes) {
                string shortName = type.Name.Replace("PropertyValue", "").ToLower();
                propertyValueTypes.Add(shortName);
            }

            return propertyValueTypes;
        }
        
        public static string getEditPartialViewName(string prop_value_type) {
            return "~/Views/PropertyValueRepresentation/Edit/_pvrepEdit_" + prop_value_type + ".cshtml";            
        }

        public static string getViewPartialViewName(string prop_value_type)
        {
            return "~/Views/PropertyValueRepresentation/View/_pvrepView_" + prop_value_type + ".cshtml";
        }

        
    }
}
