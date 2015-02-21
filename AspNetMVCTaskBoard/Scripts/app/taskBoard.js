$(document).ready(function() {
    
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