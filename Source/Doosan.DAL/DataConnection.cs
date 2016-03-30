using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonJS4;
using MySql.Data.MySqlClient;

namespace Doosan.DAL
{
    public class DataConnection : IDisposable
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        private readonly DbConnection _connection;


        /// <summary>
        /// 
        /// </summary>
        protected DbConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open && _connection.State != ConnectionState.Connecting)
                    _connection.Open();

                return _connection;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /*      public DataConnection(IDbConnection connection)
        {
            _connection = connection;
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public DataConnection(string connectionString)
        {
            _connection = new SqlConnection(GetConnectionString(connectionString));
           // _connection = new MySqlConnection(GetConnectionString(connectionString));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private string GetConnectionString(string connectionString)
        {
            return ConfigurationManager.ConnectionStrings[connectionString].AsString();
        }

        /// <summary>
        /// Close the connection if this is open
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine("Dispose");
            if (_connection != null && _connection.State != ConnectionState.Closed)
                _connection.Close();
        }
    }
}
