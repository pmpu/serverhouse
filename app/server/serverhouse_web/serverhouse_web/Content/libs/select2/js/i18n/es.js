﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/es", [], function() {
        return{
            errorLoading: function() { return"La carga falló" },
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "Por favor, elimine " + t + " car";
                return t == 1 ? n += "ácter" : n += "acteres", n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Por favor, introduzca " + remainingChars + " car";
                return remainingChars == 1 ? n += "ácter" : n += "acteres", n
            },
            loadingMore: function() { return"Cargando más resultados…" },
            maximumSelection: function(e) {
                var t = "Sólo puede seleccionar " + e.maximum + " elemento";
                return e.maximum != 1 && (t += "s"), t
            },
            noResults: function() { return"No se encontraron resultados" },
            searching: function() { return"Buscando…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();