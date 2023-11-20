const CompletarTablaRubro = async () => {
    await VaciarFormulario()
    let url = '../../Rubros/TablaRubros'

    $.get(url).done(async rubros => {
        $('#tbody-rubros').empty();
        $.each(rubros, function (i, rubro) {

            let claseEliminado = '';
            let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarRubro(${rubro.rubroID})"><i class="bi bi-pencil-square"></i> Editar</btn>
                           <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarRubro(${rubro.rubroID},1)"><i class="bi bi-trash3"></i> Desactivar</btn>`

            if (rubro.eliminado) {
                claseEliminado = 'table-danger';
                botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarRubro(${rubro.rubroID},0)"><i class="bi bi-recycle"></i> Activar</btn>`
            }
            $('#tbody-rubros').append(
                `<tr class= 'tabla-hover ${claseEliminado}'>
                   <td class='texto'>${rubro.nombreRubro}</td>
                   <td class = 'text-end'>
                    ${botones}
                   </td>
                </tr>`
            )
        })
    })
}

const nombreRubroRegex = /^[A-Za-záéíóúüÜñÑ\s.'']+$/u;
const GuardarRubro = () => {
    let idRubro = $('#idRubro').val();
    let nombreRubro = $('#nombreRubro').val().trim();
    let alertRubro = $('#alertRubro')
    let url = '../../Rubros/GuardarRubro'
    let data = { idRubro: idRubro, NombreRubro: nombreRubro }
    if (nombreRubro != '' && nombreRubro != null) {
        if (nombreRubroRegex.test(nombreRubro)) {
            $.post(url, data).done(resultado => {
                if (resultado == 0) {
                    $('#modalCrearRubro').modal('hide')
                    CompletarTablaRubro();
                }
                if (resultado == 2) {
                    alertRubro.removeClass('visually-hidden').text('El rubro ingresado ya existe')
                }
            }).fail(e => console.log('error en guardar rubro' + e))

        } else alertRubro.removeClass('visually-hidden').text('Formato no aceptado');

    } else alertRubro.removeClass('visually-hidden');
    

}

const AbrirModal = () => {
    $('#titulo-modal-rubro').text('Agregar nuevo rubro')
    $('#idRubro').val(0);
    $('#modalCrearRubro').modal('show');
    $('#bottonEdit').text('Agregar');
    $('#alertRubro').addClass('visually-hidden')
}
const VaciarFormulario = () => {
    $("#idRubro").val(0);
    $('#nombreRubro').val('');
    $('#alertRubro').addClass('visually-hidden')
}


const BuscarRubro = (rubroID) => {
    $("#titulo-modal-rubro").text("Editar Rubro");
    $("#idRubro").val(rubroID);
    $('#bottonEdit').text('Guardar Cambios');
    let url = '../../Rubros/BuscarRubro';
    let data = { RubroID: rubroID };

    $.post(url, data).done(rubro => {
        $("#nombreRubro").val(rubro.nombreRubro);
        $("#modalCrearRubro").modal("show");
    }).fail(e => console.log(e));
}

const EliminarRubro = (rubroID, elimina) => {
    let url = '../../Rubros/EliminarRubro';
    let data = {RubroID:rubroID, Elimina: elimina};
    $.post(url,data).done(() => CompletarTablaRubro()).fail(e=>console.log(e))
}


