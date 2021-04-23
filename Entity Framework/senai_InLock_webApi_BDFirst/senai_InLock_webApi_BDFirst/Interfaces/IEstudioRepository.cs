using senai_InLock_webApi_BDFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webApi_BDFirst.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        List<Estudio> Listar();

        /// <summary>
        /// Busca um estúdio através do seu ID
        /// </summary>
        /// <param name="id">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio buscado</returns>
        Estudio BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        void Cadastrar(Estudio novoEstudio);

        /// <summary>
        /// Atualiza um estudio existente
        /// </summary>
        /// <param name="id">ID do estudio a ser atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        void Atualizar(int id, Estudio estudioAtualizado);

        /// <summary>
        /// Deleta u mestudio existente
        /// </summary>
        /// <param name="id">ID do estúdio que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os estúdios com a lista de jogos
        /// </summary>
        /// <returns>Uma lista de estúdios e seus respectivos jogos</returns>
        List<Estudio> ListarJogos();
    }
}
