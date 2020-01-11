<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model frontend\models\Game */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="game-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'Stadium_id')->textInput() ?>

    <?= $form->field($model, 'League_id')->textInput() ?>

    <?= $form->field($model, 'Team_home_id')->textInput() ?>

    <?= $form->field($model, 'Team_away_id')->textInput() ?>

    <?= $form->field($model, 'game_date')->textInput() ?>

    <?= $form->field($model, 'home_score')->textInput() ?>

    <?= $form->field($model, 'away_score')->textInput() ?>

    <div class="form-group">
        <?= Html::submitButton('Save', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
