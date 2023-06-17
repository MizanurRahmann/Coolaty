$(document).ready(function () {
    var searchTimer;

    $("#product-search").on('input', function () {
        clearTimeout(searchTimer);

        var searchValue = $(this).val();

        searchTimer = setTimeout(function () {
            window.location.href = '/Admin/Products?search=' + searchValue;
        }, 1200);
    });
})