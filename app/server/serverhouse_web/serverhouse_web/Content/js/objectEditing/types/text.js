var text = {
    serialize: function ($el) {
        return { type: "text", "text": $($el).find(".valuerep textarea").val() };
    },

    onChange: function () {
        console.log("change");
    },

    initEvents: function ($el) {
        $($el).find("textarea").bind('input propertychange', this.onChange);
    }
}