$(function () {

    $.ajax({
        type: "POST",
        url: "fetchData.aspx/GetBal",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            console.log(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });
    function OnSuccess(response) {
        var full_name = response.d.full_name;
        var account_number = response.d.account_number;
        var balance = response.d.balance;
        var type = response.d.type;

        console.log(response)
        $('#full_name').html(full_name);
        $('#account_number').html(account_number);
        $('#balance').html(balance);
        $('#type').html(type);



    }


});