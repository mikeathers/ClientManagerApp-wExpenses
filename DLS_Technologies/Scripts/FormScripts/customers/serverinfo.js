
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
                    $("#ServerId").val(0);
                    $("#ServerName").val("");
                    $("#PublicIpAddress").val("");
                    $("#PrivateIpAddress").val("");
                    $("#Port").val("");
                    $("#UserName").val("");
                    $("#Password").val("");
                    $("#add-btn").show();
                    $("#edit-btns").hide();
                }
            });
        }

        function SaveServer() {
            $.ajax({
                method: "POST",
                url: "/Customers/SaveServer/",
                data: {
                    Id: $("#ServerId").val(),
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
                    toastr.success("Server saved!", "Success");
                }
            })
        }
        

        $(document).ready(function () {
            LoadServersTable();

            $("#add-server-btn").on("click", function (e) {
                e.preventDefault();
                SaveServer()
            });

            $("#save-server-btn").on("click", function (e) {
                e.preventDefault();
                SaveServer();
            });

            $("#delete-server-btn").on("click", function (e) {
                e.preventDefault();


                bootbox.confirm("Are you sure you want to delete this sever?", (result) => {
                    if (result) {
                        $.ajax({
                            method: "DELETE",
                            url: "/Api/Customers/DeleteServer/" + $("#ServerId").val(),
                            success: function () {
                                LoadServersTable();
                                toastr.success("Server deleted!", "Success");
                            }
                        });
                    }
                });

            });

        });