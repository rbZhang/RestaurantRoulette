// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getLocation(mealType) {
    document.getElementById("mealType").value = mealType;

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        alert("Geolocation is not supported by this browser.");
    }
}

function showPosition(position) {
    var lat = position.coords.latitude;
    var long = position.coords.longitude;

    var geocoder = new google.maps.Geocoder();
    var location = new google.maps.LatLng(lat, long);
    geocoder.geocode({ 'latLng': location }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            var address = results[0].formatted_address;
            document.getElementById('addr-input').value = address;
            checkMealType();
        } else {
            alert("There was a problem finding your location.");
        }
    })
}

function checkMealType() {
    var mealType = document.getElementById("mealType").value;

    if (mealType != "") {
        document.getElementById("search-btn").click();
    }
}
