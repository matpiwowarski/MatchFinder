using System;
using MySql.Data.MySqlClient;

namespace MatchFinder.Database
{
    public class DatabaseConnector
    {
        private MySqlConnection _mySqlConnection;

        public DatabaseConnector()
        {

        }

        public void Connect()
        {
            try
            {
                string connSqlString = "server=178.47.140.149;port=3306;database=test;user=root;password=;charset=utf8";
                _mySqlConnection = new MySqlConnection(connSqlString);
                _mySqlConnection.Open();

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void TestQuery()
        {
            string query = "SELECT * FROM City";
            Query(query);
        }

        public void Query(string query)
        {
            try
            {
                MySqlCommand sqlcmd = new MySqlCommand(query, _mySqlConnection);
                MySqlDataReader sqlDataReader;
                sqlDataReader = sqlcmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CloseConnection()
        {
            _mySqlConnection.Close();
        }
    }
}
