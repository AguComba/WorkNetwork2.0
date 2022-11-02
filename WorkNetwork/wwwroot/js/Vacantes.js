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
function GestionarVacante(vacanteID){
    location.href = "../../Vacantes/GestionDeVacante/"+vacanteID;
}

const BuscarVacante = idVacante=>{
    $('#vacanteID').val(idVacante);
    let data = {vacanteID: idVacante};
    let url = '../../Vacantes/BuscarVacante'
    $.post(url,data).done(vacante=>{
        $("#modalPostularVacante").modal("show");
        $('#tituloDeVacante').text(vacante.nombre);
    })
}

const EditarVacantes = vacanteID =>{
    $('#idVacante').val(vacanteID);
    const url = '../../Vacantes/BuscarVacante';
    const data = {vacanteID:vacanteID}
    $.post(url,data).done(vacante =>{
        console.log(vacante)
        $('#modalCrearVacante').modal('show');
        $('#titulo-modal-vacante').text('Editar Vacante')
        $('#tituloVacante').val(vacante.nombre);
        $('#descripcionVacante').val(vacante.descripcion);
        $('#expRequeridaVacante').val(vacante.experienciaRequerida);
        //ver como recuperar los valores de pais y provincia
        $('#LocalidadID').val();
        $('#RubroID').val(vacante.rubroID);
        $('#fechaFinalizacionVacante') .val(vacante.fechaDeFinalizacion)
        $('#idiomaVacante').val(vacante.idiomas)
        $('#disponibilidadHoraria').val(vacante.disponibilidadHoraria)
        $('#modalidadVacante').val(vacante.tipoModalidad)
    })
} 

const MostrarVacantes = () => {
    const url = '../../Vacantes/MostrarVantes';
    $.get(url).done(vacantes => {
        $('#cardVacantes').empty();
        let color = '#e9e7fd'
        $('#vacantesTotal').text(vacantes.length)
        console.log()
        $.each(vacantes, function (index, vacante) {
            let operecion = index % 2
            $('#cardVacantes').append(
                `
                <div class="project-box-wrapper">
                <div class="project-box" style="background-color:${operecion==0?'#fee4cb':color} ">
                    <div class="project-box-header">
                        <span>${vacante.fechaDeFinalizacion}</span>
                    </div>
                    <div class="project-box-content-header">
                        <p class="box-content-header">${vacante.nombre}</p>
                        <p class="box-content-subheader">${vacante.descripcion}</p>
                    </div>

                    <div class="project-box-footer">
                        <div class="participants">
                            <img src="https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=2550&q=80"
                                 alt="participant" />
                            <img src="https://images.unsplash.com/photo-1503023345310-bd7c1de61c7d?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MTB8fG1hbnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=900&q=60"
                                 alt="participant" />
                            <button class="add-participant" style="color: #ff942e">
                                <svg xmlns="http://www.w3.org/2000/svg"
                                     width="12"
                                     height="12"
                                     viewBox="0 0 24 24"
                                     fill="none"
                                     stroke="currentColor"
                                     stroke-width="3"
                                     stroke-linecap="round"
                                     stroke-linejoin="round"
                                     class="feather feather-plus">
                                <path d="M12 5v14M5 12h14" />
                                </svg>
                            </button>
                        </div>
                        <div class="days-left" style="color: #ff942e">
                            <button class="add-participant" onclick="BuscarVacante(${vacante.vacanteID})" style="color: #ff942e">Postularse</button> 
                        </div>
                    </div>
                </div>
            </div>

`
            )
        })
    })
}



const pustularVacante = ()=>{
    const url = '../../PersonaVacante/postularVacante';
    const descripcion = $('#descripcionVacante').val();
    const vacanteID = $('#vacanteID').val();
    const params = {vacanteID: vacanteID, descripcionVacante: descripcion};
    $.ajax({
        type:"POST",
        url: url,
        data: params,
        success: vacante =>{
            $('#modalPostularVacante').modal('hide');
            MostrarVacantes();
        },
        error: e=> console.log("F")
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