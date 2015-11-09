﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/fr", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "Supprimez \" + n + \" caractère";
                return t !== 1 && (n += "s"), n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Saisissez \" + n + \" caractère";
                return overChars !== 1 && (n += "s"), n
            },
            loadingMore: function() { return"Chargement de résultats supplémentaires…" },
            maximumSelection: function(e) {
                var t = "Vous pouvez seulement sélectionner " + e.maximum + " élément";
                return e.maximum !== 1 && (t += "s"), t
            },
            noResults: function() { return"Aucun résultat trouvé" },
            searching: function() { return"Recherche en cours…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();