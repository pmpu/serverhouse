var image = {
    serialize: function ($el) {
        return {
            type: "image",
            url: $($el).find(".e_valuerep input").val(),
            toString: "Image(\"" + $($el).find(".e_valuerep input").val() + "\")"
        };
    },
    

    onObjectChange: null,

    onChange: function ($prop) {                 
        var url = $prop.find("input").val();        

        $("<img/>")
            .load(function () {
                $prop.find(".e_valuerep_image_preview").html("<a href='"+url+"' data-lightbox='preview'><img src='" + url + "'></a>");
            })
            .error(function () {
                $prop.find(".e_valuerep_image_preview").html("error loading image");
            })
            .attr("src", url);

        this.onResize($prop);
    },

    init: function (el) {
        var self = this;
        $(el).find("input").bind('input propertychange', function (e) {            
            self.onChange($(el))
        });

        $(el).find("input").bind('input propertychange', function (e) { self.onObjectChange() });
        $(el).attr("data-min-sizey", 3);

        this.onChange($(el));
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