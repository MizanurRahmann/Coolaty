$(function () {
    $("#categoryImage").change(function () { showPreview(this); });
    $("#preview-cancel-layer").click(function () { closePreview(this) });
});

// Input Image Preview Controller Functions
const showPreview = (input) => {
    if (input.files && input.files[0]) {
        if (Number(input.files[0].size) / 1024 < 500) {
            $(".image-group-container").removeClass('d-none');
            $(".image-group-container-preview").removeClass('d-none');
            $(".image-group-container").hide();
            $(".image-group-container-preview").show();
            $("#error-image").html("");

            var reader = new FileReader();
            reader.onload = function (e) {
                $(".image-group-container-preview").css(`background`, `url(${e.target.result}) no-repeat center center / cover`);
            }
            reader.readAsDataURL(input.files[0]);
        }
        else {
            $("#TourModel0").val(null);
            $("#error-image").html("This image size is too large, please select an image less than 500kb.");
        }
    }
    else {
        $("#error-image").html("Tour image is required.");
    }
}

const closePreview = (input) => {
    $(".image-group-container").removeClass('d-none');
    $(".image-group-container-preview").removeClass('d-none');
    $(".image-group-container").show();
    $(".image-group-container-preview").hide();
    $("#TourModel0").val(null);
}