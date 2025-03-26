// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



// Funktion, die überprüft, ob die Bildschirmgröße unter 600px fällt
function checkScreenSize() {
    var element = document.getElementById("width-control");

    if (window.innerWidth < 1000) {
        // Entfernt die 'd-flex' Klasse, wenn die Bildschirmgröße unter 600px fällt
        element.classList.remove('d-flex');
    } else {
        // Fügt die 'd-flex' Klasse wieder hinzu, wenn die Bildschirmgröße 600px oder größer ist
        element.classList.add('d-flex');
    }
}

// Event Listener für das Fensterresize-Ereignis
window.addEventListener('resize', checkScreenSize);

// Initiale Überprüfung beim Laden der Seite
checkScreenSize();
