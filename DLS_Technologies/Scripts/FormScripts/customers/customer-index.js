
var table = $("#customerTable").DataTable({
            order: [[0, "asc"]]
        });

        $("#customerTable tbody").on("click", "tr", function () {
            var row = $(this);
            $.ajax({
                method: "GET",
                url: "/Customers/GetCustomer/" + row.attr("data-customer-id"),
                success: function () {
                    window.location.href = '/Customers/GetCustomer/' + row.attr("data-customer-id")
                }
            });
        });