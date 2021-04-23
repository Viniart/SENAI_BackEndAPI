using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_filmes_webApiDef.Domains;
using senai_filmes_webApiDef.Interfaces;
using senai_filmes_webApiDef.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_filmes_webApiDef.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }
            // Caso encontre, parte para a criação de token

            // System.IdentityModel.Tokens.Jwt --> Pacote do Nuget para criar tokens
            // AspNetCore.Authentication.JwtBearer

            // Define os dados que serão fornecidos no token - Payload
            var claims = new[]
            {
                // TipoDaClaim, ValorDaClaim
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.permissao),
                new Claim("Claim personalizada", "Valor teste")
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token
            var token = new JwtSecurityToken(
                    // Poderia ser qualquer nome
                    issuer : "Filmes.webApi", // Emissor do token
                    audience : "Filmes.webApi", // Destinatário do token
                    claims :  claims, //Dados definidos acima
                    expires : DateTime.Now.AddMinutes(30),
                    signingCredentials : creds
                );
            // Retorna um status code com o token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
