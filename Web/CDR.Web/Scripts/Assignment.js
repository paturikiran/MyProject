$(document).ready(function () {
    $('#accountNumber').numericOnly();
    $('#ddlDocumentType').on('change', docTypeBusinessRules);
    $('#search').bind('click', getRecords);
    defineProgressIndicator();
});


var getRecords = function () {
    //$('#records').empty();
    $('#details').hide();
    showProgressBar();
    var id = $('#accountNumber').val();
    var url = "GetAssignmentsById/";
    $.ajax({
        url: url + id,
        contentType: 'application/html;charset=utf-8',
        type: 'GET',
        dataType: 'html'
    }).success(function (result) {
        $('#records').html(result);
            hideProgressBar();
        })
        .error(function (xhr, status) {
            alert(status);
        hideProgressBar();
    });
};

function loadModal(id, accountNumber) {
    event.preventDefault();
    Details(id, accountNumber);
}


var HideDetails = function () {
    $("#details").hide();
};

function defineProgressIndicator() {
    $('.js-loading-bar').modal({
        backdrop: 'static',
        show: false
    });
}

function showProgressBar() {
    var $modal = $('.js-loading-bar'),
      $bar = $modal.find('.progress-bar');

    $modal.modal('show');
    $bar.addClass('animate');
}

function hideProgressBar() {
    var $modal = $('.js-loading-bar'),
      $bar = $modal.find('.progress-bar');

    $bar.removeClass('animate');
    $modal.modal('hide');

}