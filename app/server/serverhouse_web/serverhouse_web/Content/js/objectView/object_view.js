var OV = {

    init: function () {
        OV.initEvents();

        // init galleries
        $(".v_valuerep_gallery_slider").unslider({
                            speed: 500,               //  The speed to animate each slide (in milliseconds)
                            delay: 100000000,              //  The delay between slide animations (in milliseconds)
                            complete: function () { },  //  A function that gets called after every slide animation
                            keys: true,               //  Enable keyboard (left, right) arrow shortcuts
                            dots: true,               //  Display dot navigation
                            fluid: false              //  Support responsive design. May break non-responsive designs
        });

        $(".v_valuerep_gallery_slider_controls_prev").click(function () {
            var slider = $(this).closest(".v_valuerep v_valuerep_gallery")
                .find(".v_valuerep_gallery_slider");
            console.log(slider.__proto__.unslider.prev());
            slider.prev();
        });

        $(".v_valuerep_gallery_slider_controls_next").click(function () {
            var slider = $(this).closest(".v_valuerep v_valuerep_gallery")
                .find(".v_valuerep_gallery_slider").data("unslider");
            slider.next();
        });
    },

    initEvents: function () {
        $(".delete").unbind();
        $(".delete").click(function (e) {
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
            }, function () {
                //swal("Deleted!", "Your imaginary file has been deleted.", "success");
                window.location = $(e.target).attr("href");
            });
        });
    }

};

$(document).ready(function () {
    OV.init();
});