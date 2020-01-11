<?php

namespace frontend\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use frontend\models\Stadium;

/**
 * StadiumSearch represents the model behind the search form of `frontend\models\Stadium`.
 */
class StadiumSearch extends Stadium
{
    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['id', 'City_id', 'number', 'capacity'], 'integer'],
            [['street', 'name'], 'safe'],
            [['latitude', 'longitude'], 'number'],
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
        // (SELECT *) FROM STADIUM init
        $query = Stadium::find();

        // add conditions that should always apply here

        $dataProvider = new ActiveDataProvider([
            'query' => $query,  // pointer assigned to dataProvided, post changes will be applied to both
        ]);

        $this->load($params);

        if (!$this->validate()) {
            // uncomment the following line if you do not want to return any records when validation fails
            // $query->where('0=1');
            return $dataProvider;
        }

        // futher where condition build based on params if needed
        // grid filtering conditions
        $query->andFilterWhere([
            'id' => $this->id,
            'City_id' => $this->City_id,
            'number' => $this->number,
            'capacity' => $this->capacity,
            'latitude' => $this->latitude,
            'longitude' => $this->longitude,
        ]);
        
        // same for chars
        $query->andFilterWhere(['like', 'street', $this->street])
            ->andFilterWhere(['like', 'name', $this->name]);

        return $dataProvider;
    }

    // JSON OR normal php array
    public function getStadiumArray($countryName, $json = false)
    {
        $query = (new \yii\db\Query());
        $query->select('city.name AS city_name, street,latitude,longitude, country.name');
        $query->from('stadium')->leftJoin('city','stadium.City_id = city.id')->leftJoin('country','city.Country_id = country.id');

        $query->andWhere(['country.name' => $countryName]);
        $array = $query->all();

        return $json ? json_encode($array) : $array; 
    }


}
