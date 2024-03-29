﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string nomeJogo { get; set; }
        public string descricao { get; set; }
        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }
        public double valor { get; set; }
        [Required(ErrorMessage = "O id do estúdio desenvolvedor é obrigatório!")]
        public int idEstudio { get; set; }
    }
}
