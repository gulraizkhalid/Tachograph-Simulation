using System;
using System.Collections.Generic;
using System.Text;

namespace TachographSimulation
{
    public class DrivingActivityManager
    {
        private readonly ActivityPrinter _activityPrinter;
        private readonly ActivityWriter _activityWriter;

        public DrivingActivityManager(ActivityPrinter activityPrinter, ActivityWriter activityWriter)
        {
            _activityPrinter = activityPrinter ?? throw new ArgumentNullException(nameof(activityPrinter));
            _activityWriter = activityWriter ?? throw new ArgumentNullException(nameof(activityWriter));
            }

        public void ManageActivity(string driverId, DateTime startDate, bool isDrivingActivity, string driverFileExtension)
        {
            Console.WriteLine("");
            Console.WriteLine($"Please enter: {(isDrivingActivity ? "R for Activity Rest" : "D for Activity Driving")}");
            Console.WriteLine("Escape to Exit the Program");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key != ConsoleKey.Escape && keyInfo.Key != ConsoleKey.D && keyInfo.Key != ConsoleKey.R)
            {
                Console.WriteLine("");
                Console.WriteLine("Wrong Key pressed, Try Again.");
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("");
                Console.WriteLine("Program is terminated");
                _activityWriter.WriteActivity(driverId, startDate, !isDrivingActivity, driverFileExtension);
                return;
            }
            else if (keyInfo.Key == ConsoleKey.D)
            {
                isDrivingActivity = true;
                Console.WriteLine("");
                Console.WriteLine("You are in Driving Mode");
            }
            else if (keyInfo.Key == ConsoleKey.R)
            {
                isDrivingActivity = false;
                Console.WriteLine("");
                Console.WriteLine("You are in Resting Mode");
            }

            _activityPrinter.PrintActivity(driverId, startDate, isDrivingActivity);
            _activityWriter.WriteActivity(driverId, startDate, isDrivingActivity, driverFileExtension);

            ManageActivity(driverId, DateTime.Now, isDrivingActivity, driverFileExtension); // Recursive call
        }
    }
}
