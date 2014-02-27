
$(document).ready(function () {
    $("#ACCOUNT_NUMBER").bind('blur', GetCustodianDetails);
    $("#custodianDetailsPanel").hide();
    $('#ddlDocumentType').bind('change', docTypeBusinessRules);
    var transacitonType = $("#TransactionType").val();
    if (transacitonType == "Update") {
        GetCustodianDetails();
    }
    applyDateRules();
    docTypeBusinessRules();
});

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

var applyDateRules = function () {
    $('#REQUEST_DATE').datepicker({ minDate: new Date });
    //$('#DATE_ENTERED').datepicker({ minDate: new Date });//TO BE dISABLED
};

var GetCustodianDetails = function () {

    //myApp.showPleaseWait();
    var accountNumber = $("#ACCOUNT_NUMBER").val();
    var transacitonType = $("#TransactionType").val();
    if (accountNumber != '') {
        $("#custodianDetailsPanel").show();
        //var url = transacitonType == "Update" ? "Assignments/GetCustodianDetails" : "GetCustodianDetails";
        var url = "GetCustodianDetails";
        $.ajax({
            url: url,
            datatype: "json",
            type: "POST",
            data: { accountNumber: accountNumber }
        }).success(function (result) {
             //   myApp.hidePleaseWait();
            $('#CUSTODIAN_ID').val(result.data.CustodianId);
            $("#txtCustodian").val(result.data.CustodianName);
            $("#BORROWER_LAST_NAME").val(result.data.BorrowerName);
            $("#txtCustodianRef").val(result.data.CustRefNumber);
            $("#txtMersInfoNumber").val(result.data.MersInfoNumber);
            $("#txtAcquiredFrom").val(result.data.AcquiredFrom);
            $("#txtServicingFor").val(result.data.ServicingFor);
        })
            .error(function (xhr, status) {
           // myApp.hidePleaseWait();
        });
    }

};

var addLookUp = function (ele) {
    var current = $(ele).attr("LookupType");
    var name = $(ele).attr("id");
    $('#txtLookupName').val(name);
    $('#txtLookupType').val(current);
    $('#divLookupName').hide();
    $('#divLookupType').hide();
    $('#lbllookupName').text(name);
    $('#addLookUpModal').modal('show');
};


var submitLookup = function () {
    var lookupValue = $('#txtValue').val();
    var lookupType = $('#txtLookupType').val();
    var lookupName = $('#txtLookupName').val();
    var addLookupValue = "AddLookUpValue";
    var dropdown = "#ddl" + lookupName;
    $.ajax({
        url: addLookupValue,
        datatype: "json",
        type: "POST",
        data: { Value: lookupValue, Type: lookupType, Section: 'ASM' }
    }).success(function (result) {
        if (result.IsSuccess) {
            var ddl = $(dropdown);
            $(ddl).empty();
            var items = [];
            items.push("<option>Please Select</option>");
            $.each(result.data, function () {
                items.push("<option value=" + this.LOOKUP_ID + ">" + this.LOOKUP_VALUE + "</option>");
            });
            ddl.html(items.join(' '));
            $('#addLookUpModal').modal('hide');
        }
    });

};

var docTypeBusinessRules = function () {
    var selectedValue = $("#ddlDocumentType option:selected").text();
    if (selectedValue === "Assignment" || selectedValue === "Allonge") {
        $("#ASSIGNOR").attr("disabled", true);
        $('#ASSIGNEE').attr('disabled', true);
    } else {
        $("#ASSIGNOR").removeAttr("disabled", false);
        $('#ASSIGNEE').removeAttr('disabled', false);
    }
};

