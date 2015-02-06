using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serverhouse_web.Models.PropertyValue
{
    public class ImagePropertyValue: PropertyValue
    {
        public string url { get; set; }

        public ImagePropertyValue(string _url) {
            type = "image";
            url = _url;
        }

        public override string ToString()
        {
            return "Image(\""+url+"\")";
        }
    }
}