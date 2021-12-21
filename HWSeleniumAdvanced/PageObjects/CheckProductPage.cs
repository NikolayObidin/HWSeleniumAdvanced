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
    class CheckProductPage : AbstractPage
    {
        public CheckProductPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//input[@id=\"ProductName\"]")]
        private IWebElement productname;

        [FindsBy(How = How.XPath, Using = "//select[@id=\"CategoryId\"]/option[@value=\"7\"]")]
        private IWebElement categoryId;

        [FindsBy(How = How.XPath, Using = "//select[@id=\"SupplierId\"]/option[@value=\"3\"]")]
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

        public void CheckProduct()
        {
            Assert.AreEqual(productname.GetAttribute("value"), "Borovichok Mushroom");
            Assert.AreEqual(categoryId.Text, "Produce");
            Assert.AreEqual(supplierId.Text, "Grandma Kelly's Homestead");
            Assert.AreEqual(unitPrice.GetAttribute("value"), "4,0000");
            Assert.AreEqual(quantityPerUnit.GetAttribute("value"), "10 boxes x 20 bags");
            Assert.AreEqual(unitsInStock.GetAttribute("value"), "2");
            Assert.AreEqual(unitsOnOrder.GetAttribute("value"), "2");
            Assert.AreEqual(reorderLevel.GetAttribute("value"), "2");
        }
    }
}
