﻿using senai_filmes_webApiDef.Domains;
using senai_filmes_webApiDef.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApiDef.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-MLTUQRR; initial catalog=filmes; user Id=sa; pwd=senai@132";
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, email, senha, permissao FROM Usuarios WHERE email = @email AND senha = @senha;";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"])
                            ,
                            email = rdr["email"].ToString()
                            ,
                            senha = rdr["senha"].ToString()
                            ,
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
