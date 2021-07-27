using System.ComponentModel.DataAnnotations;

namespace FuncionalBank.Controllers
{
    public record Operacao
    {
        [Required(ErrorMessage = "É obrigatório informar o número da conta")]
        public int Numero { get; init; }

        [Required(ErrorMessage = "É obrigatório informar o valor")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; init; }
    }
}