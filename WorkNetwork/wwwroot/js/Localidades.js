const CompletarTablaLocalidades = async () => {
    await VaciarFormulario()

    let url = '../../Localidades/TablaLocalidades'

    $.get(url).done(async localidades => {
        $('#tbody-localidad').empty();
        $.each(localidades, await function (index, localidades) {
            let claseEliminado = '';
            let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-1' onclick = "BuscarLocalidad(${localidades.localidadID})"><i class="bi bi-pencil-square"></i><i class="ocultarCol767"> Editar</i></btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarLocalidad(${localidades.localidadID},1)"><i class="bi bi-trash3"></i><i class="ocultarCol767"> Deshabilitar<i/></btn>`;

            if (localidades.eliminado) {
                claseEliminado = 'table-danger';
                botones = `<btn type='button' class = 'btn btn-outline-primary btn-sm'onclick = "EliminarLocalidad(${localidades.localidadID},0)"><i class="bi bi-arrow-clockwise"></i> Habilitar</btn>`;
            }
            $("#tbody-localidad").append(
                `<tr class= 'tabla-hover ${claseEliminado} '>
                        <td class='texto'>${localidades.nombreLocalidad}</td>
                        <td class='texto'>${localidades.nombreProvincia}</td>
                        <td class='texto ocultarCol767'>${localidades.cp}</td>
                        <td class='text-end'>
                            ${botones}
                        </td>
                    </tr>`
            )
        })
    }).fail(e => console.error('Error al cargar tabla localidades ' + e))
}

const localidadRegex = /^[0-9A-Za-záéíóúüÜñÑ\s]+$/u;
const cpRegex = /^[0-9]+$/;
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
        if (localidadRegex.test(nombreLocalidad)) {
            if (cpLocalidad != null && cpLocalidad != undefined && cpLocalidad != 0) {
                if (cpRegex.test(cpLocalidad)) {
                    if (idPais != 0) {
                        if (idProvincia != 0) {
                            $.post(url, data).done(resultado => {
                                if (resultado == 0) {
                                    $('#modalCrearLocalidad').modal('hide');
                                    CompletarTablaLocalidades();

                                } else if (resultado == 2) {
                                    alertLocalidad.removeClass('visually-hidden').text('La localidad ingresada ya existe.');

                                } else if (resultado == 3) {
                                    alertLocalidad.removeClass('visually-hidden').text('El código postal ya existe.');
                                }

                            }).fail(e => console.log(`Error en guardar localidad ${e}`))

                        } else alertLocalidad.removeClass('visually-hidden').text('Debe seleccionar una provincia');

                    } else alertLocalidad.removeClass('visually-hidden').text('Debe seleccionar un país.');

                } else alertLocalidad.removeClass('visually-hidden').text('Sólo números');

            } else alertLocalidad.removeClass('visually-hidden').text('Debe ingresar el código postal.');

        } else alertLocalidad.removeClass('visually-hidden').text('El nombre no es correcto');

    } else alertLocalidad.removeClass('visually-hidden').text('Debe ingresar el nombre de la localidad.');
        setTimeout(() => alertLocalidad.addClass("visually-hidden"), 5000);
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
    $('#Titulo-Modal-Localidad').text('Agregar Nueva Localidad');
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
                : alert("No se puede deshabilitar porque usuarios o vacantes utilizan la Localidad.");
        },
        error: function (data) {
        }
    });
}