
$(document).ready(function () {

    var origin = document.getElementById('Origin');
    var destination = document.getElementById('Destination');
    var searchBox = new google.maps.places.SearchBox(origin);
    var searchBox = new google.maps.places.SearchBox(destination);

    function calculateDistance(origin, destination) {

        var service = new google.maps.DistanceMatrixService();
        service.getDistanceMatrix(
            {
                origins: [origin],
                destinations: [destination],
                travelMode: google.maps.TravelMode.DRIVING,
                unitSystem: google.maps.UnitSystem.IMPERIAL,
                avoidHighways: false,
                avoidTolls: false
            }, callback);
    }

    function callback(response, status) {
        if (status != google.maps.DistanceMatrixStatus.OK) {
            $('#result').html(err);
        } else {
            var origin = response.originAddresses[0];
            var destination = response.destinationAddresses[0];
            if (response.rows[0].elements[0].status === "ZERO_RESULTS") {
                $('#result').html("Issue with Origin or Destination entered, please make sure the spelling is correct and try again.").show();
                $("#TotalMiles").val("");
            } else {
                $('#result').html("");
                var distance = response.rows[0].elements[0].distance;
                var distance_value = distance.value;
                var distance_text = distance.text;
                var miles = Math.ceil(distance_text.substring(0, distance_text.length - 3));

                $("#TotalMiles").val(miles);
            }
        }
    }



    $("#TotalMiles").on("focusin", function () {

        if ($("#Destination").val() != null || undefined) {
            var originResult = $("#Origin").val();
            var destinationResult = $("#Destination").val();
            calculateDistance(originResult, destinationResult);
        }
    }).on("focusout", function () {
        var miles = $(this).val();
        var result;

        if (miles != null) {
            var cost = miles * .25;
            result = parseFloat(Math.round(cost * 100) / 100).toFixed(2);
        } else {
            result = 0;
        }

        $("#Cost").val(result);
    });



})