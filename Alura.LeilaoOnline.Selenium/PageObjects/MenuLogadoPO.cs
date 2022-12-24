using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.V2.PageObjects
{
    public class MenuLogadoPO
    {
        private IWebDriver _driver;
        private By _logoutLink;
        private By _meuPerfilLink;

        public MenuLogadoPO(IWebDriver driver)
        {
            _driver = driver;
            _logoutLink = By.Id("logout");
            _meuPerfilLink = By.Id("meu-perfil");
        }
        
        public void EfetuarLogout()
        {
            IWebElement linkPerfil = _driver.FindElement(_meuPerfilLink);
            IWebElement linkLogout = _driver.FindElement(_logoutLink);

            IAction acaoLogout = new Actions(_driver)
                // mover para elemento pai
                .MoveToElement(linkPerfil)
                // mover para logout
                .MoveToElement(linkLogout)
                // clicar
                .Click()
                .Build();
            acaoLogout.Perform();
        }
    }
}
