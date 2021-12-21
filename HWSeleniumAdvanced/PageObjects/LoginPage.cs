using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace HWSeleniumAdvanced.PageObjects
{
    class LoginPage : AbstractPage
    {
        public LoginPage(IWebDriver driver) 
        {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement login;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//input[@type=\"submit\"]")]
        private IWebElement submitLogin;

        public void Login(string log, string pass) 
        {
            IAction actions = new Actions(driver)
            .Click(login)
            .SendKeys(log)
            .Click(password)
            .SendKeys(pass)
            .Click(submitLogin)
            .Build();

            actions.Perform();
        }
    }
}
