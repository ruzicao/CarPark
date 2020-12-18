$(document).ready(function () {

    var host = window.location.host;
    var token = null;
    var headers = {};
    var carEndpoint = "/api/cars/";
    var manufacturerEndpoint = "/api/manufacturers/";
    var formAction = "Create";
    var editingId;

    $("body").on("click", "#btnDelete", deleteCar);

    $("body").on("click", "#btnEdit", editCar);

    $("#login").css("display", "none");
    $("#registration").css("display", "none");

    $("body").on("click", "#btnkia", dataByManufacturer);
    $("body").on("click", "#btnvolkswagen", dataByManufacturer);
    $("body").on("click", "#btntesla", dataByManufacturer);

    $("#btnreg").click(function () {
        $("#registration").toggle();
        $("#login").css("display", "none");
    });


    $("#btnlogin").click(function () {
        $("#login").toggle();
        $("#registration").css("display", "none");
    });


    $("#registration").submit(function (e) {
        e.preventDefault();

        var email = $("#regEmail").val();
        var loz1 = $("#regLoz").val();
        var loz2 = $("#regLoz2").val();

        var sendData = {
            "Email": email,
            "Password": loz1,
            "ConfirmPassword": loz2
        };

        $.ajax({
            type: "POST",
            url: 'https://' + host + "/api/Account/Register",
            data: sendData

        }).done(function (data) {
            $("#info").empty().append("Successful registration.");
            $("#registration").css("display", "none");
            refreshRegistration();
        }).fail(function (data) {
            alert("Error");
        });
    });



    $("#login").submit(function (e) {
        e.preventDefault();

        var email = $("#priEmail").val();
        var loz = $("#priLoz").val();

        var sendData = {
            "grant_type": "password",
            "username": email,
            "password": loz
        };

        $.ajax({
            "type": "POST",
            "url": 'https://' + host + "/Token",
            "data": sendData

        }).done(function (data) {
            token = data.access_token;
            $("#login").css("display", "none");
            $(".btnreglogin").css("display", "none");
            $("#registration").css("display", "none");
            $("#logout").css("display", "block");
            $("#formCarDiv").css("display", "block");
            refreshLogin();
            refreshButtonsAndTable();
        }).fail(function (data) {
            alert(data + "Error");
        });
    });

    $("#btnlogout").click(function () {
        token = null;
        headers = {};
        $("#info").val('Registration');
        $(".btnreglogin").css("display", "block");
        $("#logout").css("display", "none");
        refreshButtonsAndTable();
    });


    function dataByManufacturer() {
        var id = this.name;
        $("#btnkia").css("background-color", "white");
        $("#btnvolkswagen").css("background-color", "white");
        $("#btntesla").css("background-color", "white");
        $(this).css("background-color", "gray");
        var requestUri = 'https://' + host + '/api/carsbymanufacturer?id=' + id.toString();
        $.getJSON(requestUri, setCars);
    };

    function setCars(data, status) {

        var $container = $("#datacars");
        $container.empty();

        if (status == "success") {
            var div = $("<div></div>");

            var table = $("<table class='table table-bordered'></table>");

            if (token) {
                var header = $("<thead style=\"background-color: gray;\"><tr><td>Id</td><td>Name</td><td>Year</td><td>Delete</td><td>Edit</td></tr></thead>");
            } else {
                var header = $("<thead style=\"background-color: gray;\"><tr><td>Id</td><td>Name</td><td>Year</td></tr></thead>");
            }

            table.append(header);
            var tbody = $("<tbody></tbody>");
            for (i = 0; i < data.length; i++) {
                var row = "<tr>";
                var displayData = "<td>" + data[i].Id + "</td><td>" + data[i].Name + "</td><td>" + data[i].Year + "</td>";
                var stringId = data[i].Id.toString();
                var manuID = data[i].ManufacturerId.toString();
                var displayDelete = "<td><button id=btnDelete value=" + manuID + " name=" + stringId + ">Delete</button></td>";
                var displayEdit = "<td><button id=btnEdit value=" + manuID + " name=" + stringId + ">Edit</button></td>";
                if (token) {
                    row += displayData + displayDelete + displayEdit + "</tr>";
                } else {
                    row += displayData + "</tr>";
                }
                tbody.append(row);
            }
            table.append(tbody);
            div.append(table);

            $container.append(div);
        } else {
            var div = $("<div></div>");
            var h1 = $("<h1>Error!</h1>");
            div.append(h1);
            $container.append(div);
        }
    }


    function editCar() {

        var editId = this.name;
        var manuID = this.value;

        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            url: 'https://' + host + carEndpoint + editId.toString(),
            type: "GET",
            headers: headers
        })
            .done(function (data, status) {
                var requestUri = 'https://' + host + '/api/carsbymanufacturer?id=' + manuID.toString();
                $.getJSON(requestUri, setCars);
            })
            .fail(function (data, status) {
                formAction = "Create";
                alert("Desila se greska!");
            });
    };


    function deleteCar() {
        var deleteID = this.name;
        var manuID = this.value;

        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            url: 'https://' + host + carEndpoint + deleteID.toString(),
            type: "DELETE",
            headers: headers
        })
            .done(function (data, status) {
                var requestUri = 'https://' + host + '/api/carsbymanufacturer?id=' + manuID.toString();
                $.getJSON(requestUri, setCars);
            })
            .fail(function (data, status) {
                alert("Desila se greska!");
            });
    };

    function refreshRegistration() {
        $("#regEmail").val('');
        $("#regLoz").val('');
        $("#regLoz2").val('');
    };

    function refreshLogin() {
        $("#priEmail").val('');
        $("#priLoz").val('');
    };

    function refreshButtonsAndTable() {
        $("#btnkia").css('background-color', 'white');
        $("#btnvolkswagen").css('background-color', 'white');
        $("#btntesla").css('background-color', 'white');
        $("#datacars").empty();
    };

});