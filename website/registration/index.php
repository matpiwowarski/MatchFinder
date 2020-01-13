<?php

use yii\helpers\Html;
/* @var $this yii\web\View */


//ACTIVE FORM POST 
use yii\widgets\ActiveForm;


$this->title = 'Match Finder';
?>
<div class="site-index">

    <center>
        <div>
            <?= Html::img("@web/photos/Logo_Name.png", ['width' => '70%'])?>
         </div>
    </center>
    <div class="body-content">
    <center><h1>Proposed match</h1>
    <h1 id='stadiumName'> <?= $array[0]['name'] ?> </h1>
    <h6 id='stadiumStreet'> <?= $array[0]['street'] ?>   </h6>
    <h6 id='stadiumNumber'> <?= $array[0]['number'] ?> </h6>  
     <h6 id='cityName'> <?= $array[0]['cityname'] ?> </h6> 
     <h6 id='countryName'> <?= $array[0]['countryname'] ?> </h6><br>
     <h6 id='gameDate'> <?= $array[0]['game_date'] ?> </h6>
     
    </center>
        <div class="row">
            <div class="col-lg-5">
            
                <center><h2 id='homeTeam'> <?= $hometeam ?> </h2></center>
                <center> <h4 id='teamPosition'> Team current position: <?= $array[0]['position'] ?>   </h4> 
                 <h4 id='games_played'> Games played: <?= $array[0]['games_played'] ?> </h4> <br>  
                 <h5 id='wins'> Wins:  <?= $array[0]['wins'] ?> </h5> 
                 <h5 id='draws'> Draws: <?= $array[0]['draws'] ?> </h5> 
                 <h5 id='loses'> Loses: <?= $array[0]['loses'] ?> </h5> 
                 <h5 id='points'> Points: <?= $array[0]['points'] ?> </h5><br>

                 <h5 id='goalsScored'> Goals scored: <?= $array[0]['goalsScored'] ?> </h5> 
                 <h5 id='goalsAgainst'> Goals conceded: <?= $array[0]['goalsAgainst'] ?> </h5> 
                 <h5 id='goalsDifference'> Goals difference: <?= $array[0]['goalsDifference'] ?> </h5>  <br>
                 
              
                 <!-- <?= Html::img("@web/photos/form/lost.png"); ?>

                  <?php if($array[0]['5th_last_game']=='W'){
                     echo(Html::img("@web/photos/form/won.png"));
                 }
                     else if($array[0]['5th_last_game']=='D'){             
                        echo(Html::img("@web/photos/form/draw.png"));
                 }
                 else{
                   echo(Html::img("@web/photos/form/lost.png"));
                 }
               ?> -->
              

                  Last 5 games:     
                 <h6 id='5th_last_game'> <?= $array[0]['5th_last_game'] ?> </h6> 
                 <h6 id='4th_last_game'> <?= $array[0]['4th_last_game'] ?> </h6> 
                 <h6 id='3rf_last_game'> <?= $array[0]['3rd_last_game'] ?> </h6> 
                 <h6 id='2nd_last_game'> <?= $array[0]['2nd_last_game'] ?> </h6> 
                 <h6 id='last_game'> <?= $array[0]['last_game'] ?> </h6> 
                 
                
                 </center>
            </div>
            <div class="col-lg-2">
            <center><h2>Vs</h2></center>
          
            </div>
            <div class="col-lg-5">
             <center><h2 id="awayTeam"> <?= $awayteam?> </h2></center> 

             <center> <h4 id='teamPosition1'> Team current position: <?= $array[1]['position'] ?>   </h4> 
                 <h4 id='games_played1'> Games played: <?= $array[1]['games_played'] ?> </h4> <br>  
                 <h5 id='wins1'> Wins:  <?= $array[1]['wins'] ?> </h5> 
                 <h5 id='draws1'> Draws: <?= $array[1]['draws'] ?> </h5> 
                 <h5 id='loses1'> Loses: <?= $array[1]['loses'] ?> </h5> 
                 <h5 id='points1'> Points: <?= $array[1]['points'] ?> </h5><br>

                 <h5 id='goalsScored1'> Goals scored: <?= $array[1]['goalsScored'] ?> </h5> 
                 <h5 id='goalsAgainst1'> Goals conceded: <?= $array[1]['goalsAgainst'] ?> </h5> 
                 <h5 id='goalsDifference1'> Goals difference: <?= $array[1]['goalsDifference'] ?> </h5>  <br>
                 
              
                 <!-- <?= Html::img("@web/photos/form/lost.png"); ?>

                  <?php if($array[0]['5th_last_game']=='W'){
                     echo(Html::img("@web/photos/form/won.png"));
                 }
                     else if($array[0]['5th_last_game']=='D'){             
                        echo(Html::img("@web/photos/form/draw.png"));
                 }
                 else{
                   echo(Html::img("@web/photos/form/lost.png"));
                 }
               ?> -->
              

                  Last 5 games:     
                 <h6 id='5th_last_game1'> <?= $array[1]['5th_last_game'] ?> </h6> 
                 <h6 id='4th_last_game1'> <?= $array[1]['4th_last_game'] ?> </h6> 
                 <h6 id='3rf_last_game1'> <?= $array[1]['3rd_last_game'] ?> </h6> 
                 <h6 id='2nd_last_game1'> <?= $array[1]['2nd_last_game'] ?> </h6> 
                 <h6 id='last_game1'> <?= $array[1]['last_game'] ?> </h6> 
                 
                
                 </center>
            </div>
        </div>
        <!-- TABLE WITH RANKING TODO -->
       <!-- <center>
        <table class="table"style="width:70%">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">First</th>
      <th scope="col">Last</th>
      <th scope="col">Handle</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>Mark</td>
      <td>Otto</td>
      <td>@mdo</td>
    </tr>
    <tr>
      <th scope="row">2</th>
      <td>Jacob</td>
      <td>Thornton</td>
      <td>@fat</td>
    </tr>
    <tr>
      <th scope="row">3</th>
      <td>Larry</td>
      <td>the Bird</td>
      <td>@twitter</td>
    </tr>
  </tbody>
</table>
</center> -->

            <p><button id="showAllStadiums" class="btn btn-default">Show all stadiums </a></button>
            <button id="showSloviniaStadiums" class="btn btn-default">Show Slovenian stadiums </a></button>
            <button id="showAustrianStadiums" class="btn btn-default">Show Austrian stadiums </a></button>
            

            </p>
        <!-- Google maps -->
         <input id="search" class="form-control" type+"text" placeholder="Search place..."/>
         <div id="map"></div>
        <!-- Top click -->
        <button onclick="topFunction()" id="myBtn" title="Go to top">Top</button>
    </div>
</div>


  <!-- -----------------------  GOOGLE MAPS API  --------------------- -->  
  <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDLvth24crhg6AXpC-C2P1-buCS1s4l1oE&callback=createMap&libraries=places" async defer></script>