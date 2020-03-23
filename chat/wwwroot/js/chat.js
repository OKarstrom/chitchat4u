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

function newChat(friend) {
    document.getElementById("messagesList").innerHTML = '';
    for (let i = 0; i < chatLog.length; i++) {
        if (user.userID == chatLog[i].userID && friend == chatLog[i].friendID) {
            var conn = chatLog[i].connID;
        }
        }
    if (conn == null) {
        var newConnID = chatLog.length + 1;
        var ID = user.userID;
        chatLog.push({
            ID, friend, newConnID
        })
        conn = newConnID;
    }

    chatMessages[conn].forEach(m => {
        console.log(m.message + " från: " + m.sender);
        var msg = m.message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = msg;

        var l = msg;
        if (l.length > 100) {
            l = l + "<br />";
        }
        var li = document.createElement("li");
        li.textContent = encodedMsg;
        if (user.userID == m.sender) {
            li.classList.add("user-class");
        } else {
            li.classList.add("nonuser-class");
        }
        document.getElementById("messagesList").appendChild(li);
        document.getElementById("messageInput").value = "";
        updateScroll();
    })
}