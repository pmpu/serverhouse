﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/eu", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "Idatzi ";
                return t == 1 ? n += "karaktere bat" : n += t + " karaktere", n += " gutxiago", n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Idatzi ";
                return overChars == 1 ? n += "karaktere bat" : n += overChars + " karaktere", n += " gehiago", n
            },
            loadingMore: function() { return"Emaitza gehiago kargatzen…" },
            maximumSelection: function(e) { return e.maximum === 1 ? "Elementu bakarra hauta dezakezu" : e.maximum + " elementu hauta ditzakezu soilik" },
            noResults: function() { return"Ez da bat datorrenik aurkitu" },
            searching: function() { return"Bilatzen…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();