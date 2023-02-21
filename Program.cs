using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

new DriverManager().SetUpDriver(new ChromeConfig());

IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();
driver.Navigate().GoToUrl("https://github.com");

IWebElement searchInput = driver.FindElement(By.CssSelector("[name='q']"));
searchInput.SendKeys("selenium");
searchInput.SendKeys(Keys.Enter);

driver.Quit();