$(function () {
        
    $.ajax({
        type: "POST",
        url: "userinfo.aspx/GetUsers",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });
    function OnSuccess(response) {
        var username = response.d.username;
        var email = response.d.email;
        var PAN = response.d.pan;
        var aadhaar = response.d.aadhaar;
        var mobile_number = response.d.mobile_number;
        var account_number = response.d.account_number;
        var balance = response.d.balance;
        var type = response.d.type;
        var DOB = response.d.DOB;
        var address = response.d.address;

        console.log(response)
        $('#username').html(username);
        $('#PAN').html(PAN);
        $('#email').html(email);
        $('#addhaar').html(aadhaar);
        $('#mobile_number').html(mobile_number);
        $('#address_number').html(account_number);
        $('#balance').html(balance);
        $('#type').html(type);
        $('#balance').html(balance);
        $('#address').html(address);



    }

    
});