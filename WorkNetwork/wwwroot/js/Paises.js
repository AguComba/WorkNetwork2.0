//CODIGO PARA MOSTRAR LOS DATOS DE LA TABLA
const CompletarTablaPaises = async () => {
    await VaciarFormulario()
    const url = '../../Paises/TablaPaises'

    $.get(url).done(
        async paises => {
            $('#tbody-paises').empty();
            $.each(paises, await function (index, pais) {
                
                let claseEliminado = '';
                let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-2' onclick = "BuscarPais(${pais.paisID})"><i class="bi bi-pencil-square"></i><i class="ocultarCol767"> Editar</i></btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm' onclick = "EliminarPais(${pais.paisID},1)"><i class="bi bi-trash3"></i><i class="ocultarCol767"> Deshabilitar<i/></btn>`

                if (pais.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = `<btn type='button' class = 'btn btn-outline-primary btn-sm 'onclick = "EliminarPais(${pais.paisID},0)"><i class="bi bi-arrow-clockwise"></i><i class="ocultarCol767"> Habilitar<i/></btn>`

                }
                $('#tbody-paises').append(`<tr class= 'tabla-hover ${claseEliminado} '>
                        <td class='texto'>${pais.nombrePais}</td>
                        <td class = 'text-end'>
                            ${botones}
                        </td>
                    </tr>`
                )
            })
        }
    ).fail(e => console.log('cargar paises', e))
}

const AbrirModal = () => {
    $('#idPais').val(0);
    $('#titulo-modal-pais').text('Agregar Nuevo País');
    $('#bottonEdit').text('Agregar');
    $('#alertPais').addClass('visually-hidden');
    $('#modalCrearPais').modal('show');
}

const VaciarFormulario = () => {

    $("#idPais").val(0);
    $("#nombrePais").val('');
}

const nombrePaisRegex = /^[A-Za-z\s.'']+$/; // Only letters and spaces allowed
const GuardarPais = () => {
    let idPais = $('#idPais').val();
    let nombrePais = $('#nombrePais').val().trim();
    let alertPais = $('#alertPais')
    let url = '../../Paises/CrearPais';
    let data = { NombrePais: nombrePais, PaisID: idPais };
    $('#bottonEdit').text('Agregar');

    if (nombrePais != '' && nombrePais != null) {
        if (nombrePaisRegex.test(nombrePais)) {
            $.post(url, data).done((resultado) => {
                if (resultado == 0) {
                    $('#modalCrearPais').modal('hide');
                    CompletarTablaPaises();
                }
                if (resultado == 2) {
                    alertPais.removeClass('visually-hidden').text('El país ingresado ya existe');
                }
            }).fail(err => console.log('error en agregar el Pais: ', err));

        } else alertPais.removeClass('visually-hidden').text('El nombre del país no puede contener números');

    } else alertPais.removeClass('visually-hidden').text('Debes ingresar el nombre del país');
    setTimeout(() => alertPais.addClass("visually-hidden"), 5000);
}

const BuscarPais = (paisID)=>{
    $('#titulo-modal-pais').text('Editar Pais');
    $('#bottonEdit').text('Guardar Cambios');
    $('#idPais').val(paisID);    

    $('#alertPais').addClass('visually-hidden');
    let url = '../../Paises/BuscarPais';
    let data = {PaisID: paisID};
    $.post(url,data)
    .done(
        pais => {
            $('#nombrePais').val(pais.nombrePais);
            $('#modalCrearPais').modal('show');
        }
    )
    .fail(e=>console.log(e))
}

//const EliminarPais= (paisID, elimina)=>{
//    let url = '../../Paises/EliminarPais'
//    let data = { PaisID: paisID, Elimina: elimina }
//    $.post(url, data).done(() => CompletarTablaPaises()).fail(e => console.log(e));
//}

function EliminarPais(paisID, elimina) {
    $.ajax({
        type: "POST",
        url: '../../Paises/EliminarPais',
        data: { PaisID: paisID, Elimina: elimina },
        success: function (resultado) {
            if (resultado == 0) {
                CompletarTablaPaises();
            }
            else {
                alert("No se puede deshabilitar porque hay localidades activas.");
            }
        },
        error: function (data) {
        }
    });
}