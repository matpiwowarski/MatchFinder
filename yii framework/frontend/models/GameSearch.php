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
            $query->select('game.id, stadium.latitude,stadium.longitude, stadium.street, stadium.number');
            $query->from('game')->leftJoin('stadium','stadium.id = game.Stadium_id');
    

             $array = $query->all();

            $sortedArray= stadiumData($array, $UserLongitude, $UserLangitude);   

            return  $sortedArray;  
        }
        public function getTeam($id, $team)
        {
            $query2 = (new \yii\db\Query());
            $query2->select('Team.name');
            if($team=='home')
                $query2->from('team')->leftJoin('game','team.id = game.Team_home_id');
            else
                $query2->from('team')->leftJoin('game','team.id = game.Team_away_id');
            $query2->andWhere(['game.id' => $id]);

            $arrayTeam = $query2->all();

            return $arrayTeam[0]['name'];     
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
        $query->select('game.id, stadium.latitude,stadium.longitude, stadium.street, stadium.number');
        $query->from('game')->leftJoin('stadium','stadium.id = game.Stadium_id');


         $array = $query->all();

        $sortedArray= stadiumData($array, $UserLongitude, $UserLangitude);   

        return  $sortedArray;  
    }
    function getTeam($id, $team)
        {
            $query2 = (new \yii\db\Query());
            $query2->select('Team.name');
            if($team=='home')
                $query2->from('team')->leftJoin('game','team.id = game.Team_home_id');
            else
                $query2->from('team')->leftJoin('game','team.id = game.Team_away_id');
            $query2->andWhere(['game.id' => $id]);

            $arrayTeam = $query2->all();

            return $arrayTeam[0]['name'];     
        }

        function distance($lat1, $lon1, $lat2, $lon2, $unit) {
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
              } else if ($unit == "N") {
                return ($miles * 0.8684);
              } else {
                return $miles;
              }
            }
          }
    
          function stadiumData($extendedArray, $UserLongitude, $UserLangitude)
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
