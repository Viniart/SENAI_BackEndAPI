using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "Informe um email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Informe uma senha")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O campo senha precisa ter no mínimo 3 e no máximo 20 caracteres")]
        public string senha { get; set; }
        public int idTipoUsuario { get; set; }
        public string permissao { get; set; }
    }
}
