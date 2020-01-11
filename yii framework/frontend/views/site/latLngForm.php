<?php
use yii\helpers\Html;
use yii\widgets\ActiveForm;
?>
 
 <!-- ACTIVE FORM POST -->
 <?php $form = ActiveForm::begin(); ?>
            <?= $form->field($model,'latitude') ?>
            <?= $form->field($model,'longitude') ?>

            <?= Html::submitButton('Submit',['class'=>'btn btn-success']); ?>
  <!-- ACTIVE FORM POST -->

  <?php ActiveForm::end() ?>