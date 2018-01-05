$(function () {

    $.ajax({
        type: "POST",
        url: "fetchData.aspx/GetSession",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (res) {
            alert("Error:" + res.d);
        },
        error: function (res) {
            alert("Error:" + res.d);
        }
    });
    function OnSuccess(res) {
        console.log(res)
        if (res.d["userEmail"] == "") {
            window.location.replace("HomePage.html");
        }
        else {
            //alert("After");
            var userEmail = res.d.userEmail;
            var data = {
                semail: userEmail
            };
            $.ajax({
                type: "POST",
                url: "fetchData.aspx/GetUsers",
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessGet,
                failure: function (response) {
                    alert("Error: " + response.d);
                },
                error: function (response) {
                    alert("Error: " + response.d);
                }
            });

            function OnSuccessGet(response) {
                //console.log(response);
                var full_name = response.d.full_name;
                var email = response.d.email;
                var PAN = response.d.pan;
                var aadhaar = response.d.aadhaar;
                var mobile_number = response.d.mobile_number;
                var account_number = response.d.account_number;
                var balance = response.d.balance;
                var type = response.d.type;
                var DOB = response.d.DOB;
                var address = response.d.address;


                $('#PAN').html(PAN);
                $('#email').html(email);
                $('#mobile_number').html(mobile_number);
                $('#account_number').html(account_number);
                $('#balance').html("Rs. "+ balance);
                $('#type').html(type);
                $('#DOB').html(DOB);
                $('#address').html(address);
                $('#full_name').html(full_name);
                $('#aadhaar').html(aadhaar);
            }
        }











    }


});