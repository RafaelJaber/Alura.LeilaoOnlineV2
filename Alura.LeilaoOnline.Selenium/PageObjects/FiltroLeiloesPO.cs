using Alura.LeilaoOnline.Selenium.V2.Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.Selenium.V2.PageObjects
{
    public class FiltroLeiloesPO
    {
        private IWebDriver _driver;
        private By _selectCategorias;
        private By _inputTermo;
        private By _inputAndamento;
        private By _botaoPesquisar;

        public FiltroLeiloesPO(IWebDriver driver)
        {
            _driver = driver;
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
    }
}
