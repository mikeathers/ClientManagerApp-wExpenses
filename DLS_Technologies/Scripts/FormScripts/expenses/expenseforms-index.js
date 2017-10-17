
var token = $('input[name="__RequestVerificationToken"]').val();
$.ajaxPrefilter(function (options, originalOptions) {
    if (options.type.toUpperCase() == "PUT") {
        options.data = $.param($.extend(originalOptions.data, { __RequestVerificationToken: token }));
    }
});

$(document).ready(function () {
    $("#showNewExpenseFormBtn").on("click", function (e) {
        e.preventDefault();
        $("#addNewExpenseFormBtn").toggle();
    });

    var table = $("#expenseFormsTable").DataTable({
        order: [[0, "desc"]],
        columnDefs: [
            {
                'targets': [1],
                'visible': false,
                'searchable': false,
            }
        ]

    });

    $("#expenseFormsTable").on("click", ".js-delete", function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this Expense Form?", (result) => {
            if (result) {
                $.ajax({
                    method: "DELETE",
                    url: "/Api/Expenseforms/Deleteexpenseform/" + button.attr("data-expenseform-id"),
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }

                });
            }
        });
    }).on("click", ".js-edit", function () {
        var button = $(this);
        var id = button.attr("data-expenseform-id");
        bootbox.prompt("Form Name:", function (name) {
            if (name) {
                $.ajax({
                    method: "PUT",
                    url: "/Api/Expenseforms/UpdateExpenseFormName/",
                    data: {
                        id: id,
                        name: name
                    },
                    success: function (result) {
                        window.location.reload();
                    }
                });
            };
        });
    });


});