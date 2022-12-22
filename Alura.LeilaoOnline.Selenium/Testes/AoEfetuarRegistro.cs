using Alura.LeilaoOnline.Selenium.V2.Fixtures;
using Alura.LeilaoOnline.Selenium.V2.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.V2.Testes
{
    [Collection("Edge Driver")]
    public class AoEfetuarRegistro
    {
        // Setup
        private readonly IWebDriver _driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasIrParaPaginaAgradecimento()
        {
            // Arrange
            _driver.Navigate().GoToUrl("http://localhost:5000");

            IWebElement inputNome = _driver.FindElement(By.Id("Nome"));
            IWebElement inputEmail = _driver.FindElement(By.Id("Email"));
            IWebElement inputPass = _driver.FindElement(By.Id("Password"));
            IWebElement inputPassC = _driver.FindElement(By.Id("ConfirmPassword"));

            inputNome.SendKeys("Rafael Jáber");
            inputEmail.SendKeys("rafael@rafael.com");
            inputPass.SendKeys("123123");
            inputPassC.SendKeys("123123");
            
            // Act
            _driver.FindElement(By.Id("btnRegistro")).Click();
            
            // Assert
            Assert.Contains("Obrigado por se registrar!", _driver.PageSource);
        }

        [Theory]
        [InlineData("","","","")]
        [InlineData("null","","","")]
        [InlineData("","null@email","","")]
        [InlineData("","","null","")]
        [InlineData("","","","null")]
        [InlineData("Rafael","rafael","123123","123123")]
        [InlineData("Rafael","rafael@rafael.com","123123","321321")]
        public void DadoInfoInalidasDeveContinuarNaHome(string nome, string email, string pass, string passC)
        {
            // Arrange
            RegistroPO po = new RegistroPO(_driver);
            po.Visitar("");

            po.PreencherFormulario(nome, email, pass, passC);
            
            // Act
            po.SubmeteFormulario();
            
            // Assert
            Assert.Contains("Registre-se para participar dos leilões!", _driver.PageSource);
        }

        [Fact]
        public void DadoEmBrancoDeveMostrarMensagemDeErroNome()
        {
            // Arrange
            _driver.Navigate().GoToUrl("http://localhost:5000");
            
            // Act
            _driver.FindElement(By.Id("btnRegistro")).Click();
            
            // Assert
            IWebElement errorMessage = _driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Equal("The Nome field is required.", errorMessage.Text);
        }
        
        [Fact(Skip = "Teste não está funcionando muito bem, precisa ser refatorado")]
        public void DadoEmBrancoDeveMostrarMensagemDeErroEmail()
        {
            // Arrange
            _driver.Navigate().GoToUrl("http://localhost:5000");
            
            // Act
            _driver.FindElement(By.Id("btnRegistro")).Click();
            
            // Assert
            IWebElement errorMessage = _driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email]"));
            Assert.Equal("The Endereço de Email field is required.", errorMessage.Text);
        }
    }
}
