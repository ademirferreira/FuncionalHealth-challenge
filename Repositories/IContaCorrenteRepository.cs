using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FuncionalBank.Models;

namespace FuncionalBank.Repositories
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> NovaConta(ContaCorrente conta);
        Task<IEnumerable<ContaCorrente>> GetContas();
        Task<ContaCorrente> GetConta(int numeroDaConta);
        Task<ContaCorrente> Depositar(ContaCorrente conta, decimal valor);
        Task<ContaCorrente> Sacar(ContaCorrente conta, decimal valor);
        Task Atualizar(ContaCorrente conta);
    }
}