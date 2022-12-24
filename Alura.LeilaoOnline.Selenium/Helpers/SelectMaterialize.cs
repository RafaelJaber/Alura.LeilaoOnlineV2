using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.V2.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver _driver;
        private IWebElement _selectWrapper;
        private IEnumerable<IWebElement> _selectList;

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            _driver = driver;
            _selectWrapper = driver.FindElement(locatorSelectWrapper);
            _selectList = _selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        public IEnumerable<IWebElement> Options()
        {
            return _selectList;
        }

        private void OpenWrapper()
        {
            _selectWrapper.Click();
        }

        private void LoseFocus()
        {
            _selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);
        }
        
        public void DeselectAll()
        {
            OpenWrapper();
            _selectList.ToList().ForEach(o =>
            {
                o.Click();
            });
            LoseFocus();
        }

        public void SelectByText(string option)
        {
            OpenWrapper();
            
            _selectList
                .Where(o => o.Text.Contains(option))
                .ToList()
                .ForEach(o =>
                {
                    o.Click();
                });
            LoseFocus();
        }
        
        
    }
}
