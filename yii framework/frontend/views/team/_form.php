<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model frontend\models\Team */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="team-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'Stadium_id')->textInput() ?>

    <?= $form->field($model, 'League_id')->textInput() ?>

    <?= $form->field($model, 'Team_currentForm_id')->textInput() ?>

    <?= $form->field($model, 'Team_achievements_id')->textInput() ?>

    <?= $form->field($model, 'name')->textInput(['maxlength' => true]) ?>

    <?= $form->field($model, 'coach_name')->textInput(['maxlength' => true]) ?>

    <?= $form->field($model, 'logo_image')->textInput() ?>

    <div class="form-group">
        <?= Html::submitButton('Save', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
