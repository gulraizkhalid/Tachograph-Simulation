using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TachographSimulation.Models;

namespace TachographSimulation
{
    public class ActivityWriter
    {
        public void WriteActivity(string driverId, DateTime startDate, bool isDriving, string driverFileExtension)
        {
            // Code related to writing activity to files
            DateTime endDate = DateTime.Now;
            string directory = @"D:\Driver Files\" + startDate.ToString("yyyy-MM-dd");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileCount = (from file in Directory.EnumerateFiles(directory, "*" + driverFileExtension, SearchOption.AllDirectories)
                             select file).Count();

            if (fileCount >= 100)
            {
                Console.WriteLine("Cannot create more than 100 files per day");
                return;
            }

            string path = directory + "\\" + driverId + "-" + startDate.ToString("hh-mm-ss") + driverFileExtension;

            if (!File.Exists(path))
            {
                var myfile = File.Create(path);
                myfile.Close();
                TextWriter tw = new StreamWriter(path);

                if (driverFileExtension.Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    tw.WriteLine("Driver: " + driverId);
                    tw.WriteLine("Date: " + startDate.ToString("yyyy-MM-dd"));
                    tw.WriteLine("Start Time: " + startDate.ToString("hh:mm:ss"));
                    tw.WriteLine("End Time: " + endDate.ToString("hh:mm:ss"));
                    var strActivity = !isDriving ? "Driving" : "Rest";
                    tw.WriteLine("Activity: " + strActivity);
                }
                else
                {
                    DriverActivity driverActivity = new DriverActivity();
                    driverActivity.DriverId = Convert.ToInt32(driverId);
                    driverActivity.Date = startDate.ToString("yyyy-MM-dd");
                    driverActivity.StartTime = startDate.ToString("hh:mm:ss");
                    driverActivity.EndTime = endDate.ToString("hh:mm:ss");
                    driverActivity.Activity = !isDriving ? "Driving" : "Rest";

                    string output = JsonConvert.SerializeObject(driverActivity);
                    tw.WriteLine(output);
                }

                tw.Close();
            }
        }
    }
}
