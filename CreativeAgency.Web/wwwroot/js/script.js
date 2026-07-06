document.addEventListener('DOMContentLoaded', function () {
    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(function (link) {
        if (link.classList.contains('active')) {
            link.setAttribute('aria-current', 'page');
        }
    });
});
