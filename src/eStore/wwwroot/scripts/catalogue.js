$(function () {
    // display message if modal still loaded in
    if ($("#detailsId").val() != "") {
        var Id = $("#detailsId").val();
        CopyToModal(Id);
        $('#details_popup').modal('show');
    }

    // Displays the register popup modal
    if ($("#register_popup") != undefined) {
        $('#register_popup').modal('show');
    }

    // Displays the login popup modal
    if ($("#login_popup") != undefined) {
        $('#login_popup').modal('show');
    }

    // details anchor click - to load popup on catalogue
    $("a.btn-default").on("click", function (e) {
        var Id = $(this).attr("data-id");
        $("#results").text("");
        CopyToModal(Id);
    });
});

function CopyToModal(id) {
    $("#qty").val("0");
    $("#name").text($("#name-" + id).val());
    $("#msrp").text("$" + (Math.round($("#msrp-" + id).val() * 100) / 100));
    $("#descr").text($("#descr-" + id).val());
    $("#detailsGraphic").attr("src", "/img/products/" + $("#img-" + id).val());
    $("#detailsId").val(id);
}