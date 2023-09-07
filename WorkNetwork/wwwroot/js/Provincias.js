const CompletarTablaProvincias = async () => {

    await VaciarFormulario();
    let url = '../../Provincias/TablaProvincias'

    $.get(url).done(async provincias => {
        $('#tbody-provincias').empty();
        $.each(provincias, await function (index, provincia) {
            let claseEliminado = '';
            let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarProvincia(${provincia.provinciaID})"><i class="bi bi-pencil-square"></i> Editar</btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarProvincia(${provincia.provinciaID},1)"><i class="bi bi-trash3"></i> Desactivar</btn>`;
            if (provincia.eliminado) {
                claseEliminado = 'table-danger';
                botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm' onclick = 'EliminarProvincia(${provincia.provinciaID},0)'><i class="bi bi-recycle"></i> Activar</btn>`;
            }
            
            $("#tbody-provincias").append(
                `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${provincia.nombreProvincia}</td>
                        <td class='texto'>${provincia.nombrePais}</td>
                        <td class = 'text-end'>
                            ${botones}
                        </td>
                    </tr>`
            )
        })
    }).fail(e => console.error(`Error cargar provincias '${e}'`))

}

const GuardarProvincia = () => {
    let idProvincia = $('#idProvincia').val();
    let nombreProvincia = $('#nombreProvincia').val().trim();
    let idPais = $('#idPais').val();
    //let nombrePais = ('#nombrePais').val()
    let alertProvincia= $('#alertProvincia')
    let url = '../../Provincias/CrearProvincia';
    let data = { IdProvincia: idProvincia, NombreProvincia: nombreProvincia, PaisID: idPais };
    $('#bottonEdit').text('Agregar');

    if (nombreProvincia != '' && nombreProvincia != null) {
        if (idPais != 0) {
            $.post(url, data).done(resultado => {
                if (resultado == 0) {
                    $('#modalCrearProvincia').modal('hide');
                    CompletarTablaProvincias();
                }
                if (resultado == 2) {
                    alertProvincia.removeClass('visually-hidden').text('La provincia ingesada ya existe')
                }
            }).fail(e => console.error(`Error cargar provincias '${e}'`))
        }
        else alertProvincia.removeClass('visually-hidden').text('El pais no puede estar vacio')

    } else alertProvincia.removeClass('visually-hidden').text("El campo nombre no puede estar vacio")
}


//const BuscarProvincia = (provinciaID) => {
//    $("#Titulo-Modal-Provincia").text("Editar Provincia");
//    $('#bottonEdit').text('Guardar Cambios');
//    $("#idProvincia").val(provinciaID);
//    $('#idPais').val(idPais);
//    $('#alertProvincia').addClass('visually-hidden');
//    let url = '../../Provincias/BuscarProvincia';
//    let data = { ProvinciaID: provinciaID };

//    $.post(url, data).done(provincia => {
//        $("#nombreProvincia").val(provincia.nombreProvincia);
//        //$("#idProvincia").val(provinciaID);
//        $("#idPais").val(provincia.PaisID);
//        $("#modalCrearProvincia").modal("show");
//    }).fail(e => console.log(e));
//}

function BuscarProvincia(provinciaid) {
    $("#Titulo-Modal-Provincia").text("Editar Provincia");
    $('#bottonEdit').text('Guardar Cambios');
    $("#idProvincia").val(provinciaid);
    //$('#idPais').val(idPais);
    $('#alertProvincia').addClass('visually-hidden')
    $.ajax({
        type: "POST",
        url: '../../Provincias/BuscarProvincia',
        data: { ProvinciaID: provinciaid },
        success: function (provincia) {
            $("#nombreProvincia").val(provincia.nombreProvincia);
            $("#idPais").val(provincia.paisID);
            $("#modalCrearProvincia").modal("show");
        },
        error: function (data) {
        }
    });
}

//const BuscarProvincia = (provinciaID) => {
//    $('#ProvinciaID').empty();
//    let url = '../../Provincias/ComboProvincia';
//    let data = { id: $('#PaisID').val() };
//    $.post(url, data).done(provincias => {
//        provincias.length === 0
//            ? $('#ProvinciaID').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`)
//            : $.each(provincias, (i, provincia) => {
//                $('#ProvinciaID').append(`<option value=${provincia.value}>${provincia.text}</option>`)
//            });
//    }).fail(e => console.log('error en combo provincias ' + e))
//    return false
//}

const AbrirModal = () => {
    $('#idProvincia').val(0);
    $('#Titulo-Modal-Provincia').text('Agregar nueva provincia');
    $('#bottonEdit').text('Agregar');
    $('#alertProvincia').addClass('visually-hidden')
    $('#modalCrearProvincia').modal('show');
    $("#idPais").val(0);
   
}

const VaciarFormulario = () => {
    $("#idProvincia").val(0);
    $("#nombreProvincia").val('');
}


const EliminarProvincia = (provinciaID, elimina) => {
    let url = '../../Provincias/EliminarProvincia';
    let data = { ProvinciaID: provinciaID, Elimina: elimina };
    $.post(url, data).done(() => CompletarTablaProvincias()).fail(e => console.log(e))
}

//function EliminarProvincia(provinciaID, elimina) {
//    $.ajax({
//        type: "POST",
//        url: '../../Provincias/EliminarProvincias',
//        data: { ProvinciaID: provinciaID, Elimina: elimina },
//        success: function (resultado) {
//            if (resultado == 0) {
//                CompletarTablaProvincias();
//            }
//            else {
//                alert("No se puede eliminar porque contiene localidades activas.");
//            }
//        },
//        error: function (data) {
//        }
//    });
//}

