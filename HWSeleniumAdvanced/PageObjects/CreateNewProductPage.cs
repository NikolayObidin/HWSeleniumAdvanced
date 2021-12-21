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
    class CreateNewProductPage : AbstractPage
    {
        public CreateNewProductPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//input[@id=\"ProductName\"]")]
        private IWebElement productname;

        [FindsBy(How = How.XPath, Using = "//select[@id=\"CategoryId\"]")]
        private IWebElement categoryId;

        [FindsBy(How = How.XPath, Using = "//select[@id=\"SupplierId\"]")]
        private IWebElement supplierId;

        [FindsBy(How = How.XPath, Using = "//input[@id=\"UnitPrice\"]")]
        private IWebElement unitPrice;

        [FindsBy(How = How.XPath, Using = "//input[@id=\"QuantityPerUnit\"]")]
        private IWebElement quantityPerUnit;

        [FindsBy(How = How.XPath, Using = "//input[@id=\"UnitsInStock\"]")]
        private IWebElement unitsInStock;

        [FindsBy(How = How.XPath, Using = "//input[@id=\"UnitsOnOrder\"]")]
        private IWebElement unitsOnOrder;

        [FindsBy(How = How.XPath, Using = "//input[@id=\"ReorderLevel\"]")]
        private IWebElement reorderLevel;

        [FindsBy(How = How.XPath, Using = "//input[@type=\"submit\"]")]
        private IWebElement submitCreate;

        public void CreateProduct() 
        {
            new SelectElement(categoryId).SelectByText("Produce");
            new SelectElement(supplierId).SelectByText("Grandma Kelly's Homestead");

            IAction actions = new Actions(driver)
            .SendKeys(productname, "Borovichok Mushroom")
            .SendKeys(unitPrice, "4")
            .SendKeys(quantityPerUnit, "10 boxes x 20 bags")
            .SendKeys(unitsInStock, "2")
            .SendKeys(unitsOnOrder, "2")
            .SendKeys(reorderLevel, "2")
            .Click(submitCreate);
            actions.Perform();
        }
    }
}
