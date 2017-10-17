function LoadExpenseForms(id) {
            // Load new expense form partial.
            if ($("#Id").val() == 0) {
                if (id == null)
                    var id = $("#ExpenseTypeId").val();
                $.ajax({
                    type: "GET",
                    url: "/Expenses/LoadExpensePartial/" + id,
                    success: function (result) {
                        $("#PartialFormatDiv").empty();
                        $("#PartialDiv").empty();
                        $("#PartialDiv").html(result);                        
                        $.ajax({
                            method: "GET",
                            url: "/Expenses/LoadMileageFormat/" + 1,
                            success: function (result) {
                                $("#PartialFormatDiv").empty();
                                $("#PartialFormatDiv").html(result);
                            }
                        });                        
                    }
                });
            }
            // Load edit expense form partial.
            else {
                $.ajax({
                    type: "GET",
                    url: "/Expenses/LoadEditExpensePartial/",
                    data: {
                        id: $("#Id").val(),
                        expenseType: $("#ExpenseTypeId").val()
                    },
                    success: function (result) {
                        $("#PartialFormatDiv").empty();
                        $("#PartialDiv").empty();
                        $("#PartialDiv").html(result);                        
                        $.ajax({
                            method: "GET",
                            url: "/Expenses/LoadEditMileageFormat/",
                            data: {
                                id: 1,
                                mileageFormat:1
                            },
                            success: function (result) {
                                $("#PartialFormatDiv").empty();
                                $("#PartialFormatDiv").html(result);
                            }
                        })
                        
                    }
                });
            }            
        }

        $(document).ready(function () {
            LoadExpenseForms(1);       

            $("#delete-btn").on("click", function (e) {
                e.preventDefault();
                var button = $(this);
                var id = button.attr("data-form-id");
                bootbox.confirm("Are you sure you want to delete this Expense?", (result) => {
                    if (result) {
                        $.ajax({
                            method: "DELETE",
                            url: "/Api/Expenses/DeleteExpense/" + button.attr("data-expense-id"),
                            dataType: "json",
                            success: () => {
                                console.log(id);
                                window.location.href = "/ExpenseForms/ShowExpenses/" + id
                            }
                        });
                    };
                });
            });

        })