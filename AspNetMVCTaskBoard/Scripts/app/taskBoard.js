$(document).ready(function () {

    $("#taskD").click(function () {

        //$("#myModal").modal('show'); 

        var url = $('#Modalpopup').data('url');

        $.get(url, function (data) {
            $('#popupcontainer').html(data);

            $('#Modalpopup').modal({
                backdrop: true,
                keyboard: false,
                show: true
            });
        });
    });




    function contextualizePage() {
        $.get("ajax/test.html", function (data) {
            $(".result").html(data);
        });
    }

    function getTask(id) {
        var taskId = id;

        $.post("ajax/test.html", function (data) {
            $(".result").html(data);
        });

        //$.ajax({
        //    type: "POST",
        //    url: url,
        //    data: data,
        //    success: success,
        //    dataType: dataType
        //});

    }

});