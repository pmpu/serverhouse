﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/is", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "Vinsamlegast styttið texta um " + t + " staf";
                return t <= 1 ? n : n + "i"
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Vinsamlegast skrifið " + t + " staf";
                return overChars > 1 && (n += "i"), n += " í viðbót", n
            },
            loadingMore: function() { return"Sæki fleiri niðurstöður…" },
            maximumSelection: function(e) { return"Þú getur aðeins valið " + e.maximum + " atriði" },
            noResults: function() { return"Ekkert fannst" },
            searching: function() { return"Leita…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();