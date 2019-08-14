// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {
    var lat = position.coords.latitude;
    var long = position.coords.longitude;

    document.getElementById("lat").value = lat;
    document.getElementById("long").value = long;
}

function getRating(rating) {
    var rating = Math.round(rating * 2) / 2

    for (i = 0; i < 5; i++) {
        if (i < rating) {
            var span = document.createElement("span");
            span.setAttribute('class', 'fa fa-star checked');
            span.setAttribute('style', 'font-size:50px')
            document.getElementById("star-rating").appendChild(span);
        } else {
            var span = document.createElement("span");
            span.setAttribute('class', 'fa fa-star');
            span.setAttribute('style', 'font-size:50px')
            document.getElementById("star-rating").appendChild(span);
        }
    };
}

