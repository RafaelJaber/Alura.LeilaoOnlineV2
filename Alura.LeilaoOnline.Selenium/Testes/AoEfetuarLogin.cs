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
            new LoginPO(_driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                .SubmeteFormulario();

            //assert
            Assert.Contains("Dashboard", _driver.Title);
        }

        [Fact]
        public void DadoCrendenciasInvalidasDeveContinuarLogin()
        {
            LoginPO loginPo = new LoginPO(_driver);
            loginPo.EfetuarLoginComCredenciais("fulano@example.org", "1223");

            //assert
            Assert.Contains("Login", _driver.PageSource);
        }
    }
}
