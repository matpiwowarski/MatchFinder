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
      // if we do not have data for place(lan,lon)
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
  

document.getElementById("showAllStadiums").addEventListener("click", function(){

  $.get('index.php?r=stadium/stadium-array-json&countryName=Austria&json=true)', function(data)
    {
        stadiumArray = JSON.parse(data);

        var i;
        for (i = 0; i < stadiumArray.length; i++) {
      markers.push(new google.maps.Marker({
      map: map,
      title: stadiumArray[i].street,
      position:{lat: parseFloat(stadiumArray[i].latitude), lng: parseFloat(stadiumArray[i].longitude)},
    }));;
    }
    var bounds = new google.maps.LatLngBounds();

   bounds.extend({lat: parseFloat(stadiumArray[1].latitude), lng: parseFloat(stadiumArray[1].longitude)});
   
   map.setCenter(bounds.getCenter());
  //  map.fitBounds(bounds);
  zoomChangeBoundsListener = 
    google.maps.event.addListenerOnce(map, 'bounds_changed', function(event) {
        if ( this.getZoom() ){   // or set a minimum
            this.setZoom(6);  // set zoom here
        }
});

setTimeout(function(){google.maps.event.removeListener(zoomChangeBoundsListener)}, 2000);
  }
  )
});

}
 

// function getStadiumJson(countryName)
// {
//     $.get('index.php?r=stadium/stadium-array-json&countryName=' + countryName + '&json=true)', function(data)
//     {
//         stadiumArray = JSON.parse(data);
//         window.alert(stadiumArray[0].latitude);
//     }
//     )
// }

// var marker = new google.maps.Marker({
//   map: map,
//   title: "salzburg",
//   position: {lat: parseFloat(stadiumArray[0].latitude), lng: parseFloat(stadiumArray[0].longitude)}
// })
// }
// )