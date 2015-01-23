var OE = {

    getObjectId: function () {
        return $("#object_edit_container").attr("object_id");
    },

    initPropertyNameFor: function ($el) {
        $el.select2({
            ajax: {
                url: "/repo/getAllPossibleNames",
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    return {
                        q: params.term, // search term
                        page: params.page
                    };
                },
                processResults: function (data, page) {
                    var resultsArray = [];
                    for (var i in data) {
                        resultsArray.push({ id: data[i], text: data[i] });
                    }
                    return {
                        results: resultsArray
                    };
                },
                cache: true
            },
            maximumSelectionLength: 2,
            inimumInputLength: 1,
            width: 'element',
            tags: true
        }).on("change", function (e) {
            var $select = $(this);
            var $obj = $select.closest(".edit_prop");
            var old_name = $obj.attr("prop_name");
            var new_name = $select.val();

            if (old_name != new_name) {
                if (OE.objectHasKey(new_name)) {
                    swal({
                        title: "Duplicate key!",
                        text: "You already have property with key '" + new_name + "'",
                        type: "warning",
                        allowOutsideClick: true
                    });
                    $select.val(old_name).trigger("change");
                } else {
                    $obj.attr("prop_name", new_name);
                    $select.html($("<option>").html(new_name).val(new_name));
                    $select.select2("destroy");
                    OE.initPropertyNameFor($select);
                    OE.onChange();
                }
            }
        });
    },

    initEvents: function () {
        $(".object_edit_add_prop button").unbind("click");
        $(".object_edit_add_prop button").click(OE.addProperty);

        $(".object_edit_add_prop button").unbind("click");
        $(".object_edit_add_prop button").click(OE.addProperty);

        $(".object_edit_undo button").unbind("click");
        $(".object_edit_undo button").click(OE.undo);

        $(".object_edit_redo button").unbind("click");
        $(".object_edit_redo button").click(OE.redo);
        
        $(".edit_prop_delete button").unbind("click");
        $(".edit_prop_delete button").click(function () {
            $prop = $(this).closest(".edit_prop");
            OE.removeProperty($prop);
        });

        // init events for properties
        $.each($(".edit_prop"), function (i, el) {
            var type = $(el).attr("prop_type");
            window[type]["onChange"] = OE.onChange;
            window[type]["initEvents"](el);
        });
    },

    onChange: function () {
        if (OE.onChange.saveTimeout != null) {
            clearTimeout(OE.onChange.saveTimeout);
            OE.onChange.saveTimeout = null;
        }
        OE.onChange.saveTimeout = setTimeout(OE.saveObject, 1000);
        window.onbeforeunload = function () {
            return "Data is being saved. Please stay here for a while.";
        };
    },

    OESTATE: { SAVED: 0, SAVING: 1, ERROR: 2 },
    state: 0,
    updateState: function (state) {
        OE.state = state;
        switch (state) {
            case OE.OESTATE.SAVED:
                OE.setStateMesssage("All changes saved.");                
                window.onbeforeunload = function () {
                    return null;
                };
                break;
            case OE.OESTATE.SAVING:
                OE.setStateMesssage("Saving...");                
                break;
            case OE.OESTATE.ERROR:
                OE.setStateMesssage("Unknown error.");
                window.onbeforeunload = function () {
                    return null;
                };
                break;
        }
    },
    setStateMesssage: function(msg){
        $(".object_edit_status").html(msg);
    },

    addProperty: function () {
        ASYNC_NAV.load(
            "/repo/edit/" + OE.getObjectId() + "?async=1&part=new_prop",
            function (data) {
                $(".edit_props").prepend(data.html);
                OE.initPropertyNameFor($(".edit_prop_name select"));
                OE.initEvents();
            });
    },

    removeProperty: function ($prop) {
        $prop.remove();
        this.onChange();
    },

    objectHasKey: function (key) {
        return $(".edit_prop[prop_name='" + key + "']").length > 0;
    },

    saveObject: function () {
        console.log("save obj");
        OE.updateState(OE.OESTATE.SAVING);
        var serializedProperties = JSON.stringify(OE.getObjectProperties());
        $.post("/repo/edit/" + OE.getObjectId(), { properties: serializedProperties }, function (data) {

            if (data == "success") {                
                OE.updateState(OE.OESTATE.SAVED);
            } else {
                swal({ title: "Error saving!", type: "error" });
                OE.updateState(OE.OESTATE.ERROR);
            }
        });
    },

    undo: function () {        
        $.get("/repo/undo/" + OE.getObjectId(), function (result) {
            if (result == "success") {
                ASYNC_NAV.loadPage("/repo/edit/" + OE.getObjectId());
            } else if (result == "no_versions_before") {
                noty({ text: 'Nothing to UNDO', type: "warning" });
            } else {
                swal({
                    title: "Unexpected undo error",
                    type: "error",
                    allowOutsideClick: true
                });
            }
        });
    },

    redo: function () {        
        $.get("/repo/redo/" + OE.getObjectId(), function (result) {            
            if (result == "success") {
                ASYNC_NAV.loadPage("/repo/edit/" + OE.getObjectId());
            } else if (result == "no_versions_after") {
                noty({ text: 'Nothing to REDO', type: "warning"});
            } else {
                swal({
                    title: "Unexpected redo error",
                    type: "error",
                    allowOutsideClick: true
                });
            }
        });
    },

    getObjectProperties: function () {
        var properties = {};
        $.each($(".edit_prop"), function (i, el) {
            var type = $(el).attr("prop_type");
            var name = $(el).attr("prop_name");
            if (name != "") {
                var property = window[type]["serialize"](el);
                properties[name] = property;
            }            
        });
        return properties;
    }

};

$(document).ready(function () {
    //swal({ title: "Error!", text: "Here's my error message!", type: "error", confirmButtonText: "Cool" });
    //swal({ title: "Are you sure?", text: "You will not be able to recover this imaginary file!", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55", confirmButtonText: "Yes, delete it!", cancelButtonText: "No, cancel plx!", closeOnConfirm: false, closeOnCancel: false }, function (isConfirm) { if (isConfirm) { swal("Deleted!", "Your imaginary file has been deleted.", "success"); } else { swal("Cancelled", "Your imaginary file is safe :)", "error"); } });
    
    OE.initEvents();
    OE.updateState(OE.OESTATE.SAVED);

    OE.initPropertyNameFor($(".edit_prop_name select"));

    
    $('.edit_prop_type select').select2({
        minimumResultsForSearch: 0,
        width: 'element'
    });

});










    

    

    

    