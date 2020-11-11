using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiClientes.Models;

namespace WebApiClientes.DAL
{

    public class Connection
    {
        public static string getConnectionString() => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CasaDoCodigo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }


    public class ClienteDAL
    {
        public static void insert(Cliente cliente)
        {
            if (cliente.IsValid())
            {

                using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
                {
                    try
                    {

                        con.Open();

                        const string SQL = "INSERT INTO Cliente (Nome, Cpf, DataNascimento, Logradouro, Bairro, Cidade, Uf) VALUES (@Nome, @Cpf, @DataNascimento, @Logradouro, @Bairro, @Cidade, @Uf)";

                        SqlCommand cmd = new SqlCommand(SQL, con);


                        cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                        cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                        cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                        cmd.Parameters.AddWithValue("@Logradouro", cliente.Logradouro);
                        cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                        cmd.Parameters.AddWithValue("@Cidade", cliente.Cidade);
                        cmd.Parameters.AddWithValue("@Uf", cliente.Uf);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        internal static ActionResult<Cliente> get(int id)
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                Cliente cliente = null;
                const string SQL = "SELECT Id, Nome, Cpf, DataNascimento, Logradouro, Bairro, Cidade, Uf FROM Cliente WHERE Id = @Id";

                con.Open();
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.Parameters.AddWithValue("@Id", id);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                    cliente = Cliente.New(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetDateTime(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetString(7));
                return cliente;
            }

        }

        public static void delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                try
                {
                    con.Open();

                    const string SQL = "DELETE FROM Cliente WHERE (Id = @Id)";

                    SqlCommand cmd = new SqlCommand(SQL, con);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
