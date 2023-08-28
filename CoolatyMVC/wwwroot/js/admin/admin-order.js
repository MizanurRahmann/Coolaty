$(document).ready(function () {
    var searchTimer;

    $("#order-search").on('input', function () {
        clearTimeout(searchTimer);

        var searchValue = $(this).val();

        searchTimer = setTimeout(function () {
            if (!isNaN(searchValue)) {
                const url = new URL(window.location.href);

                if (url.searchParams.has('type')) {
                    console.log("here");
                    window.location.href = `/Admin/Orders?type=${url.searchParams.get('type')}&search=${searchValue}`;
                } else {
                    window.location.href = '/Admin/Orders?search=' + searchValue;
                }
            }
        }, 1200);
    });
});