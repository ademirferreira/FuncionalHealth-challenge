using FuncionalBank.Models;
using FuncionalBank.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            return Ok(conta);
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult<ContaCorrente>> NovaConta(ContaCorrente conta)
        {
            var contaCorrente = await _repository.GetConta(conta.Numero);
            if (contaCorrente is not null) return StatusCode(422, "Já existe uma conta com esse número");
            var novaConta = await _repository.NovaConta(conta);

            return CreatedAtAction("GetConta", new {numeroDaConta = novaConta.Numero}, novaConta);
        }

        [HttpGet("saldo/{numeroDaConta:int}")]
        public async Task<ActionResult<ContaCorrente>> Saldo(int numeroDaConta)
        {
            var conta = await _repository.GetConta(numeroDaConta);
            if (conta is null) return NotFound("Conta não encontrada");
            
            return Ok("Saldo disponível: R$" + conta.Saldo);
        }

        [HttpPut("depositar")]
        public async Task<ActionResult<ContaCorrente>> Depositar([FromBody] Operacao deposito)
        {
            try
            {
                var conta = await _repository.GetConta(deposito.Numero);
                if (conta is null) return NotFound("Conta não encontrada");
                var contaDeposito = await _repository.Depositar(conta, deposito.Valor);

                return Ok("Saldo disponível: R$" + contaDeposito.Saldo);

            }
            catch (ArgumentException e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [HttpPut("sacar")]
        public async Task<ActionResult<ContaCorrente>> Sacar([FromBody] Operacao saque)
        {
            try
            {
                var conta = await _repository.GetConta(saque.Numero);
                if (conta is null) return NotFound("Conta não encontrada");
                var contaSaque = await _repository.Sacar(conta, saque.Valor);

                return Ok("Saldo disponível: R$" + contaSaque.Saldo);

            }
            catch (ArgumentException e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

    }
}
