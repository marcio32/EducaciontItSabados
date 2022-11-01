var tablaProductos
$(document).ready(function () {
    tablaProductos = $('#productos').DataTable({
        ajax: {
            url: 'https://localhost:7187/api/productos/buscarproductos',
            dataSrc: ''
        },
        columns: [
            { data: 'id', title: 'Id' },
            {
                data: 'imagen', render: function (data) {
                    if (data != "") {
                        return `<img src="data:image/jpeg;base64,${data}" width="100px" heigth="100px" style="border-radius:15px">`
                    } else {
                        return `<img src="/images/Image_not_available.png" width="100px" heigth="100px" style="background-color:white; border-radius:15px">`
                    }
                } ,title: 'Imagen'
            },

            { data: 'descripcion', title: 'Descripcion' },
            { data: 'precio', title: 'Precio' },
            { data: 'stock', title: 'Stock' },
            {
                data: function (row) {
                    return row.activo == true ? "Si" : "No";
                }, title: 'Activo'
            },
            {
                data: function (row) {
                    var botones =
                        `<td><a href='javascript:EditarProducto(${JSON.stringify(row)})'</a> <i class="fa-solid fa-pen-to-square editarProducto"></i></td>` +
                        `<td><a href='javascript:EliminarProducto(${JSON.stringify(row)})'</a> <i class="fa-solid fa-trash eliminarProducto"></i></td>`
                    return botones;

                }
            }

        ],
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.12.1/i18n/es-ES.json'
        }
    });
});

function GuardarProducto() {
    $.ajax({
        type: "POST",
        url: "/Productos/ProductosAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#productosAddPartial').html(resultado)
            $('#productoModal').modal('show');
        }
    })
}

function EditarProducto(row) {
    $.ajax({
        type: "POST",
        url: "/Productos/ProductosAddPartial",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#productosAddPartial').html(resultado)
            $('#productoModal').modal('show');
        }
    })
}

function EliminarProducto(row) {
    Swal.fire({
        title: 'Estas Seguro?',
        text: "Vas a eliminar al producto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "/Productos/EliminarProducto",
                data: JSON.stringify(row),
                contentType: "application/json",
                dataType: "html",
                success: function () {
                    Swal.fire(
                        'Eliminado!',
                        'Se elimino el producto.',
                        'success'
                    )
                    tablaProductos.ajax.reload();
                }
            })


        }
    })


}