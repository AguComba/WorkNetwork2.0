function comparacionFechas(act, fin) {
    if (act.eliminado && !fin.eliminado) {
        return 1;
    } else if (!act.eliminado && fin.eliminado) {
        return -1;
    } else {
        return new Date(fin.fechaDeFinalizacion) - new Date(act.fechaDeFinalizacion);
    }
}

const formatoFecha = (fecha) => {
    const cambioFecha = { year: 'numeric', month: '2-digit', day: '2-digit' };
    return fecha.toLocaleDateString('es-AR', cambioFecha);
}

const CompletarTablaVacantes = () => {
    VaciarFormulario();

    let url = '../../Vacantes/TablaVacasntes'

    $.get(url).done(vacantes => {
        vacantes.sort(comparacionFechas);
        $('#tbody-vacante').empty();
        let currentDate = new Date();

        $.each(vacantes, function (index, vacante) {
            let claseFinalizado = '';
            let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-1' onclick = "EditarVacantes(${vacante.vacanteID})"><i class="bi bi-pencil-square"></i><i class="ocultarCol991"> Editar</i></btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm me-1' onclick = "FinalizarVacante(${vacante.vacanteID},1)"><i class="bi bi-circle-fill"></i><i class="ocultarCol991"> Finalizar</i></btn>
                                <a class ='btn btn-outline-dark btn-sm' onclick = "GestionarVacante(${vacante.vacanteID})"><i class='bi bi-gear'></i><i class="ocultarCol991"> Gestionar</i></a>`


            let fechaCreacion = formatoFecha (new Date(vacante.fechaCreacion));
            let fechaFinalizacion = formatoFecha (new Date(vacante.fechaDeFinalizacion));

            if (new Date(vacante.fechaDeFinalizacion) < currentDate || vacante.eliminado) {                
                claseFinalizado = 'table-danger';
                botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-1' onclick = "EditarVacantes(${vacante.vacanteID})"><i class="bi bi-pencil-square"></i><i class="ocultarCol991"> Editar</i></btn>
                <btn type='button' class = 'btn btn-outline-primary btn-sm me-1' onclick = "FinalizarVacante(${vacante.vacanteID},0)" title="Si la fecha de finalizaci\u00F3n ha concluido, edite la vacante"><i class="bi bi-arrow-clockwise"></i><i class="ocultarCol991"> Reactivar</i></btn>
                                <a class ='btn btn-outline-dark btn-sm' onclick = "GestionarVacante(${vacante.vacanteID})"><i class='bi bi-gear'></i><i class="ocultarCol991"> Gestionar</i></a>`

            }

            let expTexto = vacante.experienciaRequerida === '1' ? 'a&ntildeo' : 'a&ntildeos';

            $("#tbody-vacante").append(
                `<tr class= 'tabla-hover ${claseFinalizado}'>
                        <td class='texto ocultarCol767'>${fechaCreacion}</td>
                        <td class='texto'>${fechaFinalizacion}</td>
                        <td class='texto'>${vacante.nombre}</td>
                        <td class='texto ocultarCol767'>${vacante.idiomas ? vacante.idiomas : '<i>' + "Sin idiomas" + '</i>'}</td>
                        <td class='texto'>${vacante.experienciaRequerida} ${expTexto}</td>                      
                        <td class = 'text-center'>
                        ${botones}
                        </td>
                </tr>`
            )
        })
    }).fail(e => console.error('Error al cargar tabla localidades ', e));
}


