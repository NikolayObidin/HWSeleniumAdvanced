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
using HWSeleniumAdvanced.PageObjects;

namespace HWSeleniumAdvanced
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://localhost:5000";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("user", "user");
        }

        [Test]
        public void NewProduct()
        {
            HomePage homePage = new HomePage(driver);
            AllProductsPage allProducts = homePage.AllProducts();
            CreateNewProductPage createNewProduct = allProducts.NewProduct();
            createNewProduct.CreateProduct();

        }

        [Test]
        public void CheckProduct()
        {
            HomePage homePage = new HomePage(driver);
            AllProductsPage allProducts = homePage.AllProducts();
            CheckProductPage checkNewProduct = allProducts.CheckProduct();
            checkNewProduct.CheckProduct();

        }

        [Test]
        public void DeleteProduct()
        {
            HomePage homePage = new HomePage(driver);
            AllProductsPage allProducts = homePage.AllProducts();
            CheckProductPage checkNewProduct = allProducts.CheckProduct();
            checkNewProduct.CheckProduct();
        }

            [TearDown]
        public void TearDown()
        {
            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            driver.Quit();
        }
    }
}