using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-MLTUQRR; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT Usuarios.idUsuario, Usuarios.email, Usuarios.senha, Usuarios.idTipoUsuario, TiposUsuarios.permissao FROM Usuarios " +
                " INNER JOIN TiposUsuarios ON Usuarios.idTipoUsuario = TiposUsuarios.idTipoUsuario" +
                " WHERE Usuarios.email = @email AND Usuarios.senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            permissao = rdr["permissao"].ToString()
                        };
                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }
    }
}
