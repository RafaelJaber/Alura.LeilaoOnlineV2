using Alura.LeilaoOnline.Selenium.V2.Fixtures;
using Alura.LeilaoOnline.Selenium.V2.PageObjects;
using OpenQA.Selenium;
using System;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.V2.Testes
{
    [Collection("Edge Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver _driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdmEInfoValidaCadastrarLeilao()
        {
            // Arrange
            LoginPO loginPo = new LoginPO(_driver);
            loginPo.EfetuarLoginComCredenciais("admin@example.org", "123");

            NovoLeilaoPO novoLeilaoPo = new NovoLeilaoPO(_driver);
            novoLeilaoPo.Visitar();
            novoLeilaoPo.PreencheFormulario(
                "Leilão de Coleção 1",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                "Item de Colecionador",
                4000,
                "C:\\Users\\rafae\\OneDrive\\Imagens\\img.jpg",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40)
                );

            // Act
            novoLeilaoPo.SubmeteFormulario();


            // Assert
            Assert.Contains("Leilões cadastrados no sistema", _driver.PageSource);
        }
    }
}
