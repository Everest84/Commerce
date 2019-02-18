document.addEventListener("DOMContentLoaded", _init_);

function _init_() {
    initializeNavbars();
    initializeNotifications();
    initializeMenus();

    function initializeNavbars() {
        // Get all "navbar-burger" elements
        var $navbarBurgers = Array.from(document.querySelectorAll(".navbar-burger"));

        // Check if there are any navbar burgers
        if ($navbarBurgers.length > 0) {

            // Add a click event on each of them
            $navbarBurgers.forEach(function(el) {
                el.addEventListener("click", function () {

                    // Get the target from the "data-target" attribute
                    var target = el.dataset.target;
                    var $target = document.getElementById(target);

                    // Toggle the "is-active" class on both the "navbar-burger" and the "navbar-menu"
                    el.classList.toggle("is-active");
                    $target.classList.toggle("is-active");

                });
            });
        }
    }

    function initializeNotifications() {
        // Get all "notification" elements
        var $notifications = Array.from(document.querySelectorAll(".notification"));

        // Check if there are any notifications
        if ($notifications.length > 0) {

            // Iterate through each notification
            $notifications.forEach(function (el) {

                // Get the "delete" element
                var $delete = el.querySelectorAll(".delete");

                // Check if there is a delete element
                if ($delete.length === 1) {

                    // Add a click event to it
                    $delete[0].addEventListener("click", function () {
                        el.remove();
                    });
                }
            });
        }
    }

    function initializeMenus() {
        // Get all "menu" elements
        var $menus = Array.from(document.querySelectorAll(".menu"));

        // Check if there are any menus
        if ($menus.length > 0) {

            // Iterate through each menu
            $menus.forEach(function(el) {

                // Get all attributed "data-content" elements
                var $contentLinks = el.querySelectorAll("[data-content]");

                // Check if there are any content links
                if ($contentLinks.length > 0) {

                    // Iterate through each content link
                    $contentLinks.forEach(function (el2) {

                        // Get the "data-content" value (which is the content element's ID)
                        var $contentId = el2.dataset.content;

                        // Retrieve the corresponding content element
                        var $content = document.getElementById($contentId);

                        // Add a click event to each one of them
                        el2.addEventListener("click", function () {
                            reset($contentLinks);

                            el2.classList.add("is-active");
                            $content.classList.remove("is-hidden");
                        });
                    });
                }
            });
        }

        function reset(links) {
            links.forEach(function (el) {
                // Remove "is-active" class
                el.classList.remove("is-active");

                // Get the "data-content" value (which is the content element's ID)
                var contentId = el.dataset.content;

                // Retrieve the corresponding content element
                var content = document.getElementById(contentId);

                // Hide the content element
                content.classList.add("is-hidden");
            });
        }
    }
}