const CompletarTablaPostulacionPersona = () => {
    
    let url = '../../Vacantes/TablaVacantesPersonas'

    $.get(url).done(vacantes => {
        $('#tbody-postulacion').empty();
        $.each(vacantes, function (index, vacante) {

            let fechaSolicitudVacante = new Date(vacante.fechaSolicitud).toLocaleDateString('es-AR');
            let expTexto = vacante.experienciaRequerida === '1' ? 'a&ntildeo' : 'a&ntildeos';
                       
            $("#tbody-postulacion").append(
                `<tr class= 'tabla-hover'>
                        <td class='texto'>${fechaSolicitudVacante}</td>
                        <td class='texto'>${vacante.empresaNombre}</td>
                        <td class='texto'>${vacante.nombre}</td>
                        <td class='texto ocultarCol767'>${vacante.idiomas ? vacante.idiomas : '<i>' + "Sin idiomas" + '</i>'}</td>
                        <td class='texto'>${vacante.experienciaRequerida} ${expTexto}</td>
                        
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
    //validar que todos los campos esten completos
    //sacar el alert si no hay ninguna alerta
    $.post(url, data).done(vacante => {
        
        $('#modalCrearVacante').modal('show');
        $('#btn-edit').text('Guardar Cambios')
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
        console.log(vacante.tipoModalidad);
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

        if (vacantes.length === 0) {
            $('#NoVacantes').removeClass('d-none');
        } else {
            $('#NoVacantes').addClass('d-none');
            $.each(vacantes, function (index, vacante) {
                const fechaCreacion = new Date(vacante.fechaCreacion);
                const formattedFechaCreacion = `${String(fechaCreacion.getDate()).padStart(2, '0')}/${String(fechaCreacion.getMonth() + 1).padStart(2, '0')}/${fechaCreacion.getFullYear()}`;

                if (!vacante.finaliza) {
                    $('#cardVacantes').append(
                        `<div class="col-xl-4 col-md-6">
                            <div class="post-item position-relative h-100">

                            <div class="post-img position-relative overflow-hidden">
                            <img src="data:${vacante.tipoImagen};base64,${vacante.imagenVacante}" class="img-fluid" alt="imagen de la vacante">
                             <span class="post-date">${formattedFechaCreacion}</span>
                         </div>

                            <div class="post-content d-flex flex-column">

                             <h3 class="post-title">${vacante.nombre}</h3>

                            <div class="meta d-flex align-items-center">
                            <div class="d-flex align-items-center">
                                <i class="bi bi-briefcase"></i> <span class="ps-2">${vacante.empresaNombre}</span>
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

                        <a href="#" onclick ="VacanteDetalle(${vacante.vacanteID})" class="readmore stretched-link"><span>Ver m\u00E1s</span><i class="bi bi-arrow-right"></i></a>

                        </div>

                        </div>
                         </div>
                        `
                    );
                }
            });

        }
    });

}

const pustularVacante = () => {
    console.log("llego al js")
    const url = '../../PersonaVacante/postularVacante';
    const descripcion = $('#descripcionVacante').val().trim();
    const vacanteID = $('#vacanteID').val();
    const alertPostVacante = $("#alertPostVacante");
    const params = { vacanteID: vacanteID, descripcionVacante: descripcion };      
       
    if (descripcion != null && descripcion != "") {
    
        $.ajax({
            type: "POST",
            url: url,
            data: params,
            success: vacante => {
                alertPostVacante.addClass('visually-hidden').text('');
                location.href = "/";
            },
            error: e => console.log("F")
        });
    } else {
        alertPostVacante.removeClass('visually-hidden').text('Debe describir porqu\u00E9 es apto para \u00E9sta vacante');
        setTimeout(() => alertPostVacante.addClass("visually-hidden"), 5000);
    }
}


const expRegex = /^\d+$/; // Only numbers allowed

const GuardarVacante = () => {    
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
    event.preventDefault();
    const url = '../../Vacantes/GuardarVacante';
    const formulario = $('#nuevaVacante')[0];
    const params = new FormData(formulario);
    let alertVacante = $("#alertVacante");
    let idPais = $("#PaisID").val();
    let idProvincia = $("#ProvinciaID").val();
    let idLocalidad = $("#LocalidadID").val();
    let idRubro = $("#RubroID").val();
    let titulo = $("#tituloVacante").val().trim();
    let descripcion = $("#descripcionVacante").val().trim();
    let exp = $("#expRequeridaVacante").val().trim();
    let fechaFin = $("#fechaFinalizacionVacante").val().trim();
    /*let idioma = $("#idiomaVacante").val().trim();*/
    let dispHora = $("#disponibilidadHoraria").val();
    let modalidad = $("#modalidadVacante").val();

    //Validar Fecha Finalizacion
    const fechaHoy = new Date();
    const fechaFinDate = new Date(fechaFin);

    if (fechaFinDate <= fechaHoy) {
        alertVacante.removeClass('visually-hidden').text("La fecha de finalizaci\u00F3n debe ser posterior a la actual");
        setTimeout(() => alertVacante.addClass("visually-hidden"), 5000);
        return;
    }


    if (titulo != "" && titulo != null) {
        if (descripcion != "" && descripcion != null) {
            if (exp != "" && exp != null) {
                if (expRegex.test(exp)) {
                    if (idPais != 0) {

                        if (idProvincia != 0) {

                            if (idLocalidad != 0) {

                                if (idRubro != 0) {

                                    if (fechaFin != "" && fechaFin != null) {

                                        if (dispHora != "" && dispHora != null) {
                                            if (modalidad != "" && modalidad != null) {
                                                console.log(modalidad);
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

                                        } else alertVacante.removeClass('visually-hidden').text("La Disponibilidad horaria es obligatoria");


                                    } else alertVacante.removeClass('visually-hidden').text("Debe ingresar una fecha");

                                } else alertVacante.removeClass('visually-hidden').text("El rubro es obligatiorio");

                            } else alertVacante.removeClass('visually-hidden').text("La localidad es obligatioria");

                        } else alertVacante.removeClass('visually-hidden').text("La provincia es obligatioria");

                    } else alertVacante.removeClass('visually-hidden').text("El pa\u00EDs es obligatiorio");

                } else alertVacante.removeClass('visually-hidden').text("Escriba solo n\u00FCmeros");

            } else alertVacante.removeClass('visually-hidden').text("Debe ingresar la experiencia requerida");

        } else alertVacante.removeClass('visually-hidden').text("Debe ingresar una descripci\u00F3n");

    } else alertVacante.removeClass('visually-hidden').text('Debe ingresar el t\u00EDtulo de la Vacante');
      setTimeout(() => alertVacante.addClass("visually-hidden"), 5000);
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
            });
        BuscarLocalidad(localidadID)
    }).fail(e => console.log('error en combo provincias ' + e));
    return false
}

$('#ProvinciaID').change(() => BuscarLocalidad());

const BuscarLocalidad = (localidadID) => {
    $('#LocalidadID').empty();
    let url = '../../Localidades/ComboLocalidades';
    let data = { id: $('#ProvinciaID').val() };
    $.post(url, data).done(localidades => {
        $('#LocalidadID').empty();
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
    $('#btn-edit').text('Guardar')
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
    $('#alertVacante').addClass('visually-hidden')
   
}

function FinalizarVacante(vacanteID, finalizar) {
    $.ajax({
        type: 'POST',
        url: '../../Vacantes/FinalizarVacante',
        data: { VacanteID: vacanteID, Finalizar: finalizar },
        success: function (resultado) {          
                CompletarTablaVacantes();            
        },
        error: function (data) { }

    });
}
