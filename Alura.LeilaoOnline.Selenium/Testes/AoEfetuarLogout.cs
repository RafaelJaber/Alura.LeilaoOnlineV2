using Alura.LeilaoOnline.Selenium.V2.Fixtures;
using Alura.LeilaoOnline.Selenium.V2.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.V2.Testes
{
    [Collection("Edge Driver")]
    public class AoEfetuarLogout
    {
        private readonly IWebDriver _driver;
            
        public AoEfetuarLogout(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidadoDeveIrParaHomeNaoLogada()
        {
            // Arrange
            LoginPO po = new LoginPO(_driver);
            po.Visitar();
            po.PreencheFormulario("fulano@example.org", "123");
            po.SubmeteFormulario();
            
            // Act
            DashboardInteressadaPO dashPo = new DashboardInteressadaPO(_driver);
            dashPo.EfetuarLogout();
            
            // Assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}
