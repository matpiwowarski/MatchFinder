<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel frontend\models\LeagueSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Leagues';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="league-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Create League', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
     //   'filterModel' => $searchModel,
        'columns' => [
       //     ['class' => 'yii\grid\SerialColumn'],

            //'id',
            //'Country_id',
            'country.name', 
            // [
            //     'attribute' => 'country',
            //     'value' => 'country.name',
            // ]
            'name',
            [
                'attribute' => 'name',
                'value' => function($model) {return Html::a('view stadiums', ['stadium/stadium-array','countryName'=> $model->country->name], ['class' => 'btn btn-success']);},
                'format' => 'raw',
            ],
            'tier',

            // for view, delte, update
            // [
            //     'class' => 'yii\grid\ActionColumn',
            //     'template' => '{view}{delete}',
            // ],

        ],
    ]); ?>

<!-- foreach($array as $key => value)
{
    $value->getCountry()->name
    $vlue->country->name
} -->
</div>
