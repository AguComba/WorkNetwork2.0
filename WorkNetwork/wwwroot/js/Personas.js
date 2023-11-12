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


const validateSocialMedia = (fieldId, regex, errorMessage) => {
    const field = $(fieldId).val().trim();

    if (field !== '' && !/^https?:\/\/(www\.)?/.test(field)) {
        if (field.startsWith('www.')) {
            $(fieldId).val('https://' + field);
        } else {
            $(fieldId).val('https://www.' + field);
        }
    }

    if (field !== '' && !regex.test(field)) {
        alertPersona.textContent = errorMessage;
        alertPersona.classList.add('alert-danger');
        return false;
    }
    alertPersona.textContent = ''; // Clear any previous error message
    alertPersona.classList.remove('alert-danger');
    return true;
}

const guardarPersona = () => {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
    event.preventDefault();
    const nombre = $('#nombrePersona').val();
    const apellido = $('#apellidoPersona').val();
    const dni = $('#numeroDocumento').val();
    const nacimiento = $('#fecNac').val();
    const paisid = $("#paisID").val();
    const localidadid = $("#localidadID").val();
    const domicilio = $('#domicilio').val();
    const telefono = $('#telefono1Persona').val();
    const cv = $('#curriculPersona').prop('files')[0];
    const empresaFoto = $('#personaFoto').prop('files')[0];

    if (empresaFoto) {
        const fileName = empresaFoto.name;
        const ext = fileName.split('.').pop().toLowerCase();

        // Usar una expresión regular para extraer la extensión
        const extRegex = /(?:\.([^.]+))?$/;
        const extMatch = extRegex.exec(fileName);
        const fileExtension = extMatch && extMatch[1] ? extMatch[1].toLowerCase() : null;

        if (!fileExtension || !['jpg', 'jpeg', 'png', 'gif'].includes(fileExtension)) {
            alert('Por favor selecciona un archivo de imagen (jpg, jpeg, png o gif).');
            // Aquí puedes decidir qué hacer si no es una imagen
        }
    }

    const errorMessages = {
        nombre: 'El nombre no puede quedar vacio.',
        apellido: 'El apellido no puede quedar vacio.',
        dni: 'El numero de documento es obligatorio.',
        nacimiento: 'Seleccione una fecha de nacimiento.',
        paisid: 'Debe seleccionar un pais',
        localidadid: 'Debe seleccionar un pais primero',
        domicilio: 'El domicilio no debe quedar vacio.',
        telefono: 'El numero de telefono es obligatorio.',
        cv: 'Debe cargar el Curriculum',
        //provinciad: 'Debe seleccionar una provincia',
        empresaFoto: 'Debe seleccionar una foto de perfil.', // New error message for file input
    };
    const nombreRegex = /^[A-Za-z\s]+$/
    const apellidoRegex = /^[A-Za-z\s]+$/
    const telefonoRegex = /^\d+$/; // Only numbers allowed
    const dniRegex = /^\d+$/; // Only numbers allowed
    const linkedinRegex = /^(https?:\/\/)?(www\.)?linkedin\.com\/[\w-]+\/?$/i;
    const instagramRegex = /^(https?:\/\/)?(www\.)?instagram\.com\/[\w-]+\/?$/i;
    const twitterRegex = /^(https?:\/\/)?(www\.)?twitter\.com\/[\w-]+\/?$/i;
    const linkedinValid = validateSocialMedia('#linkedin', linkedinRegex, 'El formato del enlace de LinkedIn no es válido. Por favor, ingrese un enlace válido o deje el campo vacío.');
    const instagramValid = validateSocialMedia('#instagram', instagramRegex, 'El formato del enlace de Instagram no es válido. Por favor, ingrese un enlace válido o deje el campo vacío.');
    const twitterValid = validateSocialMedia('#twitter', twitterRegex, 'El formato del enlace de Twitter no es válido. Por favor, ingrese un enlace válido o deje el campo vacío.');


    let errorMessage = '';
    if (nombre.trim() === '') { errorMessage = errorMessages.nombre; }
    else if (!nombreRegex.test(nombre)) { errorMessage = 'El nombre solo puede contener letras y espacios.'; }

    else if (apellido.trim() === '') { errorMessage = errorMessages.apellido; }
    else if (!apellidoRegex.test(apellido)) { errorMessage = 'El apellido solo puede contener letras y espacios.'; }

    else if (dni.trim() === '') { errorMessage = errorMessages.dni; }
    else if (!dniRegex.test(dni)) { errorMessage = 'El DNI solo puede contener números.'; }
    else if (dni.length !== 8) { errorMessage = 'El DNI debe tener 8 caracteres.' }

    else if (nacimiento.trim() === '') { errorMessage = errorMessages.nacimiento; }
    else if (domicilio.trim() === '') { errorMessage = errorMessages.domicilio; }

    else if (telefono.trim() === '') { errorMessage = errorMessages.telefono; }
    else if (!telefonoRegex.test(telefono)) { errorMessage = 'El número  solo puede contener números.'; }
    else if (telefono.length > 15) { errorMessage = 'El numero no puede tener  mas de 15 caracteres.' }

    else if (paisid === '') { errorMessage = errorMessages.paisid; }


    else if (!cv) { errorMessage = errorMessages.cv; }
    else if (!empresaFoto) { errorMessage = errorMessages.empresaFoto; }

    if (errorMessage) {
        alertPersona.textContent = errorMessage;
        alertPersona.classList.add('alert-danger'); // Add text-danger class
        return false;
    }
    else {
        alertPersona.classList.remove('alert-danger'); // Remove text-danger class
    }

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
$('#linkedin').on('input', function () {
    validateSocialMedia('#linkedin', linkedinRegex, 'El formato del enlace de LinkedIn no es válido. Por favor, ingrese un enlace válido o deje el campo vacío.');
});

$('#instagram').on('input', function () {
    validateSocialMedia('#instagram', instagramRegex, 'El formato del enlace de Instagram no es válido. Por favor, ingrese un enlace válido o deje el campo vacío.');
});

$('#twitter').on('input', function () {
    validateSocialMedia('#twitter', twitterRegex, 'El formato del enlace de Twitter no es válido. Por favor, ingrese un enlace válido o deje el campo vacío.');
});


const editarPersona = () => {
    event.preventDefault();
    const parametros = new FormData($('#frmFormulario')[0]);
    const url = '../../Personas/EditarPersona';
    let alertPersona = $("#alertPersona");
    let nombre = $("#PersonaNombre").val().trim();
    let apellido = $("#ApellidoNombre").val().trim();
    let tel = $("#Telefono1").val().trim();
    let paisid = $("#paisID").val();
    let provinciaid = $("#provinciaID").val();
    let localidadid = $("#localidadID").val();
    let domicilio = $("#DomicilioPersona").val().trim();
    let correo = $("#CorreoPersona").val().trim();
    if (nombre != "" && nombre != null) {
        if (apellido != null && apellido != "") {
            if (tel != "" && tel != null) {
                if (paisid != 0) {
                    if (provinciaid != 0) {
                        if (localidadid != 0) {
                            if (domicilio != "" && domicilio != null) {
                                if (correo != "" && correo != null) {
                                    $.ajax({
                                        type: 'PUT',
                                        url: url,
                                        data: parametros,
                                        contentType: false,
                                        processData: false,
                                        async: false,
                                        success: e => window.location.href = '/personas/PerfilUser',
                                        error: e => console.log('error' + e)
                                    });

                                } else alertPersona.removeClass('visually-hidden').text('Debe ingresar un correo');

                            } else alertPersona.removeClass('visually-hidden').text('El domicilio es obligatorio');

                        } else alertPersona.removeClass('visually-hidden').text('Debe seleccionar una localidad');

                    } else alertPersona.removeClass('visually-hidden').text('Debe seleccionar una provincia');

                } else alertPersona.removeClass('visually-hidden').text('Debe seleccionar un país');
            
            } else alertPersona.removeClass('visually-hidden').text('El telefono es requerido');

        } else alertPersona.removeClass('visually-hidden').text('El apellido es requerido');

    } else alertPersona.removeClass('visually-hidden').text('El nombre es requerido');
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
    $("#alertPersona").addClass('visually-hidden');
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
    $('#alertPersona').addClass('visually-hidden');

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