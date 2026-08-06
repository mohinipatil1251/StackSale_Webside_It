// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// =========================
// Mobile Navigation Toggle
// =========================
(function () {
    var navToggle = document.getElementById('navToggle');
    var navLinks = document.getElementById('navLinks');
    var navBackdrop = document.getElementById('navBackdrop');
    var mainNavbar = document.getElementById('mainNavbar');

    if (!navToggle || !navLinks) {
        return;
    }

    function closeMenu() {
        navLinks.classList.remove('open');
        navToggle.classList.remove('active');
        navToggle.setAttribute('aria-expanded', 'false');
        if (navBackdrop) navBackdrop.classList.remove('show');
        document.body.classList.remove('nav-open');
    }

    function openMenu() {
        navLinks.classList.add('open');
        navToggle.classList.add('active');
        navToggle.setAttribute('aria-expanded', 'true');
        if (navBackdrop) navBackdrop.classList.add('show');
        document.body.classList.add('nav-open');
    }

    navToggle.addEventListener('click', function () {
        if (navLinks.classList.contains('open')) {
            closeMenu();
        } else {
            openMenu();
        }
    });

    // Close menu when a nav link is tapped (mobile)
    navLinks.querySelectorAll('a').forEach(function (link) {
        link.addEventListener('click', closeMenu);
    });

    // Close menu when tapping outside of it
    if (navBackdrop) {
        navBackdrop.addEventListener('click', closeMenu);
    }

    // Close menu on resize back to desktop width
    window.addEventListener('resize', function () {
        if (window.innerWidth > 992) {
            closeMenu();
        }
    });

    // Close menu on Escape key
    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') {
            closeMenu();
        }
    });

    // Shrink navbar slightly on scroll for a more app-like feel
    if (mainNavbar) {
        window.addEventListener('scroll', function () {
            if (window.scrollY > 10) {
                mainNavbar.classList.add('scrolled');
            } else {
                mainNavbar.classList.remove('scrolled');
            }
        });
    }
})();
