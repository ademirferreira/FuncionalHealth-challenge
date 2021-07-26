using FuncionalBank.Models;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FuncionalBank.Data;
using Microsoft.EntityFrameworkCore;

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
                .ContasCorrentes.FirstAsync(x => x.Numero == numeroDaConta);

            return conta ?? null;
        }

    }
}