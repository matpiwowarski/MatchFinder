<?php

namespace frontend\models;

use Yii;

/**
 * This is the model class for table "Team".
 *
 * @property int $id
 * @property int $Stadium_id
 * @property int $League_id
 * @property int|null $Team_currentForm_id
 * @property int|null $Team_achievements_id
 * @property string $name
 * @property string|null $coach_name
 * @property resource|null $logo_image
 */
class Team extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'Team';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['Stadium_id', 'League_id', 'name'], 'required'],
            [['Stadium_id', 'League_id', 'Team_currentForm_id', 'Team_achievements_id'], 'integer'],
            [['logo_image'], 'string'],
            [['name', 'coach_name'], 'string', 'max' => 45],
            [['League_id'], 'exist', 'skipOnError' => true, 'targetClass' => League::className(), 'targetAttribute' => ['League_id' => 'id']],
            [['Stadium_id'], 'exist', 'skipOnError' => true, 'targetClass' => Stadium::className(), 'targetAttribute' => ['Stadium_id' => 'id']],
            [['Team_achievements_id'], 'exist', 'skipOnError' => true, 'targetClass' => TeamAchievements::className(), 'targetAttribute' => ['Team_achievements_id' => 'id']],
            [['Team_currentForm_id'], 'exist', 'skipOnError' => true, 'targetClass' => TeamCurrentform::className(), 'targetAttribute' => ['Team_currentForm_id' => 'id']],
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
            'Team_currentForm_id' => 'Team Current Form ID',
            'Team_achievements_id' => 'Team Achievements ID',
            'name' => 'Name',
            'coach_name' => 'Coach Name',
            'logo_image' => 'Logo Image',
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
    public function getCity()
    {
        return $this->hasOne(City::className(), ['id' => 'City_id'])->viaTable('stadium', ['id' => 'Stadium_id']);
    }

}
