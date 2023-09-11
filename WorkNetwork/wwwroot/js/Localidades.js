const CompletarTablaLocalidades = async () => {
    await VaciarFormulario()

    let url = '../../Localidades/TablaLocalidades'

    $.get(url).done(async localidades => {
        $('#tbody-localidad').empty();
        $.each(localidades, await function (index, localidades) {
            let claseEliminado = '';
            let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarLocalidad(${localidades.localidadID})"><i class="bi bi-pencil-square"></i> Editar</btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarLocalidad(${localidades.localidadID},1)"><i class="bi bi-trash3"></i> Desactivar</btn>`

            if (localidades.eliminado) {
                claseEliminado = 'table-danger';
                botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarLocalidad(${localidades.localidadID},0)"><i class="bi bi-recycle"></i> Activar</btn>`
            }
            $("#tbody-localidad").append(
                `<tr class= 'tabla-hover ${claseEliminado} '>
                        <td class='texto'>${localidades.nombreLocalidad}</td>
                        <td class='texto'>${localidades.cp}</td>
                        <td class = 'text-end'>
                            ${botones}
                        </td>
                    </tr>`
            )
        })
    }).fail(e => console.error('Error al cargar tabla localidades ' + e))
}

const GuardarLocalidad = () => {
    let idLocalidad = $('#localidadID').val();
    let nombreLocalidad = $('#NombreLocalidad').val().trim();
    let cpLocalidad = $('#CPLocalidad').val();
    let idProvincia = $('#idProvincia').val();
    let idPais = $('#idPais').val();
    let alertLocalidad = $('#alertLocalidad')
    let url = '../../Localidades/GuardarLocalidad';
    let data = { IdLocalidad: idLocalidad, NombreLocalidad: nombreLocalidad, ProvinciaID: idProvincia, CP: parseInt(cpLocalidad) };
    $('#bottonEdit').text('Agregar');
    if (nombreLocalidad != '' && nombreLocalidad != null) {

        if (cpLocalidad != null && cpLocalidad != undefined && cpLocalidad != 0) {
            if (idPais != 0) {
                if (idProvincia != 0) {
                    $.post(url, data).done(resultado => {
                        if (resultado == 0) {
                            $('#modalCrearLocalidad').modal('hide');
                            CompletarTablaLocalidades();
                        }
                        if (resultado == 2) {
                            alertLocalidad.removeClass('visually-hidden').text('La localidad ingresada ya existe.')
                        }
                    }).fail(e => console.log(`Error en guardar localidad ${e}`))

                } else alertLocalidad.removeClass('visually-hidden').text('Debe seleccionar una provincia')

            } else alertLocalidad.removeClass('visually-hidden').text('Debe seleccionar un pais.')

        } else alertLocalidad.removeClass('visually-hidden').text('Debe ingresar un codigo postal.')

    } else alertLocalidad.removeClass('visually-hidden').text('Debe ingresar un nombre para la localidad.')

}


$('#idPais').change(function () { BuscarProvincia() });

function BuscarProvincia() {
    $('#idProvincia').empty();
    $.ajax({
        type: 'POST',
        async: false,
        url: '../../Provincias/ComboProvincia',
        data: { id: $('#idPais').val() },
        success: function (provincias) {
            if (provincias.length == 0) {
                $('#idProvincia').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`);
            }
            else {
                $.each(provincias, (i, provincia) => {
                    $('#idProvincia').append(`<option value=${provincia.value}>${provincia.text}</option>`)
                });
            }
        },
        error: function (data) {
            console.log('error en combo provincias ' + data)
        }
    });
}

function BuscarLocalidad(localidadID) {
    $("#Titulo-Modal-Localidad").text("Editar Localidad");
    $("#localidadID").val(localidadID);
    $('#bottonEdit').text('Guardar Cambios');
    $('#alertLocalidad').addClass('visually-hidden');
    $.ajax({
        type: "POST",
        async: false,
        url: '../../Localidades/BuscarLocalidad',
        data: { LocalidadID: localidadID },
        success: function (localidad) {
            $("#NombreLocalidad").val(localidad.nombreLocalidad);
            $("#idPais").val(localidad.paisID);
            BuscarProvincia();

            $("#CPLocalidad").val(localidad.cp);
            $("#idProvincia").val(localidad.provinciaID);
            $("#modalCrearLocalidad").modal("show");
        },
        error: function (data) {
        }
    });
}


const AbrirModal = () => {
    $('#localidadID').val(0);
    $('#Titulo-Modal-Localidad').text('Agregar nueva localidad');
    $('#bottonEdit').text('Agregar');
    $('#modalCrearLocalidad').modal('show');
    $("#idProvincia").val(0);
    $('#idPais').val(0);
    $('#alertLocalidad').addClass('visually-hidden');
    $('#CPLocalidad').val(undefined);
}

const VaciarFormulario = () => {
    $('#localidadID').val(0);
    $("#NombreLocalidad").val('');
    $('#CPLocalidad').val(undefined);
    $("#idProvincia").val(0);
    $('#idPais').val(0);
}

const EliminarLocalidad = (localidadID, elimina) => {
    $.ajax({
        type: "POST",
        url: '../../Localidades/EliminarLocalidad',
        data: { LocalidadID: localidadID, Elimina: elimina },
        success: function (resultado) {
            resultado == 0
                ? CompletarTablaLocalidades()
                : alert("No se puede eliminar la localidad.");
        },
        error: function (data) {
        }
    });
}