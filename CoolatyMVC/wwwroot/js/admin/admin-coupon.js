$(function () {
    // drop down
    var d0 = new dropDown($('#selectDropdown0'));
    var d1 = new dropDown($('#selectDropdown1'));
    var d2 = new dropDown($('#selectDropdown2'));
    $(document).click(function () {
        $('.select-dropdown').removeClass('active');
    });

    // validations
    $("#cuoponName").blur(function () { validationForString("cuoponName", "error-name", "Name"); });
    $("#couponCode").blur(function () { validationForString("couponCode", "error-category", "Code"); });
    $("#couponType").blur(function () { validationForString("couponType", "error-description", "Type"); });
    $("#couponDiscountAmount").blur(function () { validationForRequiredNumber("couponDiscountAmount", "error-price", "Discount amount"); });
    $("#cuoponExpireDate").blur(function () { validationForDate("cuoponExpireDate", "error-fat", "Expiration date"); });
    $("#cuoponMinimumItem").blur(function () { validationForNumber("cuoponMinimumItem", "error-fat", "Minimum item"); });
    $("#cuoponMinimumCost").blur(function () { validationForNumber("cuoponMinimumCost", "error-fat", "Minimum cost"); });
    $("#couponForNewUser").blur(function () { validationForNumber("couponForNewUser", "error-fat", "Coupon For New User"); });

    // delete Modal Controller
    $("#coupon-delete-btn").click(showDeleteModal);
    $("#coupon-delete-close-btn").click(closeDeleteModal);
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
            obj.input.val(parseInt(opt.attr('id')));

            if (obj.val == 'Percentage') {
                $('.symbol').html('%');
            } else if (obj.val == 'Fixed') {
                $('.symbol').html('৳');
            }

            if (obj.element.attr("id") == 'selectDropdown0') {
                $('#outer-circle').attr('class', '');
                $('#outer-circle').addClass(obj.val);
                obj.input.val(opt.attr('id'));
            } else if (obj.element.attr("id") == 'selectDropdown1') {
                obj.input.val(opt.attr('id'));
            }
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

const validationForNumber = (fieldId, errorId, name) => {
    let value = $(`#${fieldId}`).val();
    value = value.trim();

    if (isNaN(Number(value))) {
        $(`#${errorId}`).html(`${name} must be a number.`);
    } else if (Number(value) <= 0) {
        $(`#${errorId}`).html(`${name} must be greater than 0.`);
    } else {
        $(`#${errorId}`).html("");
    }
}

const validationForRequiredNumber = (fieldId, errorId, name) => {
    let value = $(`#${fieldId}`).val();
    value = value.trim();

    if (!value) {
        $(`#${errorId}`).html(`${name} is required.`);
    } else {
        validationForNumber(fieldId, errorId, name);
    }
}

const validationForDate = (fieldId, errorId, name) => {
    let value = $(`#${fieldId}`).val();
    value = value.trim();

    if (!value) {
        $(`#${errorId}`).html(`${name} is required.`);
    }
}

// DELETE MODAL CONTROLLER FUNCTIONS
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