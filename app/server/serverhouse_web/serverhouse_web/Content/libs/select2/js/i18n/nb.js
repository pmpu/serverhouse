﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/nb", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum;
                return"Vennligst fjern " + t + " tegn"
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Vennligst skriv inn ";
                return t > 1 ? n += " flere tegn" : n += " tegn til", n
            },
            loadingMore: function() { return"Laster flere resultater…" },
            maximumSelection: function(e) { return"Du kan velge maks " + e.maximum + " elementer" },
            noResults: function() { return"Ingen treff" },
            searching: function() { return"Søker…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();