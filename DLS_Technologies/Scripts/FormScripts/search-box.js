
    $(document).ready(function () {
        console.log("hello");
        var custBox = $("#custSearchBoxSide");

        custBox.on("change", function () {
            console.log("change");
        })

        $("#custSearchBoxSide").autocomplete({
            source: function (req, res) {
                $.ajax({
                    type: "POST",
                    url: "/Customers/Autocomplete",
                    dataType: "json",
                    data: {
                        Prefix: req.term
                    },
                    success: function (result) {
                        console.log(result);
                    }
                })
            }
            
        })
        
    })

    
