using FuncionalBank.Data;
using FuncionalBank.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuncionalBank.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly ContaCorrenteContext _context;

        public ContaCorrenteRepository(ContaCorrenteContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ContaCorrente>> GetContas()
        {
            return await _context.ContasCorrentes.AsNoTracking().ToListAsync();
        }

        public async Task<ContaCorrente> GetConta(int numeroDaConta)
        {
            var conta = await _context
                .ContasCorrentes.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Numero == numeroDaConta);

            return conta;
        }

        public async Task<ContaCorrente>Depositar(ContaCorrente conta, decimal valor)
        {
            var contaExistente = await GetConta(conta.Numero);
            contaExistente.Depositar(valor);
            await Atualizar(contaExistente);

            return contaExistente;

        }

        public async Task<ContaCorrente> Sacar(ContaCorrente conta, decimal valor)
        {
            var contaExistente = await GetConta(conta.Numero);
            contaExistente.Sacar(valor);
            await Atualizar(contaExistente);
            
            return contaExistente;
        }

        public async Task Atualizar(ContaCorrente conta)
        {
            _context.Update(conta);
            await _context.SaveChangesAsync();
        }

        public async Task<ContaCorrente> NovaConta(ContaCorrente conta)
        {
            _context.ContasCorrentes.Add(conta);
            await _context.SaveChangesAsync();

            return conta;
        }
    }
}