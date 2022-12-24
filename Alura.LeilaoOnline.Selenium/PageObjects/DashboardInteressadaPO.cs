using Alura.LeilaoOnline.Selenium.V2.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            _inputTermo = By.Id("termo");
            _inputAndamento = By.ClassName("lever");
            _botaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(
            List<string> categorias,
            string termo,
            bool emAndamento
            )
        {
            var select = new SelectMaterialize(_driver, _selectCategorias);
            select.DeselectAll();
            categorias.ForEach(categ =>
            {
                select.SelectByText(categ);
            });
            _driver.FindElement(_inputTermo).SendKeys(termo);
            if(emAndamento) _driver.FindElement(_inputAndamento).Click();
            _driver.FindElement(_botaoPesquisar).Click();

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
