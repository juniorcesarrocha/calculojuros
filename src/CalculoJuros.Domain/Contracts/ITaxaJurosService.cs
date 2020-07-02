using CalculoJuros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoJuros.Domain.Contracts
{
    public interface ITaxaJurosService
    {
        public decimal CalcularJurosUmPorcento();
        public decimal CalcularJurosCompostos(TaxaJuros taxaJuros);
    }
}
