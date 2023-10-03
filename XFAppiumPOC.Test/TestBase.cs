using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using static System.Net.Mime.MediaTypeNames;

namespace XFAppiumPOC.Test
{
    //[TestFixture]
    public class BaseTest
    {
        protected AppiumDriver<AppiumWebElement> driver;
        private Uri driverUri = new Uri("http://127.0.0.1:4723/wd/hub");
        public Plateform Plateform;

        public BaseTest()
        {
            GetPlateforms();
        }

        private void GetPlateforms()
        {
            string? plateform = Environment.GetEnvironmentVariable("PLATFORM");

            Console.WriteLine($"PLATFORM = {plateform}");

            string? commandLineArg = Environment.GetCommandLineArgs().FirstOrDefault();

            if (!string.IsNullOrEmpty(plateform))
            {
                plateform = commandLineArg;
            }
            else
            {
                plateform = "android";
            }

            if (plateform.ToLower().Equals("android"))
            {
                Plateform = Plateform.Android;
                StartAndroidDriver();
            }
            else if (plateform.ToLower().Equals("ios"))
            {
                Plateform = Plateform.iOS;
                StartiOSDriver();
            }
            else if (plateform.ToLower().Equals("both"))
            {
                Plateform = Plateform.Both;
                StartAndroidDriver();
            }
        }

        public void GetEnvironmentVariable()
        {
            var platform = Environment.GetEnvironmentVariables();

            foreach(var p in platform)
            {
                Console.WriteLine($"Environment Variables  = {p}");
            }
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            driver.LaunchApp();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown() method called");

            //Thread.Sleep(2000);

            //driver.Quit();
        }

        private void RuniOS()
        {
            if (Plateform == Plateform.Both)
            {
                StartiOSDriver();
                Plateform = Plateform.None;
                SetUp();
            }
        }

        private void StartAndroidDriver()
        {
            // Set up Android driver
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android 13 - API 33");
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, "/Users/alamgeer/Projects/XFAppiumPOC/XFAppiumPOC/XFAppiumPOC.Android/bin/Debug/com.companyname.xfappiumpoc-Signed.apk");

            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.companyname.xfappiumpoc");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "crc64b3c3ba7c0800c31c.MainActivity");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "uiAutomator2");

            driver = new AndroidDriver<AppiumWebElement>(driverUri, appiumOptions);

            Console.WriteLine("----------------- Android Driver Set");
        }


        private void StartiOSDriver()
        {
            // Set up iOS driver
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "iPhone 14 Pro Max");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "16.4");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "CD1606B3-6829-45AD-9DB8-848E55D08161");
            appiumOptions.AddAdditionalCapability(IOSMobileCapabilityType.BundleId, "com.companyname.XFAppiumPOC");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");

            driver = new IOSDriver<AppiumWebElement>(driverUri, appiumOptions);

            Console.WriteLine("----------------- iOS Driver Set");
        }



        //private bool IsAndroidPlatform()
        //{
        //    return Environment.GetCommandLineArgs().Any(arg => arg.Equals("--android"));
        //}

        //private bool IsiOSPlatform()
        //{
        //    return Environment.GetCommandLineArgs().Any(arg => arg.Equals("--ios"));
        //}

        public string GetElementText(string elementId)
        {
            var element = driver.FindElement(By.Id(elementId));
            var attributName = (Plateform == Plateform.Android) ? "text" : "value";
            return element.GetAttribute(attributName);
        }

    }


    public enum Plateform
    {
        Android,
        iOS,
        Both,
        None
    }
}

