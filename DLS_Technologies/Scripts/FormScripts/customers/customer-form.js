
function siteVisitCheck() {
        var dropDown = $("#AccountTypeId");
        if (dropDown.val() == 1) {
            $(".site-visit-form").show();
        }
        else
            $(".site-visit-form").hide();
        }

    $(document).ready(function () {
        var address = document.getElementById('Address');
        var searchBox = new google.maps.places.SearchBox(address);
    })