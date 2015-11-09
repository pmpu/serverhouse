﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/ru", [], function() {
        function e(e, t, n, r) { return e % 10 < 5 && e % 10 > 0 && e % 100 < 5 || e % 100 > 20 ? e % 10 > 1 ? n : t : r }

        return{
            inputTooLong: function(t) {
                var n = t.input.length - t.maximum, r = "Пожалуйста, введите на " + n + " символ";
                return r += e(n, "", "a", "ов"), r += " меньше", r
            },
            inputTooShort: function(t) {
                var n = t.minimum - t.input.length, r = "Пожалуйста, введите еще хотя бы " + n + " символ";
                return r += e(overChars, "", "a", "ов"), r
            },
            loadingMore: function() { return"Загрузка данных…" },
            maximumSelected: function(t) {
                var n = "Вы можете выбрать не более " + t.maximum + " элемент";
                return n += e(overChars, "", "a", "ов"), n
            },
            noResults: function() { return"Совпадений не найдено" },
            searching: function() { return"Поиск…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();