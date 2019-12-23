<?php

namespace frontend\controllers;

use Yii;
use frontend\models\Stadium;
use frontend\models\StadiumSearch;
use yii\web\Controller;
use yii\web\NotFoundHttpException;
use yii\filters\VerbFilter;

/**
 * StadiumController implements the CRUD actions for Stadium model.
 */
class StadiumController extends Controller
{
    /**
     * {@inheritdoc}
     */
    public function behaviors()
    {
        return [
            'verbs' => [
                'class' => VerbFilter::className(),
                'actions' => [
                    'delete' => ['POST'],
                ],
            ],
        ];
    }

    /**
     * Lists all Stadium models.
     * @return mixed
     */
    public function actionIndex()
    {
        $searchModel = new StadiumSearch();
        $dataProvider = $searchModel->search(Yii::$app->request->queryParams);

        return $this->render('index', [
            'searchModel' => $searchModel,
            'dataProvider' => $dataProvider,
        ]);
    }

    /**
     * Displays a single Stadium model.
     * @param integer $id
     * @return mixed
     * @throws NotFoundHttpException if the model cannot be found
     */
    public function actionView($id)
    {
        return $this->render('view', [
            'model' => $this->findModel($id),
        ]);
    }

    /**
     * Creates a new Stadium model.
     * If creation is successful, the browser will be redirected to the 'view' page.
     * @return mixed
     */
    public function actionCreate()
    {
        $model = new Stadium();

        if ($model->load(Yii::$app->request->post()) && $model->save()) {
            return $this->redirect(['view', 'id' => $model->id]);
        }

        return $this->render('create', [
            'model' => $model,
        ]);
    }

    /**
     * Updates an existing Stadium model.
     * If update is successful, the browser will be redirected to the 'view' page.
     * @param integer $id
     * @return mixed
     * @throws NotFoundHttpException if the model cannot be found
     */
    public function actionUpdate($id)
    {
        $model = $this->findModel($id);

        if ($model->load(Yii::$app->request->post()) && $model->save()) {
            return $this->redirect(['view', 'id' => $model->id]);
        }

        return $this->render('update', [
            'model' => $model,
        ]);
    }

    /**
     * Deletes an existing Stadium model.
     * If deletion is successful, the browser will be redirected to the 'index' page.
     * @param integer $id
     * @return mixed
     * @throws NotFoundHttpException if the model cannot be found
     */
    public function actionDelete($id)
    {
        $this->findModel($id)->delete();

        return $this->redirect(['index']);
    }

    /**
     * Finds the Stadium model based on its primary key value.
     * If the model is not found, a 404 HTTP exception will be thrown.
     * @param integer $id
     * @return Stadium the loaded model
     * @throws NotFoundHttpException if the model cannot be found
     */
    protected function findModel($id)
    {
        if (($model = Stadium::findOne($id)) !== null) {
            return $model;
        }

        throw new NotFoundHttpException('The requested page does not exist.');
    }

// DISPLAY SQL
//     public function getStadiumArray()
//     {
//         $query = (new \yii\db\Query());
//         $query->select('city.name, street,latitude,longitude, country.name');
//         $query->from('stadium')->leftJoin('city','stadium.City_id = city.id')->leftJoin('country','city.Country_id = country.id');

//         return  $query->createCommand()->rawSql;
// //        return $query->all();
//         // $query->andWhere
//     }
//     public function actionStadiumArray()
//     {
//         $searchModel = new StadiumSearch();
//         $dataProvider = $searchModel->search(Yii::$app->request->queryParams);

//         return $this->render('stadiumArray', [
//             'array' => $this->getStadiumArray(),
//             //'sql' => $query->createCommand()->rawSql,
//         ]);
//     }

    public function getStadiumArray($countryName)
    {
        $query = (new \yii\db\Query());
        $query->select('city.name AS city_name, street,latitude,longitude, country.name');
        $query->from('stadium')->leftJoin('city','stadium.City_id = city.id')->leftJoin('country','city.Country_id = country.id');

        $query->andWhere(['country.name' => $countryName]);

       return $query->all();
       
    }
    public function actionStadiumArray($countryName)
    {
        return $this->render('stadiumArray', [
            'array' => $this->getStadiumArray($countryName),
        ]);
    }

    
}
