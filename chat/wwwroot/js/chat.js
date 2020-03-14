
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
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    },
    {
        name: 'Christian',
        age: 30,
        src: '../img/christian.jpg'
    }
]


for (var friend in friends) {
    document.getElementById('friendList').innerHTML += '<li class="profile-img"; style="background-image: url(' + friends[friend].src + ');"><button class="profile-name">' + friends[friend].name + '</button></li>';

}

