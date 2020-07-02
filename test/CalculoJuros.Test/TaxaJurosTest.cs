using CalculoJuros.Domain.Entities;
using CalculoJuros.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculoJuros.Test
{
    public class TaxaJurosTest
    {
        [Fact(DisplayName = "Consultar taxa de juros de 1%")]
        [Trait("Categoria", "Taxa de Juros")]
        public void ConsultarJuros_CalcularJurosUmPorcento_DeveRetornarComSucesso()
        {
            // Arrage
            var taxaJuros = new TaxaJuros();

            // Act
            var resultado = taxaJuros.CalcularJurosUmPorcento();

            // Assert
            Assert.Equal(0.01M, resultado);
        }        

        [Fact(DisplayName = "Calcular juros compostos")]
        [Trait("Categoria", "Taxa de Juros")]
        public void CalcularJuros_JurosCompostos_DeveCalcularComSucesso()
        {
            // Arrage
            var taxaJuros = new TaxaJuros(100.00M, 5);

            // Act
            var resultado = taxaJuros.CalcularJurosCompostos();

            // Assert
            Assert.Equal(105.10M, resultado);
        }

        [Theory(DisplayName = "Calcular juros compostos - Theory")]
        [Trait("Categoria", "Taxa de Juros")]
        [InlineData(100, 5, 105.10)]
        [InlineData(254.58, 5, 267.56)]
        [InlineData(254.58, 27, 333.04)]
        public void CalcularJuros_JurosCompostosTheory_DeveCalcularComSucesso(decimal valorInicial, int meses, decimal valorFuturo)
        {
            // Arrage
            var taxaJuros = new TaxaJuros(valorInicial, meses);

            // Act
            var resultado = taxaJuros.CalcularJurosCompostos();

            // Assert
            Assert.Equal(valorFuturo, resultado);
        }

        [Fact(DisplayName = "Calcular juros compostos com valores com valor inicial inválido")]
        [Trait("Categoria", "Taxa de Juros")]
        public void CalcularJurosCompostos_ValorInicialInvalido_DeveRetornarExcecao()
        {
            // Arrage
            var taxaJuros = new TaxaJuros(-100, 5);

            // Act e Assert
            Assert.Throws<DomainException>(() => taxaJuros.CalcularJurosCompostos());
        }

        [Fact(DisplayName = "Calcular juros compostos com valores com mês inválido")]
        [Trait("Categoria", "Taxa de Juros")]
        public void CalcularJurosCompostos_MesInvalido_DeveRetornarExcecao()
        {
            // Arrage
            var taxaJuros = new TaxaJuros(100, -2);

            // Act e Assert
            Assert.Throws<DomainException>(() => taxaJuros.CalcularJurosCompostos());
        }
    }
}
