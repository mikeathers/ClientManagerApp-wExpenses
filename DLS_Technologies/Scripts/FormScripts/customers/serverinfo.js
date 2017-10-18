
var token = $('input[name="__RequestVerificationToken"]').val();
        $.ajaxPrefilter(function (options, originalOptions) {
            if (options.type.toUpperCase() == "POST") {
                options.data = $.param($.extend(originalOptions.data, { __RequestVerificationToken: token }));
            }
        });

        function LoadServersTable() {
            $.ajax({
                method: "GET",
                url: "/Customers/LoadServersTable",
                data: {
                    id: $("#CustomerId").val()
                },
                success: function (result) {
                    $("#servers-table-partial").empty();
                    $("#servers-table-partial").html(result);
                    
                }

            })
        }

        $(document).ready(function () {
            LoadServersTable();

            $("#add-server-btn").on("click", function (e) {
                e.preventDefault();
                $.ajax({
                    method: "POST",
                    url: "/Customers/AddServer/", 
                    data: {
                        serverName: $("#ServerName").val(),
                        publicIpAddress: $("#PublicIpAddress").val(),
                        privateIpAddress: $("#PrivateIpAddress").val(),
                        port: $("#Port").val(),
                        userName: $("#UserName").val(),
                        password: $("#Password").val(),
                        customerId: $("#CustomerId").val()
                    },
                    success: function () {
                        LoadServersTable();
                        toastr.success("Server Added!", "Success");
                    }
                })
            });

        });