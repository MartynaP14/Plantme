using OpenQA.Selenium.Chrome;
using Xunit;

namespace PlantMe_Tests
{
    public class SeleniumTest
    {
        [Fact]
        public void Test1()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://plantme02.azurewebsites.net/");

            driver.Quit();

        }
    }
}