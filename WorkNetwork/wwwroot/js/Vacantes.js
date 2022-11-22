const CompletarTablaVacantes = () => {
    VaciarFormulario();

    let url = '../../Vacantes/TablaVacasntes'

    $.get(url).done(vacantes => {
        $('#tbody-vacante').empty();
        $.each(vacantes, function (index, vacante) {
            let claseEliminado = '';
            let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "EditarVacantes(${vacante.vacanteID})"><i class="bi bi-pencil-square"></i> Editar</btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm' onclick = "EliminarVacante(${vacante.vacanteID},1)"><i class="bi bi-trash3"></i> Eliminar</btn>
                                <a class ='btn btn-outline-primary btn-sm' onclick = "GestionarVacante(${vacante.vacanteID})">Gestionar</a>`

            if (vacantes.eliminado) {
                claseEliminado = 'table-danger';
                botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarVacante(${vacante.vacanteID},0)"><i class="bi bi-recycle"></i> Activar</btn>`
            }
            $("#tbody-vacante").append(
                `<tr class= 'tabla-hover${claseEliminado}'>
                        <td class='texto'>${vacante.nombre}</td>
                        <td class='texto'>${vacante.idiomas}</td>
                        <td class='texto'>${vacante.experienciaRequerida}</td>
                        <td class = 'text-center'>
                        ${botones}
                        </td>
                </tr>`

            )
        })
    }).fail(e => console.error('Error al cargar tabla localidades ', e));
}

function VacanteDetalle(vacanteID) {
    location.href = "../../Vacantes/VacanteDetalle/" + vacanteID;
}

function GestionarVacante(vacanteID) {
    location.href = "../../Vacantes/GestionDeVacante/" + vacanteID;
}

function verPerfilPersona(personaID) {
    location.href = "../../Personas/PerfilUser/" + personaID;
}

const BuscarVacante = idVacante => {
    $('#vacanteID').val(idVacante);
    let data = { vacanteID: idVacante };
    let url = '../../Vacantes/BuscarVacante'
    $.post(url, data).done(vacante => {
        $("#modalPostularVacante").modal("show");
        $('#tituloDeVacante').text(vacante.nombre);
    })
}

const EditarVacantes = vacanteID => {
    $('#idVacante').val(vacanteID);
    const url = '../../Vacantes/BuscarVacante';
    const data = { vacanteID: vacanteID }
    $.post(url, data).done(vacante => {
        console.log(vacante)
        $('#modalCrearVacante').modal('show');
        $('#titulo-modal-vacante').text('Editar Vacante')
        $('#tituloVacante').val(vacante.nombre);
        $('#descripcionVacante').val(vacante.descripcion);
        $('#expRequeridaVacante').val(vacante.experienciaRequerida);
        //ver como recuperar los valores de pais y provincia
        $('#LocalidadID').val();
        $('#RubroID').val(vacante.rubroID);
        $('#fechaFinalizacionVacante').val(vacante.fechaDeFinalizacion)
        $('#idiomaVacante').val(vacante.idiomas)
        $('#disponibilidadHoraria').val(vacante.disponibilidadHoraria)
        $('#modalidadVacante').val(vacante.tipoModalidad)
    })
}

const MostrarVacantes = () => {
    const url = '../../Vacantes/MostrarVantes';
    $.get(url).done(vacantes => {
        $('#cardVacantes').empty();
        console.log(vacantes)
        $.each(vacantes, function (index, vacante) {
            $('#cardVacantes').append(
                `
                <div class="col-xl-4 col-md-6">
                <div class="post-item position-relative h-100">

                    <div class="post-img position-relative overflow-hidden">
                        <img src="data:${vacante.tipoImagen};base64,${vacante.imagenVacante}" class="img-fluid" alt="imagen de la vacante">
                        <span class="post-date">${vacante.fechaCreacion}</span>
                    </div>

                    <div class="post-content d-flex flex-column">

                        <h3 class="post-title">${vacante.nombre}</h3>

                        <div class="meta d-flex align-items-center">
                            <div class="d-flex align-items-center">
                                <i class="bi bi-person"></i> <span class="ps-2">${vacante.empresaNombre}</span>
                            </div>
                            <span class="px-3 text-black-50">/</span>
                            <div class="d-flex align-items-center">
                                <i class="bi bi-folder2"></i> <span class="ps-2">${vacante.rubroNombre}</span>
                            </div>
                        </div>

                        <p>
                            ${vacante.descripcion}
                        </p>

                        <hr>

                        <a href="#" onclick ="VacanteDetalle(${vacante.vacanteID})" class="readmore stretched-link"><span>Ver mas</span><i class="bi bi-arrow-right"></i></a>

                    </div>

                </div>
            </div>
                `
            )
        })
    })
}



const pustularVacante = () => {
    console.log("llego al js")
    const url = '../../PersonaVacante/postularVacante';
    const descripcion = $('#descripcionVacante').val();
    const vacanteID = $('#vacanteID').val();
    const params = { vacanteID: vacanteID, descripcionVacante: descripcion };
    $.ajax({
        type: "POST",
        url: url,
        data: params,
        success: vacante => {
            location.href = "/";
        },
        error: e => console.log("F")
    })
}

const GuardarVacante = () => {
    console.log('llega')
    event.preventDefault();
    const url = '../../Vacantes/GuardarVacante';
    const formulario = $('#nuevaVacante')[0];
    const params = new FormData(formulario)
    $.ajax({
        type: 'POST',
        url: url,
        data: params,
        contentType: false,
        processData: false,
        async: false,
        success: e => window.location.href = '/Vacantes',
        error: e => console.log('error' + e)
    })
}

$('#PaisID').change(() => BuscarProvincia());

const BuscarProvincia = () => {
    $('#ProvinciaID').empty();
    let url = '../../Provincias/ComboProvincia';
    let data = { id: $('#PaisID').val() };
    $.post(url, data).done(provincias => {
        provincias.length === 0
            ? $('#ProvinciaID').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`)
            : $.each(provincias, (i, provincia) => {
                $('#ProvinciaID').append(`<option value=${provincia.value}>${provincia.text}</option>`)
                BuscarLocalidad()
            });
    }).fail(e => console.log('error en combo provincias ' + e));
    return false
}

$('#ProvinciaID').change(() => BuscarLocalidad());

const BuscarLocalidad = () => {
    $('#LocalidadID').empty();
    let url = '../../Localidades/ComboLocalidades';
    let data = { id: $('#ProvinciaID').val() };
    $.post(url, data).done(localidades => {
        localidades.length === 0
            ? $('#LocalidadID').append(`<option value=${0}>[NO EXISTEN LOCALIDADES]</option>`)
            : $.each(localidades, (i, localidad) => {
                $('#LocalidadID').append(`<option value=${localidad.value}>${localidad.text}</option>`)
            });
    }).fail(e => console.log('error en combo localidades' + e))
    return false
}
const AbrirModal = () => {
    $('#idVacante').val(0);
    $('#modalCrearVacante').modal('show');
}

const AbrirModalCV = (id) => {

    $(`#cv-${id}`).modal('show')
}

const VaciarFormulario = () => {
    $('#idVacante').val(0);
    $('#idEmpresa').val(0);
    $('#tituloVacante').val('')
    $('#descripcionVacante').val('');
    $('#expRequeridaVacante').val('');
    $('#idPais').val('');
    $('#idProvincia').val('');
    $('#idLocalidad').val('');
    $('#fechaFinalizacionVacante').val('');
    $('#idiomaVacante').val('');
    $('#disponibilidadHoraria').val('');
    $('#modalidadVacante').val('');
    $('#imagenVacante').val('');
}