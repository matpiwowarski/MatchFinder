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
        $searchModel = new StadiumSearch(); // build for dataProvider
        $dataProvider = $searchModel->search(Yii::$app->request->queryParams); // not table, receipt how to obtain data (SQL + ...), object not string & 

        return $this->render('index', [ // put index view into $content variable
            'searchModel' => $searchModel, // in case of filtering in view
            'dataProvider' => $dataProvider, 
        ]);
    }

    // render -> stay in the same controller (same url), redner view
    // redirect -> change controller
    /**
     * Displays a single Stadium model.
     * @param integer $id
     * @return mixed
     * @throws NotFoundHttpException if the model cannot be found
     */
    public function actionView($id)
    {
        return $this->render('view', [  // put view view into $content variable with found model(one row)
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
        $model = new Stadium(); // create new row for stadium table

        if ($model->load(Yii::$app->request->post()) // take data from from put them into model  $model = form paramters
         && $model->save()) {                        // insert row intotable Stadium   
            return $this->redirect(['view', 'id' => $model->id]); // change controller action  (change url)
        }

        // if fail render new create view again
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
        // find model 
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
        // find model and delete 
        $this->findModel($id)->delete();

        // get back to index
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

// // not dataProvider, just data in array 
// // DISPLAY SQL
// public function getStadiumArray()
// {
//     $query = (new \yii\db\Query());
//     $query->select('city.name, street,latitude,longitude, country.name');
//     $query->from('stadium')->leftJoin('city','stadium.City_id = city.id')->leftJoin('country','city.Country_id = country.id');

//     return  $query->createCommand()->rawSql;        // return sql string
// //        return $query->all();                         // 
//     // $query->andWhere
// }

//     public function actionStadiumArray()
//     {
//         $searchModel = new StadiumSearch();

//         return $this->render('stadiumArray', [
//             'array' => $searchModel->getStadiumArray(),
//             //'sql' => $query->createCommand()->rawSql,
//         ]);
//     }

    // PHP Array unusable in js(json needed), in stadiumArray view array display in implemented
    public function actionStadiumArray($countryName, $json = false)
    {
        $model = new StadiumSearch();
        return $this->render('stadiumArray', [ // open view stadiumArray and pass array
            'array' => $model->getStadiumArray($countryName, $json), 
        ]);
    }
    // JSON
    public function actionStadiumArrayJson($countryName, $json = false)
    {
         // open view stadiumArray and pass array in json
         $model = new stadiumSearch();
            $arrayPhp = $model->getStadiumArray($countryName, $json);
            return $arrayPhp;
    }

    
}
