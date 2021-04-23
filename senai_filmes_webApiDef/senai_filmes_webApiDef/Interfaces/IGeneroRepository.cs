using senai_filmes_webApiDef.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApiDef.Interfaces
{
    interface IGeneroRepository
    {
        // TipoRetorno NomeMetodo(TipoParamentro NomeParametro)

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">id do gênero a ser buscado</param>
        /// <returns>Um objeto gênero que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com as informações a serem cadastradas</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto gênero com as novas informaçôes</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza o gênero existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do objeto que será atualizado</param>
        /// <param name="genero">Objeto gênero com as novas informações</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero a ser deletado</param>
        void Deletar(int id);
    }
}
