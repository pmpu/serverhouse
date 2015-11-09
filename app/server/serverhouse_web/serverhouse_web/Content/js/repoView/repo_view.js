

var RV = {
    init: function() {
        RV.initEvents();
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
    RV.init();
});