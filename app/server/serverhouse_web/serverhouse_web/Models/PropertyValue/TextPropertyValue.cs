using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace serverhouse_web.Models.PropertyValue
{
    public class TextPropertyValue: PropertyValue
    {
        public string text { get; set; }

        public TextPropertyValue(string _text) {
            type = "text";
            text = _text;
        }

        public override string ToString()
        {
            return text;
        }

       
    }
}