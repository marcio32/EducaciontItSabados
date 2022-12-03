var tablaUsuarios
$(document).ready(function () {
    var token = getCookie("Token");
    debugger
    tablaUsuarios = $('#usuarios').DataTable({
        ajax: {
            url: 'https://localhost:7187/api/usuarios/buscarusuarios',
            dataSrc: '',
            headers: {"Authorization": "Bearer " + token}
        },
        columns: [
            { data: 'id', title: 'Id' },
            { data: 'nombre', title: 'Nombre' },
            { data: 'apellido', title: 'Apellido' },
            {
                data: function (row) {
                    debugger
                    return moment(row.fecha_Nacimiento).format("DD/MM/YYYY")
                }, title: 'Fecha de nacimiento'
            },
            { data: 'clave', title: 'Clave' },
            { data: 'mail', title: 'Mail' },
            { data: 'roles.nombre', title: 'Rol' },
            {
                data: function (row) {
                    debugger
                    return row.activo == true ? "Si" : "No";
                }, title: 'Activo'
            },
            {
                data: function (row) {
                    var botones =
                        `<td><a href='javascript:EditarUsuario(${JSON.stringify(row)})' <i class="fa-solid fa-pen-to-square editarUsuario"></i></td>` +
                        `<td><a href='javascript:EliminarUsuario(${JSON.stringify(row)})' <i class="fa-solid fa-trash eliminarUsuario"></i></td>`
                    return botones;

                }
            }

        ],
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.12.1/i18n/es-ES.json'
        }
    });
});

function GuardarUsuario() {
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado)
            $('#usuarioModal').modal('show');
        }
    })
}

function EditarUsuario(row) {
    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#usuariosAddPartial').html(resultado)
            $('#usuarioModal').modal('show');
        }
    })
}

function EliminarUsuario(row) {
    Swal.fire({
        title: 'Estas Seguro?',
        text: "Vas a eliminar al usuario!",
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
                url: "/Usuarios/EliminarUsuario",
                data: JSON.stringify(row),
                contentType: "application/json",
                dataType: "html",
                success: function () {
                    Swal.fire(
                        'Eliminado!',
                        'Se elimino el usuario.',
                        'success'
                    )
                    tablaUsuarios.ajax.reload();
                }
            })

            
        }
    })

    
}