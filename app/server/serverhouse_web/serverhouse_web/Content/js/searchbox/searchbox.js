

var SB = {
    input: null,
    sugg_box: null,

    init: function() {
        SB.input = $(".header_searchbox_input");
        SB.sugg_box = $(".header_searchbox_suggestions");

        SB.initEvents();

        SB.hideSuggestions();

    },

    initEvents: function() {
        SB.input.bind("input propertychange, click", function(e) {
            SB.onInputChange(e.target);
        });

        $("html").click(function() {
            SB.hideSuggestions();
        });

        SB.input.click(function(e) {
            e.stopPropagation();
        });

        SB.sugg_box.click(function(e) {
            e.stopPropagation();
        });

        SB.input.keydown(function(e) {
            var key = e.which;
            if (key == 13) {
                return SB.onEnter(e);
            } else if (key == 38) {
                return SB.onArrowUp();
            } else if (key == 40) {
                return SB.onArrowDown();
            }
        });

    },

    hideSuggestions: function() {
        SB.sugg_box.hide();
    },

    onInputChange: function(el) {
        if ($(el).val().length > 1) {
            SB.showSuggestions(el);
        } else {
            SB.hideSuggestions();
        }
    },

    currentPointerPosition: -1,
    getResultsCount: function() {
        return SB.sugg_box.find(".sugg_obj").length;
    },

    initSelect: function() {
        SB.currentPointerPosition = -1;
    },

    onArrowDown: function() {
        if (SB.currentPointerPosition < SB.getResultsCount() - 1) {
            SB.currentPointerPosition++;
            SB.sugg_box.find(".sugg_obj").removeClass("sugg_focused");
            $(SB.sugg_box.find(".sugg_obj").get(SB.currentPointerPosition)).addClass("sugg_focused");
        }

        return false;
    },

    onArrowUp: function() {
        if (SB.currentPointerPosition > 0) {
            SB.currentPointerPosition--;
            SB.sugg_box.find(".sugg_obj").removeClass("sugg_focused");
            $(SB.sugg_box.find(".sugg_obj").get(SB.currentPointerPosition)).addClass("sugg_focused");
        } else if (SB.currentPointerPosition == 0) {
            SB.sugg_box.find(".sugg_obj").removeClass("sugg_focused");
            SB.currentPointerPosition--;
        }

        return false;
    },

    onEnter: function(e) {
        console.log("enter");

        if (SB.currentPointerPosition != -1) {
            e.preventDefault();
            // go to particular object
            var url = $(SB.sugg_box.find(".sugg_obj").get(SB.currentPointerPosition)).find("a").attr("href");
            ASYNC_NAV.goTo(url);
            SB.hideSuggestions();
            SB.input.blur();
            return false;
        }
        console.log("go to search");
        return true; // just go to search page
    },

    showSuggestions: function(el) {
        var q = $(el).val();
        $.ajax({
            url: "/search/suggestions?per_page=6&q=" + q,
            dataType: "html"
        }).done(function(html) {
            console.log(html);
            if ($.trim(html) != "") {
                SB.sugg_box.html(html);
                SB.sugg_box.show();

                SB.initSelect();
            } else {
                SB.sugg_box.hide();
            }
        });

    }

};


$(document).ready(function() {
    SB.init();
});