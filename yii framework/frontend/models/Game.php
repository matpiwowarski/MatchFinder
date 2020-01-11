<?php

namespace frontend\models;

use Yii;

/**
 * This is the model class for table "game".
 *
 * @property int $id
 * @property int $Stadium_id
 * @property int $League_id
 * @property int $Team_home_id
 * @property int $Team_away_id
 * @property string|null $game_date
 * @property int|null $home_score
 * @property int|null $away_score
 *
 * @property League $league
 * @property Stadium $stadium
 * @property Team $teamHome
 * @property Team $teamAway
 * @property UsersGames[] $usersGames
 * @property User[] $users
 */
class Game extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'game';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['Stadium_id', 'League_id', 'Team_home_id', 'Team_away_id'], 'required'],
            [['Stadium_id', 'League_id', 'Team_home_id', 'Team_away_id', 'home_score', 'away_score'], 'integer'],
            [['game_date'], 'safe'],
            [['League_id'], 'exist', 'skipOnError' => true, 'targetClass' => League::className(), 'targetAttribute' => ['League_id' => 'id']],
            [['Stadium_id'], 'exist', 'skipOnError' => true, 'targetClass' => Stadium::className(), 'targetAttribute' => ['Stadium_id' => 'id']],
            [['Team_home_id'], 'exist', 'skipOnError' => true, 'targetClass' => Team::className(), 'targetAttribute' => ['Team_home_id' => 'id']],
            [['Team_away_id'], 'exist', 'skipOnError' => true, 'targetClass' => Team::className(), 'targetAttribute' => ['Team_away_id' => 'id']],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'Stadium_id' => 'Stadium ID',
            'League_id' => 'League ID',
            'Team_home_id' => 'Team Home ID',
            'Team_away_id' => 'Team Away ID',
            'game_date' => 'Game Date',
            'home_score' => 'Home Score',
            'away_score' => 'Away Score',
        ];
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getLeague()
    {
        return $this->hasOne(League::className(), ['id' => 'League_id']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getStadium()
    {
        return $this->hasOne(Stadium::className(), ['id' => 'Stadium_id']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getTeamHome()
    {
        return $this->hasOne(Team::className(), ['id' => 'Team_home_id']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getTeamAway()
    {
        return $this->hasOne(Team::className(), ['id' => 'Team_away_id']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getUsersGames()
    {
        return $this->hasMany(UsersGames::className(), ['Game_id' => 'id']);
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getUsers()
    {
        return $this->hasMany(User::className(), ['id' => 'User_id'])->viaTable('users_games', ['Game_id' => 'id']);
    }

}
