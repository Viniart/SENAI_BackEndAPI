﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_gufi_webApi.Domains
{
    public partial class TiposEvento
    {
        public TiposEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdTipoEvento { get; set; }
        [Required(ErrorMessage = "O título do evento é obrigatório!")]
        public string TituloTipoEvento { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
