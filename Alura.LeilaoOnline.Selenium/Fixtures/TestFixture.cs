using Alura.LeilaoOnline.Selenium.V2.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;

namespace Alura.LeilaoOnline.Selenium.V2.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        // Setup
        public TestFixture()
        {
            Driver = new EdgeDriver(TestHelper.ExecutableFolder);
        }
        
        // TearDown
        public void Dispose()
        {
            Driver?.Quit();
        }
    }
}
