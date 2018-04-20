using System;
using System.Data.SqlClient;

namespace ArtigoTesteMetodoVoid.Core
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }

        private readonly string _conexao = @"Data Source=XPSP-019441\MSSQLLOCALDB;Initial Catalog=ArtigoTesteMetodoVoid;Integrated Security=True;Pooling=False";

        public Usuario PegarUsuarioPorId(Guid id)
        {
            try
            {
                var usuario = new Usuario();
                using (var conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("SELECT * FROM dbo.Usuarios WHERE Id = @Id", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);
                        var reader = cmd.ExecuteReader();

                        if (!reader.HasRows)
                            return null;

                        while(reader.Read())
                        {
                            usuario = CarregarUsuario(reader);
                        }

                        return usuario;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private Usuario CarregarUsuario(SqlDataReader reader)
        {
            return new Usuario
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                Nome = reader["Nome"].ToString(),
                Status = Convert.ToBoolean(reader["Status"])
            };
        }

        public Usuario InserirUsuario(Usuario usuario)
        {
            try
            {
                using (var conn = new SqlConnection(_conexao))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("INSERT INTO dbo.Usuarios (Nome, Status) VALUES (@Nome, 1)", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void InativarUsuario(int id)
        {
            //
        }

        public void DeletarUsuario(Guid id)
        {
            using (var conn = new SqlConnection(_conexao))
            {
                conn.Open();

                using (var cmd = new SqlCommand("DELETE FROM dbo.Usuarios WHERE Id = @Id", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
