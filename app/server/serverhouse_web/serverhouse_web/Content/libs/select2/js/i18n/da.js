﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/da", [], function() {
        return{
            errorLoading: function() { return"The results could not be loaded." },
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "Angiv venligst " + t + " tegn mindre";
                return n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Angiv venligst " + t + " tegn mere";
                return n
            },
            loadingMore: function() { return"Indlæser flere resultater…" },
            maximumSelected: function(e) {
                var t = "Du kan kun vælge " + e.maximum + " emne";
                return e.maximum != 1 && (t += "r"), t
            },
            noResults: function() { return"Ingen resultater fundet" },
            searching: function() { return"Søger…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();