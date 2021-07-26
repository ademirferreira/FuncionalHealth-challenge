using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FuncionalBank.Models;

namespace FuncionalBank.Repositories
{
    public interface IContaCorrenteRepository
    {
        Task<IEnumerable<ContaCorrente>> GetContas();
        Task<ContaCorrente> GetConta(int numeroDaConta);
        Task<string> GetSaldo(int numeroDaConta);
    }
}