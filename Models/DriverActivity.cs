using System;
using System.Collections.Generic;
using System.Text;

namespace TachographSimulation.Models
{
    public class DriverActivity
    {
        public int DriverId { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Activity { get; set; }
    }
}
