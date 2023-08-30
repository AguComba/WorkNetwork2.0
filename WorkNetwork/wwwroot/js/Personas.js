const CompletarTablaPersonas = () => {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Personas/TablaPersonas',
        data: {},
        success: (personas) => {
            $('#tbody-personas').empty();
            $.each(personas, function (index, personas) {
                let claseEliminado = '';
                let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarPersona(${personas.idPersona})"><i class="bi bi-pencil-square"></i> Editar</btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarPersona(${personas.idPersona},1)"><i class="bi bi-trash3"></i> Desactivar</btn>`

                if (personas.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarPersona(${personas.idPersona},0)"><i class="bi bi-recycle"></i> Activar</btn>`
                }
                $("#tbody-personas").append(
                    `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${personas.nombrePersona}</td>
                        <td class='texto'>${personas.apellidoPersona}</td>

                        <td class='texto'>${personas.tipoDocumento}</td>
                        <td class='texto'>${personas.numeroDocumento}</td>
                        <td class='texto'>${personas.correoElectronico}</td>
                        <td class='texto'>${personas.domicilioPersona}</td>
                        <td class='texto'>${personas.localidadID}</td>
                        <td class='texto'>${personas.genero}</td>
                        <td class='texto'>${personas.telefono1}</td>
                        <td class='texto'>${personas.telefono2}</td>
                        <td class='texto'>${personas.estadoCivil}</td>
                        <td class='texto'>${personas.tituloAcademico}</td>
                        <td class = 'text-center'>
                            ${botones}
                        </td>
                    </tr>`
                )
            });
        },
        error: (err) => console.log("error en CompletarTablaPersonas", err)
    });
}

const guardarPersona = () => {
    event.preventDefault();
    const parametros = new FormData($('#frmFormulario')[0]);
    const url = '../../Personas/GuardarPersona';
    $.ajax({
        type:'POST',
        url: url,
        data: parametros,
        contentType: false,
        processData: false,
        async: false,
        success: e => window.location.href = '/',
        error: e=>console.log('error' + e)
    })
}

const editarPersona = () => {
    event.preventDefault();
    const parametros = new FormData($('#frmFormulario')[0]);
    const url = '../../Personas/EditarPersona';
      $.ajax({
        type: 'PUT',
        url: url,
        data: parametros,
        contentType: false,
        processData: false,
        async: false,
        success: e => window.location.href = '/',
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
            });
        BuscarLocalidad()
    }).fail(e => console.log('error en combo provincias ' + e))
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
    $('#idPersona').val(0);
    $('#modalCrearPersona').modal('show');
    $('#exampleModal').modal('show');
}

const VaciarFormulario = () => {

    $("#idPersona").val(0);
    $("#nombrePersona").val('');
    $("#apellidoPersona").val('');
    $("#tipoDoc").val('');
    $("#nroDNI").val('');
    $("#fecNac").val('');
    $("#mailUser").val('');
    $("#userDom").val('');
    $("#idPais").val('');
    $("#idProvincia").val('');
    $("#idLocalidad").val('');
    $("#genre").val('');
    $("#tel1").val('');
    $("#tel2").val('');
    $("#estCivil").val('');
    $("#tituloAcadem").val('');
    $("#imagenUp").val('');
}

const PerfilPersona = () => {
    const url = '../../Personas/PerfilInfo';
    let nombre = $('#nombre')
    $.get(url).done(perfil => {
        nombre.append(`${perfil.nombrePersona} ${perfil.apellidoPersona}`)
        $('#celularPersona').append(`${perfil.telefono1}`);
    }).fail(e => console.log(e))
}

function BuscarPersona(idPersona) {
    $("#Titulo-Modal-Persona").text("Editar Perfil");
    $("#PersonaID").val(idPersona);
   
    $.ajax({
        type: "GET",
        url: "../Personas/BuscarPersona",
        data: { PersonaID: idPersona },
        success: function (persona) {
            $("#PersonaID").val(persona.personaID);
            $("#PersonaNombre").val(persona.nombrePersona);
            $("#ApellidoNombre").val(persona.apellidoPersona);
            $("#Telefono1").val(persona.telefono1);
            $("#LocalidadNombre").val(persona.localidad);
            $("#paisID").val(persona.paisID);
            $("#provinciaID").val(persona.provinciaID);
            $("#localidadID").val(persona.localidadID);
            $("#DomicilioPersona").val(persona.domicilioPersona);
            $("#CorreoPersona").val(persona.correo);
            $("#exampleModal").modal("show");
            console.log(persona)
        },
        error: function (data) { }
    });

}