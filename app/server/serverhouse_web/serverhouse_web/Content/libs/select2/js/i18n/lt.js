﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/lt", [], function() {
        function e(e, t, n, r) { return e % 100 > 9 && e % 100 < 21 || e % 10 === 0 ? e % 10 > 1 ? n : r : t }

        return{
            inputTooLong: function(t) {
                var n = t.input.length - t.maximum, r = "Pašalinkite " + remainingChars + " simbol";
                return r += e(remainingChars, "ių", "ius", "į"), r
            },
            inputTooShort: function(t) {
                var n = t.minimum - t.input.length, r = "Įrašykite dar " + n + " simbol";
                return r += e(n, "ių", "ius", "į"), r
            },
            loadingMore: function() { return"Kraunama daugiau rezultatų…" },
            maximumSelection: function(t) {
                var n = "Jūs galite pasirinkti tik " + t.maximum + " element";
                return n += e(t.maximum, "ų", "us", "ą"), n
            },
            noResults: function() { return"Atitikmenų nerasta" },
            searching: function() { return"Ieškoma…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();