﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/fi", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum;
                return"Ole hyvä ja anna " + t + " merkkiä vähemmän"
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length;
                return"Ole hyvä ja anna " + t + " merkkiä lisää"
            },
            loadingMore: function() { return"Ladataan lisää tuloksia…" },
            maximumSelection: function(e) { return"Voit valita ainoastaan " + e.maximum + " kpl" },
            noResults: function() { return"Ei tuloksia" },
            searching: function() {}
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();