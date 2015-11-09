﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/id", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum;
                return"Hapuskan " + t + " huruf"
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length;
                return"Masukkan " + t + " huruf lagi"
            },
            loadingMore: function() { return"Mengambil data…" },
            maximumSelection: function(e) { return"Anda hanya dapat memilih " + e.maximum + " pilihan" },
            noResults: function() { return"Tidak ada data yang sesuai" },
            searching: function() { return"Mencari…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();