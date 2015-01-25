var text = {
    serialize: function ($el) {
        return { type: "text", "text": $($el).find(".e_valuerep textarea").val() };
    },

    onObjectChange: null,

    onChange: function () {
        console.log("change");
    },

    init: function ($el) {
        $($el).find("textarea").bind('input propertychange', this.onChange);
        $($el).find("textarea").bind('input propertychange', this.onObjectChange);
        
        this.onChange({ target: $el });
    },

    onResize: function ($el) {
        $($el).find("textarea").width($($el).width() - 20);
        $($el).find("textarea").height($($el).height() - 50);
    }
}