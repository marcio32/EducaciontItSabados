var tablaRoles
$(document).ready(function () {
    var token = getCookie("Token");
    tablaRoles = $('#roles').DataTable({
        ajax: {
            url: 'https://localhost:7187/api/roles/buscarroles',
            dataSrc: '',
            headers: {"Authorization": "Bearer " + token}
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
                        `<td><a href='javascript:EditarRol(${JSON.stringify(row)})' <i class="fa-solid fa-pen-to-square editarRol"></i></td>` +
                        `<td><a href='javascript:EliminarRol(${JSON.stringify(row)})' <i class="fa-solid fa-trash eliminarRol"></i></td>`
                    return botones;

                }
            }

        ],
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.12.1/i18n/es-ES.json'
        }
    });
});

function GuardarRol() {
    $.ajax({
        type: "POST",
        url: "/Roles/RolesAddPartial",
        data: "",
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#rolesAddPartial').html(resultado)
            $('#rolModal').modal('show');
        }
    })
}

function EditarRol(row) {
    $.ajax({
        type: "POST",
        url: "/Roles/RolesAddPartial",
        data: JSON.stringify(row),
        contentType: "application/json",
        dataType: "html",
        success: function (resultado) {
            $('#rolesAddPartial').html(resultado)
            $('#rolModal').modal('show');
        }
    })
}

function EliminarRol(row) {
    Swal.fire({
        title: 'Estas Seguro?',
        text: "Vas a eliminar al rol!",
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
                url: "/Roles/EliminarRol",
                data: JSON.stringify(row),
                contentType: "application/json",
                dataType: "html",
                success: function () {
                    Swal.fire(
                        'Eliminado!',
                        'Se elimino el rol.',
                        'success'
                    )
                    tablaRoles.ajax.reload();
                }
            })

            
        }
    })

    
}