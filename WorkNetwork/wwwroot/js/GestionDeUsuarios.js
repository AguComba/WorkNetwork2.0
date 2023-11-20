

function vaciarForm() {
    $("#loginCorreo").val("");
    $("#loginPass").val("");
    $('#loginError').addClass('visually-hidden');
}

function isValidEmail(email) {
    // Expresión regular para validar el formato del correo electrónico
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    // Lista de dominios permitidos
    const allowedDomains = ['gmail.com', 'yahoo.com', 'outlook.com', 'hotmail.com', 'live.com', 'hotmail.com.ar']; 

    // Verifica el formato del correo electrónico
    if (!emailRegex.test(email)) {
        return false;
    }

    // Obtiene el dominio del correo electrónico
    const domain = email.split('@')[1];

    // Verifica si el dominio está en la lista de dominios permitidos
    if (!allowedDomains.includes(domain)) {
        return false;
    }

    return true;
}

function registerPerson() {
    event.preventDefault();
    let rol = $('#rol').val();
    let correo = $('#correo').val().trim();
    let pass = $('#pass').val();
    let passConfirm = $('#passRepeat').val();
    $("#registerBtn").addClass("visually-hidden")
    $('#registerLoader').removeClass("visually-hidden")
    let url = '../../GestionDeUsuarios/Registrar';
    let data = { email: correo, password: pass, Rol: rol }
    if (rol) {
        if (correo) {
            if (isValidEmail(correo)) {
                if (pass === passConfirm && pass !== '') {
                    $.post(url, data).done(
                        (resultado) => {
                            if (resultado) {
                                window.location.href = '/'
                            } else {
                                $('#registerError').text('El usuario ya existe')
                                $('#registerError').removeClass("visually-hidden");
                                $('#registerLoader').addClass("visually-hidden");
                                $("#registerBtn").removeClass("visually-hidden");
                            }
                        }
                    )
                } else {
                    $('#registerError').text('Las contraseñas no coinciden')
                    $('#registerError').removeClass("visually-hidden");
                    $('#registerLoader').addClass("visually-hidden");
                    $("#registerBtn").removeClass("visually-hidden");
                }
            } else {
                $('#registerError').text('El Correo no es válido')
                $('#registerError').removeClass("visually-hidden");
                $('#registerLoader').addClass("visually-hidden");
                $("#registerBtn").removeClass("visually-hidden");
            }
        } else {
            $('#registerError').text('Debe ingresar un correo')
            $('#registerError').removeClass("visually-hidden");
            $('#registerLoader').addClass("visually-hidden");
            $("#registerBtn").removeClass("visually-hidden");
        }

    } else {
        $('#registerError').text('Debe seleccionar un rol')
        $('#registerError').removeClass("visually-hidden");
        $('#registerLoader').addClass("visually-hidden");
        $("#registerBtn").removeClass("visually-hidden");
    }

}

function login() {
    event.preventDefault();
    let correo = $('#loginCorreo').val();
    let pass = $('#loginPass').val();
    let url = '../../GestionDeUsuarios/Ingresar';
    let data = { email: correo, password: pass };
    $('#loginBtn').addClass('visually-hidden');
    $('#loginLoader').removeClass('visually-hidden');
    $.post(url, data).done(resultado => {
        if (resultado) {            
            window.location.href = '/'
            
        } else {
            $("#loginLoader").addClass('visually-hidden');
            $('#loginError').removeClass('visually-hidden');
            $('#loginBtn').removeClass('visually-hidden')
        }
    }).fail(e => {
        $('#loginBtn').removeClass('visually-hidden')
        $('#loginError').removeClass('visually-hidden')
        $("#loginLoader").addClass('visually-hidden');
    })
}