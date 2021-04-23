using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApiDef.Domains;
using senai_filmes_webApiDef.Interfaces;
using senai_filmes_webApiDef.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints referentes aos gêneros
/// </summary>
namespace senai_filmes_webApiDef.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>http://localhost:5000/api/generos</returns>
        /// Não esquecer de usar BREAKPOINTS para testes
        [Authorize(Roles = "administrador")] // Verifica se o usuário está logado
        [HttpGet]
        public IActionResult Get()
        {
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            // Retorna um status code e a listaGeneros
            return Ok(listaGeneros);
        }

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <returns>Um gênero ou NotFound</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                // Caso não encontrado return um status code 404 com a mensagem atribuida
                return NotFound("Nenhum gênero encontrado!");
            }

            return Ok(generoBuscado);
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <returns>Um status code 201 - Created </returns>
        /// http://localhost:5000/api/generos
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // Faz a chamada para o método .Cadastrar()
            _generoRepository.Cadastrar(novoGenero);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        // Atualiza todos os campos, enquanto o patch só alguns
        /// <summary>
        /// Atualiza um gênero
        /// </summary>
        /// <param name="id">id do gênero a ser atualizado</param>
        /// <param name="generoAtualizado">Novo gênero</param>
        /// <returns>Um status code</returns>
        /// 
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscaod que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFOund com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (generoBuscado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    }
                );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método . AtualizarIdUrl()
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                // Return um status code 204 - No Content
                return NoContent();
            }
            catch (Exception codErro)
            {
                // Return um status code 400 - Bad Request e o código do erro
                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoArualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscaod que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            if (generoBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método AtualizarIdCorpo
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                catch (Exception codErro)
                {
                    // Retorna BadRequest com o código de erro
                    return BadRequest(codErro);
                }
            }

            // Caso não seja encontrado
            return NotFound(
                new
                {
                    mensagem = "Gênero não encontrado!"
                });
        }

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/generos/11
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método Deletar
            _generoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }
}
