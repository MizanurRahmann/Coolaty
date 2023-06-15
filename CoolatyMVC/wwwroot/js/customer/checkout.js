$(document).ready(function () {
    // Change Shipping
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

    // Apply Coupon
    $('#checkCouponValidtyBtn').click(function () {
        let enteredCoupon = $('#couponTxt').val();
        $('#coupon-message-box').css('display', 'flex');
    });

    $('#coupon-message-box .close').click(function () {
        $('#coupon-message-box').css('display', 'none');
    })
});