//Testing with modals. 


//This is an attempt to get the modal to fire a partial view into a pre-existing div on the page
//NOT WORKING
$(function () {
    $(".details").click(function () {
        $("#modal").load("_EditProjectPartial", function () {
            $("#modal").modal();
        })
    });
})

