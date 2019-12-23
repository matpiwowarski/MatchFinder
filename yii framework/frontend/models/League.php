<?php

namespace frontend\models;

use Yii;

/**
 * This is the model class for table "League".
 *
 * @property int $id
 * @property int $Country_id
 * @property string $name
 * @property int $tier
 */
class League extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'League';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['Country_id', 'name', 'tier'], 'required'],
            [['Country_id', 'tier'], 'integer'],
            [['name'], 'string', 'max' => 45],
            [['Country_id'], 'exist', 'skipOnError' => true, 'targetClass' => Country::className(), 'targetAttribute' => ['Country_id' => 'id']],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'Country_id' => 'Country ID',
            'name' => 'Name',
            'tier' => 'Tier',
        ];
    }
    public function getCountry()
    {
        return $this->hasOne(Country::className(), ['id' => 'Country_id']);
    }
}
