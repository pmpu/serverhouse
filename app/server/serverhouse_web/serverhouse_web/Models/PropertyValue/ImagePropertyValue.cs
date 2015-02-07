using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serverhouse_web.Models.PropertyValue
{
    public class ImagePropertyValue: PropertyValue
    {
        public List<string> urls { get; set; }

        public ImagePropertyValue(){
            type = "image";
            urls = new List<string>();
        }

        public ImagePropertyValue(List<string> _urls)
        {
            type = "image";
            urls = _urls;
        }

        public override string ToString()
        {
            return "Image(\""+urls+"\")";
        }
    }
}