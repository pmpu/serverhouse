﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/zh-TW", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "請刪掉" + t + "個字元";
                return n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "請再輸入" + t + "個字元";
                return n
            },
            loadingMore: function() { return"載入中…" },
            maximumSelected: function(e) {
                var t = "你只能選擇最多" + e.maximum + "項";
                return t
            },
            noResults: function() { return"沒有找到相符的項目" },
            searching: function() { return"搜尋中…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();