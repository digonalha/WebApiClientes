using System.Collections.Generic;
using System.Data.SqlClient;
using WebApiClientes.Models;

namespace WebApiClientes.Repositories
{
    public class ClienteRepository
    {
        const string TABLE_NAME = "Cliente";

        public static void insert(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                try
                {
                    string SQL = $"INSERT INTO {TABLE_NAME} (Nome, Cpf, DataNascimento) VALUES (@Nome, @Cpf, @DataNascimento)";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(SQL, con);

                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
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

        internal static void update(int id, Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                try
                {
                    string SQL = $"Update {TABLE_NAME} SET Nome = @Nome, Cpf = @Cpf, DataNascimento = @DataNascimento WHERE Id = @Id";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(SQL, con);

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
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

        internal static Cliente get(int id)
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                try
                {
                    Cliente cliente = null;
                    string SQL = $"SELECT Id, Nome, Cpf, DataNascimento FROM {TABLE_NAME} WHERE Id = @Id";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    cmd.Parameters.AddWithValue("@Id", id);

                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                        cliente = Cliente.New(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetDateTime(3));

                    return cliente;
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

        internal static List<Cliente> list()
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                try
                {
                    List<Cliente> listClientes = new List<Cliente>();
                    string SQL = $"SELECT Id, Nome, Cpf, DataNascimento FROM {TABLE_NAME}";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                        listClientes.Add(Cliente.New(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetDateTime(3)));

                    return listClientes;
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

        public static void delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                try
                {
                    const string SQL = "DELETE FROM Cliente WHERE (Id = @Id)";

                    con.Open();

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
