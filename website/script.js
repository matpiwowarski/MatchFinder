var map, infoWindow;

function createMap () {
  var options = {
    // Maribor
    center: { lat: 46.5547200, lng: 15.6466700 },
    zoom: 10
  };

  map = new google.maps.Map(document.getElementById('map'), options);
}