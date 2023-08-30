////function login(){	
////	event.preventDefault();
////	let correo =	$('#loginCorreo').val();
////	let pass = $('#loginPass').val();
////	let url = '../../GestionDeUsuarios/Ingresar';
////	let data = { email: correo, password:pass};
////	$.post(url, data).done(resultado => {
////		resultado ? window.location.href='/' : alert('usuario o contraseña incorrecta')
////	}).fail(e => console.log(e))
////}

function vaciarForm() {
    $("#loginCorreo").val("");
    $("#loginPass").val("");
    $('#loginError').addClass('visually-hidden');
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
            //una vez logueado el usuario, dirigirlo a Paises si es superusuario
            //a perfil si es empresa o usuario preguntar si se envia a su perfil
            //o al listado de vacantes
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