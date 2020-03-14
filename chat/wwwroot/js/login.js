

function login() {
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;

    if (loginWorked(username, password)) {
        
    } else {
        alert("Username or password is incorrect!");
    }
}

function loginWorked(username, password) {
    //----------------------DATABASE CODE----------------------
    if (username === 'oskar' && password === 'oskar') {
        console.log('not fail');
        return true;
    } else {
        console.log('fail');
        return false;
    }
}

var modal = document.getElementById('id01');
var modal2 = document.getElementById('id02');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal || event.target == this.modal2) {
        modal.style.display = "none";
        this.modal2.style.display = "none";
    }
}
