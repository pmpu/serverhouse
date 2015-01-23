var ASYNC_NAV = {
    onLinkClickHandler: function (e) {
        if (history.pushState && !$(this).hasClass("noasync")) {
            e.preventDefault();
            $(this).blur();
            var url = $(this).attr("href");

            ASYNC_NAV.loadPage(url, function () {
                // push to history api
                history.pushState(null, null, url);
            });
        }
    },

    loadPage: function (url, callback) {
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
            $('a').unbind("click", ASYNC_NAV.onLinkClickHandler);
            $('a').click(ASYNC_NAV.onLinkClickHandler);

            if (callback) {
                callback();
            }
        });
    },

    load: function (url, callback) {
        $.get(url, function (json) {
            var data = JSON.parse(json);
            if (callback) {
                callback(data);
            }
        });
    }

};


$(document).ready(function () {    
    $('a').click(ASYNC_NAV.onLinkClickHandler);
});

$(window).bind('popstate', function (event) {
    ASYNC_NAV.loadPage(location.pathname);
});



