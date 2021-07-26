using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuncionalBank.Models;
using FuncionalBank.Repositories;

namespace FuncionalBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteRepository _repository;

        public ContaCorrenteController(IContaCorrenteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ContaCorrente>> GetContas()
        {
            return await _repository.GetContas();
        }

        [HttpGet("{numeroDaConta:int}")]
        public async Task<ActionResult<ContaCorrente>> GetConta(int numeroDaConta)
        {
            var conta = await _repository.GetConta(numeroDaConta);
            if (conta is null) return NotFound("Conta não encontrada");

            return conta;
        }
    }
}
