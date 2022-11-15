﻿function login(){	
	event.preventDefault();
	let correo =	$('#loginCorreo').val();
	let pass = $('#loginPass').val();
	let url = '../../GestionDeUsuarios/Ingresar';
	let data = { email: correo, password:pass};
	$.post(url, data).done(resultado => {
		resultado ? window.location.href='/' : alert('usuario o contraseña incorrecta')
	}).fail(e => console.log(e))
}

function registerPerson(){
	event.preventDefault();
	let rol = $('#rol').val()
	let correo= $('#correo').val()
	let pass= $('#pass').val();
	let passConfirm= $('#passRepeat').val();
	//$("#registrarPersona").addClass('visually-hidden')
	//$('#loaderRegisterPersona').removeClass('visually-hidden')
	let url = '../../GestionDeUsuarios/Registrar';
	let data = { email: correo, password: pass, Rol: rol }
	if(pass === passConfirm){
		$.post(url,data).done(
			(resultado)=>{
				if (resultado) {
					window.location.href = '/'
				}else{
					$('#errorRegisterPersona').text('El usuario ya existe')
					$('#errorRegisterPersona').removeClass('visually-hidden');
					$('#loaderRegisterPersona').addClass('visually-hidden');
					$("#registrarPersona").removeClass('visually-hidden');
				}
			}
		)
	}else{
		$('#errorRegisterPersona').text('Las contraseñas no coinciden')
		$('#errorRegisterPersona').removeClass('visually-hidden');
		$('#loaderRegisterPersona').addClass('visually-hidden');
		$("#registrarPersona").removeClass('visually-hidden');
	}

}
function loginPersona(){	
	event.preventDefault();
	let correoPersona=	$('#correoPersona').val();
	let passPersona= $('#passwordPersona').val();
	let url = '../../GestionDeUsuarios/Ingresar';
	let loader = document.getElementById('loaderLoginPersona') 
	$('#iniciarSesionPersona').addClass('visually-hidden');
	$('#loaderLoginPersona').removeClass('visually-hidden');
	let data = { email: correoPersona, password:passPersona};
	$.post(url, data).done(resultado => {
		if(resultado){
			window.location.href='/'
		}else{
			loader.classList.add('visually-hidden');
			$('#errorInicioSesion').removeClass('visually-hidden');
			$('#iniciarSesionPersona').removeClass('visually-hidden')
		}
	}).fail(e => {
		$('#iniciarSesionPersona').removeClass('visually-hidden')
		$('#errorInicioSesion').removeClass('visually-hidden')
		loader.classList.add('visually-hidden')	
	})
}