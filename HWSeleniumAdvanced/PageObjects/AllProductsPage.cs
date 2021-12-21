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
    class AllProductsPage : AbstractPage
    {
            public AllProductsPage(IWebDriver driver)
            {
                this.driver = driver;
                PageFactory.InitElements(driver, this);
            }
        [FindsBy(How = How.LinkText, Using = "Create new")]
        private IWebElement createNew;

        [FindsBy(How = How.XPath, Using = "//a[contains (text(), 'Bor')]")]
        private IWebElement myProduct;

        [FindsBy(How = How.XPath, Using = "(//a[contains(text(), 'Rem')])[last()]")]
        private IWebElement delete;

            public CreateNewProductPage NewProduct() 
        {
            IAction actions = new Actions(driver)
            .Click(createNew);
            actions.Perform();
            return new CreateNewProductPage(driver);
        }
            
            public CheckProductPage CheckProduct() 
        {
            IAction actions = new Actions(driver).Click(myProduct);
            actions.Perform();
            return new CheckProductPage(driver);
        }

        public void Delete() 
        {
            IAction actions = new Actions(driver).Click(delete);
            actions.Perform();
            driver.SwitchTo().Alert().Accept();
        }
    }
}
