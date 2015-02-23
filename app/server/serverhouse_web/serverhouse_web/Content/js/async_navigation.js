var ASYNC_NAV = {

    initLinks: function () {
        $('a').unbind("click", ASYNC_NAV.onLinkClickHandler);
        $('a:not([href^=http],[href^=mailto])').click(ASYNC_NAV.onLinkClickHandler);
    },

    onLinkClickHandler: function (e) {
        if (history.pushState && !$(this).hasClass("noasync")) {
            e.preventDefault();
            $(this).blur();
            var url = $(this).attr("href");
            ASYNC_NAV.goTo(url);
        }
    },

    goTo: function (url) {
        ASYNC_NAV.loadPage(url, function () {
            // push to history api
            history.pushState(null, null, url);
        });
    },

    loadPage: function (url, callback) {
        var async_url = url;
        if (url.indexOf("?") != -1) {
            async_url += "&async=1";
        } else {
            async_url += "?async=1";
        }

        // add overlay
        UI_HELPERS.addOverlay($(".wrapper"));

        $.get(async_url, function (data) {
            var page = JSON.parse(data);

            // update title
            $('title').html(page.title);

            // update main content
            var newMain = $('<div class="main">').html(page.html);
            newMain.animate({ opacity: 0 }, 0);
            $(".main").animate({ opacity: 0 }, 0, "swing", function () {
                $(".main")[0].remove();
                newMain.animate({ opacity: 1 }, 0);
            });
            $('.wrapper').append(newMain);

            // update menu
            $('.leftbar').html(page.leftbar);

            // update events
            ASYNC_NAV.initLinks();
            

            if (callback) {
                callback();
            }

            // remove overlay
            UI_HELPERS.removeOverlay($(".wrapper"));
        });
    },

    load: function (url, callback) {
        $.get(url, function (json) {
            var data = JSON.parse(json);
            if (callback) {
                callback(data);
            }
        });
    },

    loadHtml: function (url, callback) {
        $.get(url, function (html) {            
            if (callback) {
                callback(html);
            }
        });
    }

};


$(document).ready(function () {    
    ASYNC_NAV.initLinks();
});

$(window).bind('popstate', function (event) {
    console.log("load back " + location.href);
    ASYNC_NAV.loadPage(location.href);
});



