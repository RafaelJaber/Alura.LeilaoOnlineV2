using OpenQA.Selenium;
using System.Globalization;

namespace Alura.LeilaoOnline.Selenium.V2.PageObjects
{
    public class DetalheLeilaoPO
    {
        private IWebDriver _driver;
        private By _inputValor;
        private By _botaoOfertar;
        private By _h5Lance;

        public DetalheLeilaoPO(IWebDriver driver)
        {
            _driver = driver;
            _inputValor = By.Id("Valor");
            _botaoOfertar = By.Id("btnDarLance");
            _h5Lance = By.Id("lanceAtual");
        }

        public double LanceAtual
        {
            get
            {
                string valorTexto = _driver.FindElement(_h5Lance).Text;
                double valor = double.Parse(valorTexto, System.Globalization.NumberStyles.Currency);
                return valor;
            }
        }

        public void Visitar(int idLeilao)
        {
            _driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/{idLeilao.ToString()}");
            
        }

        public void OfertarLance(double valor)
        {
            _driver.FindElement(_inputValor).Clear();
            _driver.FindElement(_inputValor).SendKeys(valor.ToString("F2", CultureInfo.InvariantCulture));;
            _driver.FindElement(_botaoOfertar).Click();
        }
    }
}
