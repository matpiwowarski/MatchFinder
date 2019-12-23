<?php

namespace frontend\models;

use Yii;

/**
 * This is the model class for table "City".
 *
 * @property int $id
 * @property int $Country_id
 * @property string $name
 */
class City extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'City';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['Country_id', 'name'], 'required'],
            [['Country_id'], 'integer'],
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
        ];
    }

    public function getCountry()
    {
        return $this->hasOne(Country::className(), ['id' => 'Country_id']);
    }
}
