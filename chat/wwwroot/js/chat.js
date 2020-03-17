"use strict";

var user = '12';

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var nr = 1;
//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = msg;

    var li = document.createElement("li");
    li.textContent = encodedMsg;
    if (nr == user) {
        nr = user;
        li.classList.add("user-class");
    } else {
        nr = user;
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
    var message = document.getElementById("messageInput").value;
    console.log(user, message);
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});



var friends = [
    { 
        name: 'Oskar',
        age: 28,
        userID: 123,
        src: '../img/oskar.jpg'
    },
    {
        name: 'Filip',
        age: 28,
        userID: 1234,
        src: '../img/fille.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        userID: 12345,
        src: '../img/christian.jpg'
    },
    {
        name: 'Ulf',
        age: 30,
        userID: 123456,
        src: '../img/nopic.png'
    }
]


for (var friend in friends) {
    document.getElementById('friendList').innerHTML += '<li class="profile-img"; style="background-image: url(' + friends[friend].src + ');"><button class="profile-name" onclick="newChat(' + friends[friend].userID + ')";>' + friends[friend].name + '</button></li>';

}

function updateScroll() {
    var element = document.getElementById("chatbox");
    element.scrollTop = element.scrollHeight;
}

function newChat(friend) {
    document.getElementById("messagesList").innerHTML = '';
    for (var i = 0; i < chatLog.length; i++) {
        if (user == chatLog[i].userID && friend == chatLog[i].friendID) {
            var conn = chatLog[i].connID;
        }
        }
    if (conn == null) {
        var newConnID = chatLog.length + 1;
        chatLog.push({
            user, friend, newConnID
        })
        conn = newConnID;
    }

    console.log(conn);
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
        if (user == m.sender) {
            li.classList.add("user-class");
        } else {
            li.classList.add("nonuser-class");
        }
        document.getElementById("messagesList").appendChild(li);
        document.getElementById("messageInput").value = "";
        updateScroll();
    })
}

var chatLog = [
    {
        userID: 12,
        friendID: 123,
        connID: 0,
    },
    {
        userID: 12,
        friendID: 1234,
        connID: 1,    
    },
    {
        userID: 12,
        friendID: 12345,
        connID: 2
    },
    {
        userID: 12,
        friendID: 123456,
        connID: 3
    }]

var chatMessages = [
    [
    {
        message: 'Hejsan',
        sender: 12
    },
    {
        message: 'Tjabba',
        sender: 123
    },
    {
        message: 'Läget?',
        sender: 12
    },
    {
        message: 'Jo det är bra!',
        sender: 123
    },
    {
        message: 'Själv då?',
        sender: 123
        }],
    [
        {
            message: 'Jag heter Staffansson i efternamn',
            sender: 12
        },
        {
            message: 'Jaså, Jag heter Bullared.',
            sender: 1234
        },
        {
            message: 'Fan va coolt, är du född där??',
            sender: 12
        },
        {
            message: 'Var?',
            sender: 1234
        },
        {
            message: 'Ullared?',
            sender: 1234
        },
        {
            message: 'Nej',
            sender: 12
        }],
    [
        {
            message: 'Katt',
            sender: 12
        },
        {
            message: 'Kattmat.',
            sender: 12345
        },
        {
            message: 'rar',
            sender: 12
        },
        {
            message: 'Mögelost',
            sender: 12345
        },
        {
            message: 'fy fan va snuskigt',
            sender: 12345
        },
        {
            message: 'Nej',
            sender: 12
        }],
    [
        {
            message: 'Vem du?',
            sender: 12
        },
        {
            message: 'Ulf heter jag.',
            sender: 123456
        },
        {
            message: 'Stick. du har ju inte ens en profilbild. Noob!',
            sender: 12
        }],
    ]
    