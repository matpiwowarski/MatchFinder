var map, infoWindow;

function createMap () {
  var options = {
    center: { lat:  46.558853, lng: 15.637981 },
    zoom: 10
  };

  map = new google.maps.Map(document.getElementById('map'), options);



  // ---------------- SEARCH BAR -----------------------
 var input = document.getElementById('search');
 var searchBox = new google.maps.places.SearchBox(input);

 map.addListener('bounds_changed', function() {
   searchBox.setBounds(map.getBounds());
  });

  var markers = [];
  
  // For search suggestions
  searchBox.addListener('places_changed', function () {
    // take searched place
    var places = searchBox.getPlaces();
    
    // if choosen place is not on the list
    if (places.length == 0)
      return;

    // erase all markers, foreach marker set null
    markers.forEach(function (m) { m.setMap(null); });
    // delete all markers from array
    markers = [];

    var bounds = new google.maps.LatLngBounds();
    places.forEach(function(p) {
      // if we don not have data for place(lan,lon)
      if (!p.geometry)
        return;
      
      // push new marker for our markers array
      markers.push(new google.maps.Marker({
        map: map,
        title: p.name,
        position: p.geometry.location,
        draggable: true,
        animation: google.maps.Animation.DROP
      }));
      markers[0].addListener('click', toggleBounce);

      function toggleBounce() {
        if (markers[0].getAnimation() !== null) {
          markers[0].setAnimation(null);
        } else {
          markers[0].setAnimation(google.maps.Animation.BOUNCE);
        }
      }

     

      if (p.geometry.viewport)
        bounds.union(p.geometry.viewport);
      else
        bounds.extend(p.geometry.location);
    });
    
    map.fitBounds(bounds);
    
  });
}  