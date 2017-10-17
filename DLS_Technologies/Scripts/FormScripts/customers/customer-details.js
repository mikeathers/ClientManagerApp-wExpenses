
function loadCustNotes() {
    $.ajax({
        method: "GET",
        url: "/Customers/LoadCustomerNotes/",
        data: { id: $("#Id").val() }
    }).done(function (result) {
        $("#customer-notes-partial").empty();
        $("#customer-notes-partial").html(result);
    });
}
$(document).ready(function () {

    loadCustNotes();

    $("#del-customer-btn").on("click", function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this Customer?", (result) => {
            if (result) {
                $.ajax({
                    method: "DELETE",
                    url: "/Api/Customers/DeleteCustomer/" + button.attr("data-customer-id"),
                    success: () => {
                        window.location.href = "/Customers/"                        
                    }
                });
            }
        });
    })
})