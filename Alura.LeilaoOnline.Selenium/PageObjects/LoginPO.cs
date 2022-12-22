using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.V2.PageObjects
{
    public class LoginPO
    {
        private IWebDriver _driver;
        private By _inputLogin;
        private By _inputSenha;
        private By _botaoLogin;


        public LoginPO(IWebDriver driver)
        {
            _driver = driver;
            _inputLogin = By.Id("Login");
            _inputSenha = By.Id("Password");
            _botaoLogin = By.Id("btnLogin");
        }
        
        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencheFormulario(string login, string senha)
        {
            _driver.FindElement(_inputLogin).SendKeys(login);
            _driver.FindElement(_inputSenha).SendKeys(senha);
        }

        public void SubmeteFormulario()
        {
            _driver.FindElement(_botaoLogin).Submit();
        }
    }
}
