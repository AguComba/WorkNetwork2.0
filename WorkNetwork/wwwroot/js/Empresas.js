const CompletarTablaEmpresas = () => {
    VaciarFormulario();

    let url = '../../Empresas/TablaEmpresas'

    $.get(url).done(empresas => {
        $('#tbody-empresa').empty();
        $.each(empresas, function (index, empresas) {
            let claseEliminado = '';
            let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarEmpresa(${empresas.idEmpresa})"><i class="bi bi-pencil-square"></i> Editar</btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarEmpresa(${empresas.idEmpresa},1)"><i class="bi bi-trash3"></i> Eliminar</btn>`

            if (empresas.eliminado) {
                claseEliminado = 'table-danger';
                botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarEmpresa(${empresas.idEmpresa},0)"><i class="bi bi-recycle"></i> Activar</btn>`
            }
            $("#tbody-empresa").append(
                `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${empresas.razonSocial}</td>
                        <td class='texto'>${empresas.cuit}</td>
                        <td class='texto'>${empresas.localidadID}</td>
                        <td class='texto'>${empresas.telefono1}</td>
                        <td class='texto'>${empresas.rubroID}</td>
                        <td class='texto'>${empresas.tipoEmpresa}</td>

                        <td class = 'text-center'>
                            ${botones}
                        </td>
                    </tr>`
            )
        })
    }).fail(e => console.error('Error al cargar tabla localidades ' + e));
}

function formatCuit(input, event) {
    
    // Remove all non-numeric characters
    let value = input.value.replace(/\D/g, '');

    if (event.key === 'Backspace') {
        //alert(event.key)
        value = value.substring(0, value.length - 1);
    } else if (event.key === 'Delete') {
       // alert(event.key)
        value = value.substring(1);
    }
    // Add hyphens at specific positions
    if (value.length > 2) {
        value = value.substring(0, 2) + '-' + value.substring(2, 10) + '-' + value.substring(10, 11);
    }

    // Update the input field value
    input.value = value;
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
        alertEmpresa.textContent = errorMessage;
        alertEmpresa.classList.add('alert-danger');
        return false;
    }
    alertEmpresa.textContent = ''; // Clear any previous error message
    alertEmpresa.classList.remove('alert-danger');
    return true;
}


