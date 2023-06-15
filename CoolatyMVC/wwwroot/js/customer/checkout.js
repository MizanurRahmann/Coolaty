$(document).ready(function () {
    // change shipping
    $("input[name=radio-group]").on("change", function () {
        let shippingCost = $("input[name=radio-group]:checked").val();
        $('#selected-shipping-cost').html(shippingCost);

        shippingCost = parseInt(shippingCost.slice(2))
        const totalCost = parseInt($('#totalCost').val());
        const discountCost = parseInt($('#discountCost').val());
        const payabletotal = totalCost + shippingCost - discountCost;

        $('#shippingPriceField').val(shippingCost);
        $('#totalCost').val(totalCost);
        $('#discountCost').val(discountCost);
        $('#payable-amnt-txt').html(`৳ ${payabletotal}`);

    });

    // apply coupons
    $('#checkCouponValidtyBtn').click(function () {
        let enteredCoupon = $('#couponTxt').val();
        $('#coupon-message-box').css('display', 'flex');
    });

    $('#coupon-message-box .close').click(function () {
        $('#coupon-message-box').css('display', 'none');
    });

    // validations
    $("#c-name").blur(function () { validationForString("c-name", "input-validation-error"); });
    $("#c-email").blur(function () { validationForString("c-email", "input-validation-error"); });
    $("#c-phone").blur(function () { validationForString("c-phone", "input-validation-error"); });
    $("#c-address").blur(function () { validationForString("c-address", "input-validation-error"); });
    $("#c-thana").blur(function () { validationForString("c-thana", "input-validation-error"); });
    $("#c-district").blur(function () { validationForString("c-district", "input-validation-error"); });
    $("#c-post").blur(function () { validationForString("c-post", "input-validation-error"); });

});

// VALIDATION FUNCTIONS
const validationForString = (fieldId, errorClass) => {
    let value = $(`#${fieldId}`).val();
    value = value.trim();

    if (!value) {
        $(`#${fieldId}`).addClass(errorClass);
    } else {
        $(`#${fieldId}`).removeClass(errorClass);
    }
}