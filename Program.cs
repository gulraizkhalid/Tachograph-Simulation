using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace TachographSimulation
{
    public class Program
    {
        static void Main(string[] args)
        {
             ILogger _logger = LoggerConfigurationService.logger();
            try 
            {
                string driverFileExtension = ".json";
                Console.WriteLine("Please Enter your ID to Start Driving Activity");
                var driverId = Console.ReadLine();

                if (!driverId.Equals("1", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("");
                    Console.WriteLine("invalid ID, please start again.");
                    return;
                }

                DateTime startDate = DateTime.Now;
                bool isDrivingActivity = true;
                var drivingActivityManager = new DrivingActivityManager(new ActivityPrinter(), new ActivityWriter());
                drivingActivityManager.ManageActivity(driverId, startDate, isDrivingActivity, driverFileExtension);
            }
            catch(Exception ex) 
            {
                Console.WriteLine("");
                Console.WriteLine("Something went wrong, Please contact admin");
                _logger.Error(ex, "Something went wrong");
                return;
            }
        }
    }
}
