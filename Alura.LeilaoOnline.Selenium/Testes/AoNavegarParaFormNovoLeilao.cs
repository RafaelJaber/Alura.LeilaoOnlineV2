using Alura.LeilaoOnline.Selenium.V2.Fixtures;
using Alura.LeilaoOnline.Selenium.V2.PageObjects;
using OpenQA.Selenium;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.V2.Testes
{
    [Collection("Edge Driver")]
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver _driver;

        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdmDeveMostrarMostrarTresCategorias()
        {
            // Arrange
            LoginPO loginPo = new LoginPO(_driver);
            loginPo.EfetuarLoginComCredenciais("admin@example.org", "123");

            NovoLeilaoPO novoLeilaoPo = new NovoLeilaoPO(_driver);
            
            // Act
            novoLeilaoPo.Visitar();
            
            // Assert
            Assert.Equal(3, novoLeilaoPo.Categorias.Count());
        }
    }
}
