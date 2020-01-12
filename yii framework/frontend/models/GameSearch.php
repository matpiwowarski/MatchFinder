<?php

namespace frontend\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use frontend\models\Game;

/**
 * GameSearch represents the model behind the search form of `frontend\models\Game`.
 */
class GameSearch extends Game
{
    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['id', 'Stadium_id', 'League_id', 'Team_home_id', 'Team_away_id', 'home_score', 'away_score'], 'integer'],
            [['game_date'], 'safe'],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function scenarios()
    {
        // bypass scenarios() implementation in the parent class
        return Model::scenarios();
    }

    /**
     * Creates data provider instance with search query applied
     *
     * @param array $params
     *
     * @return ActiveDataProvider
     */
    public function search($params)
    {
        $query = Game::find();

        // add conditions that should always apply here

        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            // uncomment the following line if you do not want to return any records when validation fails
            // $query->where('0=1');
            return $dataProvider;
        }

        // grid filtering conditions
        $query->andFilterWhere([
            'id' => $this->id,
            'Stadium_id' => $this->Stadium_id,
            'League_id' => $this->League_id,
            'Team_home_id' => $this->Team_home_id,
            'Team_away_id' => $this->Team_away_id,
            'game_date' => $this->game_date,
            'home_score' => $this->home_score,
            'away_score' => $this->away_score,
        ]);

        return $dataProvider;
    }
       


        
    public function getGame($UserLongitude, $UserLangitude)
    {
        $query = (new \yii\db\Query());
        $query->select('game.id, stadium.latitude, stadium.longitude, stadium.street, stadium.number, team_currentForm.position, team_currentForm.games_played, team_currentForm.wins, team_currentForm.draws, 
        team_currentForm.loses, team_currentForm.5th_last_game, team_currentForm.4th_last_game, team_currentForm.3rd_last_game, 
        team_currentForm.2nd_last_game, team_currentForm.last_game, team_currentForm.points, team_currentForm.goalsScored, team_currentForm.goalsAgainst 
        ,team_currentForm.goalsDifference');
        $query->from('game')->leftJoin('stadium','stadium.id = game.Stadium_id')->leftJoin('team', 'team.id=game.Team_home_id')
        //$query->from('game')->leftJoin('stadium','stadium.id = game.Stadium_id')->leftJoin('team', 'team.id=game.Team_home_id OR team.id=game.Team_away_id')
        ->leftJoin('team_currentForm', 'team_currentForm.id=team.Team_currentForm_id');


         $array = $query->all();

        $sortedArray= gamesValue($array, $UserLongitude, $UserLangitude);   

        return  $sortedArray;  


        $array = $query->all();

        $sortedArray= gamesValue($array, $UserLongitude, $UserLangitude);   

        return  $sortedArray;  
    }

        public function getTeam($id, $team)
        {
            $query2 = (new \yii\db\Query());
            $query2->select('team.name');
            if($team=='home')
                $query2->from('team')->leftJoin('game','team.id = game.Team_home_id');
            else
                $query2->from('team')->leftJoin('game','team.id = game.Team_away_id');
            $query2->andWhere(['game.id' => $id]);

            $arrayTeam = $query2->all();

            return $arrayTeam[0]['name'];
            
        }

        public function getTeamsCurrentForm()
        {
            $query3 = (new \yii\db\Query());
            $query3->select('team.id, team_currentForm.id, team_currentForm.position, team_currentForm.games_played, team_currentForm.wins, team_currentForm.draws, 
            team_currentForm.loses, team_currentForm.5th_last_game, team_currentForm.4th_last_game, team_currentForm.3rd_last_game 
            ,team_currentForm.2nd_last_game, team_currentForm.last_game, team_currentForm.points, team_currentForm.goalsScored, team_currentForm.goalsAgainst 
            ,team_currentForm.goalsDifference');
            $query3->from('team_currentForm')->leftJoin('team','team_currentForm.id = team.Team_currentForm_id');


            $arrayTeamCurrentForm = $query3->all();

            return $arrayTeamCurrentForm;
        }
        public function getGameJson($userlongitude, $userlangitude)
        {
            $gameArray = getGame($userlongitude, $userlangitude);

            $finalArray = $gameArray[0]; // only best game
            $finalArray['hometeam'] = getTeam($gameArray[0]['id'],'home');
            $finalArray['awayteam'] = getTeam($gameArray[0]['id'],'away');

            
            return json_encode($finalArray);
        }
    }
    function getGame($UserLongitude, $UserLangitude)
    {
        $query = (new \yii\db\Query());
        $query->select('game.id, stadium.latitude, stadium.longitude, stadium.street, stadium.number, team_currentForm.position, team_currentForm.games_played, team_currentForm.wins, team_currentForm.draws, 
        team_currentForm.loses, team_currentForm.5th_last_game, team_currentForm.4th_last_game, team_currentForm.3rd_last_game, 
        team_currentForm.2nd_last_game, team_currentForm.last_game, team_currentForm.points, team_currentForm.goalsScored, team_currentForm.goalsAgainst 
        ,team_currentForm.goalsDifference');
        $query->from('game')->leftJoin('stadium','stadium.id = game.Stadium_id')->leftJoin('team', 'team.id=game.Team_home_id')
        //$query->from('game')->leftJoin('stadium','stadium.id = game.Stadium_id')->leftJoin('team', 'team.id=game.Team_home_id OR team.id=game.Team_away_id')
        ->leftJoin('team_currentForm', 'team_currentForm.id=team.Team_currentForm_id');


         $array = $query->all();

        $sortedArray= gamesValue($array, $UserLongitude, $UserLangitude);   

        return  $sortedArray;  


        $array = $query->all();

        $sortedArray= gamesValue($array, $UserLongitude, $UserLangitude);   

        return  $sortedArray;  
    }

        function getTeam($id, $team)
        {
            $query2 = (new \yii\db\Query());
            $query2->select('team.name');
            if($team=='home')
                $query2->from('team')->leftJoin('game','team.id = game.Team_home_id');
            else
                $query2->from('team')->leftJoin('game','team.id = game.Team_away_id');
            $query2->andWhere(['game.id' => $id]);

            $arrayTeam = $query2->all();

            return $arrayTeam[0]['name'];
            
        }
    // alghoritm describing teams attractivness, on scale froom 0 to 100. 100 attractiveness should be for team that is 1 in league, it's last 5 games are wins,
    // has 90% of wins, and it it's games are at least 3 goals on average.

    //postion 50 points, last five games 25, wins 10, goals scored 15
    
    function teamPositionValue($length, $arrayTeamCurrentForm){
        
        $positionValue=0;
        for($j=0; $j<$length; $j++)
        {
            if($length>18){

                if( $arrayTeamCurrentForm[$j]['position']==1)
                $positionValue=50;
    
            elseif( $arrayTeamCurrentForm[$j]['position']==2)
                $positionValue=48;
    
                elseif( $arrayTeamCurrentForm[$j]['position']==3)
                    $positionValue=46;
                    
            elseif( $arrayTeamCurrentForm[$j]['position']==4)
            $positionValue=44;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==5)
                $positionValue=42;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==6)
            $positionValue=40;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==7)
                $positionValue=38;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==8)
            $positionValue=36;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==9)
                $positionValue=34;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==10)
            $positionValue=32;  
    
            elseif( $arrayTeamCurrentForm[$j]['position']==11)
                $positionValue=30;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==12)
            $positionValue=28;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==13)
                $positionValue=26;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==14)
            $positionValue=24;
    
            elseif( $arrayTeamCurrentForm[$j]['position']==15)
                $positionValue=22;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==16)
            $positionValue=20;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==17)
                $positionValue=18;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==18)
            $positionValue=16;

            elseif( $arrayTeamCurrentForm[$j]['position']==19)
                $positionValue=14;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==20)
            $positionValue=12;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==21)
                $positionValue=10;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==22)
            $positionValue=8;
            

            elseif( $arrayTeamCurrentForm[$j]['position']==23)
                $positionValue=6;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==24)
            $positionValue=4;

            else $positionValue=0;
        }
            
        if($length<=18 && $length>14)
        {
           
           
            if( $arrayTeamCurrentForm[$j]['position']==1)
            $positionValue=50;

        elseif( $arrayTeamCurrentForm[$j]['position']==2)
            $positionValue=47;

            elseif( $arrayTeamCurrentForm[$j]['position']==3)
                $positionValue=44;
                
        elseif( $arrayTeamCurrentForm[$j]['position']==4)
        $positionValue=41;
        
        elseif( $arrayTeamCurrentForm[$j]['position']==5)
            $positionValue=38;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==6)
        $positionValue=35;
        
        elseif( $arrayTeamCurrentForm[$j]['position']==7)
            $positionValue=32;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==8)
        $positionValue=29;
        
        elseif( $arrayTeamCurrentForm[$j]['position']==9)
            $positionValue=26;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==10)
        $positionValue=23;  

        elseif( $arrayTeamCurrentForm[$j]['position']==11)
            $positionValue=20;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==12)
        $positionValue=17;
        
        elseif( $arrayTeamCurrentForm[$j]['position']==13)
            $positionValue=14;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==14)
        $positionValue=11;

        elseif( $arrayTeamCurrentForm[$j]['position']==15)
            $positionValue=8;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==16)
        $positionValue=5;
        
        elseif( $arrayTeamCurrentForm[$j]['position']==17)
            $positionValue=2;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==18)
        $positionValue=0;
            
        else $positionValue=0;
        }


        if($length<=14 && $length>10)
        {

            if( $arrayTeamCurrentForm[$j]['position']==1)
            $positionValue=50;

        elseif( $arrayTeamCurrentForm[$j]['position']==2)
            $positionValue=46;

            elseif( $arrayTeamCurrentForm[$j]['position']==3)
                $positionValue=42;
                
        elseif( $arrayTeamCurrentForm[$j]['position']==4)
        $positionValue=38;
        
        elseif( $arrayTeamCurrentForm[$j]['position']==5)
            $positionValue=34;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==6)
        $positionValue=30;
        
        elseif( $arrayTeamCurrentForm[$j]['position']==7)
            $positionValue=26;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==8)
        $positionValue=22;
        
        elseif( $arrayTeamCurrentForm[$j]['position']==9)
            $positionValue=18;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==10)
        $positionValue=14;  

        elseif( $arrayTeamCurrentForm[$j]['position']==11)
            $positionValue=12;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==12)
        $positionValue=8;
        
        elseif( $arrayTeamCurrentForm[$j]['position']==13)
            $positionValue=4;
            
        elseif( $arrayTeamCurrentForm[$j]['position']==14)
        $positionValue=0;
        
        else $positionValue=0;
            
        }
        if($length==10)
        {
            if( $arrayTeamCurrentForm[$j]['position']==1)
                $positionValue=50;

            elseif( $arrayTeamCurrentForm[$j]['position']==2)
                $positionValue=45;

                elseif( $arrayTeamCurrentForm[$j]['position']==3)
                    $positionValue=40;
                    
            elseif( $arrayTeamCurrentForm[$j]['position']==4)
            $positionValue=35;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==5)
                $positionValue=30;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==6)
            $positionValue=25;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==7)
                $positionValue=20;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==8)
            $positionValue=15;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==9)
                $positionValue=10;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==10)
            $positionValue=5;
            
        }
        if($length<10)
        {

            if( $arrayTeamCurrentForm[$j]['position']==1)
                $positionValue=50;

            elseif( $arrayTeamCurrentForm[$j]['position']==2)
                $positionValue=44;

                elseif( $arrayTeamCurrentForm[$j]['position']==3)
                    $positionValue=38;
                    
            elseif( $arrayTeamCurrentForm[$j]['position']==4)
            $positionValue=32;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==5)
                $positionValue=26;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==6)
            $positionValue=20;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==7)
                $positionValue=14;
                
            elseif( $arrayTeamCurrentForm[$j]['position']==8)
            $positionValue=8;
            
            elseif( $arrayTeamCurrentForm[$j]['position']==9)
                $positionValue=2;
                
            else
            $positionValue=0;
            
        }
        $arrayTeamCurrentForm[$j]['positionValue']=$positionValue;
    }
        return $arrayTeamCurrentForm;
    }

    function teamLastGamesValue($length, $arrayTeamCurrentForm){
         

        for($i=0; $i<$length; $i++)
        {
            $lastGamesValue=0;

            if($arrayTeamCurrentForm[$i]['5th_last_game']=='W')
                $lastGamesValue +=2;
            
            elseif($arrayTeamCurrentForm[$i]['5th_last_game']=='D')
                $lastGamesValue +=1;
            
            
                if($arrayTeamCurrentForm[$i]['4th_last_game']=='W')
                $lastGamesValue +=3;
            
            elseif($arrayTeamCurrentForm[$i]['4th_last_game']=='D')
                $lastGamesValue +=1;

                
            if($arrayTeamCurrentForm[$i]['3rd_last_game']=='W')
            $lastGamesValue +=5;
        
        elseif($arrayTeamCurrentForm[$i]['3rd_last_game']=='D')
            $lastGamesValue +=2;

            
            if($arrayTeamCurrentForm[$i]['2nd_last_game']=='W')
                $lastGamesValue +=7;
            
            elseif($arrayTeamCurrentForm[$i]['2nd_last_game']=='D')
                $lastGamesValue +=3;

                
            if($arrayTeamCurrentForm[$i]['last_game']=='W')
            $lastGamesValue +=8;
        
        elseif($arrayTeamCurrentForm[$i]['last_game']=='D')
            $lastGamesValue +=4;

            $arrayTeamCurrentForm[$i]['lastGamesValue']=$lastGamesValue;
        }
        return $arrayTeamCurrentForm;
    }

    function teamWinsPercentage($length, $arrayTeamCurrentForm){

        for($i=0; $i<$length; $i++)
        {
            $winsPercentageValue=0;
            $winsPercentage=($arrayTeamCurrentForm[$i]['wins']/$arrayTeamCurrentForm[$i]['games_played']);

            if($winsPercentage>0.90)
                $winsPercentageValue =10;
            
            elseif ($winsPercentage<0.9 && $winsPercentage>0.8)
                $winsPercentageValue =9;
            
            elseif ($winsPercentage<0.8 && $winsPercentage>0.7)
                $winsPercentageValue =8;

                
            elseif ($winsPercentage<0.7 && $winsPercentage>0.6)
            $winsPercentageValue =7;

            
            elseif ($winsPercentage<0.6 && $winsPercentage>0.5)
                $winsPercentageValue =6;

                
            elseif ($winsPercentage<0.5 && $winsPercentage>0.4)
            $winsPercentageValue =5;
            
            elseif ($winsPercentage<0.4 && $winsPercentage>0.3)
                $winsPercentageValue =4;
                
            elseif ($winsPercentage<0.3 && $winsPercentage>0.2)
            $winsPercentageValue =3;
            
            elseif ($winsPercentage<0.2 && $winsPercentage>0.1)
                $winsPercentageValue =2;

                
            elseif ($winsPercentage<0.1)
            $winsPercentageValue =1;

            $arrayTeamCurrentForm[$i]['winsPercentageValue']=$winsPercentageValue;

        }

        return $arrayTeamCurrentForm;
    }

    function teamGoalsScoredValue($length, $arrayTeamCurrentForm){
        
        for($i=0;$i<$length;$i++){
            $goalsScoredValue=0;
            $goalsPerGame=($arrayTeamCurrentForm[$i]['goalsScored']/$arrayTeamCurrentForm[$i]['games_played']);

            if($goalsPerGame>=3)
                $goalsScoredValue = 15;

            elseif($goalsPerGame<3 && $goalsPerGame>=2.5)
                $goalsScoredValue = 15;

                elseif($goalsPerGame<2.5 && $goalsPerGame>=2)
                $goalsScoredValue = 12;

                elseif($goalsPerGame<2 && $goalsPerGame>=1.5)
                $goalsScoredValue = 10;

                elseif($goalsPerGame<1.5 && $goalsPerGame>=1)
                $goalsScoredValue = 15;

                elseif($goalsPerGame<1 && $goalsPerGame>=0.5)
                $goalsScoredValue = 3;

                elseif($goalsPerGame<0.5)
                $goalsScoredValue = 0;

                $arrayTeamCurrentForm[$i]['goalsScoredValue']=$goalsScoredValue;
        }
        return $arrayTeamCurrentForm;


    }

    function teamAttractiveness($arrayTeamCurrentForm)
        {
            $length=count($arrayTeamCurrentForm);

            $arrayTeamCurrentForm= teamPositionValue($length, $arrayTeamCurrentForm);
            $arrayTeamCurrentForm= teamLastGamesValue($length, $arrayTeamCurrentForm);
            $arrayTeamCurrentForm=  teamWinsPercentage($length, $arrayTeamCurrentForm);
            $arrayTeamCurrentForm= teamGoalsScoredValue($length, $arrayTeamCurrentForm);

            for($i=0; $i<$length; $i++)
            {
                $arrayTeamCurrentForm[$i]['teamCurrentFormValue']=($arrayTeamCurrentForm[$i]['positionValue'] + $arrayTeamCurrentForm[$i]['lastGamesValue'] +
                $arrayTeamCurrentForm[$i]['winsPercentageValue']+$arrayTeamCurrentForm[$i]['goalsScoredValue']);
            }

            return $arrayTeamCurrentForm;
        }



    function distance($lat1, $lon1, $lat2, $lon2, $unit) 
        {
            if (($lat1 == $lat2) && ($lon1 == $lon2)) {
              return 0;
            }
            else {
              $theta = $lon1 - $lon2;
              $dist = sin(deg2rad($lat1)) * sin(deg2rad($lat2)) +  cos(deg2rad($lat1)) * cos(deg2rad($lat2)) * cos(deg2rad($theta));
              $dist = acos($dist);
              $dist = rad2deg($dist);
              $miles = $dist * 60 * 1.1515;
              $unit = strtoupper($unit);
          
              if ($unit == "K") {
                return ($miles * 1.609344);
              } elseif ($unit == "N") {
                return ($miles * 0.8684);
              } else {
                return $miles;
              }
            }
          }
    

          
    
    
    
    
    
          function stadiumDistance($extendedArray, $UserLongitude, $UserLangitude)
          {

            
            $length=count($extendedArray);
            
            for($i=0; $i<$length; $i++){
                $extendedArray[$i]['distance']=distance($UserLongitude, $UserLangitude, $extendedArray[$i]['latitude'], $extendedArray[$i]['longitude'], "K");
            }
            
            // sorting associative table
            $distance= array_column($extendedArray, 'distance');

            array_multisort($distance, $extendedArray);
           return $extendedArray;   
            }


    


    function distanceValue($sortedArray, $length){

        for($i=0;$i<2;$i++){

            
            $distanceValue=0;
            
            $distance=$sortedArray[$i]['distance'];

            if($distance<5)
            {
                $distanceValue=50;
            }

            elseif($distance>5 && $distance<10)
            {
                $distanceValue = 45;
            }

            elseif($distance>10 && $distance<20)
            {
                $distanceValue = 40;
            }

            elseif($distance>20 && $distance<40)
            {
                $distanceValue = 30;
            }

            elseif($distance>40 && $distance<75)
            {
                $distanceValue = 20;
            }

            elseif($distance>75 && $distance<110)
            {
                $distanceValue = 10;
            }

            elseif($distance>110 && $distance<150)
            {
                $distanceValue = 0;
            }

            elseif($distance>150)
            {
                $distanceValue = -100;
            }
            else 
            $distanceValue=0;
            $sortedArray[$i]['distanceValue']=$distanceValue;
        }
        return $sortedArray;
    }


    function gamesValue($sortedArray, $UserLongitude, $UserLangitude)
    {
        $sortedArray= stadiumDistance($sortedArray, $UserLongitude, $UserLangitude);
        $sortedArray= distanceValue($sortedArray, $length,);
        $sortedArray= teamAttractiveness($sortedArray);

        $length=count($sortedArray);

        for($i=0;$i<$length;$i++)
        {
            $sortedArray[$i]['gameValue']=($sortedArray[$i]['distanceValue']+$sortedArray[$i]['teamCurrentFormValue']);
        }

        $gameValue= array_column($sortedArray, 'gameValue');

        array_multisort($gameValue, SORT_DESC, $sortedArray);

       return $sortedArray;   
    }