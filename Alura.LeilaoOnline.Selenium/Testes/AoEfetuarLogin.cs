using Alura.LeilaoOnline.Selenium.V2.Fixtures;
using Alura.LeilaoOnline.Selenium.V2.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.V2.Testes
{
    [Collection("Edge Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver _driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }
        
        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //arrange
            var loginPO = new LoginPO(_driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");

            //act
            loginPO.SubmeteFormulario();

            //assert
            Assert.Contains("Dashboard", _driver.Title);
        }

        [Fact]
        public void DadoCrendenciasInvalidasDeveContinuarLogin()
        {
            //arrange
            var loginPO = new LoginPO(_driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "");

            //act
            loginPO.SubmeteFormulario();

            //assert
            Assert.Contains("Login", _driver.PageSource);
        }
    }
}
