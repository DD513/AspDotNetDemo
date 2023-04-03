var dataTable;
$(document).ready(function () {

    var url = window.location.search;
    console.log(url)
    if (url.includes("Processing")) {
        loadDataTable("Processing");
    }
    else {
        if (url.includes("Pending")) {
            loadDataTable("Pending");
        }
        else {
            if (url.includes("Ready")) {
                loadDataTable("Ready");
            }
            else {
                if (url.includes("Completed")) {
                    loadDataTable("Completed");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status,
        },
        "columns": [//注意這裡的欄位數量要跟html的欄位數量相同，否則會報錯
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
            { "data": "orderTotal", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/Admin/Order/Details?orderId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i></a>
                        </div>
                    `
                },
                "width": "5%"
            },
        ]
    });
}