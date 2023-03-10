using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;

new DriverManager().SetUpDriver(new ChromeConfig());

IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();
driver.Navigate().GoToUrl("https://github.com");

string searchPhrase = "selenium";

IWebElement searchInput = driver.FindElement(By.CssSelector("[name='q']"));
searchInput.SendKeys("selenium");
searchInput.SendKeys(Keys.Enter);

IList<string> actualItems = driver.FindElements(By.CssSelector(".repo-list-item"))
    .Select(item => item.Text.ToLower())
    .ToList();
IList<string> expectedItems = actualItems
    .Where(item => item.Contains(searchPhrase))
    .ToList();

Assert.AreEqual(expectedItems, actualItems);

//Assert.True(actualItems.All(item => item.ToLower().Contains("invalid search phrase")));

driver.Quit();