var image = {
    serialize: function ($el) {
        return { type: "image", "url": $($el).find(".e_valuerep input").val() };
    },

    onObjectChange: null,

    onChange: function (e) {        
        console.log("chnage");
        console.log(e);
        var url = $(e.target).val();
        var $prop = $(e.target).closest(".edit_prop");

        $("<img/>")
            .load(function () {
                $prop.find(".e_valuerep_image_preview").html("<a href='"+url+"' data-lightbox='preview'><img src='" + url + "'></a>");
            })
            .error(function () {
                $prop.find(".e_valuerep_image_preview").html("error loading image");
            })
            .attr("src", url);
        
    },

    init: function (el) {
        $(el).find("input").bind('input propertychange', this.onChange);
        $(el).find("input").bind('input propertychange', this.onObjectChange);
        $(el).attr("data-min-sizey", 3);

        this.onChange({ target: $(el).find("input") });
        this.onResize($(el));   
    },

    onResize: function ($prop) {
        $($prop).find(".e_valuerep_image_preview").height($($prop).height() - 110);
        $($prop).find(".e_valuerep_image_preview").width($($prop).width() - 20);
        if ($($prop).height() < 190) {
            OE.gridster.resize_widget($($prop), $($prop).attr("data-sizex"), 3);
        }
    }
}