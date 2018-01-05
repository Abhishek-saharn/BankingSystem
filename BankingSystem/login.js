$(function () {
    $('#loginform').on('click', '#login', function () {
        
        var username = $("#username").val()
        var password = $("#pwd").val()
        var sendData = {
            "username": username,
            "password": password,
        };
        $.ajax({
            type: "POST",
            url: "userActions.aspx/checkPassword",
            data: JSON.stringify(sendData),
            contentType: "application/json; charset=utf-8",
            dataType: "text json",
            success: afterSuccess,
            failure: function (response) {
                console.log("ERROR:");
                console.log(response);

            },
            error: function (response) {
                console.log("ERROR:");
                console.log(response);
            }
        });
        function afterSuccess(response) {
            console.log(response);
            if (response.d.error === "NULL") {

                window.location.replace("userInfo.html")
            } else {
                alert(response.d.error);
            }

        }

    });
});

