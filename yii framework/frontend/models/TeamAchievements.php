<?php

namespace frontend\models;

use Yii;

/**
 * This is the model class for table "team_achievements".
 *
 * @property int $id
 * @property int|null $nr_of_championship
 * @property string|null $years_of_championship
 * @property int|null $nr_of_cup_wins
 * @property string|null $years_of_cup_wins
 * @property int|null $nr_of_lesser_cups_win
 * @property string|null $years_of_leser_cups_win
 * @property int|null $nr_of_club_wc_win
 * @property string|null $years_of_club_wc_win
 * @property int|null $nr_of_champions_league_win
 * @property string|null $years_of_champions_league_win
 * @property int|null $nr_of_lesser_international_wins
 * @property string|null $years_of_lesser_international_wins
 *
 * @property Team[] $teams
 */
class TeamAchievements extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'team_achievements';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['nr_of_championship', 'nr_of_cup_wins', 'nr_of_lesser_cups_win', 'nr_of_club_wc_win', 'nr_of_champions_league_win', 'nr_of_lesser_international_wins'], 'integer'],
            [['years_of_championship', 'years_of_cup_wins', 'years_of_leser_cups_win', 'years_of_club_wc_win', 'years_of_champions_league_win', 'years_of_lesser_international_wins'], 'string', 'max' => 45],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'nr_of_championship' => 'Nr Of Championship',
            'years_of_championship' => 'Years Of Championship',
            'nr_of_cup_wins' => 'Nr Of Cup Wins',
            'years_of_cup_wins' => 'Years Of Cup Wins',
            'nr_of_lesser_cups_win' => 'Nr Of Lesser Cups Win',
            'years_of_leser_cups_win' => 'Years Of Leser Cups Win',
            'nr_of_club_wc_win' => 'Nr Of Club Wc Win',
            'years_of_club_wc_win' => 'Years Of Club Wc Win',
            'nr_of_champions_league_win' => 'Nr Of Champions League Win',
            'years_of_champions_league_win' => 'Years Of Champions League Win',
            'nr_of_lesser_international_wins' => 'Nr Of Lesser International Wins',
            'years_of_lesser_international_wins' => 'Years Of Lesser International Wins',
        ];
    }

    /**
     * @return \yii\db\ActiveQuery
     */
    public function getTeams()
    {
        return $this->hasMany(Team::className(), ['Team_achievements_id' => 'id']);
    }
}
