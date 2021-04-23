using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-MLTUQRR; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos(nomeJogo, descricao, dataLancamento, valor, idEstudio) " +
                    "VALUES (@Nome, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Jogos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = DateTime.Parse(rdr["dataLancamento"].ToString()),
                            valor = Double.Parse(rdr["valor"].ToString()),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"])
                        };
                        listaJogos.Add(jogo);
                    }
                }
            }

        return listaJogos;
        }
    }
}
