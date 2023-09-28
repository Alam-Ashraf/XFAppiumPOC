using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace XFAppiumPOC.Test
{
    //public class TestMainPage<T, W> : AppiumTest<T, W>
    //    where T : AppiumDriver<W>
    //    where W : IWebElement
    //{
    //    public TestMainPage(string testName) : base(testName)
    //    {
    //    }

    //    string platformName = string.Empty;

    //    protected override T GetDriver()
    //    {
    //        // Implemented by platform specific class
    //        throw new NotImplementedException();
    //    }

    //    protected override void InitAppiumOptions(AppiumOptions appiumOptions)
    //    {
    //        platformName = appiumOptions.PlatformName;
    //    }

    //    [SetUp]
    //    public void SetupTest()
    //    {
    //        appiumDriver.CloseApp();
    //        appiumDriver.LaunchApp();
    //    }

    //    [Test]
    //    [Order(1)]
    //    public void TestLogin()
    //    {
    //        //appiumDriver.FindElement(By.XPath("//XCUIElementTypeStaticText[@name=\"Select Device Type\"]")).Click();
    //        //appiumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    //        //appiumDriver.FindElement(By.XPath("//XCUIElementTypeStaticText[@name=\"Select Device Type\"]")).SendKeys("RPOC");


    //        // Find RadComboBox element by id
    //        //var radComboBox = appiumDriver.FindElementById("DeviceTypeRadCombo");

    //        // Tap on RadComboBox to open the dropdown list
    //        //radComboBox.Click();

    //        // Get all the options from the dropdown list
    //        //var optionsList = appiumDriver.FindElements(By.ClassName("XCUIElementTypeCell"));

    //        // Select the first option from the dropdown list
    //        //optionsList[1].Click();

    //        //appiumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


    //        List<string> values = new List<string>()
    //        {
    //            "RPOC",
    //            "EDGE I",
    //        };



    //        //ios
    //        //string selectedValue = GetSelectedValueFromDropDown(values,1,true);

    //        // Android
    //        //var radComboBox = appiumDriver.FindElementByAccessibilityId("DeviceTypeRadCombo");
    //        var radComboBox = appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"DeviceTypeRadCombo\"]");
    //        radComboBox.Click();

    //        Thread.Sleep(3000);

    //        //// Wait for the dropdown to open
    //        //WebDriverWait wait = new WebDriverWait(appiumDriver, TimeSpan.FromSeconds(5));
    //        //wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("android.widget.ListView")));

    //        int xamarinFormsControlHeight = 200;
    //        int totalItemInDropDown = 51;
    //        int targetIndex = 2;
    //        int maxVisibleItems = 4;
    //        int screenHeight = ConvertFormsUnitsToPixels(xamarinFormsControlHeight);


    //        SelectItemFromDropDownInAndroid(totalItemInDropDown,targetIndex, maxVisibleItems, screenHeight, radComboBox);


    //        //appiumDriver.FindElement(By.Id("UserName")).SendKeys("user@email.com");
    //        //Thread.Sleep(2000);
    //        //appiumDriver.FindElement(By.Id("UserPassword")).SendKeys("123456");
    //        //Thread.Sleep(2000);

    //    }

    //    private void SelectItemFromDropDownInAndroid(int totalItemInDropDown, int targetIndex, int maxVisibleItems, int screenHeight, W radComboBox)
    //    {
    //        // Get the location and size of the element
    //        Point location = radComboBox.Location;
    //        Size size = radComboBox.Size;

    //        // Calculate start and end coordinates
    //        int startX = location.X;
    //        int startY = location.Y;
    //        int endX = location.X + size.Width;
    //        int endY = location.Y + size.Height;

    //        Console.WriteLine($"ComboBox Start Coordinates: X = {startX}, Y = {startY}");
    //        Console.WriteLine($"ComboBox End Coordinates: X = {endX}, Y = {endY}");

    //        int screenLastXCoordinates = appiumDriver.Manage().Window.Size.Width;
    //        int screenLastYCoordinates = appiumDriver.Manage().Window.Size.Height;

    //        Console.WriteLine($"Screen Last Coordinates: X = {screenLastXCoordinates}, Y = {screenLastYCoordinates}");

    //        bool isDropDownOpenInBottom = (endY + screenHeight) < screenLastYCoordinates;

    //        Console.WriteLine($"Drop Down open in bottom = '{isDropDownOpenInBottom}'");

    //        // Calculate how many times you need to scroll to reach the target item & Item to click position
    //        (int scrollsRequired, int itemIndexInVisibleItems) = CalculateNoOfScrollAndClickPosition(totalItemInDropDown,maxVisibleItems,targetIndex);

    //        Console.WriteLine($"Total Scrolls Required = {scrollsRequired}, Item Position = {itemIndexInVisibleItems}");

    //        // Implement the scrolling action
    //        for (int scroll = 0; scroll < scrollsRequired; scroll++)
    //        {
    //            ScrollDown(isDropDownOpenInBottom,scroll, screenHeight, radComboBox); // Your implementation of a scroll action
    //                                                   // Consider adding a small delay to allow the UI to stabilize
    //        }

    //        // Logic to select specific item in visible list
    //        int eachItemHeight = screenHeight / maxVisibleItems;
    //        int widthOfDropDown = size.Width;
    //        int dropDownBoxStartAtYCoordinates = (isDropDownOpenInBottom) ? endY : (startY - screenHeight);
    //        int selectedItemStartY = 0;
    //        int selectedItemEndY = 0;

    //        for(int i=0; i< maxVisibleItems; i++)
    //        {
    //            if(i==0)
    //            {
    //                selectedItemStartY = dropDownBoxStartAtYCoordinates;
    //                selectedItemEndY = selectedItemStartY + eachItemHeight;
    //            }
    //            else
    //            {
    //                selectedItemStartY = selectedItemStartY + eachItemHeight;
    //                selectedItemEndY = selectedItemStartY + eachItemHeight;
    //            }

    //            Console.WriteLine($"Index {i} = selectedItemStartY = {selectedItemStartY}, selectedItemEndY = {selectedItemEndY}");

    //            if (itemIndexInVisibleItems == i)
    //                break;
    //        }

    //        // Simulate a tap using the calculated coordinates
    //        TouchAction tapAction = new TouchAction(appiumDriver);
    //        int xCoordinate = widthOfDropDown/2;
    //        int yCoordinate = ((selectedItemEndY - selectedItemStartY)/2) + selectedItemStartY;
    //        Console.WriteLine($"X = {xCoordinate}  Y = {yCoordinate}");
    //        tapAction.Press(xCoordinate, yCoordinate).Release().Perform();

    //        var selectedItem = appiumDriver.FindElementByXPath("//android.view.ViewGroup[@content-desc=\"DeviceTypeRadCombo\"]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.TextView");
    //        Console.WriteLine("Selected Item : " + selectedItem.Text);
    //    }

    //    private int ConvertFormsUnitsToPixels(float xamarinControlHeightDius)
    //    {
    //        // Device density (DPI)
    //        double density = TestMainPage_Droid.GetScreenDensity(); //240; // adjust this value based on the actual device's DPI

    //        // Convert DIUs to pixels
    //        double pixelHeight = xamarinControlHeightDius * (density / 160);

    //        Console.WriteLine($"Density : {density}  Screen Height : {pixelHeight}");

    //        return (int)pixelHeight;
    //    }

    //    private (int, int) CalculateNoOfScrollAndClickPosition(int totalItems, int itemsPerPage, int targetIndex)
    //    {
    //        // Calculate the total number of screens/pages
    //        //int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

    //        // Calculate the current screen/page where the target index is located
    //        int targetPage = (targetIndex / itemsPerPage) + 1;

    //        // Calculate the index of the item within the current screen/page
    //        int itemIndex = targetIndex % itemsPerPage;

    //        // Calculate the number of scrolls required to reach the target page
    //        int scrollsRequired = targetPage - 1;

    //        return (scrollsRequired, itemIndex);
    //    }

    //    private void ScrollDown(bool isDropDownOpenInBottom, int scrollPosition, int height, W radComboBox)
    //    {
    //        Console.WriteLine($"Scroll Position = {scrollPosition}");

    //        // Get the location and size of the element
    //        Point location = radComboBox.Location;
    //        Size size = radComboBox.Size;

    //        // Calculate start and end coordinates
    //        int radComboBoxEndY = location.Y + size.Height;

    //        int startX = size.Width/2;
    //        int startY = (isDropDownOpenInBottom) ? radComboBoxEndY + height : (location.Y - ConvertFormsUnitsToPixels(7.3f));
    //        int endY = (isDropDownOpenInBottom) ? (int)(radComboBoxEndY + ConvertFormsUnitsToPixels(7.3f))
    //                                            : (int) (location.Y - height); 

    //        Console.WriteLine($"Scroll Start at X = {startX} Y = {startY}  End at X = {startX} Y = {endY}");

    //        // Perform the swipe gesture
    //        new TouchAction(appiumDriver)
    //            .Press(startX, startY)
    //            .MoveTo(startX, endY)
    //            .Release()
    //            .Perform();

    //        Thread.Sleep(3000);
    //    }




       

    //    //[Test]
    //    //[Order(1)]
    //    //public void TestLogin()
    //    //{
    //    //    appiumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

    //    //    appiumDriver.FindElement(By.Id("UserName")).SendKeys("user@email.com");
    //    //    appiumDriver.FindElement(By.Id("UserPassword")).SendKeys("123456");

    //    //    appiumDriver.FindElement(By.Id("LoginButton")).Click();

    //    //    //appiumDriver.FindElement(By.Id("PickerItems")).Click();
    //    //    //appiumDriver.FindElement(By.ClassName("XCUIElementTypePickerWheel")).SendKeys("Howler Monkey");

    //    //    var text = GetElementText("StatusLabel"); 

    //    //    Assert.IsNotNull(text);
    //    //    Assert.IsTrue(text.StartsWith("Logging in", StringComparison.CurrentCulture));

    //    //}

    //    //[Test]
    //    //[TestCase(10, 8, 18)]
    //    //[TestCase(45, 45, 90)]
    //    //[Order(2)]
    //    //public void TestAddFunctionality(int a, int b, int res)
    //    //{
    //    //    appiumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

    //    //    appiumDriver.FindElement(By.Id("Num1")).SendKeys(a.ToString());
    //    //    appiumDriver.FindElement(By.Id("Num2")).SendKeys(b.ToString());

    //    //    appiumDriver.FindElement(By.Id("Addition")).Click();
    //    //    var text = GetElementText("ResultText");

    //    //    Assert.IsNotNull(text);
    //    //    Assert.IsTrue(text.Equals(res.ToString()));

    //    //    ClearFields();
    //    //}

    //    //[Test]
    //    //[TestCase(10, 8, 80)]
    //    //[TestCase(11, 5, 55)]
    //    //[Order(3)]
    //    //public void TestMultiplyFunctionality(int a, int b, int res)
    //    //{
    //    //    appiumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 

    //    //    appiumDriver.FindElement(By.Id("Num1")).SendKeys(a.ToString());
    //    //    appiumDriver.FindElement(By.Id("Num2")).SendKeys(b.ToString());

    //    //    appiumDriver.FindElement(By.Id("Multiplication")).Click();
    //    //    var text = GetElementText("ResultText");

    //    //    Assert.IsNotNull(text);
    //    //    Assert.IsTrue(text.Equals(res.ToString()));

    //    //    ClearFields();
    //    //}

    //    //private void ClearFields()
    //    //{
    //    //    appiumDriver.FindElement(By.Id("Num1")).Clear();
    //    //    appiumDriver.FindElement(By.Id("Num2")).Clear();
    //    //}














    //    //[Test]
    //    //public void TestAddItem()
    //    //{
    //    //    appiumDriver.FindElement(By.Id("Browse")).Click();
    //    //    appiumDriver.FindElement(By.Id("AddToolbarItem")).Click();
    //    //    var itemNameField = appiumDriver.FindElement(By.Id("ItemNameEntry"));
    //    //    itemNameField.SendKeys("todo");

    //    //    var itemDesriptionField = appiumDriver.FindElement(By.Id("ItemDescriptionEntry"));
    //    //    itemDesriptionField.SendKeys("todo description");

    //    //    appiumDriver.FindElement(By.Id("SaveToolbarItem")).Click();
    //    //}

    //    //[Test]
    //    //public void TestAbout()
    //    //{
    //    //    appiumDriver.FindElement(By.Id("About")).Click(); // works for iOS
    //    //}
    //}
}

