

$(document).ready(function () {

    $('#custSearchBoxSide').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Customers/AutoComplete",
                data: {
                    custName: request.term
                },
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    response($.map(data, function (item) {
                        return {
                            label: item.name,
                            value: item.id
                        };
                    }));
                }
            });
        },
        minLength: 1, // require at least one character from the user
        select: function (event, ui) {
            window.location.href = "/Customers/GetCustomer/" + ui.item.value;
        }
    })
    
})

