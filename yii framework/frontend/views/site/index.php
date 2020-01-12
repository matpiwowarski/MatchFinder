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

        <div class="row">
            <div class="col-lg-5">
            
                <center><h2 id='homeTeam'> <?= $hometeam ?> </h2></center>
               
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et
                    dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip
                    ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
                    fugiat nulla pariatur.</p>

                <p><a class="btn btn-default" href="http://www.yiiframework.com/doc/">Yii Documentation &raquo;</a></p>
            </div>
            <div class="col-lg-2">
            <center><h2>Vs</h2></center>
          
            </div>
            <div class="col-lg-5">
             <center><h2 id="awayTeam"> <?= $awayteam?> </h2></center> 

                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et
                    dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip
                    ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
                    fugiat nulla pariatur.</p>

                <p><a class="btn btn-default" href="http://www.yiiframework.com/forum/">Yii Forum &raquo;</a></p>
            </div>
        </div>
       
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