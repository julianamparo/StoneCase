using StoneCase.Services;
using System;
using Xunit;

namespace TestesStoneCase
{
    public class TesteCobranca
    {
        [Theory]
        [InlineData("39115227898")]
        [InlineData("04147557821")]
        public void CobrancaServiceTest(string cpf)
        {
            CobrancaService cobrancaService = new CobrancaService();
            double resultado = cobrancaService.CalculoConsumo(cpf);
            string digitosIniciais = cpf.Substring(0, 2);
            string digitosFinais = cpf.Substring(cpf.Length - 2, 2);

            double valorEsperado = double.Parse(digitosIniciais + digitosFinais);
            Assert.Equal(valorEsperado, resultado);

        }

    }
}
