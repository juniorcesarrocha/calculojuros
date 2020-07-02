using AutoMapper;
using CalculoJuros.Domain.Entities;
using CalculoJuros.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJuros.Web.Api.Config
{
    public class AutoMapperEntityToViewModel : Profile
    {
        public AutoMapperEntityToViewModel()
        {
            TaxaJurosMap();
        }

        private void TaxaJurosMap()
        {
            CreateMap<TaxaJuros, TaxaJurosViewModel>();
        }
    }
}
