$(document).ready(function () {

    bindDropDownEvents();
    bindButtonClickEvents();
    bindDateRules();
    applyDateRules();
    $("#custodianDetailsPanel").hide();
    $("#divNoRecordsFound").hide();
    $('#LAST_STATUS_DATE').prop("readonly",true);
    $('#DATE_ENTERED').prop("readonly", true);
    //$("body").on('blur', "#ACCOUNT_NUMBER", GetCustodianAndNotesDetails);

    displayCustomMessageForCustodian(false);
    enableControlsForAdmin();
});

//Binds all the dropdown change events 
var bindDropDownEvents = function () {
    $('body').on('change', '#ddlDocumentType', docTypeBusinessRules);
    $('body').on('change', '#ddlAssignedTo', assignedToBusinessRules);
    $('body').on('change', "#ddlRecordStatus", recordStatusBusinessRules);
    $('body').on('change', "#ddlStatus", statusDateBusinessRules);
    docTypeBusinessRules();
};

//Business rule to handle AssginedTo dropdown change event
var assignedToBusinessRules = function () {
    if ($('#ASSIGNED_DATE').val() != undefined) {
        var d = new Date();
        var dformat = [
             d.getMonth() + 1,
             d.getDate(),
             d.getFullYear()
        ].join('/');
        $('#ASSIGNED_DATE').val(dformat);
    } else {
        $('#ASSIGNED_DATE').val('');
    }
};

var statusDateBusinessRules = function () {
    $('#LAST_STATUS_DATE').prop('readonly', true);
    if ($('#LAST_STATUS_DATE').val() != undefined) {
        var d = new Date();
        var dformat = [
             d.getMonth() + 1,
             d.getDate(),
             d.getFullYear()
        ].join('/');
        $('#LAST_STATUS_DATE').val(dformat);
    } else {
        $('#LAST_STATUS_DATE').val('');
    }
    $('#DATE_ENTERED').prop('readonly', true);
    enableControlsForAdmin();
};

//function to handle docType dropdown change event
var docTypeBusinessRules = function () {
    var selectedValue = $("#ddlDocumentType option:selected").text();
    if (selectedValue === "Assignment" || selectedValue === "Allonge") {
        $("#ASSIGNOR").prop('readonly', false);
        $("#ASSIGNEE").prop('readonly', false);
    }
    else {
        $("#ASSIGNOR").prop('readonly', true);
        $("#ASSIGNEE").prop('readonly', true);
    }
    enableControlsForAdmin();
};

//function to handle recordStatus dropdown change event
var recordStatusBusinessRules = function () {
    
    var selectedValue = $("#ddlRecordStatus option:selected").text();
    if (selectedValue === "Recorded") {
        $(".change").prop('readonly', false);
        
        $('#recordedDate').datepicker();
    } else {
        $(".change").prop('readonly', true);
    }
};

var setRecordStatusDate = function () {
    if ($('#recordedDate').val() != '') {
        var value = $('#recordedDate').val();
        value = value.replace(/\d{1,2}:\d{2}:\d{2} (AM|PM)/ig, '');
        $('#recordedDate').val(value);
    }
};

var bindButtonClickEvents = function () {
    $('#search').on('click', testGridData);
    // $('#accountNumber').numericOnly();
    $('#accountNumber').on('keypress', function (event) {
        if (event.keyCode === 13) {
            testGridData();
        } else {
            $('#accountNumber').numericOnly();
        }
    });
    $('body').on('blur keypress', '#ACCOUNT_NUMBER', function (event) {

        if (event.type == 'keypress' && event.keyCode == 13) {
            event.preventDefault();
        }
        else if (event.type == 'focusout') {
            GetCustodianAndNotesDetails();
        }
        else {
            $('#ACCOUNT_NUMBER').numericOnly();
        }
    });
    $('input').on('keypress', function (event) {
        if (event.type == 'keypress' && event.keyCode == 13) {
            event.preventDefault();
        }
    });
};

var bindDateRules = function () {
    $(".datepicker").datepicker();
};

var getAssignments = function () {
    var id = $('#accountNumber').val();
    if (id != '') {
        $("#jqGrid").setGridParam({ datatype: 'json' }).trigger('reloadGrid', [{ page: 1 }]);
        var url = "GetAssignmentsById/";
        $.ajax({
            url: url + id,
            //contentType: 'application/html;charset=utf-8',
            type: 'GET',
            //dataType: 'html'
        }).success(function (result) {
            $('#records').html(result);
            //   hideProgressBar();
        })
            .error(function (xhr, status) {
                alert(status);
                //  hideProgressBar();
            });
    }
};

