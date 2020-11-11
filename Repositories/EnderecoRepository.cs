using System.Collections.Generic;
using System.Data.SqlClient;
using WebApiClientes.Models;

namespace WebApiClientes.Repositories
{
    public class EnderecoRepository
    {
        const string TABLE_NAME = "Endereco";

        public static void insert(Endereco endereco)
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                try
                {
                    string SQL = $"INSERT INTO {TABLE_NAME} (Logradouro, Bairro, Cidade, Estado) VALUES (@Logradouro, @Bairro, @Cidade, @Estado)";
                    
                    con.Open();
                    SqlCommand cmd = new SqlCommand(SQL, con);

                    cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
                    cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
                    cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
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

        internal static void update(int id, Endereco endereco)
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                try
                {
                    string SQL = $"UPDATE {TABLE_NAME} SET Logradouro = @Logradouro, Bairro = @Bairro, Cidade = @Cidade, Estado WHERE Id = @Id";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(SQL, con);

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
                    cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
                    cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
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

        internal static Endereco get(int id)
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                try
                {
                    Endereco endereco = null;
                    string SQL = $"SELECT Id, Logradouro, Bairro, Cidade, Estado FROM {TABLE_NAME} WHERE Id = @Id";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                        endereco = Endereco.New(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(3));

                    return endereco;
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

        internal static List<Endereco> list()
        {
            using (SqlConnection con = new SqlConnection(Connection.getConnectionString()))
            {
                try
                {
                    List<Endereco> listEnderecos = new List<Endereco>();
                    string SQL = $"SELECT Id, Logradouro, Bairro, Cidade, Estado FROM {TABLE_NAME}";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                        listEnderecos.Add(Endereco.New(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4)));

                    return listEnderecos;
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
                    string SQL = $"DELETE FROM {TABLE_NAME} WHERE (Id = @Id)";

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
