var text = {
    serialize: function (el) {
        return { type: "text", "text": $(el).find(".valuerep textarea").val() };
    }
}