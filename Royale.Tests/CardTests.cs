using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;

namespace Tests
{
    public class CardTests
    {
        IWebDriver driver;
        
        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
            driver.Url = "https://statsroyale.com";
        }

        [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {
            var cardsPage= new CardsPage(driver);
            var iceSpirit= cardsPage.Goto().GetCardByName("Ice Spirit");
            Assert.That(iceSpirit.Displayed);
        }     
/*
        public void Ice_Spirit_is_on_Cards_Page_old()
        {
            // 1. go to statsroyale.com
            driver.Url = "https://statsroyale.com";
            // 2. click Cards link in header nav
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            // 3. Assert ice spirit is displayed
            //var iceSpirit = driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
            var cardsPage = new CardsPage(driver);
            var iceSpirit = cardsPage.Goto().GetCardByName("Ice Spirit");
            Assert.That(iceSpirit.Displayed);          
        }
        */
      [Test]
      public void Ice_Spirit_headers_are_correct_on_Details_Page()
        {
            // 1. go to statsroyale.com            //driver.Url = "https://statsroyale.com";
            // 2. click Cards link in header nav  //driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            // 3. go to ice spirit             //driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']")).Click();
            // 4. Assert basic header stats

            new CardsPage(driver).Goto().GetCardByName("Ice Spirit").Click();
            var cardDetails = new CardDetailsPage(driver);
            var (category, arena)= cardDetails.GetCardCategory();
            var cardName =cardDetails.Map.CardName.Text;
            var (rarity, common)= cardDetails.GetCardCommon();
            //var cardRarity = cardDetails.Map.CardRarity.Text;

            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", category);
            Assert.AreEqual("Arena 8", arena);
            Assert.AreEqual("Common", common);            
            
        }       

        public void Mirror_headers_are_correct_on_Card_Details_Page()
        {
            new CardsPage(driver).Goto().GetCardByName("Mirror").Click();
            var cardDetails = new CardDetailsPage(driver);

            var (category, arena)= cardDetails.GetCardCategory();            
            var cardName =cardDetails.Map.CardName.Text;
            var (rarity, common)= cardDetails.GetCardCommon();

            Assert.AreEqual("Mirror", cardName);
            Assert.AreEqual("Spell", category);
            Assert.AreEqual("Arena 12", arena);
            Assert.AreEqual("Epic", common);            
            
        }   
    }
}