<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel frontend\models\GameSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Coming footaball games';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="game-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
    <button class = 'btn btn-success' href="http://example.com/css/ie5.css">More games</button>

        

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

           // 'id',
           ['attribute' => 'stadium.name',
            'header' => 'Stadium'],
            ['attribute' => 'league.name',
            'header' => 'League'],
            ['attribute' => 'teamHome.name',
            'header' => 'Home Team'],
            ['attribute' => 'teamAway.name',
            'header' => 'Away Team'],
            
            //'game_date',
            //'home_score',
            //'away_score',

            //FOR CRUD
            //['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
