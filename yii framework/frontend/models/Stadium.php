<?php

namespace frontend\models;

use Yii;

/**
 * This is the model class for table "stadium".
 *
 * @property int $id
 * @property int $City_id
 * @property string $street
 * @property int $number
 * @property string|null $name
 * @property int|null $capacity
 * @property float|null $latitude
 * @property float|null $longitude
 *
 * @property Game[] $games
 * @property City $city
 * @property Team[] $teams
 */
class Stadium extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'stadium';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['City_id', 'street', 'number'], 'required'],
            [['City_id', 'number', 'capacity'], 'integer'],
            [['latitude', 'longitude'], 'number'],
            [['street', 'name'], 'string', 'max' => 45],
            [['City_id'], 'exist', 'skipOnError' => true, 'targetClass' => City::className(), 'targetAttribute' => ['City_id' => 'id']],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'City_id' => 'City ID',
            'street' => 'Street',
            'number' => 'Number',
            'name' => 'Name',
            'capacity' => 'Capacity',
            'latitude' => 'Latitude',
            'longitude' => 'Longitude',
        ];
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getGames()
    {
        return $this->hasMany(Game::className(), ['Stadium_id' => 'id']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getCity()
    {
        return $this->hasOne(City::className(), ['id' => 'City_id']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getTeam()
    {
        return $this->hasOne(Team::className(), ['Stadium_id' => 'id']);
    }
}
