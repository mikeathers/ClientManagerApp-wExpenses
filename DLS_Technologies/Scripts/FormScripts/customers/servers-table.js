
var token = $('input[name="__RequestVerificationToken"]').val();
$.ajaxPrefilter(function (options, originalOptions) {
    if (options.type.toUpperCase() == "DELETE" || options.type.toUpperCase() == "POST") {
        options.data = $.param($.extend(originalOptions.data, { __RequestVerificationToken: token }));
    }
});


var serverDetails = function (btn) {

    var serverName = btn.parent().parent().children()[0].innerText;
    var publicIp = btn.parent().parent().children()[1].innerText;
    var privateIp = btn.parent().parent().children()[2].innerText;
    var port = btn.parent().parent().children()[3].innerText;
    var userName = btn.parent().parent().children()[4].innerText;
    var password = btn.parent().parent().children()[5].innerText;

    var serverVals = {
        serverName: serverName,
        publicIp: publicIp,
        privateIp: privateIp,
        port: port,
        userName: userName,
        password: password
    };

    return serverVals;
}


$(document).ready(function () {
    $("#servers-table").DataTable();
    $("#servers-table").on("click", ".js-web-connect", function (e) {
        e.preventDefault();
        var btn = $(this);

        var server = new serverDetails(btn);

        var serverUrl = server.publicIp + ':' + server.port;
        var encodedServer = encodeURI(serverUrl);
        var encodedUsername = encodeURI(server.userName);
        var encodedPassword = encodeURI(server.password);

        var url = `https://192.168.0.8/Myrtille/?__EVENTTARGET=&__EVENTARGUMENT=&server=${encodedServer}&user=${encodedUsername}&password=${encodedPassword}&program=&connect=Connect%21`;

        window.open(url, "_blank");

    }).on("click", ".js-rdp-connect", function (e) {
        e.preventDefault();
        var btn = $(this);
        var server = new serverDetails(btn);
        window.location.href = "http://localhost:54904/Customers/OpenRDP?address=" + server.publicIp;

    }).on("click", ".js-edit-btn", function (e) {
        e.preventDefault();
        var btn = $(this);
        var server = new serverDetails(btn);

        $("#ServerName").val(server.serverName);
        $("#PublicIpAddress").val(server.publicIp);
        $("#PrivateIpAddress").val(server.privateIp);
        $("#Port").val(server.port);
        $("#UserName").val(server.userName);
        $("#Password").val(server.password);

        $("#add-btn").hide();
        $("#edit-btns").show();
        $("#ServerId").val(btn.attr("data-server-id"));
    });

    

})

