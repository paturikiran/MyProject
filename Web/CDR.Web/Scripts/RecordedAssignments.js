var submitAssignment = function (event) {
    event.preventDefault();
    var url = $('#assignmentForm').attr("action");
    var formData = $('#assignmentForm').serialize();
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        dataType: "json",
        success: function (result) {
            $("#result").text(result.data);
        },
        error: function (result) {
            $("#result").val("Assingment Request Failed");
        }
    });
};

var cancelChanges = function () {
    if ($("#AddOrUpdate").closest('form').data('changed')) {
        //do something
        alert("Data changed");
    }
   // HideDetails();
};

var HideDetails = function () {
    $("#details").html();
    $("#details").hide();
};


$(document).ready(function() {
    $("#ddlRecordStatus").on('change', recordStatusBusinessRules);
    recordStatusBusinessRules();
});

var recordStatusBusinessRules = function() {
    var selectedValue = $("#ddlRecordStatus option:selected").text();
    if (selectedValue === "Recorded") {
        $(".change").removeAttr('disabled', false);
    } else {
        $(".change").attr('disabled', true);
    }
}