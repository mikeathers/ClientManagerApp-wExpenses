
 $(document).ready(function () {
            
            $("#expensesTable").append('<tfoot><th></th><th></th><th></th><th></th><th></th><th></th><th></th></tfoot>');
            var table = $('#expensesTable').DataTable({
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],                
                order: [[2, "desc"]],
                columnDefs: [
                    { width: 100, targets: [5, 6] },
                    {
                        'targets': [2],
                        'visible': false,
                        'searchable': false
                    }
                ],
                dom: 'Blfrtip',
                buttons: [
                    {
                        extend: 'copyHtml5',
                        footer: true,
                        exportOptions: {
                            order: [[2, "asc"]],
                            columns: [0, 1, 3, 4, 5, 6]
                        }
                    },
                    { 
                        extend: 'excelHtml5',
                        footer: true,
                        exportOptions: {
                            columns: [0, 1, 3, 4, 5, 6]
                        }
                    },
                    {
                        extend: 'csvHtml5',
                        footer: true,
                        exportOptions: {
                            columns: [0, 1, 3, 4, 5, 6]
                        }
                    },
                    {
                        extend: 'pdfHtml5',
                        footer: true,
                        exportOptions: {
                            order: [[2, "asc"]],
                            columns: [0, 1, 3, 4, 5, 6]
                        }
                    }
                ],
                "footerCallback": function (row, data, start, end, display) {
                    var api = this.api(), data;
                    // Remove the formatting to get integer data for summation
                    var intVal = function (i) {
                        return typeof i === 'string' ?
                            i.replace(/[\£,]/g, '') * 1 :
                            typeof i === 'number' ? i : 0;
                    };

                    // Total over all pages
                    totalCost = api
                        .column(6)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);
                    // Total over this page
                    pageTotal = api
                        .column(6, { page: 'current' })
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var totalCostResult = parseFloat(Math.round(totalCost * 100) / 100).toFixed(2); 

                    // Total over all pages
                    totalMiles = api
                        .column(5)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);
                    // Total over this page
                    pageTotal = api
                        .column(5, { page: 'current' })
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);
                    

                    // Update footer
                    $(api.column(6).footer()).html(
                        'Total: £' + totalCostResult
                    );

                    // Update footer
                    $(api.column(5).footer()).html(
                        'Total Miles: ' + totalMiles
                    );                    
                }
            });       

            //table.page("last").draw("page");
            
            $("#expensesTable tbody").on("click", "tr", function () {
                var row = $(this);
                $.ajax({
                    method: "GET",                    
                    url: "/Expenses/GetExpense/" + row.attr("data-expense-id"),
                    success: function () {
                        window.location.href = '/Expenses/GetExpense/' + row.attr("data-expense-id")
                    }
                });                
            });
        })