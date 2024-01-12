﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRUDMultiTabela
{
    public class DatabaseManagerMultiTable
    {
        private SqlConnection _conn;
        private SqlConnection CreateConnection()
        {
            _conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\roger\\OneDrive\\Geral\\Documentos\\Estudo 2023\\dotnet\\Leandro\\AulasDotNet\\CRUDMultiTabela\\CrudNovo.mdf\";Integrated Security=True");
            return _conn;
        }

        public bool Testconnection()
        {
            CreateConnection().Open();
            return true;
        }

        public void Create(string tabela, List<string> colunas, List<string> valores)
        {
            CreateConnection().Open();

            var command = _conn.CreateCommand();
            var colunasSeparadas = string.Join(",", colunas);
            var valoresSeparadas = string.Join("','", valores);
            var colunasParametros = string.Join(",@", colunas);

            command.CommandText = $"Insert into {tabela} ( {colunasSeparadas} ) Values (@{colunasParametros})";

            for (int i = 0; i < colunas.Count; i++)
            {
                command.Parameters.Add(new SqlParameter(colunas[i], valores[i]));
            }
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(valoresSeparadas + ' ' + command.CommandText + ' ' + ex.Message);
            }

            CreateConnection().Close();
        }

        public SqlDataReader Read(string tabela)
        {
            CreateConnection().Open();

            var command = _conn.CreateCommand();
            command.CommandText = $"select * from {tabela} (nolock) where ativo <> 0";
            var reader = command.ExecuteReader();

            return reader;
        }

        public int Delete(string tabela, int id)
        {
            CreateConnection().Open();

            var command = _conn.CreateCommand();

            command.Parameters.Add(new SqlParameter("id", id));
            command.CommandText = $"Update {tabela} set ativo = 0 where id = @id ";

            //command.CommandText = $"delete from {tabela} where id = @id";

            int qtdDeletada = command.ExecuteNonQuery();
            return qtdDeletada;

            //Avaliar a FK para deletar cliente/produto com venda.
        }

        public void Update (string tabela, int id, List<string>colunas, List<string> valores)
        {
            CreateConnection().Open();

            var command = _conn.CreateCommand();
            var colunasSeparadas = string.Join(",", colunas);
            var valoresSeparadas = string.Join("','", valores);
            var colunasParametros = string.Join(",@", colunas);

            command.CommandText = $"Update {tabela} set ( {colunasSeparadas} ) Values (@{colunasParametros})";

            for (int i = 0; i < colunas.Count; i++)
            {
                command.Parameters.Add(new SqlParameter(colunas[i], valores[i]));
            }

        }


    }
}

//Criar um Database manager Object
//Não usar valores e colunas e sim objetos
//criar 3 classes novas e sera uma para cada tabela do banco
//o return passa a ser o objeto
//o add passa o objeto daquele tipo
//Se chegar um cliente, monta a query para o cliente
//reflection (System.Reflection) -> Generico, passa o cliente e ele insere na cliente
//o return do read, retornar uma lista (usar Generic)
//remover deve receber sempre o objeto
//Pasta Entidades
//As colunas serao propriedades do mesmo tipo