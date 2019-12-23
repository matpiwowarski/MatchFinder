<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>MatchFinder</title>

    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/styleAPI.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Cabin&display=swap" rel="stylesheet">
</head>
<body>

    <header>
        
        <nav id="nav">
            <ul>
                <li class="nav-li"><a href="index.php">HOME</a></li>
                <li class="nav-li"><a href="news.php">SEARCH</a></li>
                <li class="nav-li"><a href="teams.php">MATCHES</a></li>
                <li class="nav-li"><a href="about.php">ALL TEAMS</a></li>
                <li class="nav-li"><a href="registration/index.php">REGISTRATION</a></li>
            </ul>
        </nav>
          
    
     </header>

    <main>
        <div class="logo" >
            <img src="pictures/matchlogo.png" alt="logo">
        </div>

        <div class="scoreboard">
            <div class="team">

                <div class="team1">
                    <h1>NK Maribor</h1>
                    <h3>1st place</h3>
                    <img src="pictures/form/won.png" alt="W">
                    <img src="pictures/form/won.png" alt="W">
                    <img src="pictures/form/draw.png" alt="D">
                    <img src="pictures/form/won.png" alt="W">
                    <img src="pictures/form/lost.png" alt="L">
                </div>

                <div class="versus">
                    <h2>VS</h2>
                </div>

                <div class="team2">
                    <h1>Manchester United</h1>
                    <h3>5th place</h3>
                    <img src="pictures/form/draw.png" alt="D">
                    <img src="pictures/form/draw.png" alt="D">
                    <img src="pictures/form/won.png" alt="W">
                    <img src="pictures/form/lost.png" alt="L">                  
                    <img src="pictures/form/won.png" alt="W">
                </div>
            </div>
        

            <div class="time">

            </div>
        </div>

      
         <!-- Google maps -->
         <input id="search" type+"text" placeholder="Search place..."/>
         <div id="map"></div>
         <!-- Top click -->
         <button onclick="topFunction()" id="myBtn" title="Go to top">Top</button> 

    </main>

    <footer>
        <div class="socialmedia"> 
            <a href=""><img src="pictures/instagram.jpg" alt="instagram" class="instagram"></a>
            <a href=""><img src="pictures/facebook.png" alt="facebook" class= "facebook"></a>
            <a href=""><img src="pictures/gmail.png" alt="gmail dg" class= "gmail"></a>
            
        </div>

        <div class="languages">
            <h3>Change languages</h3>
            <nav id="nav">
                <ul> 
                    <li class="nav-li"><a href="German">German</a></li>
                    <li class="nav-li"><a href="Polish">Polish</a></li>
                    <li class="nav-li"><a href="Turkish">Turkish</a></li>
                </ul>
            </nav>
        </div>


    </footer>

  <!-- -----------------------  SOURCES  --------------------- -->  
  <!-- Google Maps scripts. -->
  <script src="js/script.js"></script>
  <script src="https://maps.googleapis.com/maps/api/js?key=IzaSyDLvth24crhg6AXpC-C2P1-buCS1s4l1oE&callback=createMap&libraries=places" async defer></script>
  <!-- scroll button script -->
  <script src="js/scrollButton.js"></script>

</body>
</html>