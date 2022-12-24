using Alura.LeilaoOnline.Selenium.V2.Fixtures;
using Alura.LeilaoOnline.Selenium.V2.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.V2.Testes
{
    [Collection("Edge Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver _driver;

        public AoFiltrarLeiloes(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginDeveMostrarPainelResultado()
        {
            // Arrange
            LoginPO loginPo = new LoginPO(_driver);
            loginPo.Visitar();
            loginPo.PreencheFormulario("fulano@example.org", "123");
            loginPo.SubmeteFormulario();

            DashboardInteressadaPO dashboardInteressadaPo = new DashboardInteressadaPO(_driver);
            
            // Act
            dashboardInteressadaPo.Filtro.PesquisarLeiloes(
                new List<string> {"Arte", "Coleções"}, 
                "", 
                true);
            
            // Assert
            Assert.Contains("Resultado da pesquisa", _driver.PageSource);
        }
    }
}
