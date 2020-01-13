var map, infoWindow;

function createMap() {
  var options = {
    center: { lat: 46.558853, lng: 15.637981 },
    zoom: 10
  };

  map = new google.maps.Map(document.getElementById("map"), options);

  // ---------------- SEARCH BAR -----------------------
  var input = document.getElementById("search");
  var searchBox = new google.maps.places.SearchBox(input);

  map.addListener("bounds_changed", function() {
    searchBox.setBounds(map.getBounds());
  });

  var markers = [];
  var markersStadiums = [];
  var longitude;

  // For search suggestions
  searchBox.addListener("places_changed", function() {
    // take searched place
    var places = searchBox.getPlaces();

    // if choosen place is not on the list
    if (places.length == 0) return;

    // erase all markers, foreach marker set null
    markers.forEach(function(m) {
      m.setMap(null);
    });
    // delete all markers from array
    markers = [];

    var bounds = new google.maps.LatLngBounds();
    places.forEach(function(p) {
      // if we do not have data for place(lan,lon)
      if (!p.geometry) return;

      // push new marker for our markers array
      markers.push(
        new google.maps.Marker({
          map: map,
          title: p.name,
          position: p.geometry.location,
          draggable: true,
          animation: google.maps.Animation.DROP
        })
      );

      toggleBounce();

      if (p.geometry.viewport) bounds.union(p.geometry.viewport);
      else bounds.extend(p.geometry.location);
    });

    //toggleBounce();
    function toggleBounce() {
      if (markers[0].getAnimation() !== null) {
        markers[0].setAnimation(null);
      } else {
        markers[0].setAnimation(google.maps.Animation.BOUNCE);
      }
    }

    map.fitBounds(bounds);

    //toggleBounce();
  });

  searchBox.addListener("places_changed", function() {
    $.get(
      "index.php?r=game/get-game-json&userlatitude=" +
        markers[0].position.lat() +
        "&userlongitude=" +
        markers[0].position.lng(),
      function(data) {
        const bestGame = JSON.parse(data);
        console.log(bestGame);
        // console.log(typeof data);
        //SCROLL UP
        document.body.scrollTop = 0; // For Safari
        document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera

        document.getElementById("homeTeam").textContent = bestGame[0].team;
        document.getElementById("awayTeam").textContent = bestGame[1].team;
        // Stadium info
        document.getElementById("stadiumName").textContent = bestGame[0].name;
        //        document.getElementById("leagueName").textContent = bestGame[0].league;
        document.getElementById("stadiumStreet").textContent =
          bestGame[0].street;
        document.getElementById("stadiumNumber").textContent =
          bestGame[0].number;
        document.getElementById("cityName").textContent = bestGame[0].cityname;
        document.getElementById("countryName").textContent =
          bestGame[0].countryname;
        document.getElementById("gameDate").textContent = bestGame[0].game_date;
        // Home team info
        document.getElementById("teamPosition").textContent =
          bestGame[0].position;
        document.getElementById("games_played").textContent =
          bestGame[0].games_played;
        document.getElementById("wins").textContent = bestGame[0].wins;
        document.getElementById("draws").textContent = bestGame[0].draws;
        document.getElementById("loses").textContent = bestGame[0].loses;
        document.getElementById("points").textContent = bestGame[0].points;
        document.getElementById("goalsScored").textContent =
          bestGame[0].goalsScored;
        document.getElementById("goalsAgainst").textContent =
          bestGame[0].goalsAgainst;
        document.getElementById("goalsDifference").textContent =
          bestGame[0].goalsDifference;
        document.getElementById("5th_last_game").textContent =
          bestGame[0].a5th_last_game;
        document.getElementById("4th_last_game").textContent =
          bestGame[0].a4th_last_game;
        document.getElementById("3rd_last_game").textContent =
          bestGame[0].a3rd_last_game;
        document.getElementById("2nd_last_game").textContent =
          bestGame[0].a2nd_last_game;
        document.getElementById("last_game").textContent =
          bestGame[0].alast_game;

        // Away team info

        document.getElementById("teamPosition1").textContent =
          bestGame[1].position;
        document.getElementById("games_played1").textContent =
          bestGame[1].games_played;
        document.getElementById("wins1").textContent = bestGame[1].wins;
        document.getElementById("draws1").textContent = bestGame[1].draws;
        document.getElementById("loses1").textContent = bestGame[1].loses;
        document.getElementById("points1").textContent = bestGame[1].points;
        document.getElementById("goalsScored1").textContent =
          bestGame[1].goalsScored;
        document.getElementById("goalsAgainst1").textContent =
          bestGame[1].goalsAgainst;
        document.getElementById("goalsDifference1").textContent =
          bestGame[1].goalsDifference;
        document.getElementById("5th_last_game1").textContent =
          bestGame[1].a3rd_last_game;
        document.getElementById("4th_last_game1").textContent =
          bestGame[1].a4th_last_game;
        document.getElementById("3rd_last_game1").textContent =
          bestGame[1].a3rd_last_game;
        document.getElementById("2nd_last_game1").textContent =
          bestGame[1].a2nd_last_game;
        document.getElementById("last_game1").textContent =
          bestGame[1].alast_game;
      }
    );
  });

  function displayStadiumsOnMap(country) {
    // erase all markers, foreach marker set null
    markersStadiums.forEach(function(m) {
      m.setMap(null);
    });
    // delete all markers from array
    markersStadiums = [];

    $.get(
      "index.php?r=stadium/stadium-array-json&countryName=" +
        country +
        "&json=true)",
      function(data) {
        stadiumArray = JSON.parse(data);

        var i;
        for (i = 0; i < stadiumArray.length; i++) {
          markersStadiums.push(
            new google.maps.Marker({
              map: map,
              title: stadiumArray[i].street,
              position: {
                lat: parseFloat(stadiumArray[i].latitude),
                lng: parseFloat(stadiumArray[i].longitude)
              }
            })
          );
        }

        // Opening google maps with navigate to stadium
        for (i = 0; i < markersStadiums.length; i++) {
          let stadiumChosen = markersStadiums[i];
          markersStadiums[i].addListener("click", function() {
            $lonUser = markers[0].getPosition().lat();
            $lngUser = markers[0].getPosition().lng();
            $lonStadium = stadiumChosen.getPosition().lat();
            $lngStadium = stadiumChosen.getPosition().lng();
            window.open(
              " https://www.google.pl/maps/dir/'" +
                $lonUser +
                "," +
                $lngUser +
                "'/'" +
                $lonStadium +
                "," +
                $lngStadium +
                "'",
              "_blank"
            );
          });
        }

        // setting right bounds
        var bounds = new google.maps.LatLngBounds();

        bounds.extend({
          lat: parseFloat(stadiumArray[1].latitude),
          lng: parseFloat(stadiumArray[1].longitude)
        });

        map.setCenter(bounds.getCenter());

        zoomChangeBoundsListener = google.maps.event.addListenerOnce(
          map,
          "bounds_changed",
          function(event) {
            if (this.getZoom()) {
              // or set a minimum
              this.setZoom(6); // set zoom here
            }
          }
        );

        setTimeout(function() {
          google.maps.event.removeListener(zoomChangeBoundsListener);
        }, 2000);
      }
    );
  }

  // ------------------------- Button Show stadiums --------------------------------
  document
    .getElementById("showAllStadiums")
    .addEventListener("click", function() {
      displayStadiumsOnMap("Austria");
      displayStadiumsOnMap("Slovenia");
    });

  document
    .getElementById("showSloviniaStadiums")
    .addEventListener("click", function() {
      displayStadiumsOnMap("Slovenia");
    });

  document
    .getElementById("showAustrianStadiums")
    .addEventListener("click", function() {
      displayStadiumsOnMap("Austria");
    });
  // ------------------------- Button Show stadiums --------------------------------
}
