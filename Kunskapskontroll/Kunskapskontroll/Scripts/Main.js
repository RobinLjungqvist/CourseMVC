/// <reference path="sweetalert.min.js" />
/// <reference path="jquery.validate.min.js" />
/// <reference path="jquery.validate.unobtrusive.min.js" />


$('document').ready(function (e) {
    $.get("/Person/GetAll", function (data) {
        $("#posts").html(data);
    });

});


function OnCreateSuccess(response) {
    swal("Nice!","Post Updated", "success");
    $("#createform")[0].reset();
}



function OnEditSuccess(response) {
    swal("Nice!", "Edit Successful", "success");

    $("#crudfields").html("");
}

function OnFailure(response) {
    swal("Whoops!", "That didn't go so well did it?", "error");
}

$('#posts').on('click', ".deletebtn", function (e) {
    var thisBtnValue = $(this).attr('value');
    e.preventDefault();
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this post!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    },
function (isConfirm) {
    if (isConfirm) {
        $.post("/Person/Delete", "id=" + thisBtnValue, function (data) {
            $.get("/Person/GetAll", function (data) {
                $("#posts").html(data);
            });
        });
        swal("Deleted!", "Your com has been deleted.", "success");
    }
});
});

function onWindowChange() {
    $.validator.unobtrusive.parse($("#crudfields"));

};