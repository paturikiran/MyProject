$(document).ready(function () {
    //$("#ACCOUNT_NUMBER").numericOnly();
    bindDropDownEvents();
    bindButtonClickEvents();
    bindDateRules();
    applyDateRules();
    //loadGridData();
    // $('#loadGrid').hide();
    $("#custodianDetailsPanel").hide();
    $("body").on('blur', "#ACCOUNT_NUMBER", GetCustodianDetails);
    

});

//Binds all the dropdown change events 
var bindDropDownEvents = function () {
    $('body').on('change', '#ddlDocumentType', docTypeBusinessRules);
    $('body').on('change', '#ddlAssignedTo', assignedToBusinessRules);
    $('body').on('change', "#ddlRecordStatus", recordStatusBusinessRules);
};

//Business rule to handle AssginedTo dropdown change event
var assignedToBusinessRules = function () {
    if ($(this).val() != '0') {
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

//function to handle docType dropdown change event
var docTypeBusinessRules = function () {
    var selectedValue = $("#ddlDocumentType option:selected").text();
    if (selectedValue === "Assignment" || selectedValue === "Allonge") {
        $("#ASSIGNOR").removeAttr("disabled", false);
        $('#ASSIGNEE').removeAttr('disabled', false);

    }
    else {
        $("#ASSIGNOR").attr("disabled", true);
        $('#ASSIGNEE').attr('disabled', true);
    }
};

//function to handle recordStatus dropdown change event
var recordStatusBusinessRules = function () {
    var selectedValue = $("#ddlRecordStatus option:selected").text();
    if (selectedValue === "Recorded") {
        $(".change").removeAttr('disabled', false);
    } else {
        $(".change").attr('disabled', true);
    }
};

var bindButtonClickEvents = function () {
    $('#search').on('click', testGridData);
};

var bindDateRules = function () {
    $(".datepicker").datepicker();
    //$('#REQUEST_DATE').datepicker();
    //$('#DATE_ENTERED').datepicker({ minDate: new Date });//TO BE dISABLED
};

var getAssignments = function () {
    // showProgressBar();
    var id = $('#accountNumber').val();
    $("#jqGrid").setGridParam({ datatype: 'json' }).trigger('reloadGrid', [{ page: 1 }]);
    var url = "GetAssignmentsById/";
    $.ajax({
        url: url + id,
        contentType: 'application/html;charset=utf-8',
        type: 'GET',
        dataType: 'html'
    }).success(function (result) {
        $('#records').html(result);
        //   hideProgressBar();
    })
        .error(function (xhr, status) {
            alert(status);
            //  hideProgressBar();
        });
};

var testGridData = function () {
    $('#loadGrid').show();
    loadGridData();
    var accountNumber = $('#accountNumber').val();
    $("#jqTable").setGridParam({ datatype: 'json', url: 'LoadjqData', mtype: 'POST', postData: { accountNumber: accountNumber } }).trigger('reloadGrid');

};

var GridColumns = ["Id", "Account Number", "Borrower Name", "Date Received", "Status","Doc Type", "Assignor", "Assignee", "", "", ""];
var GridColumnData = [
    { name: "ASSIGNMENT_ID", hidden: true },
    { name: "ACCOUNT_NUMBER", width: 100, align: "left" },
    { name: "BORROWER_LAST_NAME", width: 200, align: "left" },
    { name: "DATE_ENTERED", width: 100, align: "left", formatter: "date", sorttype: "date" },
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
                        .append('<a href="href="javascript:void(0)"">View Details</a>')
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
                      .append('<a href="javascript:void(0)">Recorded Assignments</a>')
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
                      .append('<a href="javascript:void(0)">New Rec Assig</a>')
                     //.append('<span class="ui-icon ui-icon-document"><label>Details</label></span>')
                     .appendTo($(this).children("div"));
                });
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

var GetCustodianDetails = function () {

    var accountNumber = $("#ACCOUNT_NUMBER").val();
    var transacitonType = $("#TransactionType").val();
    if (accountNumber != '') {
        showLoading(true);
        $("#custodianDetailsPanel").show();
        //var url = transacitonType == "Update" ? "Assignments/GetCustodianDetails" : "GetCustodianDetails";
        var url = "GetCustodianDetails";
        $.ajax({
            url: url,
            datatype: "json",
            type: "POST",
            data: { accountNumber: accountNumber }
        }).success(function (result) {
            showLoading(false);
            $('#CUSTODIAN_ID').val(result.data.CustodianId);
            $("#txtCustodian").val(result.data.CustodianName);
            $("#BORROWER_LAST_NAME").val(result.data.BorrowerName);
            $("#txtCustodianRef").val(result.data.CustRefNumber);
            $("#txtMersInfoNumber").val(result.data.MersInfoNumber);
            $("#txtAcquiredFrom").val(result.data.AcquiredFrom);
            $("#txtServicingFor").val(result.data.ServicingFor);
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
        contentType: 'application/html;charset=utf-8',
        type: 'GET',
        dataType: 'html'
    }).success(function (result) {
        showLoading(false);
        $('#details').html(result);
        GetCustodianDetails();
        $('#custodianDetailsPanel').show();
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

var addLookUp = function (ele) {
    var current = $(ele).attr("LookupType");
    var name = $(ele).attr("id");
    $('#txtLookupName').val(name);
    $('#txtLookupType').val(current);
    $('#divLookupName').hide();
    $('#divLookupType').hide();
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
            //items.push("<option>Please Select</option>");
            $.each(result.data, function () {
                items.push("<option value=" + this.LOOKUP_ID + ">" + this.LOOKUP_VALUE + "</option>");
            });
            ddl.html(items.join(' '));
            $('#txtValue').val('');
            $('#addLookUpModal').dialog('close');
        }
    });

};

var submitAssignment = function (event) {
    event.preventDefault();
    var submitForm = true;
    var selectedValue = $("#ddlStatus option:selected").text();
    var accountNumber = $('#ACCOUNT_NUMBER').val();
    var trackingNumber = $('#TRACKING_NUMBER').val();
    if (selectedValue == "Complete - Shipped") {
        submitForm = trackingNumber != '';
    }

    if (submitForm) {
        showLoading(true);
        var url = $('#assignmentForm').attr("action");
        var formData = $('#assignmentForm').serialize();
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            dataType: "json",
            success: function (result) {
                showLoading(false);
                window.location.href = "/Home/?id=" + accountNumber;
                $("#result").text(result.data);
            },
            error: function (result) {
                showLoading(false);
                $("#result").val("Assingment Request Failed");
            }
        });
    }
    else {
        $('#TRACKING_NUMBER').addClass('form-control input-validation-error');
        $('#TRACKING_NUMBER').attr('data-val-required', "Tracking Number Required").after('<span for="TRACKING_NUMBER" generated="true" style="color: #e80c4d;font-weight: bold;">Tracking Number Requried</span>');
    }
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
