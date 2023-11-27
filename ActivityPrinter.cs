using System;
using System.Collections.Generic;
using System.Text;

namespace TachographSimulation
{
    public class ActivityPrinter
    {
        public void PrintActivity(string driverId, DateTime startDate, bool isDriving)
        {
            // Code related to printing activity
            DateTime endDate = DateTime.Now;
            Console.WriteLine("");
            Console.WriteLine("Your Recent Activity:");
            Console.WriteLine("Driver: " + driverId);
            Console.WriteLine("Date: " + startDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Start Time: " + startDate.ToString("hh:mm:ss"));
            Console.WriteLine("End Time: " + endDate.ToString("hh:mm:ss"));
            var strActivity = !isDriving ? "Driving" : "Rest";
            Console.WriteLine("Activity: " + strActivity);
        }
    }
}
