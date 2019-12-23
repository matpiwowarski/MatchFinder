<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model frontend\models\League */

$this->title = 'Create League';
$this->params['breadcrumbs'][] = ['label' => 'Leagues', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="league-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
