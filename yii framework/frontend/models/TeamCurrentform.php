<?php

namespace frontend\models;

use Yii;

/**
 * This is the model class for table "team_currentform".
 *
 * @property int $id
 * @property int|null $position
 * @property int|null $ranking
 * @property string|null $5th_last_game
 * @property string|null $4th_last_game
 * @property string|null $3rd_last_game
 * @property string|null $2nd_last_game
 * @property string|null $last_game
 * @property int|null $points
 * @property int|null $goalsScored
 * @property int|null $goalsAgainst
 * @property int|null $goalsDifference
 * @property int|null $cleanSheets
 *
 * @property Team[] $teams
 */
class TeamCurrentform extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'team_currentform';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['position', 'ranking', 'points', 'goalsScored', 'goalsAgainst', 'goalsDifference', 'cleanSheets'], 'integer'],
            [['5th_last_game', '4th_last_game', '3rd_last_game', '2nd_last_game', 'last_game'], 'string'],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'position' => 'Position',
            'ranking' => 'Ranking',
            '5th_last_game' => '5th Last Game',
            '4th_last_game' => '4th Last Game',
            '3rd_last_game' => '3rd Last Game',
            '2nd_last_game' => '2nd Last Game',
            'last_game' => 'Last Game',
            'points' => 'Points',
            'goalsScored' => 'Goals Scored',
            'goalsAgainst' => 'Goals Against',
            'goalsDifference' => 'Goals Difference',
            'cleanSheets' => 'Clean Sheets',
        ];
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getTeams()
    {
        return $this->hasMany(Team::className(), ['Team_currentForm_id' => 'id']);
    }
}
