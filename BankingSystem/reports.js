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
        if (res.d["userEmail"] == "") {
            window.location.replace("HomePage.html");
        } else {
            $.ajax({
                type: "POST",
                url: "fetchData.aspx/getTransations",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    console.log(response.d);
                },
                error: function (response) {
                    console.log(response.d);
                }
            });
            function OnSuccess(response) {
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

        }
    }



});