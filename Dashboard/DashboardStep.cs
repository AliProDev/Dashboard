using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Dashboard
{
    [Binding]
    public sealed class DashboardStep
    {
        IWebDriver webDriver;
        DashboardPage dashboard;

        #region Launch_Application

        [Given(@"launch the application")]
        public void GivenLaunchTheApplication()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demos.telerik.com/kendo-ui/admin-dashboard/");
            dashboard = new DashboardPage(webDriver);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();
            System.Threading.Thread.Sleep(2000);
        }

        #endregion

        #region Check_All_Task

        [Given(@"check all task information in frist row")]
        public void Check_All_Task()
        {
            System.Threading.Thread.Sleep(2000);
            dashboard.Check_All_Task();
        }

        #endregion

        #region Check_Chart_Information

        public class Chart
        {
            public string StartYear { get; set; }
            public string StartMonth { get; set; }
            public string StartDay { get; set; }
            public string EndYear { get; set; }
            public string EndMonth { get; set; }
            public string EndDay { get; set; }
        }

        [When(@"check the total points chart")]
        public void Check_Chart_Information(Table table)
        {
            System.Threading.Thread.Sleep(2000);
            var info = table.CreateSet<Chart>();
            foreach (Chart item in info)
            {
                dashboard.Check_Chart_Information(item.StartYear, item.StartMonth, item.StartDay, item.EndYear, item.EndMonth, item.EndDay);
            }
        }

        #endregion

        #region Check_Grid_Information

        public class grid
        {
            public string FullName { get; set; }
            public string JobTitle { get; set; }
            public string Rating { get; set; }
            public string Budget { get; set; }
        }

        [Then(@"check MK team grid information")]
        public void ThenCheckMKTeamGridInformation(Table table)
        {
            System.Threading.Thread.Sleep(2000);
            var GridInformation = dashboard.Grid_Information();

            if (GridInformation.Count != 8)
            {
                Console.WriteLine("The number of information displayed is not equal to the available information");
            }

            var i = 0;

            var info = table.CreateSet<grid>();
            foreach (grid item in info)
            {

                if (item.FullName == GridInformation[i].FullName)
                {
                    Console.WriteLine("Full name information is equal to the desired information");
                }
                else
                {
                    Console.WriteLine("Full name information is not equal to the desired information");
                    Assert.Fail("Full name information is not equal to the desired information");
                }


                if (item.JobTitle == GridInformation[i].JobTitle)
                {
                    Console.WriteLine("Job title information is equal to the desired information");
                }
                else
                {
                    Console.WriteLine("Job title information is not equal to the desired information");
                    Assert.Fail("Job title information is not equal to the desired information");
                }


                if (item.Rating == GridInformation[i].Rating)
                {
                    Console.WriteLine("The ranking information is equal to the desired information");
                }
                else
                {
                    Console.WriteLine("The ranking information is not equal to the desired information");
                    Assert.Fail("The ranking information is not equal to the desired information");
                }


                if (item.Budget == GridInformation[i].Budget)
                {
                    Console.WriteLine("Budget information is equal to the desired information");
                }
                else
                {
                    Console.WriteLine("Budget information is not equal to the desired information");
                    Assert.Fail("Budget information is not equal to the desired information");
                }

                i++;
            }

        }

        #endregion


    }
}
