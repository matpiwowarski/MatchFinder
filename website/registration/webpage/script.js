var map, infoWindow;

function createMap () {
  var options = {
    // Maribor
    center: { lat: 46.5547200, lng: 15.6466700 },
    zoom: 10
  };

  map = new google.maps.Map(document.getElementById('map'), options);
  infoWindow = new google.maps.InfoWindow;

  // Google Maps handling errors
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(function (p) {
      var position = {
        lat: p.coords.latitude,
        lng: p.coords.longitude
      };

      infoWindow.setPosition(position);
      infoWindow.setContent('Your location!');
      infoWindow.open(map);
      map.setCenter(position);
    }, function () {
      handleLocationError('Geolocation service failed', map.getCenter());
    });
  } else {
    handleLocationError('No geolocation available.', map.getCenter());
  }
}

function handleLocationError (content, position) {
  infoWindow.setPosition(position);
  infoWindow.setContent(content);
  infoWindow.open(map);
}
