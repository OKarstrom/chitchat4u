// When the user clicks anywhere outside of the modal, close it

var modal = document.getElementById('id03');

window.onclick = function (event) {
    if (event.target == modal || event.target == this.modal2) {
        modal.style.display = "none";
        this.modal2.style.display = "none";
    }
}