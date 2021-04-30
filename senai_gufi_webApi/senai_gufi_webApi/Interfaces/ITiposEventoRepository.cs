using senai_gufi_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Interfaces
{
    interface ITiposEventoRepository
    {
        List<TiposEvento> ListarTodos();

        TiposEvento BuscarPorId(int id);

        void Cadastrar(TiposEvento novoTipoEvento);

        void Atualizar(int id, TiposEvento tipoEventoAtualizado);

        void Deletar(int id);
    }
}
