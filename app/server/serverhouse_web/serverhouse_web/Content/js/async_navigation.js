$(document).ready(function () {
    
    $('a').click(onLinkClick);

});

$(window).bind('popstate', function (event) {
    loadPage(location.pathname);
});




var onLinkClick = function (e) {
    if (history.pushState && !$(this).hasClass("noasync")) {
        e.preventDefault();
        $(this).blur();
        var url = $(this).attr("href");

        loadPage(url, function () {
            // push to history api
            history.pushState(null, null, url);
        });
    }
};

function loadPage(url, callback) {
    var async_url = url;
    if (url.indexOf("?") != -1) {
        async_url += "&async=1";
    } else {
        async_url += "?async=1";
    }

    $.get(async_url, function (data) {
        var page = JSON.parse(data);

        // update title
        $('title').html(page.title);

        // update main content
        var newMain = $('<div class="main">').html(page.html);
        newMain.animate({ opacity: 0 }, 0);
        $(".main").animate({ opacity: 0 }, 100, "swing", function () {
            $(".main")[0].remove();
            newMain.animate({ opacity: 1 }, 100);
        });
        $('.wrapper').append(newMain);

        // update menu
        $('.leftbar').html(page.leftbar);

        // update events
        $('a').unbind("click", onLinkClick);
        $('a').click(onLinkClick);

        if (callback) {
            callback();
        }


    });
}
