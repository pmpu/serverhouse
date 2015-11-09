﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/hr", [], function() {
        function e(e) {
            var t = " " + e + " znak";
            return e % 10 < 5 && e % 10 > 0 && (e % 100 < 5 || e % 100 > 19) ? e % 10 > 1 && (t += "a") : t += "ova", t
        }

        return{
            inputTooLong: function(t) {
                var n = t.input.length - t.maximum;
                return"Unesite " + e(n)
            },
            inputTooShort: function(t) {
                var n = t.minimum - t.input.length;
                return"Unesite još " + e(n)
            },
            loadingMore: function() { return"Učitavanje rezultata…" },
            maximumSelection: function(e) { return"Maksimalan broj odabranih stavki je " + e.maximum },
            noResults: function() { return"Nema rezultata" },
            searching: function() { return"Pretraga…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();