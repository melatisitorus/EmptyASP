$('#Create').click(function (e) {
    if ($('#Name').val() == "") {
        sweetAlert("Field Shouldn't Be Empty!!", "Please Input Your Name", "error");
        //alert("File Shouldn't Be Empty!!");
        return false;
    }
    else {
        //sweetAlert("Congratulations!!", "Thank You", "success"),
        //function () {
        debugger;
        $.ajax({
            url: "/Supplier/Create/",  //Merupakan nama controller dan nama view
            data: {
                id: Id // sebelah kiri adalah penampung dan sebelah kanan pemberi 
            },
            success: function (response) {
                swal({
                    title: "Insert",
                    text: "That data has been soft insert!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Supplier/Create/';
                });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
        //return false;
    }
});

    //$('#Create').click(function (e) {
    //    if ($('#Name').val() == "") {
    //        sweetAlert("Field Shouldn't Be Empty!!", "Please Input Your Name", "error");
    //        alert("File Shouldn't Be Empty!!");
    //        return false;
    //    }
    //    else {
    //        sweetAlert("Congratulations!!", "Thank You", "success"),
    //        function () {
    //        debugger;
    //        $.ajax({
    //            url: "/Supplier/Create/",
    //            data: { "Id": id }
    //        })
    //              .done(function (data) {
    //                  sweetAlert
    //                         ({
    //                             title: "Insert!",
    //                             text: "Your file was successfully deleted!"
    //                         },
    //                  function ()
    //                  {
    //                      window.location.href = '/Supplier/Create';
    //                  });
    //              })
    //               .error(function (data)
    //               {
    //                   swal("Oops", "We couldn't connect to the server!", "error");
    //               });
    //        }
    //        return false;

    //    }
    //});


