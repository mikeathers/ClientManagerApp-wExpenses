
var token = $('input[name="__RequestVerificationToken"]').val();
$.ajaxPrefilter(function (options, originalOptions) {
    if (options.type.toUpperCase() == "PUT") {
        options.data = $.param($.extend(originalOptions.data, { __RequestVerificationToken: token }));
    }
});

$("#edit-notes-btn").on("click", function (e) {
    e.preventDefault();
    $("#Note").removeAttr("readonly");
    $(".new-cust-note").focus();
});

$("#save-notes-btn").on("click", function (e) {
    e.preventDefault();
    $.ajax({
        method: "PUT",
        url: "/Customers/SaveCustomerNote/",
        data: {
            id: $("#save-notes-btn").attr("data-customer-id"),
            note: $("#Note").val()
        },
    }).then(function () { 
        $.ajax({
            method: "GET",
            url: "/Customers/LoadCustomerNotes/",
            data: {
                id: $("#Id").val()
            },
        }).done( function (result) {
                $("#customer-notes-partial").empty();
                $("#customer-notes-partial").html(result);
                toastr.success("Note Added!", "Success");
                
        })
        
    })
});