using Microsoft.EntityFrameworkCore;
using senai_gufi_webApi.Contexts;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        GufiContext context = new GufiContext();

        public void Atualizar(int id, TiposEvento tipoEventoAtualizado)
        {
            TiposEvento tipoEventoBuscado = BuscarPorId(id);

            if (tipoEventoAtualizado.TituloTipoEvento != null)
            {
                tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;
            }

            context.TiposEventos.Update(tipoEventoBuscado);

            context.SaveChanges();
        }

        public TiposEvento BuscarPorId(int id)
        {
            return context.TiposEventos.FirstOrDefault(e => e.IdTipoEvento == id);
        }

        public void Cadastrar(TiposEvento novoTipoEvento)
        {
            context.TiposEventos.Add(novoTipoEvento);

            context.SaveChanges();
        }

        public List<TiposEvento> ListarTodos()
        {
            return context.TiposEventos.Include(e => e.Eventos).ToList();
        }

        public void Deletar(int id)
        {
            context.TiposEventos.Remove(BuscarPorId(id));

            context.SaveChanges();
        }
    }
}
