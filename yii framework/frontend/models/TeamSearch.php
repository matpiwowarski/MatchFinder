<?php

namespace frontend\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use frontend\models\Team;

/**
 * TeamSearch represents the model behind the search form of `frontend\models\Team`.
 */
class TeamSearch extends Team
{
    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['id', 'Stadium_id', 'League_id', 'Team_currentForm_id', 'Team_achievements_id'], 'integer'],
            [['name', 'coach_name', 'logo_image'], 'safe'],
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
        $query = Team::find();

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
            'Team_currentForm_id' => $this->Team_currentForm_id,
            'Team_achievements_id' => $this->Team_achievements_id,
        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'coach_name', $this->coach_name])
            ->andFilterWhere(['like', 'logo_image', $this->logo_image]);

        return $dataProvider;
    }
}
