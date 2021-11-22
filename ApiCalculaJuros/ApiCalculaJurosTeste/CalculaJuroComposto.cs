using CalculaJuros.Service;
using Xunit;


namespace ApiCalculaJurosTeste
{
    public class CalculaJuroComposto
    {
        CalculaJurosService calcJ = new CalculaJurosService();

        [Fact]
        public void CalculaJuros_InseriValor_RetornaCalculo()
        {
            //Arrange
            double v = 100;
            int m = 5;
            double tx = 0.01;
            double vEsperado = 105.10;
            
            // Act            
            double ValorComJuros = calcJ.TaxaJurosComposto(v ,m ,tx);            

            // Assert
            Assert.Equal(vEsperado.ToString("F2"), ValorComJuros.ToString("F2"));
        }

               
    }
}
