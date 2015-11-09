var image = {
    serialize: function(el) {
        return {
            type: "image",
            urls: this.getUrls(el),
            toString: "Image(\"" + $(el).find(".e_valuerep textarea").val() + "\")"
        };
    },

    getUrls: function(el) {
        var urls = [];
        var value = $.trim($(el).find(".e_valuerep textarea").val());
        urls = value.split("\n");
        for (var k in urls) {
            urls[k] = $.trim(urls[k]);
        }

        return urls;
    },


    onObjectChange: null,

    onChange: function(prop) {
        var urls = this.getUrls(prop);


        this.onResize(prop);
        this.updatePreview(prop);
    },

    init: function(el) {
        var self = this;
        $(el).find("textarea").bind("input propertychange", function(e) {
            self.onChange($(el));
            self.onObjectChange();
        });
        $(el).bind("mouseup", function(e) {
            self.onResize($(el));
        });


        $(el).attr("data-min-sizey", 3);


        self.onChange($(el));


    },

    onResize: function(prop) {
        var $textarea = $(prop).find("textarea");
        var $preview = $(prop).find(".e_valuerep_image_preview");
        var $header = $(prop).find(".edit_prop_header");
        var $thumbs = $(prop).find(".e_valuerep_image_thumbs");

        var padding = 10;

        $textarea.width($(prop).width() - padding * 2);
        $preview.width($(prop).width() - padding * 2);


        //if ($(prop).height() - ($header.height() + padding * 11) < $textarea.height() + $preview.height()) {
        var new_y_size = Math.round(
            ($textarea.height() + $preview.height()
                + $thumbs.height()
                + $header.height() + (padding * 12)) / 45
        );
        if (new_y_size != $(prop).attr("data-sizey")) {
            OE.gridster.resize_widget($(prop), $(prop).attr("data-sizex"), new_y_size);
            this.onObjectChange();
        }
        // }
    },


    checkImageForErrors: function(prop, url, callback) {
        $("<img/>")
            .load(function() {
                callback(false, url);
            })
            .error(function() {
                callback(true, url);
            })
            .attr("src", url);
    },

    setPreview: function(prop, url) {
        var self = this;
        $("<img/>")
            .load(function() {
                prop.find(".e_valuerep_image_preview").html("<a href='" + url + "' data-lightbox='preview'><img src='" + url + "'></a>");
                self.onResize(prop);
            })
            .error(function() {
                prop.find(".e_valuerep_image_preview").html("error loading image");
            })
            .attr("src", url);


    },

    updatePreview: function(prop) {
        var self = this;
        var urls = this.getUrls(prop);
        var $preview = prop.find(".e_valuerep_image_preview");
        var $thumbs = $(prop).find(".e_valuerep_image_thumbs");
        $thumbs.html("");
        if (urls.length > 0) {
            for (var k in urls) {
                var url = urls[k];
                self.checkImageForErrors(prop, url, function(errors, url) {

                    if (!errors) {
                        var $thumb = $("<img>").attr("src", url).click(function() {
                            self.setPreview(prop, url);
                        });
                    } else {
                        noty({
                            text: "Image has wrong URL in '" + $(prop).attr("prop_name") + "' property",
                            type: "warning",
                            timeout: 10000
                        });
                    }

                    ///$thumb.css({ cursor: "pointer"})

                    $thumbs.append($thumb);
                    self.onResize(prop);
                });
            }
        }


        this.onResize(prop);

    }
}