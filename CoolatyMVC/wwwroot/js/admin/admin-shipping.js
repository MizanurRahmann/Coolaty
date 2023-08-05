$(function () {
    // Modal Controller
    $("#service-create-btn-open").click(showServiceCreateModal);
    $("#service-create-btn-close").click(closeServiceCreateModal);
});

const showServiceCreateModal = () => {
    $(".createService-modal-container").css("display", "flex");
    $(".createService-modal").css("animation-name", "scaleToNormal");
    $(".createService-modal").css("animation-duration", "0.5s");
}

const closeServiceCreateModal = () => {
    $(".createService-modal").css("animation-name", "scaleToZero");
    $(".createService-modal").css("animation-duration", "0.3s");
    setTimeout(() => { $(".createService-modal-container").css("display", "none"); }, 310);
}