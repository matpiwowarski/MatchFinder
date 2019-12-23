<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel frontend\models\StadiumSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Stadiums';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="stadium-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Create Stadium', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <pre>  <?php yii\helpers\VarDumper::dump($array, 10, true) ?> </pre>
    
 </div>
?>
