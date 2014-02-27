$(document).ready(function () {
    $('#accountNumber').numericOnly();
    $('#subRequestSearch').bind('click', loadRecords);
});



function loadGrid() {
    var accountNumber = $('#accountNumber').val();
    var url = "SubRequestSearchUpdate/LoadjqData";

    $("#jqTable").jqGrid({
        // Ajax related configurations
        url: url,
        datatype: "json",
        mtype: "POST",

        colNames: ["Loan Number", "Account Number", "Last Name", "Date Received"],

        // Configure the columns
        colModel: [
        { name: "ID", width: 40, align: "left" },
        { name: "GT_Loan_Number", width: 100, align: "left" },
        { name: "Borrower_Last_Name", width: 200, align: "left" },
        { name: "Date_Received", width: 200, align: "left", formatter: "date", sorttype: "date" }],
        // Grid total width and height
        width: 'auto',
        height: 'auto',
        sortable: true,
        postData: { accountNumber: accountNumber },
        // Paging
        toppager: true,
        pager: $("#jqTablePager"),
        rowNum: 10,
        rowList: [5, 10, 20],
        viewrecords: true, // Specify if "total number of records" is displayed

        // Default sorting
        sortname: "DateReceived",
        sortorder: "asc",
        loadComplete: function () {
            var $self = $(this);
            if ($self.jqGrid("getGridParam", "datatype") === "json") {
                setTimeout(function () {
                    $(this).trigger("reloadGrid"); // Call to fix client-side sorting
                }, 50);
            }
        },

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

function loadRecords() {
    var accountNumber = $('#accountNumber').val();

    var url = "SubRequestSearchUpdate/Search/";
    var data;
    $.ajax({
        url: url + accountNumber,
        contentType: 'application/html;charset=utf-8',
        type: 'GET',
        dataType: 'html'
    }).success(function (result) {
        $('#loadRecords').html(result);
    })
        .error(function (xhr, status) {
            alert(status);
        });
}


function loadModal(id,loanNumber) {
    ShowSubRequestDetails(id,loanNumber);
   // loadGrid(processName);
    $("#subRequestModal").modal('show');
}

function ShowSubRequestDetails(id, loanNumber) {
    var url = "SubRequestSearchUpdate/GetSubRequestDetails?id="+id+"&loanNumber="+loanNumber;
    $.ajax({
        url: url,
      //  data: { id: id, loanNumber: loanNumber },
        contentType: 'application/html;charset=utf-8',
        type: 'POST',
        dataType: 'html'
    }).success(function (result) {
        $('#loanDetails').html(result);
    })
           .error(function (xhr, status) {
               alert(status);
           });
}

