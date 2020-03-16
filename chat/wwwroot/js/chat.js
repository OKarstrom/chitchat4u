"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var nr = 1;
//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg;

    var l = msg;
    if (l.length > 100) {
        l = l + "<br />";
    }
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    if (nr == 1) {
        nr = 2;
        li.classList.add("user-class");
    } else {
        nr = 1;
        li.classList.add("nonuser-class");
    }
    document.getElementById("messagesList").appendChild(li);
    document.getElementById("messageInput").value = "";
    updateScroll();
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = "Oskar"
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});



var friends = [
    { 
        name: 'Oskar',
        age: 28,
        src: '../img/oskar.jpg'
    },
    {
        name: 'Filip',
        age: 28,
        src: '../img/fille.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    },
    {
        name: 'Ulf',
        age: 30,
        src: '../img/nopic.png'
    },

]


for (var friend in friends) {
    document.getElementById('friendList').innerHTML += '<li class="profile-img"; style="background-image: url(' + friends[friend].src + ');"><button class="profile-name">' + friends[friend].name + '</button></li>';

}

function updateScroll() {
    var element = document.getElementById("chatbox");
    element.scrollTop = element.scrollHeight;
}