﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/ro", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "Vă rugăm să introduceți mai puțin de " + t;
                return n += " caracter", n !== 1 && (n += "e"), n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Vă rugăm să introduceți incă " + t;
                return n += " caracter", n !== 1 && (n += "e"), n
            },
            loadingMore: function() { return"Se încarcă…" },
            maximumSelection: function(e) {
                var t = "Aveți voie să selectați cel mult " + e.maximum;
                return t += " element", t !== 1 && (t += "e"), t
            },
            noResults: function() { return"Nu a fost găsit nimic" },
            searching: function() { return"Căutare…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();