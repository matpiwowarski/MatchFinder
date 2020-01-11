<?php

namespace frontend\models;

use yii\base\Model;

class LatLngForm extends Model{
    public $latitude;
    public $longitude;

    public function rules()
    {
        return [
            [['latitude','longitude'],'safe']
        ];
    }
}

?>

