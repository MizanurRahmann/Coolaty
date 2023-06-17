$(document).ready(function () {
    var searchTimer;

    $("#category-search").on('input', function () {
        clearTimeout(searchTimer);

        var searchValue = $(this).val();

        searchTimer = setTimeout(function () {
            window.location.href = '/Admin/Categories?search=' + searchValue;
        }, 1200);
    });
})