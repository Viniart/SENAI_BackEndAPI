using senai_InLock_webApi_BDFirst.Contexts;
using senai_InLock_webApi_BDFirst.Domains;
using senai_InLock_webApi_BDFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace senai_InLock_webApi_BDFirst.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos Estúdios
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Objeto context por onde serão chamados os métodos do EF Core
        /// </summary>
        InlockContext _context = new InlockContext();


        public void Atualizar(int id, Estudio estudioAtualizado)
        {
            Estudio estudioBuscado = _context.Estudios.Find(id);

            if (estudioAtualizado.NomeEstudio != null)
            {
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            }

            _context.Estudios.Update(estudioBuscado);

            _context.SaveChanges();
        }

        public Estudio BuscarPorId(int id)
        {
            return _context.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            _context.Estudios.Add(novoEstudio);

            // Salvar as informações para serem gravadas no banco de dados
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estudio estudioBuscado = _context.Estudios.Find(id);

            _context.Estudios.Remove(estudioBuscado);

            _context.SaveChanges();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        public List<Estudio> Listar()
        {
            // Retorna uma lista com todas as informações dos estúdios
            return _context.Estudios.ToList();
        }

        public List<Estudio> ListarJogos()
        {
            return _context.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
