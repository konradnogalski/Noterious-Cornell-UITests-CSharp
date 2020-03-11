﻿using Infrastructure.PageObject.PageElements;
using Infrastructure.PageObject;
using OpenQA.Selenium;
using System.Linq;

namespace PageObjects
{

    public class LoginPageObject : PageObject, IHasErrorsPage
    {
        private string _loginPageUrl = "login";
        private string _usernameFieldId = "inputUsername";
        private string _passwordFieldId = "inputPassword";
        private string _loginButtonCssSelector = "button";
        private string _googleLoginButtonCssSelector = "a[href='/auth/google']";
        private string _registerLinkCssSelector = "a[href='/register']";

        public LoginPageObject(IWebDriver driver) : base(driver)
        {
            UserName = new TextField(new WebElement(Driver, By.Id(_usernameFieldId)));
            Password = new TextField(new WebElement(Driver, By.Id(_passwordFieldId)));
            LoginButton = new Button(new WebElement(Driver, By.CssSelector(_loginButtonCssSelector)));
            GoogleLoginButton = new Button(new WebElement(Driver, By.CssSelector(_googleLoginButtonCssSelector)));
            RegisterLink = new Button(new WebElement(Driver, By.CssSelector(_registerLinkCssSelector)));
        }

        public bool HasErrors()
        {
            return Driver.FindElements(By.CssSelector(".is-invalid")).Count > 0;
        }

        public override string RelativeUrl => _loginPageUrl;
        public TextField UserName { get; private set; }
        public TextField Password { get; private set; }
        public Button LoginButton { get; private set; }
        public Button GoogleLoginButton { get; private set; } 
        public Button RegisterLink  { get; private set; }

    }
}