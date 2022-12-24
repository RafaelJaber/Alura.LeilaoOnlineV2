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
        
        public LoginPO Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
            return this;
        }

        public LoginPO PreencheFormulario(string login, string senha)
        {
            return 
                InformarEmail(login)
                .InformarSenha(senha);
        }

        public LoginPO SubmeteFormulario()
        {
            _driver.FindElement(_botaoLogin).Submit();
            return this;
        }

        public LoginPO InformarEmail(string email)
        {
            _driver.FindElement(_inputLogin).SendKeys(email);
            return this;
        }

        public LoginPO InformarSenha(string senha)
        {
            _driver.FindElement(_inputSenha).SendKeys(senha);
            return this;
        }
        
        public void EfetuarLoginComCredenciais(string login, string senha)
        {
            Visitar()
                .PreencheFormulario(login, senha)
                .SubmeteFormulario();
        }
    }
}
