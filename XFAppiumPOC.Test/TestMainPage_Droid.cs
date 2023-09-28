using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace XFAppiumPOC.Test
{
    //[TestFixture]
    //public class TestMainPage_Droid : TestMainPage<AndroidDriver<AndroidElement>, AndroidElement>
    //{
    //    public TestMainPage_Droid() : base("MainPageTests") { }

    //    public static AndroidDriver<AndroidElement> driver;

    //    protected override AndroidDriver<AndroidElement> GetDriver()
    //    {
    //        //appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus One - API 33");
    //        //appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 5 - API 33");
    //        return driver = new AndroidDriver<AndroidElement>(driverUri, appiumOptions);
    //    }

    //    protected override void InitAppiumOptions(AppiumOptions appiumOptions)
    //    {
    //        appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel 5 - API 33");
    //        //appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
    //        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
    //        //appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, "/Users/alamgeer/Projects/XFAppiumPOC/XFAppiumPOC/XFAppiumPOC.Android/bin/Debug/com.companyname.xfappiumpoc-Signed.apk");

    //        appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.companyname.xfappiumpoc");
    //        appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "crc64b3c3ba7c0800c31c.MainActivity");
    //        appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "uiAutomator2");
    //    }

    //    public static int GetScreenDensity()
    //    {
    //        return (int) driver.GetDisplayDensity();
    //    }

    //    public static double GetDeviceDpi()
    //    {
    //        var densityCapability = driver.Capabilities.GetCapability("pixelDensity");
    //        if (densityCapability != null && double.TryParse(densityCapability.ToString(), out double dpi))
    //        {
    //            return dpi;
    //        }
    //        else
    //        {
    //            // Provide a default DPI value if the pixelDensity capability is not available
    //            return 160; // You might need to adjust this based on your device's actual DPI
    //        }
    //    }
    //}
}

