$(function () {
    //wait for DOM to be loaded ( ready function )

    //DataTables
    $("#tablesorted").DataTable({
        "columnDfs": [
            { "orderable": false, "targets": -1 },//stop sorting on last column
        ],
        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]]//drop down for how many entries
    });
});