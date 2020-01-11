<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model frontend\models\GameSearch */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="game-search">

    <?php $form = ActiveForm::begin([
        'action' => ['index'],
        'method' => 'get',
    ]); ?>

    <?= $form->field($model, 'id') ?>

    <?= $form->field($model, 'Stadium_id') ?>

    <?= $form->field($model, 'League_id') ?>

    <?= $form->field($model, 'Team_home_id') ?>

    <?= $form->field($model, 'Team_away_id') ?>

    <?php // echo $form->field($model, 'game_date') ?>

    <?php // echo $form->field($model, 'home_score') ?>

    <?php // echo $form->field($model, 'away_score') ?>

    <div class="form-group">
        <?= Html::submitButton('Search', ['class' => 'btn btn-primary']) ?>
        <?= Html::resetButton('Reset', ['class' => 'btn btn-outline-secondary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