var testGridData = function () {
    var accountNumber = $('#accountNumber').val();
    $('#divNoRecordsFound').hide();
    if (accountNumber != '') {
        displayDetails(false);
        $('#loadGrid').show();
        loadGridData();
        $("#jqTable").setGridParam({ datatype: 'json', url: 'LoadjqData', mtype: 'POST', postData: { accountNumber: accountNumber } }).trigger('reloadGrid');
    }

};

var displayDetails = function (show) {
    if (!show)
        $('#details').hide();
    else
        $('#details').show();
};

var GridColumns = ["Id", "Account Number", "Borrower Name", "Date Entered", "Status", "Doc Type", "Assignor", "Assignee", "", "", ""];
var GridColumnData = [
    { name: "ASSIGNMENT_ID", hidden: true },
    { name: "ACCOUNT_NUMBER", width: 100, align: "left" },
    { name: "BORROWER_LAST_NAME", width: 200, align: "left" },
    { name: "DATE_ENTERED", width: 100, align: "left", sorttype: "date", sortable: true },
    { name: "Status", width: 200, align: "left" },
    { name: "DocumentType", width: 100, align: "left" },
    { name: "ASSIGNOR", width: 100, align: "left" },
    { name: "ASSIGNEE", width: 100, align: "left" },
    { name: "act", width: 100, align: "left", formatter: 'actions', formatoptions: { delbutton: false, editbutton: false } },
    { name: "record", width: 150, align: "left", formatter: 'actions', formatoptions: { delbutton: false, editbutton: false } },
    { name: "new", width: 150, align: "left", formatter: 'actions', formatoptions: { delbutton: false, editbutton: false } }
];
var loadGridData = function () {
    var grid = $('#jqTable');
    $("#jqTable").jqGrid({
        datatype: "local",
        colNames: GridColumns,
        colModel: GridColumnData,
        // Grid total width and height
        width: "auto",
        height: 'auto',
        sortable: true,
        //postData: { accountNumber: accountNumber },
        // Paging
        toppager: true,
        pager: $("#jqTablePager"),
        rowNum: 5,
        rowList: [5, 10, 20],
        caption: 'Assignments',
        viewrecords: true, // Specify if "total number of records" is displayed
        // Default sorting
        sortname: "DATE_ENTERED",
        sortorder: "asc",
        loadonce: false,
        
        loadComplete: function () {

           // 
            var iCol = getColumnIndexByName(grid, 'act');
            var iRec = getColumnIndexByName(grid, 'record');
            var inew = getColumnIndexByName(grid, 'new');
            grid.children("tbody")
                .children("tr.jqgrow")
                .children("td:nth-child(" + (iCol + 1) + ")")
                .each(function () {
                    $("<div>",
                        {
                            //style: "margin-left: 5px; float:left",
                            //class: "ui-pg-div ui-inline-custom",
                            title: "Details",
                            mouseover: function () {
                                $(this).addClass('ui-state-hover');
                            },
                            mouseout: function () {
                                $(this).removeClass('ui-state-hover');
                            },
                            click: function (e) {
                                e.preventDefault();
                                //alert("'Custom' button is clicked in the rowis=" +
                                //      $(e.target).closest("tr.jqgrow").attr("id") + " !");
                                var celValue = $(e.target).closest("tr.jqgrow").attr("id");
                                var id = grid.jqGrid('getRowData', celValue).ASSIGNMENT_ID;
                                getAssignmentDetails(id, "update");
                                //alert(id);
                            }
                        }
                      ).css({ "margin-left": "5px", float: "left" })
                       .addClass("ui-pg-div ui-inline-custom")
                        .append('<a style="font-weight:bold;color:blue" href="href="javascript:void(0)"">View Details</a>')
                       //.append('<span class="ui-icon ui-icon-document"><label>Details</label></span>')
                       .appendTo($(this).children("div"));
                });
            grid.children("tbody")
                .children("tr.jqgrow")
                .children("td:nth-child(" + (iRec + 1) + ")")
                .each(function () {
                    $("<div>",
                      {
                          //style: "margin-left: 5px; float:left",
                          //class: "ui-pg-div ui-inline-custom",
                          title: "Recorded Assignments",
                          mouseover: function () {
                              $(this).addClass('ui-state-hover');
                          },
                          mouseout: function () {
                              $(this).removeClass('ui-state-hover');
                          },
                          click: function (e) {
                              e.preventDefault();
                              //alert("'Custom' button is clicked in the rowis=" +
                              //      $(e.target).closest("tr.jqgrow").attr("id") + " !");
                              var celValue = $(e.target).closest("tr.jqgrow").attr("id");
                              var id = grid.jqGrid('getRowData', celValue).ASSIGNMENT_ID;
                              getAssignmentDetails(id, "recordedAssignments");
                              //alert(id);
                          }
                      }
                    ).css({ "margin-left": "5px", float: "left" })
                     .addClass("ui-pg-div ui-inline-custom")
                      .append('<a style="font-weight:bold;color:blue" href="javascript:void(0)">Recorded Assignments</a>')
                     //.append('<span class="ui-icon ui-icon-document"><label>Details</label></span>')
                     .appendTo($(this).children("div"));
                });
            grid.children("tbody")
                .children("tr.jqgrow")
                .children("td:nth-child(" + (inew + 1) + ")")
                .each(function () {
                    $("<div>",
                      {
                          //style: "margin-left: 5px; float:left",
                          //class: "ui-pg-div ui-inline-custom",
                          title: "new ",
                          mouseover: function () {
                              $(this).addClass('ui-state-hover');
                          },
                          mouseout: function () {
                              $(this).removeClass('ui-state-hover');
                          },
                          click: function (e) {
                              e.preventDefault();
                              //alert("'Custom' button is clicked in the rowis=" +
                              //      $(e.target).closest("tr.jqgrow").attr("id") + " !");
                              var celValue = $(e.target).closest("tr.jqgrow").attr("id");
                              var id = grid.jqGrid('getRowData', celValue).ASSIGNMENT_ID;
                              getAssignmentDetails(id, "newRecord");
                              //alert(id);
                          }
                      }
                    ).css({ "margin-left": "5px", float: "left" })
                     .addClass("ui-pg-div ui-inline-custom")
                      .append('<a style="font-weight:bold;color:blue" href="javascript:void(0)">New Rec Assig</a>')
                     //.append('<span class="ui-icon ui-icon-document"><label>Details</label></span>')
                     .appendTo($(this).children("div"));
                });
            //hideGridIfNoRecordsFound();
        }

        // Grid caption
        //caption: "A Basic jqGrid - Read Only"
    }).navGrid("#jqTablePager",
            { refresh: true, add: false, edit: false, del: false },
                {}, // settings for edit
                {}, // settings for add
                {}, // settings for delete
                { sopt: ["cn"] } // Search options. Some options can be set on column level
         );
};
var getColumnIndexByName = function (grid, columnName) {

    var cm = grid.jqGrid('getGridParam', 'colModel'), i = 0, l = cm.length;
    for (; i < l; i += 1) {
        if (cm[i].name === columnName) {
            return i; // return the index
        }
    }
    return -1;
};

