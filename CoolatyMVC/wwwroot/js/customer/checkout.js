$(document).ready(function () {
    $("input[name=radio-group]").on("change", function () {
        const shippingCost = $("input[name=radio-group]:checked").val();
        console.log(shippingCost);
        $('#selected-shipping-cost').html(shippingCost);
    });
});