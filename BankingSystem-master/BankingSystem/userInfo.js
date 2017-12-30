$(function () {

    $.ajax({
        type: "POST",
        url: "fetchData.aspx/GetUsers",
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
        console.log("sdfghsdhdfghdfg")
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
        $('#balance').html(balance);
        $('#type').html(type);
        $('#DOB').html(DOB);
        $('#address').html(address);
        $('#full_name').html(full_name);
        $('#aadhaar').html(aadhaar);




    }


});