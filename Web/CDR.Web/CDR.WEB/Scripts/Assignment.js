$(document).ready(function () {
    $('#accountNumber').numericOnly();
    $('#search').bind('click', loadGrid);
    $('#ddlDocumentType').on('change', docTypeBusinessRules);
    // $('#search').bind('click', getRecords);
});


var getRecords = function () {
    var id = $('#accountNumber').val();

    var url = "GetAssignmentsById/";
    $.ajax({
        url: url + id,
        contentType: 'application/html;charset=utf-8',
        type: 'GET',
        dataType: 'html'
    }).success(function (result) {
        $('#records').html(result);
    })
        .error(function (xhr, status) {
            alert(status);
        });
};

function Details(id, accountNumber, type) {
    showDetails();
    var url = "GetDetails?assignmentId=" + id + "&accountNumber=" + accountNumber + "&type=" + type;
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
    event.preventDefault();
    Details(id, accountNumber);
}
var GetCustodianDetails = function () {
    var accountNumber = $("#ACCOUNT_NUMBER").val();
    if (accountNumber != '') {
        $("#custodianDetailsPanel").show();
        var url = "Assignments/GetCustodianDetails";
        $.ajax({
            url: url,
            datatype: "json",
            type: "POST",
            data: { accountNumber: accountNumber }
        }).success(function (result) {
            $('#CUSTODIAN_ID').val(result.data.CustodianId);
            $("#txtCustodian").val(result.data.CustodianName);
            $("#BORROWER_LAST_NAME").val(result.data.BorrowerName);
            $("#txtCustodianRef").val(result.data.CustRefNumber);
            $("#txtMersInfoNumber").val(result.data.MersInfoNumber);
            $("#txtAcquiredFrom").val(result.data.AcquiredFrom);
            $("#txtServicingFor").val(result.data.ServicingFor);
        })
            .error(function (xhr, status) {

            });
    }
};

function loadGrid() {
    var accountNumber = $('#accountNumber').val();
    var url = "LoadjqData";

    $("#jqTable").jqGrid({
        // Ajax related configurations
        url: url,
        datatype: "json",
        mtype: "POST",

        colNames: ["Id", "Account Number", "Borrower Name", "Date Received", "Status", "",""],

        // Configure the columns
        colModel: [
            { name: "ASSIGNMENT_ID", hidden: true },
        { name: "ACCOUNT_NUMBER", width: 150, align: "left" },
        { name: "BORROWER_LAST_NAME", width: 200, align: "left" },
        { name: "DATE_CREATED", width: 100, align: "left", formatter: "date", sorttype: "date" },
        { name: "STATUS_ID", width: 100, align: "left" },

            {
                name: "act",
                width: 100,
                align: "left",
                formatter: 'actions',
                formatoptions: {
                    delbutton: false,
                    editbutton: false
                }
            },
             {
                 name: "record",
                 width: 250,
                 align: "left",
                 formatter: 'actions',
                 formatoptions: {
                     delbutton: false,
                     editbutton: false
                 }
             }

        ],

        // Grid total width and height
        width: "auto",
        height: 'auto',
        sortable: true,
        postData: { accountNumber: accountNumber },
        // Paging
        toppager: true,
        pager: $("#jqTablePager"),
        rowNum: 5,
        rowList: [5, 10, 20],
        viewrecords: true, // Specify if "total number of records" is displayed

        // Default sorting
        sortname: "Date Received",
        sortorder: "asc",
        loadComplete: function () {
            var iCol = getColumnIndexByName(grid, 'act');
            var iRec = getColumnIndexByName(grid, 'record');
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
                                //alert("'Custom' button is clicked in the rowis=" +
                                //      $(e.target).closest("tr.jqgrow").attr("id") + " !");
                                var celValue = $(e.target).closest("tr.jqgrow").attr("id");
                                var id = grid.jqGrid('getRowData', celValue).ASSIGNMENT_ID;
                                Details(id, accountNumber, "update");
                                //alert(id);
                            }
                        }
                      ).css({ "margin-left": "5px", float: "left" })
                       .addClass("ui-pg-div ui-inline-custom")
                        .append('<a href="#">Details</a>')
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
                              //alert("'Custom' button is clicked in the rowis=" +
                              //      $(e.target).closest("tr.jqgrow").attr("id") + " !");
                              var celValue = $(e.target).closest("tr.jqgrow").attr("id");
                              var id = grid.jqGrid('getRowData', celValue).ASSIGNMENT_ID;
                              Details(id, accountNumber, "recordedAssignments");
                              //alert(id);
                          }
                      }
                    ).css({ "margin-left": "5px", float: "left" })
                     .addClass("ui-pg-div ui-inline-custom")
                      .append('<a href="#">Recorded Assignments</a>')
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


}

var grid = $("#jqTable");
var getColumnIndexByName = function(grid, columnName) {
    var cm = grid.jqGrid('getGridParam', 'colModel'), i = 0, l = cm.length;
    for (; i < l; i += 1) {
        if (cm[i].name === columnName) {
            return i; // return the index
        }
    }
    return -1;
};

var showDetails = function () {
    $("#details").show();
};

var docTypeBusinessRules = function () {
    var selectedValue = $("#ddlDocumentType option:selected").text();
    if (selectedValue != "Assignment" || selectedValue != "Allonge") {
        $("#ASSIGNOR").removeAttr("disabled", false);
        $('#ASSIGNEE').removeAttr('disabled', false);

    } else {
        $("#ASSIGNOR").attr("disabled", true);
        $('#ASSIGNEE').attr('disabled', true);
    }
};

