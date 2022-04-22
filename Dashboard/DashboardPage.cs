using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class DashboardPage
    {
        public IWebDriver WebDriver { get; }
        public DashboardPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        #region List Information

        public class Item
        {
            public string FullName { get; set; }
            public string JobTitle { get; set; }
            public string Rating { get; set; }
            public string Budget { get; set; }
        }

        #endregion

        #region Get_Element

        //First Row
        public IWebElement taskontrack => WebDriver.FindElement(By.XPath("//div[@id='dashboard-tilelayout']/child::div[1]/child::div[2]/child::div[1]"));
        public IWebElement inbacklog => WebDriver.FindElement(By.XPath("//div[@id='dashboard-tilelayout']/child::div[1]/child::div[2]/child::div[2]"));
        public IWebElement overduetasks => WebDriver.FindElement(By.XPath("//div[@id='dashboard-tilelayout']/child::div[2]/child::div[2]/child::div[1]"));
        public IWebElement fromyesterday => WebDriver.FindElement(By.XPath("//div[@id='dashboard-tilelayout']/child::div[2]/child::div[2]/child::div[2]"));
        public IWebElement issues => WebDriver.FindElement(By.XPath("//div[@id='dashboard-tilelayout']/child::div[3]/child::div[2]/child::div[1]"));
        public IWebElement closedbyteam => WebDriver.FindElement(By.XPath("//div[@id='dashboard-tilelayout']/child::div[3]/child::div[2]/child::div[2]"));
        public IWebElement usedspace => WebDriver.FindElement(By.XPath("//div[@id='dashboard-tilelayout']/child::div[4]/child::div[2]/child::div[1]/child::div[2]/child::span"));
        public IWebElement used => WebDriver.FindElement(By.XPath("//div[@id='dashboard-tilelayout']/child::div[4]/child::div[2]/child::div[2]"));

        //Second Row
        public IWebElement startyear => WebDriver.FindElement(By.XPath("//div[@id='range-selection']/child::span[1]/child::input"));
        public IWebElement endyear => WebDriver.FindElement(By.XPath("//div[@id='range-selection']/child::span[3]/child::input"));
        public IWebElement selectyearmonth => WebDriver.FindElement(By.XPath("//div[@class='k-calendar-header k-hstack']/child::a"));

        string xpathselectyears = "//div[@class='k-animation-container']/child::div/child::div/child::div[2]/child::table/child::tbody/child::tr[{0}]/child::td[{1}]/child::a";
        string xpathselectmonth = "//div[@class='k-animation-container']/child::div/child::div/child::div[2]/child::table/child::tbody/child::tr[{0}]/child::td[{1}]/child::a";
        string xpathselectdayleft = "//div[@class='k-animation-container']/child::div/child::div/child::div[2]/child::table[1]/child::tbody/child::tr[{0}]/child::td[{1}]/child::a";
        string xpathselectdayright = "//div[@class='k-animation-container']/child::div/child::div/child::div[2]/child::table[2]/child::tbody/child::tr[{0}]/child::td[{1}]/child::a";
        public IWebElement chart => WebDriver.FindElement(By.ClassName("k-tilelayout-item-body k-card-body"));

        //grid information
        
        string xpathgridinformation = "//div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[{0}]/child::td[{1}]";


        #endregion

        #region Check_All_Task

        public void Check_All_Task()
        {
            string converttaskontrack = taskontrack.Text.Replace(" ", "");
            string convertinbacklog = inbacklog.Text.Replace("In Backlog:", "").Replace(" ", "");

            if (converttaskontrack == "22" && convertinbacklog == "43")
            {
                Console.WriteLine("tasks on track information is correct");
            }
            else
            {
                Console.WriteLine("tasks on track information is incorrect");
                Assert.Fail("tasks on track information is incorrect");
            }


            string convertoverduetasks = overduetasks.Text.Replace(" ", "");
            string convertfromyesterday = fromyesterday.Text.Replace("From Yesterday:", "").Replace(" ", "");

            if (convertoverduetasks == "7" && convertfromyesterday == "16")
            {
                Console.WriteLine("Overdue Tasks information is correct");
            }
            else
            {
                Console.WriteLine("Overdue Tasks information is incorrect");
                Assert.Fail("Overdue Tasks information is incorrect");
            }


            string convertissues = issues.Text.Replace(" ", "");
            string convertclosedbyteam = closedbyteam.Text.Replace("Closed By Team:", "").Replace(" ", "");

            if (convertissues == "47" && convertclosedbyteam == "15")
            {
                Console.WriteLine("Issues information is correct");
            }
            else
            {
                Console.WriteLine("Issues information is incorrect");
                Assert.Fail("Issues information is incorrect");
            }


            string convertusedspace = usedspace.Text.Replace(" ", "").Replace("%", "");

            if (convertusedspace == "50" && used.Text == "25 of 50GB Used")
            {
                Console.WriteLine("Used Space information is correct");
            }
            else
            {
                Console.WriteLine("Used Space information is incorrect");
                Assert.Fail("Used Space information is incorrect");
            }


        }

        #endregion

        #region Check_Chart_Information

        public void Check_Chart_Information(string StartYear, string StartMonth, string StartDay, string EndYear, string EndMonth, string EndDay)
        {
            startyear.Click();
            System.Threading.Thread.Sleep(500);
            selectyearmonth.Click();
            System.Threading.Thread.Sleep(500);
            selectyearmonth.Click();
            System.Threading.Thread.Sleep(500);

            var i = 1;
            IList<IWebElement> selectstartyear = WebDriver.FindElements(By.XPath("//div[@class='k-animation-container']/child::div/child::div/child::div[2]/child::table/child::tbody/child::tr"));

            foreach (var item in selectstartyear)
            {
                IList<IWebElement> selectyearlist = WebDriver.FindElements(By.XPath("//div[@class='k-animation-container']/child::div/child::div/child::div[2]/child::table/child::tbody/child::tr[" + i + "]/child::td"));
                var j = 1;
                foreach (var item2 in selectyearlist)
                {
                    var selectyears = "";
                    selectyears = WebDriver.FindElement(By.XPath(String.Format(xpathselectyears, i, j))).Text;

                    if (selectyears == StartYear)
                    {
                        WebDriver.FindElement(By.XPath(String.Format(xpathselectyears, i, j))).Click();
                        break;
                    }
                    j++;
                }
                i++;
            }

            System.Threading.Thread.Sleep(1000);

            var y = 1;
            IList<IWebElement> selectstartmonth = WebDriver.FindElements(By.XPath("//div[@class='k-calendar-tbody']/child::tr"));

            foreach (var item in selectstartmonth)
            {
                IList<IWebElement> selectmonthlist = WebDriver.FindElements(By.XPath("//div[@class='k-calendar-tbody']/child::tr[" + y + "]/child::td"));
                var j = 1;
                foreach (var item2 in selectmonthlist)
                {
                    var selectmonth = "";
                    selectmonth = WebDriver.FindElement(By.XPath(String.Format(xpathselectmonth, y, j))).Text;

                    if (selectmonth == StartMonth)
                    {
                        WebDriver.FindElement(By.XPath(String.Format(xpathselectmonth, y, j))).Click();
                        break;
                    }
                    j++;
                }
                y++;
            }

            System.Threading.Thread.Sleep(1000);

            if (StartMonth == "Dec")
            {
                var o = 1;
                IList<IWebElement> selectstartday = WebDriver.FindElements(By.XPath("//div[@id='bf246a3f-1036-4f9a-ad3c-4429bd3abd8a']/child::div[2]/child::table[2]/child::tbody/child::tr"));

                foreach (var item in selectstartday)
                {
                    IList<IWebElement> selectdaylist = WebDriver.FindElements(By.XPath("//div[@id='bf246a3f-1036-4f9a-ad3c-4429bd3abd8a']/child::div[2]/child::table[2]/child::tbody/child::tr[" + o + "]/child::td"));
                    var j = 1;
                    foreach (var item2 in selectdaylist)
                    {
                        var selectday = "";
                        selectday = WebDriver.FindElement(By.XPath(String.Format(xpathselectdayright, o, j))).Text;

                        if (selectday == StartDay)
                        {
                            WebDriver.FindElement(By.XPath(String.Format(xpathselectdayright, o, j))).Click();
                            break;
                        }
                        j++;
                    }
                    o++;
                }

                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                var o = 1;
                IList<IWebElement> selectstartday = WebDriver.FindElements(By.XPath("//div[@id='bf246a3f-1036-4f9a-ad3c-4429bd3abd8a']/child::div[2]/child::table[1]/child::tbody/child::tr"));

                foreach (var item in selectstartday)
                {
                    IList<IWebElement> selectdaylist = WebDriver.FindElements(By.XPath("//div[@id='bf246a3f-1036-4f9a-ad3c-4429bd3abd8a']/child::div[2]/child::table[1]/child::tbody/child::tr[" + o + "]/child::td"));
                    var j = 1;
                    foreach (var item2 in selectdaylist)
                    {
                        var selectday = "";
                        selectday = WebDriver.FindElement(By.XPath(String.Format(xpathselectdayleft, o, j))).Text;

                        if (selectday == StartDay)
                        {
                            WebDriver.FindElement(By.XPath(String.Format(xpathselectdayleft, o, j))).Click();
                            break;
                        }
                        j++;
                    }
                    o++;
                }

                System.Threading.Thread.Sleep(1000);
            }

            endyear.Click();
            System.Threading.Thread.Sleep(1000);
            selectyearmonth.Click();
            System.Threading.Thread.Sleep(500);
            selectyearmonth.Click();
            System.Threading.Thread.Sleep(500);

            var k = 1;
            IList<IWebElement> selectendtyear = WebDriver.FindElements(By.XPath("//div[@class='k-calendar-tbody']/child::tr"));

            foreach (var item in selectendtyear)
            {
                IList<IWebElement> selectyearlist = WebDriver.FindElements(By.XPath("//div[@class='k-calendar-tbody']/child::tr[" + k + "]/child::td"));
                var j = 1;
                foreach (var item2 in selectyearlist)
                {
                    var selectyears = "";
                    selectyears = WebDriver.FindElement(By.XPath(String.Format(xpathselectyears, k, j))).Text;

                    if (selectyears == EndYear)
                    {
                        WebDriver.FindElement(By.XPath(String.Format(xpathselectyears, k, j))).Click();
                        break;
                    }
                    j++;
                }
                k++;
            }

            System.Threading.Thread.Sleep(1000);

            var u = 1;
            IList<IWebElement> selectendmonth = WebDriver.FindElements(By.XPath("//div[@class='k-calendar-tbody']/child::tr"));

            foreach (var item in selectendmonth)
            {
                IList<IWebElement> selectmonthlist = WebDriver.FindElements(By.XPath("//div[@class='k-calendar-tbody']/child::tr[" + u + "]/child::td"));
                var j = 1;
                foreach (var item2 in selectmonthlist)
                {
                    var selectmonth = "";
                    selectmonth = WebDriver.FindElement(By.XPath(String.Format(xpathselectmonth, u, j))).Text;

                    if (selectmonth == EndMonth)
                    {
                        WebDriver.FindElement(By.XPath(String.Format(xpathselectmonth, u, j))).Click();
                        break;
                    }
                    j++;
                }
                u++;
            }

            System.Threading.Thread.Sleep(1000);

            if (EndMonth == "Dec")
            {
                var o = 1;
                IList<IWebElement> selectendday = WebDriver.FindElements(By.XPath("//div[@id='bf246a3f-1036-4f9a-ad3c-4429bd3abd8a']/child::div[2]/child::table[2]/child::tbody/child::tr"));

                foreach (var item in selectendday)
                {
                    IList<IWebElement> selectdaylist = WebDriver.FindElements(By.XPath("//div[@id='bf246a3f-1036-4f9a-ad3c-4429bd3abd8a']/child::div[2]/child::table[2]/child::tbody/child::tr[" + o + "]/child::td"));
                    var j = 1;
                    foreach (var item2 in selectdaylist)
                    {
                        var selectday = "";
                        selectday = WebDriver.FindElement(By.XPath(String.Format(xpathselectdayright, o, j))).Text;

                        if (selectday == EndDay)
                        {
                            WebDriver.FindElement(By.XPath(String.Format(xpathselectdayright, o, j))).Click();
                            break;
                        }
                        j++;
                    }
                    o++;
                }

                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                var o = 1;
                IList<IWebElement> selectEndday = WebDriver.FindElements(By.XPath("//div[@id='bf246a3f-1036-4f9a-ad3c-4429bd3abd8a']/child::div[2]/child::table[1]/child::tbody/child::tr"));

                foreach (var item in selectEndday)
                {
                    IList<IWebElement> selectdaylist = WebDriver.FindElements(By.XPath("//div[@id='bf246a3f-1036-4f9a-ad3c-4429bd3abd8a']/child::div[2]/child::table[1]/child::tbody/child::tr[" + o + "]/child::td"));
                    var j = 1;
                    foreach (var item2 in selectdaylist)
                    {
                        var selectday = "";
                        selectday = WebDriver.FindElement(By.XPath(String.Format(xpathselectdayleft, o, j))).Text;

                        if (selectday == EndDay)
                        {
                            WebDriver.FindElement(By.XPath(String.Format(xpathselectdayleft, o, j))).Click();
                            break;
                        }
                        j++;
                    }
                    o++;
                }

                System.Threading.Thread.Sleep(1000);
            }

            System.Threading.Thread.Sleep(1500);

            if (chart.Displayed == true)
            {
                Console.WriteLine("The chart was displayed after entering the information");
            }
            else
            {
                Console.WriteLine("The chart was not displayed after entering the information");
                Assert.Fail("The chart was not displayed after entering the information");
            }


        }

        #endregion

        #region Grid_Information

        public List<Item> Grid_Information()
        {
            var ListInformation = new List<Item>();

            for (int i = 0; i < 7; i++)
            {
                var fullname = "";
                var jobtitle = "";
                var rating = "";
                var budget = "";

                fullname = WebDriver.FindElement(By.XPath("//div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr["+i+ "]/child::td[2]/child::div[2]")).Text;
                jobtitle = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 3))).Text;
                rating = WebDriver.FindElement(By.XPath("//div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[" + i + "]/child::td[4]/child::span")).GetAttribute("aria-valuenow");
                budget = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 5))).Text;

                ListInformation.Add(new Item()
                {
                    FullName = fullname,
                    JobTitle = jobtitle,
                    Rating = rating,
                    Budget = budget
                });

                System.Threading.Thread.Sleep(500);
                i++;
            }
            return ListInformation;

        }

        #endregion

    }
}
