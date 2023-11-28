using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI2023.RepositorioDatos
{
    class DBConnection
    {
        private string _connectionString;
        private static DBConnection instance = new DBConnection();

        //declaro variable que almacerá un objeto <cmd> del tipo <SqlConnection>
        private SqlConnection _connection;

        //declaro variable que almacerá un objeto <cmd> del tipo <SqlCommand>
        private SqlCommand _cmd;


        private DBConnection()
        {

            // string_conexion = "Data Source=DESKTOP-LBVUJ09\\SQLEXPRESS;Initial Catalog=BTSPAVI3K220201;Integrated Security=True;MultipleActiveResultSets=True";
            _connectionString = "Data Source=Nicolás-PC\\PPAISQLSERVER;Initial Catalog=PPAI_DSI;Integrated Security=True";
        }

        public static DBConnection GetConnection()
        {
            if (instance == null)
                instance = new DBConnection();
            return instance;
        }

        private void CloseConnection(SqlConnection cnn)
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                cnn.Dispose();
            }
        }

        /// Resumen:
        ///     Se utiliza para sentencias SQL del tipo “Select”. Recibe por valor una sentencia sql como string
        /// Devuelve:
        ///      un objeto de tipo DataTable con el resultado de la consulta
        public DataTable ConsultaSQL(string strSql)
        {
            try
            {
                SqlConnection cnn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                DataTable tabla = new DataTable();
                cnn.ConnectionString = _connectionString;
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                tabla.Load(cmd.ExecuteReader());
                this.CloseConnection(cnn);
                return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new ApplicationException("Ocurrio un problema desconocido con el almacenamento de datos");
            }

        }

        /// Resumen:
        ///     Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”. Recibe por valor una sentencia sql como string
        /// Devuelve:
        ///      un valor entero con el número de filas afectadas por la sentencia ejecutada
        public int EjecutarSQL(string strSql)
        {
            int afectadas = 0;
            SqlConnection cnn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cnn.ConnectionString = _connectionString;
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            afectadas = cmd.ExecuteNonQuery();
            this.CloseConnection(cnn);
            return afectadas;
        }

        public void Conectar()
        {
            _connection = new SqlConnection();
            _cmd = new SqlCommand();
            //asigan al objeto <conexion> la cadena de conexion
            _connection.ConnectionString = _connectionString;
            //agrega la conexion (se crea el pipe entre la aplicación y la base de datos)
            _connection.Open();
            //se comunica al objeto <cmd> sobre que conexion debe trabajar
            _cmd.Connection = _connection;
            //se establece el tipo de comando que va ha ejecutar
            _cmd.CommandType = CommandType.Text;
        }


        public SqlTransaction IniciarTransaccion()
        {
            Conectar();
            var transaccion = _connection.BeginTransaction();
            _cmd.Transaction = transaccion;
            return transaccion;
        }


        public int EjecutarTransaccionSQL(string strSql)
        {
            var id = 0;
            _cmd.CommandText = strSql;

            if (_cmd.ExecuteNonQuery() > 0)
            {
                string consultaGetId = "Select @@Identity";
                _cmd.CommandText = consultaGetId;
                var idDevuelto = _cmd.ExecuteScalar();
                //id = int.Parse(idDevuelto?.ToString());
                //id = int.Parse(null);
                if (idDevuelto != null)
                    id = int.Parse(idDevuelto.ToString());

            }
            return id;
        }

        public void EjecutarUpdateTransaccionSQL(string strSql)
        {
            _cmd.CommandText = strSql;
            _cmd.ExecuteNonQuery();
        }

        public DataTable ConsultaDuranteTransaccion(string comando)
        {

            _cmd.CommandText = comando;
            //instancia un objeto <tabla> del tipo DataTable
            DataTable tabla = new DataTable();

            tabla.Load(_cmd.ExecuteReader());

            //devuelve el valor calculado a través de la función
            return tabla;
        }

    }
}