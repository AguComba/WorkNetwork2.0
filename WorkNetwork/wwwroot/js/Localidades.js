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
    let idLocalidad = $('#idLocalidad').val();
    let nombreLocalidad = $('#nombreLocalidad').val().trim();
    let cpLocalidad = $('#cpLocalidad').val();
    let idProvincia = $('#idProvincia').val();
    let idPais = $('#idPais').val();
    let alertLocalidad = $('#alertLocalidad')
    let url = '../../Localidades/GuardarLocalidad';
    let data = { IdLocalidad: idLocalidad, NombreLocalidad: nombreLocalidad, ProvinciaID: idProvincia, CP: parseInt(cpLocalidad) };
    $('#bottonEdit').text('Agregar');
    if (nombreLocalidad != '' && nombreLocalidad != null) {

        if(cpLocalidad != null && cpLocalidad != undefined && cpLocalidad !=0){
            if(idPais != 0){
                if(idProvincia != 0){
                    $.post(url, data).done(resultado => {
                        if(resultado == 0){
                            $('#modalCrearLocalidad').modal('hide');
                            CompletarTablaLocalidades();
                        }
                        alertLocalidad.removeClass('visually-hidden').text('La localidad ingresada ya existe.')
                    }).fail(e => console.log(`Error en guardar localidad ${e}`))

                } else alertLocalidad.removeClass('visually-hidden').text('Debe seleccionar una provincia')
                            
            } else alertLocalidad.removeClass('visually-hidden').text('Debe seleccionar un pais.')
            
        } else alertLocalidad.removeClass('visually-hidden').text('Debe ingresar un codigo postal.')
                 
    }else alertLocalidad.removeClass('visually-hidden').text('Debe ingresar un nombre para la localidad.')
    
}


$('#idPais').change(() => BuscarProvincia())

const BuscarProvincia = () => {
    $('#idProvincia').empty();
    let url = '../../Provincias/ComboProvincia';
    let data = { id: $('#idPais').val() };
    $.post(url, data).done(provincias => {
        provincias.length === 0
            ? $('#idProvincia').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`)
            : $.each(provincias, (i, provincia) => {
                $('#idProvincia').append(`<option value=${provincia.value}>${provincia.text}</option>`)
            });
    }).fail(e => console.log('error en combo provincias ' + e))
    return false
}


//function BuscarLocalidad(localidadID) {
//    $("#Titulo-Modal-Localidad").text("Editar Localidad");
//    //$("#LocalidadID").val(localidadID);
//    $('#bottonEdit').text('Guardar Cambios');
//    $("#idLocalidad").val(localidadID);
//    $.ajax({
//        type: "POST",
//        url: '../../Localidades/BuscarLocalidad',
//        data: { LocalidadID: localidadID },
//        success: function (localidad) {
//            $("#NombreLocalidad").val(localidad.NombreLocalidad);
//            $("#PaisID").val(localidad.PaisID);
//            BuscarLocalidad();


//            $("#exampleModal").modal("show");
//        },
//        error: function (data) {
//        }
//    });
//}

$('#idProvincia').change(() => BuscarLocalidad())

const BuscarLocalidad = (localidadID) => {
    $("#Titulo-Modal-Localidad").text("Editar Localidad");
    $('#bottonEdit').text('Guardar Cambios');
    $("#idLocalidad").val(localidadID);
    //$("#cpLocalidad").val(cpLocalidad);
    $("#idProvincia").val(idProvincia);
    //$('#paisID').val(paisID);
    $('#alertLocalidad').addClass('visually-hidden');
    let url = '../../Localidades/BuscarLocalidad';
    let data = { LocalidadID: localidadID, };

    $.post(url, data).done(localidad => {
        $("#nombreLocalidad").val(localidad.nombreLocalidad);
        $("#idPais").val(localidad.paisID);
        $("#ProvinciaID").val(localidad.provinciaID);
        $("#cpLocalidad").val(localidad.cp);
        $("#modalCrearLocalidad").modal("show");
    }).fail(e => console.log(e));
}

//const BuscarLocalidad = (localidadID) => {
//    //$('#LocalidadID').empty();
//    $("#Titulo-Modal-Localidad").text("Editar Localidad");
//    $('#bottonEdit').text('Guardar Cambios');
//    $("#idLocalidad").val(localidadID);
//    //$("#codigoPostal").val(cpLocalidad);
//    //$('#idProvincia').val(provinciaID);
//    $('#alertLocalidad').addClass('visually-hidden');
//    let url = '../../Localidades/ComboLocalidades';
//    let data = { id: $('#ProvinciaID').val() };
//    $.post(url, data).done(localidades => {
//        localidades.length === 0
//            ? $('#LocalidadID').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`)
//            : $.each(localidades, (i, localidad) => {
//                $('#LocalidadID').append(`<option value=${localidad.value}>${localidad.text}</option>`)
//            });

//    }).fail(e => console.log('error en combo provincias ' + e))
//    return false
//}

const AbrirModal = () => {
    $('#idLocalidad').val(0);
    $('#Titulo-Modal-Localidad').text('Agregar nueva localidad');
    $('#bottonEdit').text('Agregar');
    $('#modalCrearLocalidad').modal('show');
    $("#idProvincia").val(0);
    $('#idPais').val(0);
    $('#alertLocalidad').addClass('visually-hidden');
    $('#cpLocalidad').val(undefined);
}

const VaciarFormulario = () => {
    $('#idLocalidad').val(0);
    $('#nombreLocalidad').val('');
    $('#cpLocalidad').val(undefined);
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
