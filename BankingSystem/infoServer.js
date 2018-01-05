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
    function OnSuccess(res){
        if (res.d["userEmail"] == "") {
            window.location.replace("HomePage.html");
        } else{
            

            $('#tform').on('click', '#transfer', function () {

                var from_acc = $("#fromAccount").val()
                var to_acc = $("#recieverAccNumber").val()
                var amount = $("#amount").val()
                var password = $("#password").val()

                var sendData = {
                    "from_acc": from_acc,
                    "to_acc": to_acc,
                    "amount": amount,
                    "password": password,

                };
                $.ajax({
                    type: "POST",
                    url: "userActions.aspx/transferAmount",
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
                        alert("Transaction Successfull");
                    } else {
                        alert(response.d.error);
                    }

                }

            });

            $('#dform').on('click', '#deposit', function () {
                alert("depo")
                var email = $("#email").val()
                var from_acc = $("#accountnumber").val()
                var amount = $("#depositAmount").val()

                var sendData = {
                    "from_acc": from_acc,
                    "email": email,
                    "amount": amount,

                };
        
                $.ajax({
                    type: "POST",
                    url: "userActions.aspx/depositAmount",
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
                        alert("Deposit Successfull");
                    } else {
                        alert(response.d.error);
                    }

                }

            });
        }
    }
   

    
});