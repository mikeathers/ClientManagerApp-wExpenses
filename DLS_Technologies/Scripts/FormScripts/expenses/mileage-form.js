
function LoadMileageFormats(button) {

        if ($("#Id").val() == 0) {
            $.ajax({
                method: "GET",
                url: "/Expenses/LoadMileageFormat/" + button.attr("data-radioBtn-id"),
                success: function (result) {
                    $("#PartialFormatDiv").empty();
                    $("#PartialFormatDiv").html(result);
                }
            });
        }
        else {
            $.ajax({
                method: "GET",
                url: "/Expenses/LoadEditMileageFormat/",
                data: {
                    id: $("#Id").val(),
                    mileageFormat: button.attr("data-radioBtn-id")
                },
                success: function (result) {
                    $("#PartialFormatDiv").empty();
                    $("#PartialFormatDiv").html(result);
                }
            });
        }
        
    }

    if ($("#odometerRadBtn").is(":checked")) {
        LoadMileageFormats($(".js-mileage-radiobtn"));
    }

    $(".js-mileage-radiobtn").on("change", function () {
        LoadMileageFormats($(this));
    });