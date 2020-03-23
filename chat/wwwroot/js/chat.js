"use strict";

//document.getElementById("userInfo").innerHTML = user.username;

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    let msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    let encodedMsg = msg;
    
    let li = document.createElement("li");
    li.textContent = encodedMsg;
    if (session.currenuserid === user) {
        li.classList.add("user-class");
    } else if (session.friendsid === user) {
        li.classList.add("nonuser-class");
    }
    else {
        return;
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
    let message = document.getElementById("messageInput").value;
    let users = [session.currenuserid, session.friendsid,session.id];
    connection.invoke("SendMessage", users, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function updateScroll() {
    var element = document.getElementById("chatbox");
    element.scrollTop = element.scrollHeight;
}