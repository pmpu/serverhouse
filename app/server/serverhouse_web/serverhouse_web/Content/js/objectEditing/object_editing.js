$(document).ready(function () {
    //swal({ title: "Error!", text: "Here's my error message!", type: "error", confirmButtonText: "Cool" });
    //swal({ title: "Are you sure?", text: "You will not be able to recover this imaginary file!", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55", confirmButtonText: "Yes, delete it!", cancelButtonText: "No, cancel plx!", closeOnConfirm: false, closeOnCancel: false }, function (isConfirm) { if (isConfirm) { swal("Deleted!", "Your imaginary file has been deleted.", "success"); } else { swal("Cancelled", "Your imaginary file is safe :)", "error"); } });
    $(".edit_prop_name").select2({
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
        tags: true
    }).on("change", function (e) {
        var $select = $(this);
        var old_name = $(this).parent().attr("prop_name");
        var new_name = $(this).val();

        if (old_name != new_name) {
            if ($(".edit_prop[prop_name='" + new_name + "']").length) {
                swal({ title: "Duplicate key!", text: "You already have property with key '" + new_name+"'", type: "warning", confirmButtonText: "Ok" });
                //setTimeout(function () {
                    $select.val(old_name).trigger("change");
                //}, 100);

            } else {
                $(this).val($(this).parent().attr("prop_name"));
                $(this).parent().attr("prop_name", new_name);
            }
        }
        
        

        return true;
    });
    $('.edit_prop_type').select2();

});

$(".object_edit_save").click(function () {
    saveObject();
});

function saveObject() {
    var serializedProperties = JSON.stringify(getObjectProperties());
    $.post("/repo/edit/" + getObjectId(), { properties: serializedProperties }, function (data) {
        
        if (data == "success") {
            swal({ title: "Saved!", type: "success",timer: 1000 });
        } else {

        }
    });
}

function getObjectId(){
    return $("#object_edit_container").attr("object_id");
}

function getObjectProperties() {
    var properties = {};
    $.each($(".edit_prop"), function (i, el) {
        var type = $(el).attr("prop_type");
        var name = $(el).attr("prop_name");
        var property = window[type]["serialize"](el);
        properties[name] = property;
    });
    return properties;
}