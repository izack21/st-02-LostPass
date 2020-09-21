// Desenvolvido por: Izack G. Passos Rodrigues - Setembro/2020
// O objetivo do teste é validar o comportamento do sistema ao tentar recuperar uma senha
// informando dados corretos.
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
public class Ct03SubmitSuccessTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  public string username = ""; //Variavel de preenchimento obrigatório para o teste.
  public string userEmail = ""; //Variavel de preenchimento obrigatório para o teste.
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
  public void ct03SubmitSuccess() {
    driver.Navigate().GoToUrl("https://mantis-prova.base2.com.br/lost_pwd_page.php");
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys(username);
    driver.FindElement(By.Name("email")).SendKeys(userEmail);
    driver.FindElement(By.CssSelector(".button")).Click();
    Assert.That(driver.FindElement(By.CssSelector("b")).Text, Is.EqualTo("Password Message Sent"));

        Thread.Sleep(3000);
        driver.Quit();
   }

}
