using System;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using static System.Net.Mime.MediaTypeNames;

namespace XFAppiumPOC.Test
{
    [TestFixture]
    public class BaseTest
    {
        protected AppiumDriver<AppiumWebElement> driver;
        private Uri driverUri = new Uri("http://127.0.0.1:4723/wd/hub");
        public Plateform Plateform;

        public BaseTest()
        {
            Console.WriteLine("BaseTest() constructor called");
        }

        public void GetPlateforms()
        {
            string? plateform = Environment.GetEnvironmentVariable("Platform");

            Console.WriteLine($"Platform = {plateform}");

            if (string.IsNullOrEmpty(plateform))
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
            var environmentVariables = Environment.GetEnvironmentVariables();

            foreach(var key in environmentVariables.Keys)
            {
                var value = environmentVariables[key];
                Console.WriteLine($"{key} = {value}");
            }
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            Console.WriteLine("SetUp() method called");
            GetPlateforms();
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

        public void SendEmail()
        {
            // Email configuration
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 465;
            string smtpUsername = "wft.alamgeer.ashraf@gmail.com";
            string smtpPassword = "nfwo emkh exlx ybtb";
            string senderEmail = "wft.alamgeer.ashraf@gmail.com";
            string recipientEmail = "wft.alamgeer.ashraf@gmail.com";

            // Create an email message
            MailMessage mail = new MailMessage(senderEmail, recipientEmail);
            mail.Subject = "HTML Report";
            mail.Body = "Please find the attached HTML report.";

            // Attach the HTML report file
            string reportFilePath = "/Users/alamgeer/buildAgentFull (1)/work/TestResults/Android-TestResults.html"; // Replace with the actual file path
            Attachment attachment = new Attachment(reportFilePath, MediaTypeNames.Text.Html);
            mail.Attachments.Add(attachment);

            // Create an SMTP client and send the email
            SmtpClient smtpClient = new SmtpClient(smtpServer);
            smtpClient.Port = smtpPort;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true; // Use SSL if your SMTP server supports it

            try
            {
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                mail.Dispose();
                smtpClient.Dispose();
            }
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

