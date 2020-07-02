using AutoMapper;
using CalculoJuros.Domain.Contracts;
using CalculoJuros.Domain.Entities;
using CalculoJuros.Domain.ViewModels;
using CalculoJuros.Infrastructure.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace CalculoJuros.Web.Api.Controllers
{

    [Route("taxaJuros")]
    public class TaxaJurosController : ApiControllerBase
    {
        private readonly ITaxaJurosService _taxaJurosService;
        private readonly IMapper _mapper;
        public TaxaJurosController(ITaxaJurosService taxaJurosService,
            IMapper mapper,
            IRequestNotificator notifications) : base(notifications) 
        {
            _taxaJurosService = taxaJurosService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get() => Result(_taxaJurosService.CalcularJurosUmPorcento());

        [HttpGet("calculajuros")]
        public IActionResult CalcularJurosCompostos(decimal valorInicial, int meses)
        {
            var taxaJuros = _mapper.Map<TaxaJuros>(new TaxaJurosViewModel { 
                ValorInicial = valorInicial,
                Meses = meses
            });

            return Result(_taxaJurosService.CalcularJurosCompostos(taxaJuros));
        }
    }
}
