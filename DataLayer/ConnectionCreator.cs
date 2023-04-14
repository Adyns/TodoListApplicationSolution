using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class ConnectionCreator
    {
        SqlConnection conn;
        DataTable dataTable;

        public MySqlConnection ConnectMysql(string DataBase, string UserId, string Password)
        {
            connmysql = new MySqlConnection();
            string dataSource = "";
            string userID = "";
            string passWord = "";
            string port = "";
            string database = "";

            try
            {
                switch (DataBase)
                {
                    case "CLOUD":

                        dataSource = "192.168.120.99";
                        port = "3306";
                        userID = UserId;
                        passWord = Password;
                        database = "rekor";
                        break;
                    case "REKOR":

                        dataSource = "192.168.100.205";
                        //dataSource = "localhost";
                        port = "3306";
                        userID = UserId;
                        passWord = Password;
                        database = "rekor";
                        break;
                    case "REKORNET":

                        dataSource = "192.168.100.215";
                        //dataSource = "localhost";
                        port = "3306";
                        userID = UserId;
                        passWord = Password;
                        database = "rekor_net";
                        break;

                    default:
                        dataSource = "";
                        userID = "";
                        passWord = "";
                        break;
                }
                string connectionString = "server=" + dataSource + ";port=" + port + ";database=" + database + ";uid=" + userID + ";pwd=" + passWord;
                connmysql.ConnectionString = connectionString;
                connmysql.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connmysql;
        }
        public void disconnectMysql(MySqlConnection connmysql)
        {
            try
            { connmysql.Close(); connmysql.Dispose(); }
            catch (Exception) { /*EventLogKayit("disconnectOracle", e.Message);*/ }
        }
    }
}
