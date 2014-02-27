$(document).ready(function () {
    $('#accountNumber').numericOnly();
    $('#search').bind('click', getRecords);
});


var getRecords = function() {
    var id = $('#accountNumber').val();

    var url = "Assignments/GetAssignmentsById/";
    $.ajax({
            url: url + id,
            contentType: 'application/html;charset=utf-8',
            type: 'GET',
            dataType: 'html'
        }).success(function(result) {
            $('#records').html(result);
        })
        .error(function(xhr, status) {
            alert(status);
        });
};

function Details(id, accountNumber) {
    var url = "Assignments/GetDetails?assignmentId=" + id + "&accountNumber=" + accountNumber;
    $.ajax({
        url: url,
        //  data: { id: id, loanNumber: loanNumber },
        contentType: 'application/html;charset=utf-8',
        type: 'GET',
        dataType: 'html'
    }).success(function (result) {
        $('#details').html(result);
    })
           .error(function (xhr, status) {
               alert(status);
           });
}

function loadModal(id, accountNumber) {
    Details(id, accountNumber);
    // loadGrid(processName);
    $("#detailsModal").modal('show');
}