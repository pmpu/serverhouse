﻿window.$ = window.$ || {}, function() {
    $ && $.fn && $.fn.select2 && $.fn.select2.amd && (define = $.fn.select2.amd.define, require = $.fn.select2.amd.require), define("select2/i18n/az", [], function() {
        return{
            inputTooLong: function(e) {
                var t = e.input.length - e.maximum;
                return t + " simvol silin"
            },
            inputTooShort: function(e) {
                var t = e.minimum - e.input.length;
                return t + " simvol daxil edin"
            },
            loadingMore: function() { return"Daha çox nəticə yüklənir…" },
            maximumSelected: function(e) { return"Sadəcə " + e.maximum + " element seçə bilərsiniz" },
            noResults: function() { return"Nəticə tapılmadı" },
            searching: function() { return"Axtarılır…" }
        }
    }), require("jquery.select2"), $.fn.select2.amd = { define: define, require: require }
}();