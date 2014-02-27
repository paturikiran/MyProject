
$(document).ready(function () {
    $(".datepicker").datepicker({ maxDate: new Date });
    $("#Account_Number").bind('blur', GetCustodianDetails);
    $("#custodianDetailsPanel").hide();
});

var GetCustodianDetails = function () {
    var accountNumber = $("#Account_Number").val();
    $("#custodianDetailsPanel").show();
    var url = "GetCustodianDetails";
    $.ajax({
        url: url,
        datatype: "json",
        type: "POST",
        data: { accountNumber: accountNumber }
    }).success(function (result) {
        $("#txtCustodian").val(result.data.CustodianName);
        $("#Borrower_Last_Name").val(result.data.BorrowerName);
        $("#txtCustodianRef").val(result.data.CustRefNumber);
        $("#txtMersInfoNumber").val(result.data.MersInfoNumber);
        $("#txtAcquiredFrom").val(result.data.AcquiredFrom);
        $("#txtServicingFor").val(result.data.ServicingFor);
        //    // alert(result.data);
    })
        .error(function (xhr, status) {
            alert(status);
        });

};

var addLookUp = function (ele) {
    var current = $(ele).attr("id");
    var ddl = 'ddl' + current;
    var values = [];
    $('#ddl' + current + ' option').each(function () {
        values.push($(this).attr('value'));
    });
    $('#txtLookupType').val(current);
    $('#addLookUpModal').modal('show');
};

var submitLookup = function () {
    var lookupValue = $('#txtValue').val();
    var lookupType = $('#txtLookupType').val();
    var addLookupValue = "AddLookup";
    $.ajax({
        url: url,
        datatype: "json",
        type: "POST",
        data: { lookupValue: lookupValue,lookupType:lookupType}
    }).success(function (result) {
        alert(result.data);
    }.error(function(result) {
        
    }));

};
