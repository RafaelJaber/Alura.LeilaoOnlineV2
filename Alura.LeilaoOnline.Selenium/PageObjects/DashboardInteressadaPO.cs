using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.V2.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver _driver;
        private By _logoutLink;
        private By _meuPerfilLink;
        private By _selectCategorias;
        private By _inputTermo;
        private By _inputAndamento;
        private By _botaoPesquisar;
        

        
        public DashboardInteressadaPO(IWebDriver driver)
        {
            _driver = driver;
            _logoutLink = By.Id("logout");
            _meuPerfilLink = By.Id("meu-perfil");
            _selectCategorias = By.ClassName("select-wrapper");
        }

        public void PesquisarLeiloes(List<string> categorias)
        {
            IWebElement selectWrapper = _driver.FindElement(_selectCategorias);
            selectWrapper.Click();

            List<IWebElement> opcoes = selectWrapper
                .FindElements(By.CssSelector("li>span"))
                .ToList();
            
            foreach (IWebElement webElement in opcoes)
            {
                webElement.Click();
            }
            
            foreach (string s in categorias)
            {
                opcoes
                    .Where(o => o.Text.Contains(s))
                    .ToList()
                    .ForEach(o =>
                    {
                        o.Click();
                    });
            }
            
            selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);

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
