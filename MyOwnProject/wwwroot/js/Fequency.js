var datatable;

$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {

    datatable = $('#tblFreqData').DataTable({
        "ajax": {
            "url": "/admin/frequency/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "50%" },
            { "data": "frequencyCount", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/frequency/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px; border-radius:1rem;'>
                                    <i class="far fa-edit"></i> Edit 
                                 </a> 
                                &nbsp;
                                 <a onClick=Delete('/Admin/frequency/Delete/${data}') class='btn btn-danger text-white' style='cursor:pointer; width:100px; border-radius:1rem;'>
                                    <i class="far fa-trash-alt"></i> Delete 
                                </a> 
                            </div>
                            `;
                }, "width": "30%"

            }
        ],
        "language": {
            "emptyTable": "No Record Found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are You sure You want To delete?",
        text: "You will not be able to restore the file!!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "DD6B55",
        confirmButtonText: "Yes,Delete It",
        closeOnConfirm: true
    },
        function () {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        ShowMessage(data.message);
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        });
}

function ShowMessage(message) {
    toastr.success(message);
}