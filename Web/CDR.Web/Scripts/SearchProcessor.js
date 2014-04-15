$(document).ready(function () {
    $('#activeProcessor').bind('click', activeProcess)
});

//create a method per button
function activeProcess() {
    loadModal('activeProcess');
}

function loadModal(processName) {
    loadGrid(processName);
    $("#subRequestModal").modal('show');
}

function loadGrid(processName) {
    var repId = $("#LstDataRepresentative option:selected").val();
   // representativeId = 21;
    var url = "SearchProcessor/LoadjqData";

    $("#jqTable").jqGrid({
        // Ajax related configurations
        url: url,
        datatype: "json",
        mtype: "POST",

        // Specify the column names
        colNames: ["Loan Number", "Account Number", "Last Name", "Date Received"],

        // Configure the columns
        colModel: [
        { name: "ID", width: 40, align: "left" },
        { name: "GT_Loan_Number", width: 100, align: "left" },
        { name: "Borrower_Last_Name", width: 200, align: "left" },
        { name: "Date_Received", width: 200, align: "left",formatter:"date", sorttype: "date" }],

        // Grid total width and height
        width: 'auto',
        height: 'auto',
        sortable: true,
        postData: { representativeId: repId },
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
        },        // Grid caption
        //caption: "A Basic jqGrid - Read Only"
    }).navGrid("#jqTablePager",
            { refresh: true, add: false, edit: false, del: false },
                {}, // settings for edit
                {}, // settings for add
                {}, // settings for delete
                { sopt: ["cn"] } // Search options. Some options can be set on column level
         );


}

function exportData()
{
    $("#subRequestModal").modal('hide');
    var repId = $("#LstDataRepresentative option:selected").val();
    var url = "SearchProcessor/ExportSubRequestToExcel"
    $.ajax({
        url: url,
        //contentType:"application/ms-excel",
        data: { representativeId: repId },
        type: 'Post',
    }).success(function (result) {
        $("#subRequestModal").modal('hide');
    })
           .error(function (xhr, status) {
              
           });
}


