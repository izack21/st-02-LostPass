// Desenvolvido por: Izack G. Passos Rodrigues - Setembro/2020
// O objetivo do teste é validar o comportamento do sistema ao tentar recuperar uma senha
// Sem informar os dados necessários.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

[TestFixture]
public class Ct01ValidateFieldsTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void ct01ValidateFields() {
    driver.Navigate().GoToUrl("https://mantis-prova.base2.com.br/lost_pwd_page.php");
    driver.Manage().Window.Size = new System.Drawing.Size(1382, 754);
    var UserName = driver.FindElements(By.Name("username"));
    Assert.True(UserName.Count > 0);
    var UserEmail = driver.FindElements(By.Name("email"));
    Assert.True(UserEmail.Count > 0);
    var SubmitButton = driver.FindElements(By.CssSelector(".button"));
    Thread.Sleep(2000);
    Assert.True(SubmitButton.Count > 0);
    driver.FindElement(By.CssSelector(".button")).Click();
    Assert.That(driver.FindElement(By.CssSelector(".form-title")).Text, Is.EqualTo("APPLICATION ERROR #1200"));
    Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(2) .center")).Text, Is.EqualTo("Invalid e-mail address."));

    Thread.Sleep(2000);
    driver.Quit();
    }
}
