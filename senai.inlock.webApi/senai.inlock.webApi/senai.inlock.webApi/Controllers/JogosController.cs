﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [Authorize(Roles = "comum,administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

            return Ok(listaJogos);
        }

        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }
    }
}
