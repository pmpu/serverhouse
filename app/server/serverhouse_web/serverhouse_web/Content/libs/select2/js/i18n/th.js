﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/th", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum, n = "โปรดลบออก " + t + " ตัวอักษร";
                return n
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length, n = "โปรดพิมพ์เพิ่มอีก " + t + " ตัวอักษร";
                return n
            },
            loadingMore: function() { return"กำลังค้นข้อมูลเพิ่ม…" },
            maximumSelected: function(e) {
                var t = "คุณสามารถเลือกได้ไม่เกิน " + e.maximum + " รายการ";
                return t
            },
            noResults: function() { return"ม่พบข้อมูล" },
            searching: function() { return"กำลังค้นข้อมูล…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();