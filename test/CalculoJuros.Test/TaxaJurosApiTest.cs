using CalculoJuros.Test.Config;
using CalculoJuros.Web.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculoJuros.Test
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class TaxaJurosApiTest
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;
        private static string _endpointBase = "taxaJuros";

        public TaxaJurosApiTest(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Consultar taxa de juros de 1%")]
        [Trait("Categoria", "Integração API - Taxa de Juros")]
        public async Task ConsultarJuros_CalcularJurosUmPorcento_DeveRetornarComSucesso()
        {
            // Arrange e Act
            var getResponse = await _testsFixture.Client.GetAsync($"{_endpointBase}");

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }


        [Fact(DisplayName = "Calcular juros compostos")]
        [Trait("Categoria", "Integração API - Taxa de Juros")]
        public async Task CalcularJuros_JurosCompostos_DeveCalcularComSucesso()
        {
            // Arrange 
            var valorInicial = 100M;
            var meses = 5;

            //Act
            var getResponse = await _testsFixture.Client.GetAsync($"{_endpointBase}/calculajuros?valorInicial={valorInicial}&meses={meses}");

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }
    }
}
