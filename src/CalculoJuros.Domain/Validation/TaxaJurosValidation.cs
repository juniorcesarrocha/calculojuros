using CalculoJuros.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoJuros.Domain.Validation
{
    public class TaxaJurosValidation : AbstractValidator<TaxaJuros>
    {
        public TaxaJurosValidation() { }

        public void ValidarValorInicial() 
        {
            var propertyName = "Valor Inicial";
            RuleFor(c => c.ValorInicial)
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThan(0).WithName(propertyName).WithMessage("O {PropertyName} deve ser maior que zero.");
        }

        public void ValidarMeses()
        {
            var propertyName = "Meses";
            RuleFor(c => c.Meses)
                .NotEmpty().WithName(propertyName).WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThan(0).WithName(propertyName).WithMessage("Os {PropertyName} devem ser maior que zero.");
        }
    }
}
