$(document).ready(function () {
    $("#selectedItem").change(function () {
        if ($("#selectedItem").val() !== "") {
            let val = parseInt($("#selectedItem").val());

            if (val > 100) {
                val = 99;
            } else if (val < 1) {
                val = 1
            }

            let price = parseInt($("#disable-productPrice").html()) * val;
            $("#selectedItem").val(val.toString().padStart(2, 0));
            $("#productPrice").html(price);
        }
    })

    $('#decreament').click(function() {
        let val = parseInt($("#selectedItem").val()) - 1;

        if (val > 0) {
            $("#selectedItem").val(val.toString().padStart(2, 0));
        } else {
            val = 1;
        }

        let price = parseInt($("#disable-productPrice").html()) * val;
        $("#productPrice").html(price);
    });

    $('#increament').click(function() {
        let val = parseInt($("#selectedItem").val()) + 1;

        if (val < 100) {
            $("#selectedItem").val(val.toString().padStart(2, 0));
        } else {
            val = 99;
        }

        let price = parseInt($("#disable-productPrice").html()) * val;
        $("#productPrice").html(price);
    })
});
