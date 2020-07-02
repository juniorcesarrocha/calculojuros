using CalculoJuros.Domain.Core;
using System;

namespace CalculoJuros.Domain.Entities
{
    public class TaxaJuros
    {
        public decimal ValorInicial { get; private set; }
        public int Meses { get; private set; }

        public TaxaJuros() { }
        public TaxaJuros(decimal valorInicial, int meses)
        {
            this.ValorInicial = valorInicial;
            this.Meses = meses;
        }

        public decimal CalcularJurosUmPorcento()
        {
            return 0.01M;
        }

        public decimal CalcularJurosCompostos()
        {
            if (this.ValorInicial <= 0) throw new DomainException("O valor inicial deve ser maior que zero.");
            if (this.Meses <= 0) throw new DomainException("A quantidade de meses deve ser maior que zero.");

            var valorFuturo = Convert.ToDouble(this.ValorInicial) * Math.Pow(1D + Convert.ToDouble(CalcularJurosUmPorcento()), Convert.ToDouble(this.Meses));
            return Math.Truncate(100 * Convert.ToDecimal(valorFuturo)) / 100;
        }
    }
}
