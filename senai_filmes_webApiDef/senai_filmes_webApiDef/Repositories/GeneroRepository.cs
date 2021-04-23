using senai_filmes_webApiDef.Domains;
using senai_filmes_webApiDef.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApiDef.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        // DESTOP\\SQLEXPRESS precisa de 2 barras pra ele identificar uma barra
        // Ctrl+K+C pra comentar linha toda
        private string stringConexao = "Data Source=DESKTOP-MLTUQRR; initial catalog=filmes; user Id=sa; pwd=senai@132";
        // private string stringConexao = "Data Source=DESKTOP-MLTUQRR; initial catalog; integrated security=true";
        // Se conectando pelo usuário do pc

        /// <summary>
        /// Atualiza um gênero passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto gênero com as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdBody = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@ID", genero.idGenero);
                    cmd.Parameters.AddWithValue("Nome", genero.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um gênero passando o Id pelo recurso (URL)
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="genero">Objeto gênero com as novas informações</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("Nome", genero.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um gênero através de seu id
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>Um gênero buscado ou null</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara o query a ser executada
                string querySelectById = "SELECT * FROM Generos WHERE idGenero = @ID";

                // Abre a conexão com o banco
                con.Open();

                // Declarar o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();
                    
                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instacia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            // Atribui à propriedade idGenero o valor da coluna idGenero do banco de dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),
                            nome = rdr["nome"].ToString()
                        };

                        return generoBuscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a conexão con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                // INSERT INTO Generos(Nome) VALUES ('Ficção Científica');
                // INSERT INTO Generos(Nome) VALUES ('Joana D'Arc');
                // string queryInsert = "INSERT INTO Generos(Nome) VALUES ('" + novoGenero.nome + "')";
                // Não usar dessa forma pois irá gerar o efeito Joana D'Arc
                // Além de permitir SQL Injection
                // Ex: "nome" : "Perdeu mané')DROP TABLE Filmes--"

                // Correto:
                string queryInsert = "INSERT INTO Generos(Nome) VALUES (@Nome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero a ser deletado</param>
        public void Deletar(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada passando o parâmetro @@ID
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no método
                    cmd.Parameters.AddWithValue("ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comand
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma listas de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma listaGeneros onde serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection con passando a string de conexao como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT * FROM Generos";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui à propriedade idGenero o valor da primeira coluna da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString()
                        };
                        // Adiciona o objeto gênero criado à listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            }

            // Retorna a lista de gêneros
            return listaGeneros;
        }
    }
}
