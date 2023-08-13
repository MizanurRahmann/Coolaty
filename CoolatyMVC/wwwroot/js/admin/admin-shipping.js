$(function () {
    $("#serviceFeature").on('keyup', function () {
        if ($("#serviceFeature").val().trim() === "") {
            $("#submitBtn").prop('disabled', true);
        } else {
            $("#submitBtn").prop('disabled', false);
        }
    })

    $('.input-switch').on('change', function () {
        if (this.checked) {
            console.log("checked");
        }
        else {
            console.log("un checked");
        };
    });
});

const showServiceCreateModal = (feature, id) => {
    $(".createService-modal-container").css("display", "flex");
    $(".createService-modal").css("animation-name", "scaleToNormal");
    $(".createService-modal").css("animation-duration", "0.5s");

    $("#serviceFeature").val(feature);
    $("#serviceId").val(id);

    if (id != 0) {
        $("#submitBtn").html("Update Service");
    } else {
        $("#submitBtn").html("Add New Service");
    }
    
    if ($("#serviceFeature").val().trim() === "") {
        $("#submitBtn").prop('disabled', true);
    } else {
        $("#submitBtn").prop('disabled', false);
    }
}

const closeServiceCreateModal = () => {
    $("#serviceFeature").val("");
    $("#serviceId").val(0);

    $(".createService-modal").css("animation-name", "scaleToZero");
    $(".createService-modal").css("animation-duration", "0.3s");
    setTimeout(() => { $(".createService-modal-container").css("display", "none"); }, 310);
}

const showServiceDeleteModal = (id) => {
    $(".delete-modal-container").css("display", "flex");
    $(".delete-modal").css("animation-name", "scaleToNormal");
    $(".delete-modal").css("animation-duration", "0.5s");
    $("#deleteServiceId").val(id);
}

const closeServiceDeleteModal = () => {
    $("#delete").val(0);
    $(".delete-modal").css("animation-name", "scaleToZero");
    $(".delete-modal").css("animation-duration", "0.3s");
    setTimeout(() => { $(".delete-modal-container").css("display", "none"); }, 310);
}