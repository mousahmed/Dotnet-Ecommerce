let datatable;
function Delete(url) {
    Swal.fire({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: `<i class="bi bi-trash"></i> Delete`,
        customClass: {
            confirmButton: "btn btn-danger",
            cancelButton: "btn btn-primary"
        },
    }).then((willDelete) => {
        console.log(willDelete);
        if (willDelete && willDelete.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        datatable.ajax.reload();
                        toastr.success(data.message);

                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    }
    );
}

function loadDataTable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Company/GetAll"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "address", "width": "10%" },
            { "data": "city", "width": "10%" },
            { "data": "state", "width": "10%" },
            { "data": "postalCode", "width": "10%" },
            { "data": "phoneNumber", "width": "10%" },

            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Company/Upsert/${data}" class="btn btn-primary btn-sm mx-2">
                                <i class="bi bi-pencil"></i> Edit
                            </a>
                            <a onclick=Delete("/Admin/Company/Delete/${data}") class="btn btn-danger btn-sm mx-2">
                                <i class="bi bi-trash"></i> Delete
                            </a>
                        </div>
                    `;
                },
            }
        ]
    });
}
$(document).ready(function () {
    loadDataTable();
});