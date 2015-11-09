var OV = {
    init: function() {
        OV.initEvents();

        // init galleries
        $(".v_valuerep_gallery").each(function(i, el) {
            var $el = $(el);
            $($el.find(".v_valuerep_gallery_image img").get(0)).show();
            if ($el.find(".v_valuerep_gallery_image img").length < 2) {
                $el.find(".v_valuerep_gallery_thumbs").hide();
            }
        });


        $(".v_valuerep_gallery_thumb").click(function(e) {
            var index = $(e.target).parent().index();
            //alert(index)
            $gallery = $(e.target).closest(".v_valuerep_gallery");
            $gallery.find(".v_valuerep_gallery_image img").hide();
            $($gallery.find(".v_valuerep_gallery_image img").get(index)).show();

        });
    },

    initEvents: function() {
        $(".delete").unbind();
        $(".delete").click(function(e) {
            e.preventDefault();
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this object!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false,
                allowOutsideClick: true
            }, function() {
                //swal("Deleted!", "Your imaginary file has been deleted.", "success");
                window.location = $(e.target).attr("href");
            });
        });
    }

};

$(document).ready(function() {
    OV.init();
});