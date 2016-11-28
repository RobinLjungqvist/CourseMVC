

$('document').ready(function (e) {
    $.get("/Person/GetAll", function (data) {
        $("#posts").html(data);
    });

});


function OnCreateSuccess(response) {
    $("#createform")[0].reset();
}



function OnEditSuccess(response) {
    $("#editform")[0].reset();
}

function OnFailure(response) {
    alert("Whoops! That didn't go so well did it?");
}