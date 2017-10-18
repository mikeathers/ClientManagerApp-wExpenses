


    $(document).ready(function () {

        $("#servers-table").on("click", ".js-web-connect", function (e) {
            e.preventDefault();
            var btn = $(this);

            var serverName = btn.parent().parent().children()[0].innerText;

            var publicIp = btn.parent().parent().children()[1].innerText;

            var privateIp = btn.parent().parent().children()[2].innerText;

            var port = btn.parent().parent().children()[3].innerText;

            var userName = btn.parent().parent().children()[4].innerText;

            var password = btn.parent().parent().children()[5].innerText;


            var serverUrl = publicIp + ':' + port;
            var encodedServer = encodeURI(serverUrl);
            
            var encodedUsername = encodeURI(userName);
            
            var encodedPassword = encodeURI(password);

            var url = `https://192.168.0.8/Myrtille/?__EVENTTARGET=&__EVENTARGUMENT=&server=${encodedServer}&user=${encodedUsername}&password=${encodedPassword}&program=&connect=Connect%21`;

            window.open(url, "_blank");            
        });

        $("#mybtn").on("click", function (e) {
            e.preventDefault();
            var id = "212.159.24.125";
            
            window.location.href = "http://localhost:54904/Customers/OpenRDP?address=" + id  

        })

    })

