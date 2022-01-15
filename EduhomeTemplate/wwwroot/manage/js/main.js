$(function () {
    $(document).on("click", ".image-delete-btn", function () {
        $(".image-box").remove();
        $(".image-box-index").remove();
    })

    $(document).on("click", ".deleteBtn", function () {
        alert("click")
        let roleID = $(this).attr("data-id")
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(`role/delete/${roleID}`)
                    .then(response => {
                        console.log(response)
                        var statusCode = response.status;
                        if (response.ok)
                        {
                            Swal.fire(
                                'Deleted!',
                                'Your file has been deleted.',
                                'success'
                            ).then((input) =>
                            {
                                if (input.isConfirmed)
                                {
                                    window.location.reload(true)
                                }
                            })
                        }
                       
                    })
            }
            else if (result.dismiss === Swal.DismissReason.cancel) {
                swalWithBootstrapButtons.fire(
                    'Cancelled',
                    'Your imaginary file is safe :)',
                    'error'
                )
            }
        })
    })
})