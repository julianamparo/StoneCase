using StoneCase.Services;
using System;
using Xunit;

namespace TestesStoneCase
{
    public class TesteCobranca
    {
        [Fact]
        public void CobrancaServiceTest()
        {
            CobrancaService cobrancaService = new CobrancaService();
            double resultado = cobrancaService.CalculoConsumo("39115227898");
            Assert.Equal(3998, resultado);
            double resultado2 = cobrancaService.CalculoConsumo("04147557821");
            Assert.Equal(421, resultado);
        }

    }
}
