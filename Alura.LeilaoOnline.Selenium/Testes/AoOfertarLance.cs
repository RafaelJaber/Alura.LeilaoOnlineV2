using Alura.LeilaoOnline.Selenium.V2.Fixtures;
using Alura.LeilaoOnline.Selenium.V2.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.V2.Testes
{
    [Collection("Edge Driver")]
    public class AoOfertarLance
    {
        // Setup
        private readonly IWebDriver _driver;

        public AoOfertarLance(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDevePermitirDarLance()
        {
            // Arrange
            LoginPO loginPo = new LoginPO(_driver);
            loginPo.EfetuarLoginComCredenciais("fulano@example.org", "123");

            DetalheLeilaoPO detalheLeilaoPo = new DetalheLeilaoPO(_driver);
            detalheLeilaoPo.Visitar(1);
            
            // Act
            detalheLeilaoPo.OfertarLance(300);
            
            // Assert
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            bool iguais =  wait.Until(drv => detalheLeilaoPo.LanceAtual == 300);

            Assert.True(iguais);
        }
    }
}
