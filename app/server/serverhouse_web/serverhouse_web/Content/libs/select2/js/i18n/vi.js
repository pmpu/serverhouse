﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/vi", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "Vui lòng nhập ít hơn " + t + " ký tự";
                return t != 1 && (n += "s"), n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "Vui lòng nhập nhiều hơn " + t + " ký tự\"";
                return n
            },
            loadingMore: function() { return"Đang lấy thêm kết quả…" },
            maximumSelected: function(e) {
                var t = "Chỉ có thể chọn được " + e.maximum + " lựa chọn";
                return t
            },
            noResults: function() { return"Không tìm thấy kết quả" },
            searching: function() { return"Đang tìm…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();