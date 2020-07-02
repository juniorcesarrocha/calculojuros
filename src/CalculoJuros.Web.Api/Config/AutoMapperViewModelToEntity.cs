using AutoMapper;
using CalculoJuros.Domain.Entities;
using CalculoJuros.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJuros.Web.Api.Config
{
    public class AutoMapperViewModelToEntity : Profile
    {
        public AutoMapperViewModelToEntity()
        {
            TaxaJurosMap();
        }

        private void TaxaJurosMap()
        {
            CreateMap<TaxaJurosViewModel, TaxaJuros>();
        }
    }
}
