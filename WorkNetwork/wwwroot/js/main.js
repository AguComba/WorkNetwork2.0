/**
 * Template Name: UpConstruction - v1.2.1
 * Template URL: https://bootstrapmade.com/upconstruction-bootstrap-construction-website-template/
 * Author: BootstrapMade.com
 * License: https://bootstrapmade.com/license/
 */
document.addEventListener('DOMContentLoaded', () => {
	'use strict';

	/**
	 * Preloader
	 */
	const preloader = document.querySelector('#preloader');
	if (preloader) {
		window.addEventListener('load', () => {
			preloader.remove();
		});
	}

	/**
	 * Mobile nav toggle
	 */

	const mobileNavShow = document.querySelector('.mobile-nav-show');
	const mobileNavHide = document.querySelector('.mobile-nav-hide');

	document.querySelectorAll('.mobile-nav-toggle').forEach(el => {
		el.addEventListener('click', function (event) {
			event.preventDefault();
			mobileNavToogle();
		});
	});

	function mobileNavToogle() {
		document.querySelector('body').classList.toggle('mobile-nav-active');
		mobileNavShow.classList.toggle('d-none');
		mobileNavHide.classList.toggle('d-none');
	}

	/**
	 * Hide mobile nav on same-page/hash links
	 */
	document.querySelectorAll('#navbar a').forEach(navbarlink => {
		if (!navbarlink.hash) return;

		let section = document.querySelector(navbarlink.hash);
		if (!section) return;

		navbarlink.addEventListener('click', () => {
			if (document.querySelector('.mobile-nav-active')) {
				mobileNavToogle();
			}
		});
	});

	/**
	 * Toggle mobile nav dropdowns
	 */
	const navDropdowns = document.querySelectorAll('.navbar .dropdown > a');

	navDropdowns.forEach(el => {
		el.addEventListener('click', function (event) {
			if (document.querySelector('.mobile-nav-active')) {
				event.preventDefault();
				this.classList.toggle('active');
				this.nextElementSibling.classList.toggle('dropdown-active');

				let dropDownIndicator = this.querySelector('.dropdown-indicator');
				dropDownIndicator.classList.toggle('bi-chevron-up');
				dropDownIndicator.classList.toggle('bi-chevron-down');
			}
		});
	});

	/**
	 * Scroll top button
	 */
	const scrollTop = document.querySelector('.scroll-top');
	if (scrollTop) {
		const togglescrollTop = function () {
			window.scrollY > 100
				? scrollTop.classList.add('active')
				: scrollTop.classList.remove('active');
		};
		window.addEventListener('load', togglescrollTop);
		document.addEventListener('scroll', togglescrollTop);
		scrollTop.addEventListener(
			'click',
			window.scrollTo({
				top: 0,
				behavior: 'smooth',
			})
		);
	}

	/**
	 * Animation on scroll function and init
	 */
	function aos_init() {
		AOS.init({
			duration: 800,
			easing: 'slide',
			once: true,
			mirror: false,
		});
	}
	window.addEventListener('load', () => {
		aos_init();
	});

	//Para que la pestaña en la que este el usuario, se pinte de color
	// Get the current URL or controller (you may need to adjust this based on your routing)
	const currentUrl = window.location.pathname;

	// Get all the nav-links
	const navLinks = document.querySelectorAll('.nav-link');

	// Loop through each nav-link
	navLinks.forEach(link => {
		// Get the href attribute of the link
		const href = link.getAttribute('href');

		// Check if the current URL matches the link's href
		if (currentUrl === href) {
			// Add a CSS class to make it active
			link.classList.add('active');
		} else {
			// Remove the active class from other links
			link.classList.remove('active');
		}
	});
});

