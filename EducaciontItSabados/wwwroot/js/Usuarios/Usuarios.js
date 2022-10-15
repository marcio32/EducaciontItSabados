$(document).ready(function () {
    $('#usuarios').DataTable({
        ajax: {
            url: 'https://localhost:7187/api/usuarios/buscarusuarios',
            dataSrc: ''
        },
        columns: [
            { data: 'id', title: 'Id' },
            { data: 'nombre', title: 'Nombre' },
            { data: 'apellido', title: 'Apellido' },
            {
                data: function (row) {
                    debugger
                    return moment(row.fecha_Nacimiento).format("DD/MM/YYYY")
                }, title: 'Fecha de nacimiento' },
            { data: 'clave', title: 'Clave' },
            { data: 'mail', title: 'Mail' },
            { data: 'id_Rol', title: 'Rol' },
            {
                data: function (row)
                {
                    return row.activo == true ? "Si" : "No";
                }, title: 'Activo'
            },
            { data: 'codigo', title: 'Codigo' },
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
        contentType: "html",
        success: function (resultado) {
            debugger
            $('#usuariosAddPartial').html(resultado)
            $('#usuarioModal').modal('show');
        }
    })
}