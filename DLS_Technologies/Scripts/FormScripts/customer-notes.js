




$(document).ready(function () {
    console.log("Hello");
    $("#customer-notes-table").on("click", "js-delete", function (e) {
        e.preventDefault();
        console.log("clicked delete");
            var button = $(this);
            var id = button.attr("data-form-id");
            bootbox.confirm("Are you sure you want to delete this Note?", (result) => {
                if (result) {
                    $.ajax({
                        method: "DELETE",
                        url: "/api/customers/deletecustomernote/" + button.attr("data-note-id"),
                        success: function () {
                            LoadExpenseForms();
                        }
                    });
                };
            });
        });
})