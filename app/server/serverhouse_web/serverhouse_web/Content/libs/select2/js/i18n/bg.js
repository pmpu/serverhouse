﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/bg", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "Моля въведете с " + t + " по-малко символ";
                return t > 1 && (n += "a"), n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Моля въведете още " + t + " символ";
                return t > 1 && (n += "a"), n
            },
            loadingMore: function() { return"Зареждат се още…" },
            maximumSelected: function(e) {
                var t = "Можете да направите до " + e.maximum + " ";
                return e.maximum > 1 ? t += "избора" : t += "избор", t
            },
            noResults: function() { return"Няма намерени съвпадения" },
            searching: function() { return"Търсене…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();