﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/gl", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "Engada ";
                return t === 1 ? n += "un carácter" : n += t + " caracteres", n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Elimine ";
                return t === 1 ? n += "un carácter" : n += t + " caracteres", n
            },
            loadingMore: function() { return"Cargando máis resultados…" },
            maximumSelection: function(e) {
                var t = "Só pode ";
                return e.maximum === 1 ? t += "un elemento" : t += e.maximum + " elementos", t
            },
            noResults: function() { return"Non se atoparon resultados" },
            searching: function() { return"Buscando…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();