var GetCustodianAndNotesDetails = function () {

    var accountNumber = $("#ACCOUNT_NUMBER").val();
    var assignmentId = $("#ASSIGNMENT_ID").val();
    var transacitonType = $("#TransactionType").val();
    if (accountNumber != '') {
        showLoading(true);
        $("#custodianDetailsPanel").show();
        //var url = transacitonType == "Update" ? "Assignments/GetCustodianDetails" : "GetCustodianDetails";
        var url = "GetCustodianAndNotesDetails";
        $.ajax({
            url: url,
            datatype: "json",
            type: "POST",
            data: { accountNumber: accountNumber, assignmentId: assignmentId }
        }).success(function (result) {
            showLoading(false);
            if (result.custodianDetails != null) {
                displayCustomMessageForCustodian(false);
                $('#CUSTODIAN_ID').val(result.custodianDetails.CustodianId);
                $("#txtCustodian").val(result.custodianDetails.CustodianName);
                $("#BORROWER_LAST_NAME").val(result.custodianDetails.BorrowerName);
                $("#txtCustodianRef").val(result.custodianDetails.CustRefNumber);
                $("#txtMersInfoNumber").val(result.custodianDetails.MersInfoNumber);
                $("#txtAcquiredFrom").val(result.custodianDetails.AcquiredFrom);
                $("#txtServicingFor").val(result.custodianDetails.ServicingFor);
                $('#MERS_INFO_NUMBER').val(result.custodianDetails.MersInfoNumber);
                $("#LSCOD1").val(result.custodianDetails.LSCOD1);
                $("#SBSCOD").val(result.custodianDetails.SBSCOD);
            } else {
                displayCustomMessageForCustodian(true);
            }
            if (result.notes && result.notes.length > 0) {
                var notesList = result.notes;
                var existingNotes = '';
                $.each(notesList, function (index, item) {
                    var ctrl = $('#txtExistingNotes');
                    ctrl.val(ctrl.val() + item + '\n');
                });

            }
        })

            .error(function (xhr, status) {
                showLoading(false);
            });
    }
};

