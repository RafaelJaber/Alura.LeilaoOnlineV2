using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.V2.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver _driver;
        private By _inputTitulo;
        private By _inputDescricao;
        private By _inputCategoria;
        private By _inputCategoriaItemColec;
        private By _inputValorInicial;
        private By _inputImagem;
        private By _inputInicioPregao;
        private By _inputTerminoPregao;
        private By _buttonSalvar;

        public NovoLeilaoPO(IWebDriver driver)
        {
            _driver = driver;

            _inputTitulo = By.Id("Titulo");
            _inputDescricao = By.Id("Descricao");
            _inputCategoria = By.Id("Categoria");
            _inputCategoriaItemColec = By.XPath("//*[contains(@class,'dropdown-content select-dropdown')]/li[2]/span");
            _inputValorInicial = By.Id("ValorInicial");
            _inputImagem = By.Id("ArquivoImagem");
            _inputInicioPregao = By.Id("InicioPregao");
            _inputTerminoPregao = By.Id("TerminoPregao");
            _buttonSalvar = By.CssSelector("Button[type=submit]");

        }

        public IEnumerable<string> Categorias
        {
            get
            {
                IWebElement elementoCategoria =  _driver.FindElement(By.ClassName("select-wrapper"));
                return elementoCategoria.FindElements(By.TagName("li"))
                    .Select(o => o.Text);
                // Não foi possivel usar o select ui mas como exemplo fica ai 
                // SelectElement elementoCategoria = new SelectElement(_driver.FindElement(_inputCategoria));
                // return elementoCategoria.Options
                //     .Where(o => o.Enabled)
                //     .Select(o => o.Text);
            }
        }

        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormulario(
            string titulo,
            string descricao,
            string categoria,
            double valor,
            string imagem,
            DateTime inicio,
            DateTime fim
        )
        {
            _driver.FindElement(_inputTitulo).SendKeys(titulo);
            _driver.FindElement(_inputDescricao).SendKeys(descricao);
            _driver.FindElement(By.ClassName("select-wrapper")).Click();
            Thread.Sleep(500);
            _driver.FindElement(_inputCategoriaItemColec).Click();
            Thread.Sleep(500);
            //_driver.FindElement(_inputCategoria).SendKeys(categoria);
            _driver.FindElement(_inputValorInicial).SendKeys(valor.ToString());
            _driver.FindElement(_inputImagem).SendKeys(imagem);
            _driver.FindElement(_inputInicioPregao).SendKeys(inicio.ToString("dd/MM/yyyy"));
            _driver.FindElement(_inputTerminoPregao).SendKeys(fim.ToString("dd/MM/yyyy"));
        }

        public void SubmeteFormulario()
        {
            _driver.FindElement(_buttonSalvar).Click();
        }
    }
}
