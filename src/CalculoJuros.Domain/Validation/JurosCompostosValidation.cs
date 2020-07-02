using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoJuros.Domain.Validation
{
    public class JurosCompostosValidation : TaxaJurosValidation
    {
        public JurosCompostosValidation()
        {
            ValidarValorInicial();
            ValidarMeses();
        }
    }
}
