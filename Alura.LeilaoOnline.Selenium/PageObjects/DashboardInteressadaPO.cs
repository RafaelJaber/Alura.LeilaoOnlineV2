using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.V2.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver _driver;


        public FiltroLeiloesPO Filtro { get; }
        public MenuLogadoPO Menu { get; }

        public DashboardInteressadaPO(IWebDriver driver)
        {
            _driver = driver;

            Filtro = new FiltroLeiloesPO(_driver);
            Menu = new MenuLogadoPO(_driver);
        }


    }
}
