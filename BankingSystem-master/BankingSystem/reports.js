$(function () {

    $.ajax({
        type: "POST",
        url: "fetchData.aspx/GetTransations",
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
        /* var id = response.d[0].id;
         var transaction_type = response.d[0].transaction_type;
         var to_acc = response.d[0].to_acc;
         var from_acc = response.d[0].from_acc;
         var amount = response.d[0].amount;
         var tr_date = response.d[0].tr_date;
         */
        console.log(">>>>>>>>>>>", response);
        var transactions = response.d;

        $(transactions).each(function () {

            var newRow = "<tr>" +
                                "<td>" + this.id + "</td>" +
                                "<td>" + this.transaction_type + "</td>" +
                                "<td>" + this.tr_date + "</td>" +
                                "<td>" + this.from_acc + "</td>" +
                                "<td>" + this.to_acc + "</td>" +
                                "<td>" + this.amount + "</td>" +
                                "</tr>";
            $("table tbody").append(newRow)

        });



    }


});