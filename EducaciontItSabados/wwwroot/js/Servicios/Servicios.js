var tablaServicios
$(document).ready(function () {
    var token = getCookie("Token");
    var AjaxUrl = getCookie("AjaxUrl");
    tablaServicios = $('#servicios').DataTable({
        ajax: {
            url: `${AjaxUrl}servicios/buscarservicios`,
            dataSrc: '',
            headers: { "Authorization": "Bearer " + token }
        },
        columns: [
            { data: 'id', title: 'Id' },
            { data: 'nombre', title: 'Nombre' },
            {
                data: function (row) {
                    return row.activo == true ? "Si" : "No";
                }, title: 'Activo'
            },
            {
                data: function (row) {
                    var botones =
                        `<td><a href='javascript:EditarServicio(${JSON.stringify(row)})' <i class="fa-solid fa-pen-to-square editarServicio"></i></td>` +
                        `<td><a href='javascript:EliminarServicio(${JSON.stringify(row)})' <i class="fa-solid fa-trash eliminarServicio"></i></td>`
                    return botones;

                }
            }

        ],
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.12.1/i18n/es-ES.json'
        }
    });
});

function GuardarServicio() {
    $.ajax({
        type: "POST",
        url: "/Servicios/ServiciosAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#serviciosAddPartial').html(resultado)
            $('#servicioModal').modal('show');
        }
    })
}

function EditarServicio(row) {
    $.ajax({
        type: "POST",
        url: "/Servicios/ServiciosAddPartial",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#serviciosAddPartial').html(resultado)
            $('#servicioModal').modal('show');
        }
    })
}

function EliminarServicio(row) {
    Swal.fire({
        title: 'Estas Seguro?',
        text: "Vas a eliminar al servicio!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar!',
        cancelButtonText:'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "/Servicios/EliminarServicio",
                data: JSON.stringify(row),
                contentType: "application/json",
                dataType: "html",
                success: function () {
                    Swal.fire(
                        'Eliminado!',
                        'Se elimino el servicio.',
                        'success'
                    )
                    tablaServicios.ajax.reload();
                }
            })

            
        }
    })
}

function SincronizarServicio() {
    $.ajax({
        type: "POST",
        url: "/Servicios/SincronizarServicio",
        contentType: "application/json",
        success: function (resultado) {
            debugger
            if (!resultado) {
                Swal.fire(
                    'Cuidado!',
                    'Ya existe el elemento, no se puede volver a guardar',
                    'warning'
                )
            }
            tablaServicios.ajax.reload();
        }
    })
}