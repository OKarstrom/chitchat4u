// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function termsPopup() {
    var x = document.getElementById("snackbar");
    x.className = "show";
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
}

function openSignIn() {
    document.getElementById('id02').style.display = 'none';
    document.getElementById('id01').style.display = 'block';
}

function openRegister() {
    document.getElementById('id01').style.display = 'none';
    document.getElementById('id02').style.display = 'block';
}