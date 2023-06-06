$(function () {
    // drop down
    var d1 = new dropDown($('#selectDropdown'));
    $(document).click(function () {
        $('.select-dropdown').removeClass('active');
    });

    // Preview Controller
    $("#image-preview-button").click(showPreview);
    $("#image-preview-close").click(hidePreview);

    // validations
    $("#productName").blur(function () { validationForString("productName", "error-name", "Name"); });
    $("#productCategory").blur(function () { validationForString("productCategory", "error-category", "Category"); });
    $("#productDescription").blur(function () { validationForString("productDescription", "error-description", "Description"); });
    $("#productCompund").blur(function () { validationForString("productCompund", "error-compound", "Compound"); });
    $("#productPrice").blur(function () { validationForRealNumber("productPrice", "error-price", "Price"); });
    $("#productFat").blur(function () { validationForRealNumber("productFat", "error-fat", "Fats"); });
    $("#productProtien").blur(function () { validationForRealNumber("productProtien", "error-protein", "Proteins"); });
    $("#productCarbohydrates").blur(function () { validationForRealNumber("productCarbohydrates", "error-carbohydrates", "Carbohydrates"); });
    $("#productCalories").blur(function () { validationForRealNumber("productCalories", "error-calories", "Calories"); });
    $("#productImage").change(function () { previewController(this); });

    // Delete Modal Controller
    $("#product-delete-btn").click(showDeleteModal);
    $("#product-delete-close-btn").click(closeDeleteModal);
});

// DROPDOWN CONTROLLER
function dropDown(el) {
    this.element = el;
    this.placeholder = this.element.children('span');
    this.input = this.element.children('input');
    this.opts = this.element.find('ul.dropdown > li');
    this.val = '';
    this.index = -1;
    this.initEvents();
}

dropDown.prototype = {
    initEvents: function () {
        var obj = this;

        obj.element.on('click', function () {
            $(this).toggleClass('active');
            return false;
        });

        obj.opts.on('click', function () {
            var opt = $(this);
            obj.val = opt.text();
            obj.index = opt.index();
            obj.placeholder.text(obj.val);
            obj.input.val( parseInt(opt.attr('id')) );
        });
    }
}

// VALIDATION FUNCTIONS
const validationForString = (fieldId, errorId, name) => {
    let value = $(`#${fieldId}`).val();
    value = value.trim();

    if (!value) {
        $(`#${errorId}`).html(`${name} is required.`);
    } else {
        $(`#${errorId}`).html("");
    }
}

const validationForRealNumber = (fieldId, errorId, name) => {
    let value = $(`#${fieldId}`).val();
    value = value.trim();

    if (!value) {
        $(`#${errorId}`).html(`${name} is required.`);
    } else if (isNaN(Number(value))) {
        $(`#${errorId}`).html(`${name} must be a number.`);
    } else if (Number(value) <= 0) {
        $(`#${errorId}`).html(`${name} must be greater than 0.`);
    } else {
        $(`#${errorId}`).html("");
    }
}

const validationForFile = () => {
    let value = $("#productImage").val();
    value = value.trim();

    if (!value) {
        $("#error-category").html("Product category is required.");
    } else {
        $("#error-category").html("");
    }
}

// IMAGE PREVIEW
const previewController = (input) => {
    if (input.files && input.files[0]) {
        if (Number(input.files[0].size) / 1024 < 500) {
            $("#error-image").html("");

            var reader = new FileReader();
            reader.onload = function (e) {
                $("#label-title").html("Select another image.");
                $(".image i").remove();
                $(".image img").remove();
                $(".image").append(`<img src="${e.target.result}" style="width: 60%" />`);
                $("#image-preview .container").append(`<img src="${e.target.result}" style="width: 90%" />`);
            }
            reader.readAsDataURL(input.files[0]);
        }
        else {
            $("#productImage").val(null);
            $("#error-image").html("Image size is too large, please select an image less than 500kb.");
        }
    }
    else {
        $("#error-image").html("Product image is required.");
    }
}

const showPreview = () => {
    if ($("#productImage").val() || $("#productImageUrl").val()) {
        $("#image-preview").css("display", "flex");
        $("#image-preview .container").css("animation-name", "scaleToNormal");
        $("#image-preview .container").css("animation-duration", "0.5s");
    }
}

const hidePreview = () => {
    $("#image-preview .container").css("animation-name", "scaleToZero");
    $("#image-preview .container").css("animation-duration", "0.3s");
    setTimeout(() => { $("#image-preview").css("display", "none"); }, 310);
}

const showDeleteModal = () => {
    $(".delete-modal-container").css("display", "flex");
    $(".delete-modal").css("animation-name", "scaleToNormal");
    $(".delete-modal").css("animation-duration", "0.5s");
}

const closeDeleteModal = () => {
    $(".delete-modal").css("animation-name", "scaleToZero");
    $(".delete-modal").css("animation-duration", "0.3s");
    setTimeout(() => { $(".delete-modal-container").css("display", "none"); }, 310);
}