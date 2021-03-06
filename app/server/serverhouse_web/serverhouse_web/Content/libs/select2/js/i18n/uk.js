﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/uk", [], function() {
        function e(e, t, n, r) { return[11, 12, 13, 14].indexOf(e % 100) !== -1 ? r : e % 10 === 1 ? t : [2, 3, 4].indexOf(e % 10) !== -1 ? n : r }

        return{
            errorLoading: function() { return"Неможливо завантажити результати" },
            inputTooLong: function(t) {
                var n = t.input.length - t.maximum;
                return"Будь ласка, видаліть " + n + " " + e(t.maximum, "літеру", "літери", "літер")
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length;
                return"Будь ласка, введіть " + t + " або більше літер"
            },
            loadingMore: function() { return"Завантаження інших результатів…" },
            maximumSelected: function(t) { return"Ви можете вибрати лише " + t.maximum + " " + e(t.maximum, "пункт", "пункти", "пунктів") },
            noResults: function() { return"Нічого не знайдено" },
            searching: function() { return"Пошук…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();