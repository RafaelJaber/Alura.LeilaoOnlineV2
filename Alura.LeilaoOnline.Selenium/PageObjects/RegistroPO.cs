using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.V2.PageObjects
{
    public class RegistroPO
    {
        private IWebDriver _driver;
        private By _formRegistro;
        private By _inputNome;
        private By _inputEmail;
        private By _inputSenha;
        private By _inputSenhaC;
        private By _botaoRegistro;

        public RegistroPO(IWebDriver driver)
        {
            _driver = driver;
            _formRegistro = By.TagName("form");
            _inputNome = By.Id("Nome");
            _inputEmail = By.Id("Email");
            _inputSenha = By.Id("Password");
            _inputSenhaC = By.Id("ConfirmPassword");
            _botaoRegistro = By.Id("btnRegistro");
        }

        public void Visitar(string path)
        {
            string url = $"http://localhost:5000/{path}";
            _driver.Navigate().GoToUrl(url);
        }

        public void SubmeteFormulario()
        {
            _driver.FindElement(_botaoRegistro).Click();
        }

        public void PreencherFormulario(string nome, string email, string senha, string senhaC)
        {
            _driver.FindElement(_inputNome).SendKeys(nome);
            _driver.FindElement(_inputEmail).SendKeys(email);
            _driver.FindElement(_inputSenha).SendKeys(senha);
            _driver.FindElement(_inputSenhaC).SendKeys(senhaC);
        }
    }
}
