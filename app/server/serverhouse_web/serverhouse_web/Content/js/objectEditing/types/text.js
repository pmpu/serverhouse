var text = {
    serialize: function ($el) {
        return {
            type: "text",
            text: $($el).find(".e_valuerep textarea").val(),
            toString: $($el).find(".e_valuerep textarea").val()
        };
    },

    onObjectChange: null,

    onChange: function ($prop) {
        
    },

    init: function (el) {
        var self = this;
        $(el).find("textarea").bind('input propertychange', function (e) {
            self.onChange($(el));
        });
        $(el).find("textarea").bind('input propertychange', this.onObjectChange);        
        this.onChange($(el));
    },

    onResize: function ($el) {
        $($el).find("textarea").width($($el).width() - 20);
        $($el).find("textarea").height($($el).height() - 50);
    }
}