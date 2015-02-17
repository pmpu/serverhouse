

var SB = {

    input: null,
    sugg_box: null,

    init: function () {
        SB.input = $(".header_searchbox_input");
        SB.sugg_box = $(".header_searchbox_suggestions");

        SB.initEvents();

        SB.hideSuggestions();

    },

    initEvents: function () {
        SB.input.bind("input propertychange, click", function (e) {
            SB.onInputChange(e.target);
        });

        $("html").click(function () {
            SB.hideSuggestions();
        });

        SB.input.click(function (e) {
            e.stopPropagation();
        });

        SB.sugg_box.click(function (e) {
            e.stopPropagation();
        });

    },

    hideSuggestions: function(){
        SB.sugg_box.hide();
    },

    onInputChange: function (el) {
        if ($(el).val().length > 1) {
            SB.showSuggestions(el);
        } else {
            SB.hideSuggestions();
        }
    },

    showSuggestions: function (el) {
        var q = $(el).val();
        $.ajax({
            url: "/search/suggestions?q=" + q,
            dataType: "html"
        }).done(function (html) {
            console.log(html);
            $(".header_searchbox_suggestions").html(html);
            SB.sugg_box.show();
        });

    }

};



$(document).ready(function () {
    SB.init();
});