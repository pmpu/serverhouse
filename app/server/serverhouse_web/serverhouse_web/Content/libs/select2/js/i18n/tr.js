﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/tr", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = t + " karakter daha girmelisiniz";
                return n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "En az " + t + " karakter daha girmelisiniz";
                return n
            },
            loadingMore: function() { return"Daha fazla…" },
            maximumSelected: function(e) {
                var t = "Sadece " + e.maximum + " seçim yapabilirsiniz";
                return t
            },
            noResults: function() { return"Sonuç bulunamadı" },
            searching: function() { return"Aranıyor…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();