var getAssignmentDetails = function (id, type) {
    var accountNumber = $('#accountNumber').val();
    showLoading(true);
    var url = "GetDetails?assignmentId=" + id + "&accountNumber=" + accountNumber + "&type=" + type;
    $.ajax({
        url: url,
        //  data: { id: id, loanNumber: loanNumber },
        //contentType: 'application/html;charset=utf-8',
        type: 'GET',
        //dataType: 'html'
    }).success(function (result) {
        displayDetails(true);
        showLoading(false);
        $('#details').html(result);
        GetCustodianAndNotesDetails();
        docTypeBusinessRules();
        recordStatusBusinessRules();
       // statusDateBusinessRules();
        //assignedToBusinessRules();
        setAssignmentDate();
        setRecordStatusDate();
        $("#DATE_ENTERED,#LAST_STATUS_DATE,#ASSIGNED_DATE").datepicker();
        $('#custodianDetailsPanel').show();
        enableControlsForAdmin();
    }).error(function (xhr, status) {
        showLoading(false);
        alert(status);
    });
};

var applyDateRules = function () {
    $('body').on('focus', ".datepicker", function () {
        $(this).datepicker();
    });

};

var addValidator = function (control, message) {
    control.addClass('form-control input-validation-error');
    control.attr('data-val-required', message);
};

var removeValidator = function (control) {
    control.removeClass('form-control input-validation-error');
};

var showLoading = function (show) {
    if (show) {
        $("#divModalPoup").dialog({
            modal: true
            // open: function(event, ui) { $(".ui-dialog-titlebar-close", ui.dialog || ui).hide(); }
        });
        $(".ui-dialog-titlebar").hide();
        $(".ui-dialog-titlebar-close").hide();
    } else {
        $("#divModalPoup").dialog('close');
    }

};

var hideGridIfNoRecordsFound = function () {
    var recs = parseInt($("#jqTable").getGridParam("records"), 10);
    if (isNaN(recs) || recs == 0) {
        $("#loadGrid").hide();
        $('#divNoRecordsFound').show();
    } else {
        $('#loadGrid').show();
        $('#divNoRecordsFound').hide();
    }
};

function displayCustomMessageForCustodian(show) {
    if (show) {
        $('#divNoCustodianDetailsFound').show();
    } else {
        $('#divNoCustodianDetailsFound').hide();
    }
}

function setAssignmentDate() {
    $('#ASSIGNED_DATE').val($('#ASSIGNED_DATE').val().replace('12:00:00 AM', ''));
}

var addLookUp = function (ele, transactionType) {
    var current = $(ele).attr("LookupType");
    var dropdown = '#ddl' + $(ele).attr("id");
    var name = $(ele).attr("id");
    var id = $('' + dropdown + '').val();
    var value = $('' + dropdown + ' :selected').text();
     $('#txtLookupId').val(id);
    $('#txtLookupName').val(name);
    $('#txtLookupType').val(current);
    $('#txtOperation').val(transactionType);
    $('#divLookupName').hide();
    $('#divLookupType').hide();
    $('#divLookupId').hide();
    if (transactionType == 'Delete') {
        $('#txtValue').val(value);
    }
    else {
        $('#txtValue').val('');
    }
    $('#lbllookupName').text(name);
    $("#addLookUpModal").dialog({
        modal: true,
        width: 700,
        height: 200
    });
};



