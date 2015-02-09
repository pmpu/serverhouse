var OE = {

    getObjectId: function () {
        return $("#object_edit_container").attr("object_id");
    },

    initPropertyNameFor: function ($el) {

        var matchesSource = function () {
            return function findMatches(q, cb) {

                $.ajax({
                    url: "/repo/getAllPossibleNames?q="+q,
                    dataType: "json"
                }).done(function (data) {
                    console.log(data);
                    cb($.map(data, function(item) { return { name: item }; }));
                });

            };
        };

        $el.typeahead({
            hint: true,
            highlight: true,
            minLength:1
        },
        {            
            displayKey: 'name',
            source: matchesSource()
        });

        $el.on('keypress', function (e) {
            var p = e.which;
            if (p == 13) {
                $el.typeahead("close");
                OE.onPropNameChange($(e.target).closest(".edit_prop"));
                $el.blur();
            }
        });

        $el.on("input propertychange, typeahead:selected", function (e) {
            OE.onPropNameChange($(e.target).closest(".edit_prop"));
        });
      
    },    

    onPropNameChange: function (prop) {
        var $input = $(prop).find(".edit_prop_name .tt-input");
        var old_name = $(prop).attr("prop_name");
        var new_name = $input.typeahead("val").toLowerCase();

        
        if (old_name != new_name) {
            if (OE.objectHasKey(new_name)) {
                setTimeout(function () {
                    swal({
                        title: "Duplicate key!",
                        text: "You already have property with key '" + new_name + "'",
                        type: "warning",
                        allowOutsideClick: true
                    });
                }, 100);
                $input.typeahead('val', old_name);
            } else {
                if (new_name == "") {
                    $(prop).addClass("not_saving");
                } else {
                    $(prop).removeClass("not_saving");
                }
                
                $(prop).attr("prop_name", new_name);
                //$input.typeahead('val', new_name);
                OE.onChange();                
            }
        } else {
            //$input.typeahead('val', new_name);
        }
        
        
    },

    initPropertyTypeFor: function ($el) {
        $el.select2({
            width: 'element'
        }).on("change", function (e) {
            var $select = $(this);
            var $prop = $select.closest(".edit_prop");
            OE.onPropTypeChange($prop);
        });
    },

    onPropTypeChange: function ($prop) {
        var $select = $prop.find(".edit_prop_type select");
        var old_type = $prop.attr("prop_type");
        var new_type = $select.val();

        OE.loadValueRep($prop, new_type, function () {
            $prop.attr("prop_type", new_type);
            window[new_type]["onObjectChange"] = OE.onChange;
            window[new_type]["init"]($prop);
            window[new_type]["onResize"]($prop);
            OE.onChange();
        });
    },

    loadValueRep: function ($prop, type, callback) {
        ASYNC_NAV.loadHtml("/AsyncPartial/edit/value_representation?type=" + type,
            function (data) {
                $prop.find(".e_valuerep").html(data);
                if (callback)
                    callback();
            });
    },

    gridster: null,

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


        // init gridster
        OE.gridster = $("ul.gridster").gridster({
            widget_margins: [10, 10],
            widget_base_dimensions: [25, 25],
            max_cols: 20,
            draggable: {
                stop: OE.onChange
            },
            resize: {
                enabled: true,                
                resize: function (e, ui, el) {
                    var type = $(el).attr("prop_type");
                    window[type]["onResize"](el);
                },
                stop: function (e, ui, el) {
                    var type = $(el).attr("prop_type");
                    window[type]["onResize"](el);
                    OE.onChange();
                }
            }

        }).data("gridster");

        // init events for properties
        $.each($(".edit_prop"), function (i, el) {
            var type = $(el).attr("prop_type");
            window[type]["onObjectChange"] = OE.onChange;
            window[type]["init"](el);            
            window[type]["onResize"](el);
        });

        // update object name
        OE.updateObjectName();
    },

    

    onChange: function () {
        // update object name
        OE.updateObjectName();

        if (OE.onChange.saveTimeout != null) {
            clearTimeout(OE.onChange.saveTimeout);
            OE.onChange.saveTimeout = null;
        }
        OE.onChange.saveTimeout = setTimeout(OE.saveObject, 400);
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
        ASYNC_NAV.loadHtml(
            "/AsyncPartial/edit/new_property",
            function (data) {
                $prop = OE.gridster.add_widget(data, 14, 4, 1, 1);
                $prop.addClass("not_saving");                
                OE.initPropertyNameFor($prop.find(".edit_prop_name input"));
                OE.initPropertyTypeFor($prop.find(".edit_prop_type select"));
                OE.initEvents();
            });
    },

    removeProperty: function ($prop) {
        OE.gridster.remove_widget($prop);               
        this.onChange();
    },

    objectHasKey: function (key) {
        return $(".edit_prop[prop_name='" + key + "']").length > 0;
    },

    saveObject: function () {                
        OE.updateState(OE.OESTATE.SAVING);
        var serializedProperties = JSON.stringify(OE.getObjectProperties());
        $.post("/repo/edit/" + OE.getObjectId(), { properties: serializedProperties }, function (data) {

            if (data == "success") {                
                OE.updateState(OE.OESTATE.SAVED);
                OE.updateObjectName();
            } else {
                swal({ title: "Error saving!", type: "error" });
                OE.updateState(OE.OESTATE.ERROR);
            }
        });
    },

    updateObjectName: function () {
        var properties = OE.getObjectProperties();
        var name = "#"+OE.getObjectId();
        if (properties["name"]) {
            if (properties["name"].text != "") {
                name = properties["name"].toString
            }            
        }

        $(".edit_title").html("Edit "+name);
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
                // add order position
                property.order_data = { 
                    row: parseInt($(el).attr("data-row")),
                    sizex: parseInt($(el).attr("data-sizex")),
                    sizey: parseInt($(el).attr("data-sizey"))
                };

                properties[name] = property;                
            }            
        });
        console.log(properties);
        return properties;
    }

};

$(document).ready(function () {
    //swal({ title: "Error!", text: "Here's my error message!", type: "error", confirmButtonText: "Cool" });
    //swal({ title: "Are you sure?", text: "You will not be able to recover this imaginary file!", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55", confirmButtonText: "Yes, delete it!", cancelButtonText: "No, cancel plx!", closeOnConfirm: false, closeOnCancel: false }, function (isConfirm) { if (isConfirm) { swal("Deleted!", "Your imaginary file has been deleted.", "success"); } else { swal("Cancelled", "Your imaginary file is safe :)", "error"); } });
    
        OE.initEvents();
        OE.updateState(OE.OESTATE.SAVED);

        OE.initPropertyNameFor($(".edit_prop_name input"));

        OE.initPropertyTypeFor($('.edit_prop_type select'));    

});










    

    

    

    