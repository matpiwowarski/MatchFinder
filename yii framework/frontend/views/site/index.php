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
       <h1 id='stadiumName'> <?= $array[0]['name'] ?>  </h1> 
     <h5 id='leagueName'> <?= $array[0]['leagueName'] ?> </h5> <br>
    <h6> <h6 id='stadiumStreet'> <?= $array[0]['street'] ?>   </h6> </h6>
    <h6 id='stadiumNumber'> <?= $array[0]['number'] ?> </h6>  
     <h6 id='cityName'> <?= $array[0]['cityname'] ?> </h6> 
     <h6 id='countryName'> <?= $array[0]['countryname'] ?> </h6><br>
     <h6 id='gameDate' > <?= $array[0]['game_date'] ?> </h6> <br>
     
    </center> 
        <div class="row">
            <div class="col-lg-5">
             
                <center><h2 id='homeTeam'> <?= $array[0]['teamName'] ?> </h2></center>
                <center> <h4> Position:</h4> <h4 id='teamPosition'> <?= $array[0]['position'] ?>   </h4> <br> 
               <h5> Games played: </h5>   <h5 id='games_played'><?= $array[0]['games_played'] ?> </h5> 
               <h5> | Wins:</h5>   <h5 id='wins'><?= $array[0]['wins'] ?> </h5> 
               <h5>| Draws: </h5>  <h5 id='draws'> <?= $array[0]['draws'] ?> </h5> 
               <h5> | Loses:</h5> <h5 id='loses'> <?= $array[0]['loses'] ?> </h5> 
               <h5>| Points: </h5> <h5 id='points'><?= $array[0]['points'] ?> </h5><br>

               <h5> Goals scored: </h5><h5 id='goalsScored'> <?= $array[0]['goalsScored'] ?> </h5> 
               <h5> | Goals conceded:  </h5><h5 id='goalsAgainst'> <?= $array[0]['goalsAgainst'] ?> </h5> 
               <h5>| Goals difference:</h5> <h5 id='goalsDifference'> <?= $array[0]['goalsDifference'] ?> </h5>  <br>
                 
               

                  Last 5 games:     
                 <h6 id='5th_last_game'> <?= $array[0]['5th_last_game'] ?> </h6> 
                 <h6 id='4th_last_game'> <?= $array[0]['4th_last_game'] ?> </h6> 
                 <h6 id='3rd_last_game'> <?= $array[0]['3rd_last_game'] ?> </h6> 
                 <h6 id='2nd_last_game'> <?= $array[0]['2nd_last_game'] ?> </h6> 
                 <h6 id='last_game'> <?= $array[0]['last_game'] ?> </h6> 
<!--                  
                 <div>
                  <?php if($array[0]['5th_last_game']=='W') : ?>
                    <?= Html::img("@web/photos/form/won.png"); ?>
                  <?php elseif ($array[0]['5th_last_game']=='D') : ?>
                                 
                    <?= Html::img("@web/photos/form/draw.png"); ?>              
                 <?php else : ?>
                  <?= Html::img("@web/photos/form/lost.png"); ?>
                   <?php endif; ?>

              </div> -->
              
                
                 </center>
            </div>
            <div class="col-lg-2">
            <center><h2>VS</h2></center>
          
            </div>
            <div class="col-lg-5">
             <center><h2 id="awayTeam"> <?= $arrayForm[0]['teamName']?> </h2></center> 

             <center> <h4> Position:</h4> <h4 id='teamPosition1'> <?= $arrayForm[0]['position'] ?> </h4> <br>  
             <h5> Games played: </h5><h5 id='games_played1'> Games played: <?= $arrayForm[0]['games_played'] ?> </h5> 
             <h5> | Wins:</h5>    <h5 id='wins1'><?= $arrayForm[0]['wins'] ?> </h5> 
             <h5>| Draws: </h5>   <h5 id='draws1'> <?= $arrayForm[0]['draws'] ?> </h5> 
             <h5> | Loses:</h5>    <h5 id='loses1'><?= $arrayForm[0]['loses'] ?> </h5> 
             <h5>| Points: </h5>   <h5 id='points1'><?= $arrayForm[0]['points'] ?> </h5><br>

             <h5> Goals scored: </h5>   <h5 id='goalsScored1'> <?= $arrayForm[0]['goalsScored'] ?> </h5> 
             <h5> | Goals conceded:  </h5>   <h5 id='goalsAgainst1'> <?= $arrayForm[0]['goalsAgainst'] ?> </h5> 
             <h5>| Goals difference:</h5>   <h5 id='goalsDifference1'><?= $arrayForm[0]['goalsDifference'] ?> </h5>  <br>
                 
              
                 <!-- <?= Html::img("@web/photos/form/lost.png"); ?>

                  <?php if($arrayForm[0]['5th_last_game']=='W'){
                     echo(Html::img("@web/photos/form/won.png"));
                 }
                     else if($arrayForm[0]['5th_last_game']=='D'){             
                        echo(Html::img("@web/photos/form/draw.png"));
                 }
                 else{
                   echo(Html::img("@web/photos/form/lost.png"));
                 }
               ?> -->
              

                  Last 5 games:     
                 <h6 id='5th_last_game1'> <?= $arrayForm[0]['5th_last_game'] ?> </h6> 
                 <h6 id='4th_last_game1'> <?= $arrayForm[0]['4th_last_game'] ?> </h6> 
                 <h6 id='3rd_last_game1'> <?= $arrayForm[0]['3rd_last_game'] ?> </h6> 
                 <h6 id='2nd_last_game1'> <?= $arrayForm[0]['2nd_last_game'] ?> </h6> 
                 <h6 id='last_game1'> <?= $arrayForm[0]['last_game'] ?> </h6> 
                 
                
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

            <p style="margin-top: 20px;"><button id="showAllStadiums" class="btn btn-default">Show all stadiums </a></button>
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