using Alura.LeilaoOnline.Selenium.V2.Helpers;
using Alura.LeilaoOnline.Selenium.V2.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.V2.Testes
{
    [Collection("Edge Driver")]
    public class AoNavegarParaHome
    {
        // Setup
        private readonly IWebDriver _driver;
        
        public AoNavegarParaHome(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoEdgeAbertoDeveMostrarLeiloesNoTitulo()
        {
            // Arrange
            // Act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            Assert.Contains("Leilões", _driver.Title);
        }
        
        [Fact]
        public void DadoEdgeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            // Arrange
            // Act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
        
        [Fact]
        public void DadoEdgeAbertoFormRegistroNaoDeveMostrarMensagensDeErro()
        {
            // Arrange
            _driver.Navigate().GoToUrl("http://localhost:5000");

            // Act
            IWebElement form = _driver.FindElement(By.TagName("form"));
            ReadOnlyCollection<IWebElement> spans = form.FindElements(By.TagName("span"));

            // Assert

            foreach (IWebElement span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }


    }
}
