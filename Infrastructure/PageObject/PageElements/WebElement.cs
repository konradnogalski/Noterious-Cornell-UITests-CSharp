﻿using System;
using System.Drawing;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Infrastructure.PageObject.PageElements
{
    public class WebElement : IWebElement
    {
        public readonly ISearchContext Parent;
        private readonly By _elementLocator;
        
        private IWebElement _stalableElement;

        public WebElement(ISearchContext parent, By elementLocator)
        {
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
            _elementLocator = elementLocator ?? throw new ArgumentNullException(nameof(elementLocator));
        }

        public IWebElement Element
        {
            get
            {
                try
                {
                    return StalableElement;
                }
                catch (StaleElementReferenceException)
                {
                    return StalableElement;
                }
            }
           
        }

        private IWebElement StalableElement
        {
            get
            {
                if (_stalableElement == null)
                {
                    _stalableElement = Parent.FindElement(_elementLocator);
                }

                return _stalableElement;
            }
        }

        public string TagName => Element.TagName;

        public string Text => Element.Text;

        public bool Enabled => Element.Enabled;

        public bool Selected => Element.Selected;

        public Point Location => Element.Location;

        public Size Size => Element.Size;

        public bool Displayed => Element.Displayed;

        public void Clear()
        {
            Element.Clear();
        }

        public void Click()
        {
            Element.Click();
        }

        public IWebElement FindElement(By by)
        {
            return Element.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Element.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return Element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return Element.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            return Element.GetProperty(propertyName);
        }

        public void SendKeys(string text)
        {
            Element.SendKeys(text);
        }

        public void Submit()
        {
            Element.Submit();
        }
    }
}