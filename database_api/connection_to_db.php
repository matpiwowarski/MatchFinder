<?php

/**
 * Database_Class is a sample class for database 
 * connection and db operations management
 * 
 * @author  Jakub 
 * @access  public
 */
class Database {
    
    private $_dsn = 'mysql:host=127.0.0.1;dbname=mfdb;charset=utf8';
    private $_user = 'root';
    private $_password = 'zbitemaslo';
    private $_dbh;

    /**
     * Returns PDO database object
     * 
     * @return PDO
     * @access public
     */
    public function __construct() {
        $this->_dbh = null;

        try {
            $this->_dbh = new PDO($this->_dsn, $this->_user, $this->_password);
        } catch(PDOException $e) {
            printf("Database Connection error! - %s", $e->getMessage());
            exit;
        }

        return $this->_dbh;
    }

    /**
     * Returns dataset after executing query
     * 
     * @return PDOStatement $sth
     */
    public function select_country() {
        $sql = "SELECT * FROM country";
        $sth = $this->_dbh->prepare($sql);
        $result = $sth->execute();

        if($result) {
            return $sth;
        }
    }

    /**
     * Returns dataset after executing query
     * 
     * @param mixed $columns column names to select
     * @return PDOStatement $sth
     */
    public function select_country_columns($columns) {
        if(is_array($columns))
            $columns = implode(',', $columns);

        $sql = "SELECT {$columns} FROM country";
        $sth = $this->_dbh->prepare($sql);
        $result = $sth->execute();

        if($result) {
            return $sth;
        }
    }

    /**
     * Lists countries through associative fetching
     * 
     * @param PDOStatement $sth 
     */
    public function list_articles($sth) {
        while($row = $sth->fetch(PDO::FETCH_ASSOC)) {
            isset($row['id']) ? printf('<h1> %s </h1>', $row['id']) : '';
            isset($row['name']) ? printf('<p> %s </p>', $row['name']) : '';

            echo '<hr>';
        }
    }
}