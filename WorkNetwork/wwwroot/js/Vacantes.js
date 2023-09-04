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
            //const idiomasTexto = vacante.idiomas ? vacante.idiomas : '-';
            $("#tbody-vacante").append(
                `<tr class= 'tabla-hover${claseEliminado}'>
                        <td class='texto'>${vacante.nombre}</td>
                        <td class='texto'>${vacante.idiomas}</td> 
                        <td class='texto'>${vacante.experienciaRequerida} años</td>
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
        $("#PaisID").val(vacante.paisID);
        $('#LocalidadID').val(vacante.localidadID);
        BuscarProvincia(vacante.paisID, vacante.provinciaID, vacante.localidadID);
        $('#ProvinciaID').val(vacante.provinciaID);

        var datetime = new Date(vacante.fechaDeFinalizacion);
        var dia = datetime.getDate();
        var mes = datetime.getMonth() + 1;
        var anho = datetime.getFullYear();

        var diaFormato = anho + '-' + padNumber(mes) + '-' + padNumber(dia);
        $('#fechaFinalizacionVacante').val(diaFormato);

        $('#RubroID').val(vacante.rubroID);
        $('#idiomaVacante').val(vacante.idiomas)
        $('#disponibilidadHoraria').val(vacante.disponibilidadHoraria)
        $('#modalidadVacante').val(vacante.tipoModalidad)
    })
}

function padNumber(number) {
    return number < 10 ? '0' + number : number;
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
        });
    });

}



const pustularVacante = () => {
    console.log("llego al js")
    const url = '../../PersonaVacante/postularVacante';
    const descripcion = $('#descripcionVacante').val();
    const vacanteID = $('#vacanteID').val();
    const params = { vacanteID: vacanteID, descripcionVacante: descripcion };
    if (descripcion != null && descripcion != "") {
        $.ajax({
            type: "POST",
            url: url,
            data: params,
            success: vacante => {
                location.href = "/";
            },
            error: e => console.log("F")
        });
    }else $("#Error-descripcionVacante").text("Debe ingresar una descripción")
}

const GuardarVacante = () => {
    //console.log('llega')
    event.preventDefault();
    const url = '../../Vacantes/GuardarVacante';
    const formulario = $('#nuevaVacante')[0];
    const params = new FormData(formulario);
    let alertVacante = $("#alertVacante");
    let idPais = $("#PaisID");
    let idProvincia = $("#ProvinciaID");
    let idLocalidad = $("#LocalidadID");
    let idRubro = $("#RubroID");
    let titulo = $("#tituloVacante").val().trim();
    let descripcion = $("#descripcionVacante").val().trim();
    let exp = $("#expRequeridaVacante").val().trim();
    let fechaFin = $("#fechaFinalizacionVacante").val().trim();
    let idioma = $("#idiomaVacante").val().trim();
    let dispHora = $("#disponibilidadHoraria").val();
    let modalidad = $("#modalidadVacante").val();
    //Validar Pais-Provincia-Localidad-Rubro,
    if (titulo != "" && titulo != null) {
        if (descripcion != "" && descripcion != null) {
            if (exp != "" && exp != null) {
                if (idPais != 0) {

                    if (idProvincia != 0) {

                        if (idLocalidad != 0) {

                            if (idRubro != 0) {

                                if (fechaFin != "" && fechaFin != null) {
                                    if (idioma != "" && idioma != null) {
                                        if (dispHora != "" && dispHora != null) {
                                            if (modalidad != "" && modalidad != null) {
                                                $.ajax({
                                                    type: 'POST',
                                                    url: url,
                                                    data: params,
                                                    contentType: false,
                                                    processData: false,
                                                    async: false,
                                                    success: e => window.location.href = '/Vacantes',
                                                    error: e => console.log('error' + e)
                                                });

                                            } else alertVacante.removeClass('visually-hidden').text("La modalidad es obligatioria");

                                        } else alertVacante.removeClass('visually-hidden').text("La Disponibilidad Horaria es obligatoria");

                                    } else alertVacante.removeClass('visually-hidden').text("Debe ingresar un idioma");

                                } else alertVacante.removeClass('visually-hidden').text("Debe ingresar una fecha");

                            } else alertVacante.removeClass('visually-hidden').text("El rubro es obligatiorio");

                        } else alertVacante.removeClass('visually-hidden').text("La localidad es obligatioria");

                    } else alertVacante.removeClass('visually-hidden').text("La provincia es obligatioria");

                } else alertVacante.removeClass('visually-hidden').text("El pais es obligatiorio");

            } else alertVacante.removeClass('visually-hidden').text("Debe ingresar la experiencia requerida");

        } else alertVacante.removeClass('visually-hidden').text("Debe ingresar una descripción");

    } else alertVacante.removeClass('visually-hidden').text('Debe ingresar el titulo de la Vacante');

}

$('#PaisID').change(() => BuscarProvincia());

const BuscarProvincia = (paisID, provinciaID, localidadID) => {
    if (paisID === null)
        paisID = $("#PaisID").val();
    $('#ProvinciaID').empty();
    let url = '../../Provincias/ComboProvincia';
    let data = { id: $('#PaisID').val() };
    $.post(url, data).done(provincias => {
        provincias.length === 0
            ? $('#ProvinciaID').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`)
            : $.each(provincias, (i, provincia) => {
                var selected = "";
                if (provinciaID == provincia.value)
                    selected = "selected";
                $('#ProvinciaID').append(`<option ${selected} value=${provincia.value}>${provincia.text}</option>`)
                BuscarLocalidad(localidadID)
            });
    }).fail(e => console.log('error en combo provincias ' + e));
    return false
}

$('#ProvinciaID').change(() => BuscarLocalidad());

const BuscarLocalidad = (localidadID) => {
    $('#LocalidadID').empty();
    let url = '../../Localidades/ComboLocalidades';
    let data = { id: $('#ProvinciaID').val() };
    $.post(url, data).done(localidades => {
        localidades.length === 0
            ? $('#LocalidadID').append(`<option value=${0}>[NO EXISTEN LOCALIDADES]</option>`)
            : $.each(localidades, (i, localidad) => {
                var selected = "";
                if (localidadID == localidad.value)
                    selected = "selected";
                $('#LocalidadID').append(`<option ${selected} value=${localidad.value}>${localidad.text}</option>`)
            });
    }).fail(e => console.log('error en combo localidades' + e))
    return false
}
const AbrirModal = () => {
    $('#idVacante').val(0);
    $('#modalCrearVacante').modal('show');
    $('#alertVacante').addClass('visually-hidden');
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
    $('#RubroID').val(0);
    $('#PaisID').val(0);
    $('#ProvinciaID').empty();
    $('#ProvinciaID').append('<option value="0">[SELECCIONE UNA PROVINCIA]</option>');
    $('#LocalidadID').empty();
    $('#LocalidadID').append('<option value="0">[SELECCIONE UNA LOCALIDAD]</option>');
    $('#fechaFinalizacionVacante').val('');
    $('#idiomaVacante').val('');
    $('#disponibilidadHoraria').append();
    $('#modalidadVacante').append();
    $('#imagenVacante').val('');
}

function EliminarVacante(vacanteID, elimina) {
    $.ajax({
        type: 'POST',
        url: '../../Vacantes/EliminarVacante',
        data: { VacanteID: vacanteID, Elimina: elimina },
        success: function (resultado) {
            if (resultado == 0) {
                CompletarTablaVacantes();
            }
            else alert("No se puede eliminar la vacante")
        },
        error: function (data) { }

    });
}