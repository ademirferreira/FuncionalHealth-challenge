using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuncionalBank.Models
{
    public class ContaCorrente
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O número da conta é obrigatório")]
        public int Numero { get; set; }

        private decimal _saldo;

        [Column(TypeName = "decimal")]
        [DataType(DataType.Currency)]
        public decimal Saldo
        {
            get => _saldo;
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("Valor inválido para depósito.");
            _saldo += valor;
        }

        public virtual void Sacar(decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("Valor inválido para saque.");

            if (_saldo < valor) throw new ArgumentException("Saldo insuficiente");

            _saldo -= valor;
        }
    }
}