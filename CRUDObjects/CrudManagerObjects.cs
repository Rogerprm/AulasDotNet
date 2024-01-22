using CRUDObjects.Entidades;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Criar um Database manager Object -
//Não usar valores e colunas e sim objetos -
//criar 3 classes novas e sera uma para cada tabela do banco -
//o return passa a ser o objeto -?
//o add passa o objeto daquele tipo -
//Se chegar um cliente, monta a query para o cliente -
//reflection (System.Reflection) -> Generico, passa o cliente e ele insere na cliente -
//o return do read, retornar uma lista (usar Generic) -
//remover deve receber sempre o objeto -
//Pasta Entidades -
//As colunas serao propriedades do mesmo tipo -

//Interface em cada classe com os metodos de getUpdade, GetInsert etc as queries precisariam estar na propria classe.
//o Create estaria em outra interface
//recebe a interface ao inves de T
//Se criar uma tabela nova, mexer em nada do CrudManagerObjects ou no minimo possivel

namespace CRUDObjects
{
    public class CrudManagerObjects
    {

        private SqlConnection _conn;
        private SqlConnection CreateConnection()
        {
            _conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\roger\\OneDrive\\Geral\\Documentos\\Estudo 2023\\dotnet\\Leandro\\AulasDotNet\\CRUDObjects\\CrudObjects.mdf\";Integrated Security=True");
            return _conn;
        }

        public void Create<T>(T entidade)
        {
            CreateConnection().Open();

            var command = _conn.CreateCommand();
            var tipoEntidade = entidade.GetType().Name;
            var propriedades = entidade.GetType().GetProperties();

            string colunas = "", parametros = "";

            foreach (var prop in propriedades)
            {
                if (prop.Name == "Id")
                {
                    continue;
                }
                colunas += $"{prop.Name}, ";
                parametros += $"@{prop.Name}, ";

                command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entidade));
            }

            colunas = colunas.TrimEnd(',', ' ');
            parametros = parametros.TrimEnd(',', ' ');

            command.CommandText = $"INSERT INTO {tipoEntidade} ({colunas}) VALUES ({parametros})";

            command.ExecuteNonQuery();

            _conn.Close();

        }

        public List<T> Read<T>(T entidade)
        {
            CreateConnection().Open();
            var command = _conn.CreateCommand();
            var tipoEntidade = entidade.GetType().Name;
            var propriedades = entidade.GetType().GetProperties();

            command.CommandText = $"SELECT * FROM {tipoEntidade} (NOLOCK) ";

            var resultado = command.ExecuteReader();

            int colCount = resultado.FieldCount;

            List<T> listaRetorno = new List<T>();

            while (resultado.Read())
            {
                T entidades = Activator.CreateInstance<T>();

                for (int i = 0; i < colCount; i++)
                {
                    string colName = resultado.GetName(i);
                    object colValue = resultado[i];

                    PropertyInfo propriedade = typeof(T).GetProperty(colName);

                    if (propriedade != null && colValue != DBNull.Value)
                    {
                        Type propType = Nullable.GetUnderlyingType(propriedade.PropertyType) ?? propriedade.PropertyType;
                        object convertedValue = Convert.ChangeType(colValue, propType);
                        propriedade.SetValue(entidades, convertedValue);
                    }
                }

                listaRetorno.Add(entidades);
            }

            _conn.Close();
            return listaRetorno;
        }



        public void Update<T>(T entidade)
        {
            CreateConnection().Open();
            int id = 0;
            var command = _conn.CreateCommand();
            var tipoEntidade = entidade.GetType().Name;
            var propriedades = entidade.GetType().GetProperties();

            string texto = "", colunas = "", parametros = "";

            foreach (var item in propriedades)
            {
                if (item.Name == "Id")
                {
                    id = int.Parse(item.GetValue(entidade).ToString());
                    continue;
                }
                colunas = $"{item.Name} ";
                parametros = $"@{item.Name}, ";
                texto = texto + $"{colunas} = {parametros}";

                command.Parameters.AddWithValue($"@{item.Name}", item.GetValue(entidade));
            }

            texto = texto.TrimEnd(',', ' ');



            command.CommandText = $"UPDATE {tipoEntidade} SET {texto} WHERE ID = {id}";

            command.ExecuteNonQuery();

            _conn.Close();

        }



        public int Delete<T>(T entidade, int id)
        {
            CreateConnection().Open();
            var command = _conn.CreateCommand();
            var tipoEntidade = entidade.GetType().Name;
            var propriedades = entidade.GetType().GetProperties();
            bool ativoEncontrado = false;

            foreach (var item in propriedades)
            {
                if (item.Name == "Ativo")
                {
                    ativoEncontrado = true;                    
                }
            }

            if (ativoEncontrado == true)
            {
                command.CommandText = $"UPDATE {tipoEntidade} SET ATIVO = 0 where id = {id} ";
            }
            else
            {
                command.CommandText = $"DELETE FROM {tipoEntidade} where id = {id} ";
            }

            return command.ExecuteNonQuery();

            _conn.Close();
        }





    }


}