const guardarEmpresa = () => {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
    event.preventDefault();
    //Validar Rubro, ya que sino guarda, 
    //se rompe al editar
    const formulario = $('#registrarEmpresa')[0];
    const razonSocial = $('#RazonSocial').val();
    const cuitEmpresa = $('#cuitEmpresa').val();
    const telefono1Empresa = $('#telefono1Empresa').val();
    const descripcion = $('#descripcion').val();
    const paisid = $("#paisID").val();    
    const provinciaid = $("#provinciaID").val();
    const localidadid = $("#localidadID").val();
    const domicilio = $('#domicilio').val();
    const altura = $('#nro').val();
    const rubroid = $("#rubroID").val();
    const empresaFoto = $('#fotoPerfilEmpresa').prop('files')[0]; // Get the selected file
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
        razonSocial: 'El nombre de la empresa no puede quedar vacio.',
        cuitEmpresa: 'El CUIT no puede quedar vacio.',
        telefono1Empresa: 'El numero de la empresa es obligatorio.',
        descripcion: 'La descripcion no puede quedar vacia.',
        paisid: 'Debe seleccionar un pais',
        provinciaid: 'Debe seleccionar un pais primero',
        localidadid: 'Debe seleccionar una provincia primero',
        domicilio: 'El domicilio no debe quedar vacio.',
        altura:'Seleccione la altura de su domicilio',
        rubroid: 'Debe seleccionar un rubro',
        empresaFoto: 'Debe seleccionar una foto de perfil.', // New error message for file input
    };

    const razonSocialRegex = /^[A-Za-z0-9_\s.'']+$/; // Only letters, numbers and spaces allowed
    const cuitEmpresaRegex = /^[\d-]+$/; // Only numbers allowed
    const telefono1EmpresaRegex = /^\d+$/; // Only numbers allowed
    const linkedinRegex = /^(https?:\/\/)?(www\.)?linkedin\.com\/[\w-]+\/?$/i;
    const instagramRegex = /^(https?:\/\/)?(www\.)?instagram\.com\/[\w-]+\/?$/i;
    const twitterRegex = /^(https?:\/\/)?(www\.)?twitter\.com\/[\w-]+\/?$/i;
    const linkedinValid = validateSocialMedia('#linkedin', linkedinRegex, 'El formato del enlace de LinkedIn no es válido. Por favor, ingrese un enlace válido o deje el campo vacío.');
    const instagramValid = validateSocialMedia('#instagram', instagramRegex, 'El formato del enlace de Instagram no es válido. Por favor, ingrese un enlace válido o deje el campo vacío.');
    const twitterValid = validateSocialMedia('#twitter', twitterRegex, 'El formato del enlace de Twitter no es válido. Por favor, ingrese un enlace válido o deje el campo vacío.');
    if (!linkedinValid || !instagramValid || !twitterValid) {
        return false;
    }

    const domicilioCompleto = `${domicilio} ${nro}`;

    let errorMessage = '';
    if (razonSocial.trim() === '') { errorMessage = errorMessages.razonSocial; }
    else if (!razonSocialRegex.test(razonSocial)) { errorMessage = 'El nombre de la empresa solo puede contener letras y espacios.'; }

    else if (cuitEmpresa.trim() === '') { errorMessage = errorMessages.cuitEmpresa; }
    else if (!cuitEmpresaRegex.test(cuitEmpresa)) { errorMessage = 'El CUIT solo puede contener números.'; }
    else if (cuitEmpresa.length !== 13) { errorMessage = 'El CUIT debe tener 11 caracteres.' }

    else if (telefono1Empresa.trim() === '') { errorMessage = errorMessages.telefono1Empresa; }
    else if (!telefono1EmpresaRegex.test(telefono1Empresa)) { errorMessage = 'El número de la empresa solo puede contener números.'; }
    else if (telefono1Empresa.length > 15) { errorMessage = 'El numero no puede tener  mas de 15 caracteres.' }

    else if (descripcion.trim() === '') { errorMessage = errorMessages.descripcion; }
    else if (descripcion.length <10 || descripcion.length > 600) { errorMessage = 'La descripción debe estar entre 10 y 600 caracteres.' }

    else if (paisid === '0') { errorMessage = errorMessages.paisid; }
    else if (provinciaid === '0') { errorMessage = errorMessages.provinciaid; }
    else if (localidadid === '0') { errorMessage = errorMessages.localidadid; }
    
    // Determina cuál campo está vacío y establece el mensaje de error correspondiente
    else if (domicilio.trim() === '' || altura.trim() === '') { errorMessage = (domicilio.trim() === '') ? errorMessages.domicilio : errorMessages.altura; }

    else if (rubroid === '0') { errorMessage = errorMessages.rubroid; }

    else if (!empresaFoto) { errorMessage = errorMessages.empresaFoto; }
   /* else if (provinciaID === '') { errorMessage = errorMessages.provinciad; }*/


    if (errorMessage) {
        alertEmpresa.textContent = errorMessage;        
        alertEmpresa.classList.add('alert-danger'); // Add text-danger class

        setTimeout(() => {
            alertEmpresa.textContent = '';  // Limpiar el mensaje después de 5 segundos
            alertEmpresa.classList.remove('alert-danger'); // Remove text-danger class
        }, 5000);

        return false;
    }
    else {        
        alertEmpresa.classList.remove('alert-danger'); // Remove text-danger class
    }

    const parametros = new FormData(formulario);
    const url = '../../Empresas/GuardarEmpresa';
    $.ajax({
        type: 'POST',
        url: url,
        data: parametros,
        contentType: false,
        processData: false,
        async: false,
        success: e => window.location.href = '/',
        error: e => console.log('error' + e)
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

$('#registrarEmpresa').on('submit', guardarEmpresa);


const razonSocialRegex = /^[A-Za-z0-9_\s.'']+$/;

const editarEmpresa = () => {
    event.preventDefault();
    const url = '../../Empresas/EditarEmpresa'
    const params = new FormData($('#frmFormulario')[0]);
    let alertEmpresa = $("#alertEmpresa");    
    let razon = $("#RazonSocial").val().trim();
    //let rubroID = $("#RubroID").val();
    let cuit = $("#Cuit").val().trim();
    let tel = $("#Telefono1").val().trim();
    let paisid = $("#paisID").val();
    let provinciaid = $("#provinciaID").val();
    let localidadid = $("#localidadID").val();
    let domicilio = $("#DomicilioEmpresa").val().trim();
    if (razon != "" && razon != null) {
        if (razonSocialRegex.test(razon)){
            if (cuit != "" && cuit != null) {
                if (tel != "" && tel != null) {
                    if (paisid != 0) {
                        if (provinciaid != 0) {
                            if (localidadid != 0) {
                                if (domicilio != "" && domicilio != null) {
                                    $.ajax({
                                        type: 'PUT',
                                        url: url,
                                        data: params,
                                        contentType: false,
                                        processData: false,
                                        async: false,
                                        success: e => window.location.href = '/empresas/PerfilEmpresa',
                                        error: e => console.log('error' + e)
                                    });

                                } else alertEmpresa.removeClass('visually-hidden').text('El domicilio es obligatorio');

                            } else alertEmpresa.removeClass('visually-hidden').text('Debe seleccionar una localidad');

                        } else alertEmpresa.removeClass('visually-hidden').text('Debe seleccionar una provincia');

                    } else alertEmpresa.removeClass('visually-hidden').text('Debe seleccionar un país');

                } else alertEmpresa.removeClass('visually-hidden').text('El Teléfono es obligatorio');

            } else alertEmpresa.removeClass('visually-hidden').text('Debe escribir un CUIT');

        } else alertEmpresa.removeClass('visually-hidden').text('La Razón Social contiene caracteres no permitidos');

    } else alertEmpresa.removeClass('visually-hidden').text('La Razón Social no puede estar vacía');
    setTimeout(() => alertEmpresa.addClass("visually-hidden"), 5000);
}

$('#paisID').change(function () {    
    BuscarProvincia(0);
});

//Si país llega en 0, se eliminan los valores del resto
if ($("#paisID").val() == 0) {
    var provincias = document.getElementById("provinciaID");
    var localidades = document.getElementById("localidadID");
    while (provincias.options.length > 1) {
        provincias.remove(1);
    } while (localidades.options.length > 1) {
        localidades.remove(1);
    }
}

function BuscarProvincia(provinciaID) {
    $('#provinciaID').empty();
    $.ajax({
        type: 'POST',
        async: false,
        url: '../../Provincias/ComboProvincia',
        data: { id: $('#paisID').val() },
        success: function (provincias) {
            if (provincias.length == 0) {
                $('#provinciaID').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`);
            }
            else {
                $.each(provincias, (i, provincia) => {
                    $('#provinciaID').append(`<option value=${provincia.value}>${provincia.text}</option>`)
                });
            }

            if (provinciaID > 0) {
                $("#provinciaID").val(provinciaID);
            } else {
                BuscarLocalidad(0);
            }

        },
        error: function (data) {
            console.log('error en combo provincias ' + data)
        }
    });
}




$('#provinciaID').change(function() { 
    BuscarLocalidad(0);
});

const BuscarLocalidad = (localidadID) => {    
    $('#localidadID').empty();
    let url = '../../Localidades/ComboLocalidades';
    let data = { id: $('#provinciaID').val() };
    $.post(url, data).done(localidades => {
        localidades.length === 0
            ? $('#localidadID').append(`<option value=${0}>[NO EXISTEN LOCALIDADES]</option>`)
            : $.each(localidades, (i, localidad) => {
                $('#localidadID').append(`<option value=${localidad.value}>${localidad.text}</option>`)
            });
        if (localidadID > 0) {
            $("#localidadID").val(localidadID);
        }

    }).fail(e => console.log('error en combo localidades' + e))
    return false
}


const BuscarEmpresa = (empresaID) => {
    $("#Titulo-Modal-Empresa").text("Editar Empresa");
    $("#EmpresaID").val(empresaID);
    $("#RazonSocial").val(RazonSocial);
    $("#Cuit").val(Cuit);
    $("#paisID").val(paisID);
    $("#provinciaID").val(provinciaID);
    $("#localidadID").val(localidadID);
    $("#Telefono1").val(Telefono1);
    $("#DomicilioEmpresa").val(DomicilioEmpresa);
    $("#CorreoEmpresa").val(CorreoEmpresa);
    $('#alertEmpresa').addClass('visually-hidden');
    let url = '../../Empresas/BuscarEmpresa';
    let data = { EmpresaID: empresaID };  
    $.post(url, data)
        .done(empresa => {
            $("#RazonSocial").val(empresa.razonSocial);
            $("#Cuit").val(empresa.cuit);
            $("#Telefono1").val(empresa.telefono1);
            $("#DomicilioEmpresa").val(empresa.domicilio);
            $("#paisID").val(empresa.paisID);
            BuscarProvincia(empresa.provinciaID);
            
            BuscarLocalidad(empresa.localidadID);
            
            $("#CorreoEmpresa").val(empresa.correo);
            $("#modalCrearEmpresa").modal("show");
        })
        .fail(e => console.log(e));
}

const AbrirModal = () => {
    $('#modalCrearEmpresa').modal('show');
    $('#provinciaID').val(0);
    $('#localidadID').val(0);
    $("#alertEmpresa").addClass('visually-hidden');
}

const VaciarFormulario = () => {
    $('#idEmpresa').val(0);
    $('#nombreEmpresa').val('')
}
