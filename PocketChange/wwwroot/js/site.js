document.addEventListener('DOMContentLoaded', function() {

    // Get all "navbar-burger" elements
    var $navbarBurgers = Array.from(document.querySelectorAll('.navbar-burger'));

    // Check if there are any navbar burgers
    if ($navbarBurgers.length > 0) {

    // Add a click event on each of them
    $navbarBurgers.forEach( function(el) {
        el.addEventListener('click', function() {

            // Get the target from the "data-target" attribute
            var target = el.dataset.target;
            var $target = document.getElementById(target);

            // Toggle the "is-active" class on both the "navbar-burger" and the "navbar-menu"
            el.classList.toggle('is-active');
            $target.classList.toggle('is-active');

        });
    });
    
    if (typeof DataTable === "function") {
        document.querySelectorAll('[data-table]').forEach(function(el) {
            var dataTable = new DataTable(el);
        });
    }
    
    document.querySelectorAll('[data-open="modal"]').forEach(openModal);
    document.querySelectorAll('[data-close="modal"]').forEach(closeModal);
    
    function openModal(el) {
        var target = document.querySelector(el.dataset.target);
        el.addEventListener('click', function() {
            target.classList.add('is-active');
        });
    }
    function closeModal(el) {
        var target = document.querySelector(el.dataset.target);
        el.addEventListener('click', function() {
            target.classList.remove('is-active');
        });
    }
}

});