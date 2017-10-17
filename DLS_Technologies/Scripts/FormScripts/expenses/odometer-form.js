$(document).ready(function () {
        $("#OdometerEnd").on("focusout", function () {

            var startOdometer = $("#OdometerStart").val();
            var endOdometer = $("#OdometerEnd").val();

            if (endOdometer != "") {
                var result = endOdometer - startOdometer;
                if (result < 0) {
                    $("#result").html("End odometer value cannot be less than the start odometer value.");
                    result = 0;
                }
                else {
                    $("#result").html("");
                }
            } else {
                result = 0;                
            }
            $("#TotalMiles").val(result);
        });  

        $("#TotalMiles").on("focusout", function () {
            var miles = $(this).val();
            var cost = miles * .25;
            var result = parseFloat(Math.round(cost * 100) / 100).toFixed(2);
            $("#Cost").val(result);
        });;
        
    });