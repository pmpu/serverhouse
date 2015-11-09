﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/et", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "Sisesta " + t + " täht";
                return t != 1 && (n += "e"), n += " vähem", n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Sisesta " + t + " täht";
                return t != 1 && (n += "e"), n += " rohkem", n
            },
            loadingMore: function() { return"Laen tulemusi…" },
            maximumSelected: function(e) {
                var t = "Saad vaid " + e.maximum + " tulemus";
                return e.maximum == 1 ? t += "e" : t += "t", t += " valida", t
            },
            noResults: function() { return"Tulemused puuduvad" },
            searching: function() { return"Otsin…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();