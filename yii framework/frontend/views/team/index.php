<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel frontend\models\TeamSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Teams';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="team-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <!-- <p>
        <?=  Html::a('Create Team', ['create'], ['class' => 'btn btn-success']) ?>
    </p> -->

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            //'id',
           //  'Stadium_id',
           // 'League_id',
        ['attribute' => 'name',
         'header' => 'Team'],
        'coach_name',
         ['attribute' => 'city.name',
         'header' => 'City'],
         ['attribute' => 'stadium.street',
         'header' => 'Street'],
         ['attribute' => 'stadium.number',
         'header' => 'Nr'],  
         ['attribute' => 'league.name',
         'header' => 'League'], 
            
            //'Team_currentForm_id',
            //'Team_achievements_id',
            
            
            //'logo_image',

            // FOR CRUD
            //['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
