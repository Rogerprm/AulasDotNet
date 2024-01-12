using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCRUD
{
    public class DataBaseManager
    {
        private SqlConnection _conn;
        private SqlConnection CreateConnection()
        {
            _conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\roger\\OneDrive\\Geral\\Documentos\\Estudo 2023\\dotnet\\Leandro\\AulasDotNet\\ProjetoCRUD\\CrudDB.mdf\";Integrated Security=True");
            return _conn;
        }

        public bool Testconnection()
        {
            CreateConnection().Open();
            return true;
        }

        public void Create(string nome, decimal preco)
        {
            CreateConnection().Open();

            var command = _conn.CreateCommand();

            command.Parameters.Add(new SqlParameter("nome", nome));
            command.Parameters.Add(new SqlParameter("preco", preco));
            command.Parameters.Add(new SqlParameter("data", DateTime.Now));

            command.CommandText = "Insert into produtos (Nome, Preco, DataInclusaoAlteracao) Values (@nome , @preco, @data)";

            command.ExecuteNonQuery();

            CreateConnection().Close();
            
        }

        public SqlDataReader Read()
        {
            CreateConnection().Open();

            List<SqlDataReader> lista = new List<SqlDataReader>();

            var command = _conn.CreateCommand();

            command.CommandText = "Select * from produtos";
            var reader = command.ExecuteReader();

            return reader;

        }

        public int Update(int id, decimal novoPreco)
        {
            CreateConnection().Open();
            var command = _conn.CreateCommand();

            command.Parameters.Add(new SqlParameter("id", id));
            command.Parameters.Add(new SqlParameter("novoPreco", novoPreco));
            command.Parameters.Add(new SqlParameter("data", DateTime.Now));
            command.CommandText = "update produtos set preco = @novoPreco, DataInclusaoAlteracao = @data where id = @id ";

           int qtdAlterada = command.ExecuteNonQuery();

            CreateConnection().Close();

            return qtdAlterada;

        }

        public int Delete(int id)
        {
            CreateConnection().Open();


            var command = _conn.CreateCommand();

            command.Parameters.Add(new SqlParameter("id", id));
            command.CommandText = "delete from produtos where id = @id";
            
            int qtdDeletada = command.ExecuteNonQuery();

            CreateConnection().Close();

            return qtdDeletada;
        }

    }
}
