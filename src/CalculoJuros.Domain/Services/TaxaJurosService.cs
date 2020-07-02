using CalculoJuros.Domain.Contracts;
using CalculoJuros.Domain.Entities;
using CalculoJuros.Domain.Validation;
using CalculoJuros.Infrastructure.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoJuros.Domain.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly IRequestNotificator _notifications;

        public TaxaJurosService(IRequestNotificator notifications)
        {
            _notifications = notifications;
        }

        public decimal CalcularJurosUmPorcento()
        {
            return new TaxaJuros().CalcularJurosUmPorcento();
        }

        public decimal CalcularJurosCompostos(TaxaJuros taxaJuros)
        {
            var validationResult = new JurosCompostosValidation().Validate(taxaJuros);
            if (!validationResult.IsValid)
            {
                _notifications.Add(validationResult);
                return 0;
            }
            
            return taxaJuros.CalcularJurosCompostos();
        }
    }
}