var submitLookup = function () {
    var lookupValue = $('#txtValue').val();
    var lookupType = $('#txtLookupType').val();
    var lookupName = $('#txtLookupName').val();
    var lookupId = $('#txtLookupId').val();
    var submitType = $('#txtOperation').val();
    var addLookupValue = "AddLookUpValue";
    var dropdown = "#ddl" + lookupName;
    var hasOtherDropDowns = false;
    var processedBy,enteredBy;
    //Remove data from AssignedTo,ProcessedBy and EnteredBy
    if (lookupName == 'AssignedTo') {
         processedBy= "#ddlProcessedBy";
        enteredBy = '#ddlEnteredBy';
        hasOtherDropDowns = true;
    }
    $.ajax({
        url: addLookupValue,
        datatype: "json",
        type: "POST",
        data: { Value: lookupValue, Type: lookupType, Section: 'ASM', Id: lookupId, Transaction: submitType }
    }).success(function (result) {
        if (result.IsSuccess) {
            var ddl = $(dropdown);
            $(ddl).empty();
            if (hasOtherDropDowns) {
                $("#ddlEnteredBy").empty();
                $("#ddlProcessedBy").empty();
            }
            var items = [];
            items.push("<option value=0>Please Select</option>");
            $.each(result.data, function () {
                if (this.LOOKUP_VALUE != 'Please Select') {
                    items.push("<option value=" + this.LOOKUP_ID + ">" + this.LOOKUP_VALUE + "</option>");
                }
            });

            ddl.html(items.join(' '));
            if (hasOtherDropDowns) {
                $("#ddlEnteredBy").html(items.join(' '));
                $("#ddlProcessedBy").html(items.join(' '));
            }
            $('#txtValue').val('');
            $('#addLookUpModal').dialog('close');
        }
    });

};


var submitAssignment = function (event) {
    event.preventDefault();
    if (event.keyCode != 13) {
        var submitForm = true;
        var selectedValue = $("#ddlStatus option:selected").text();
        var accountNumber = $('#ACCOUNT_NUMBER').val();
        var trackingNumber = $('#TRACKING_NUMBER').val();
        $('#Notes').val($('#txtNotes').val());
        if (selectedValue == "Complete - Shipped") {
            submitForm = trackingNumber != '';
        }

        var url = $('#assignmentForm').attr("action");
        var formData = $('#assignmentForm').serialize();

        if (submitForm && accountNumber != '' && $('#assignmentForm').valid()) {
            showLoading(true);

            $.ajax({
                url: url,
                type: "POST",
                data: formData,
                // dataType: "json",
                success: function (result) {
                    showLoading(false);
                    window.location.href = "/Home/?id=" + accountNumber;
                    //$("#result").text(result.data);
                },
                error: function (result) {
                    showLoading(false);
                    $("#result").val("Assingment Request Failed");
                }
            });
        } else {
            if (!submitForm) {
                if ($('#TRACKING_NUMBER').attr('data-val-required') != "Tracking Number Required") {
                    $('#TRACKING_NUMBER').addClass('form-control input-validation-error');
                    $('#TRACKING_NUMBER').attr('data-val-required', "Tracking Number Required").after('<span for="TRACKING_NUMBER" generated="true" style="color: #e80c4d;font-weight: bold;">Tracking Number Requried</span>');
                }
            }
            if (accountNumber == '') {
                if ($('#ACCOUNT_NUMBER').attr('data-val-required') != "Account Number Required") {
                    $('#ACCOUNT_NUMBER').addClass('form-control input-validation-error');
                    $('#ACCOUNT_NUMBER').attr('data-val-required', "Account Number Required").after('<span for="ACCOUNT_NUMBER" generated="true" style="color: #e80c4d;font-weight: bold;">Account Number Requried</span>');
                }
            }
        }
    }
};
var enableControlsForAdmin = function (){
    var isAdmin = $('#hdnRole').val();
    if (isAdmin == "True") {
        $("#DATE_ENTERED,#LAST_STATUS_DATE,#ASSIGNED_DATE").datepicker();
        $('#ASSIGNOR,#ASSIGNEE,#DATE_ENTERED,#LAST_STATUS_DATE').prop('readonly',false);
    }
};


//$('#loadGrid').ajaxStart(function () {
//    console.log('ajax request started');
//});

$('#loadGrid').ajaxStop(function () {
    hideGridIfNoRecordsFound();
});

