var UI_HELPERS = {
    addOverlay: function (el) {
        if (!$(el).find(".uihelpers_overlay").length) {
            var overlay = $("<div>").attr("class", "uihelpers_overlay").css({ opacity: 0 });
            $(el).append(overlay);
            overlay.animate({ opacity: 1 }, 100, function () { });
        }
    },
    removeOverlay: function (el) {
        if ($(el).find(".uihelpers_overlay").length) {
            var overlay = $(el).find(".uihelpers_overlay");
            overlay.animate({ opacity: 0 }, 300, function () {
                overlay.remove();
            });
            
        }
    }
};


$(document).ready(function () {
    
});