﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/hu", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum;
                return"Túl hosszú. " + t + " karakterrel több, mint kellene."
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length;
                return"Túl rövid. Még " + t + " karakter hiányzik."
            },
            loadingMore: function() { return"Töltés…" },
            maximumSelection: function(e) { return"Csak " + e.maximum + " elemet lehet kiválasztani." },
            noResults: function() { return"Nincs találat." },
            searching: function() { return"Keresés…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();