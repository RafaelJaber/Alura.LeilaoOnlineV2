using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.V2.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver _driver;
        private By _logoutLink;

        
        public DashboardInteressadaPO(IWebDriver driver)
        {
            _driver = driver;
            _logoutLink = By.Id("logout");
        }

        public void EfetuarLogout()
        {
            _driver.FindElement(_logoutLink).Click();
        }
    }
}
