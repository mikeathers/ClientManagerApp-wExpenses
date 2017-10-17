
function LoadCustomerInfoPartial(button) {
    var btnId = button.attr("data-btn-id");

    $.ajax({
        method: "GET",
        url: "/Customers/LoadCustomerInfoPartial/",
        data: {
            custId: $("#Id").val(),
            btnId: btnId
        }
    }).done(function (result) {
        $("#customer-partial").empty();
        $("#customer-partial").html(result);
    });
}

$(document).ready(function () {

    LoadCustomerInfoPartial($("#cust-info-btn"));

    $("#cust-info-btn").on("click", function () {
        LoadCustomerInfoPartial($("#cust-info-btn"));
    });
    $("#site-info-btn").on("click", function () {
        LoadCustomerInfoPartial($("#site-info-btn"));
    });
    $("#server-info-btn").on("click", function () {
        LoadCustomerInfoPartial($("#server-info-btn"));
    });
    $("#account-info-btn").on("click", function () {
        LoadCustomerInfoPartial($("#account-info-btn"));
    });
})