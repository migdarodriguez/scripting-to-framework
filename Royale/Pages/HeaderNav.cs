using System;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;
        public HeaderNav(IWebDriver driver)
        {
            Map = new HeaderNavMap(driver);
        }
        public void GotoCardsPage()
        {
            Map.CardsTabLink.Click();
        }
        public IWebElement GetCardByName(string cardName)
        {
            // Given the cardName "Ice Spirit" => should turn into "Ice+Spirit" to work with our locator.
            if (cardName.Contains(" "))
            {
                cardName = cardName.Replace(" ", "+");
            }
            return Map.CardsTabLink;
        }
    }
    public class HeaderNavMap
    {
        IWebDriver _driver;
        public HeaderNavMap(IWebDriver driver) => _driver = driver; 
        public IWebElement CardsTabLink=> _driver.FindElement(By.CssSelector("a[href='/cards']"));    
                    
 //     public IWebElement TagInput=> _driver.FindElement(By.CssSelector("input[contains(@class, 'header__input')]"));

    }    
}