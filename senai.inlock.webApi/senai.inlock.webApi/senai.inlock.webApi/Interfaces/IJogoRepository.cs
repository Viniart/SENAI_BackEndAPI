using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista com todos os jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo com as informações a serem cadastradas</param>
        void Cadastrar(JogoDomain novoJogo);
    }
}
