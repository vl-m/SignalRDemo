using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRDemo.Services
{
    public class PerfService
    {
        public PerfService()
        {
            _counters = new List<PerfWrapper>();
            
            _counters.Add(new PerfWrapper("Processor", 
                "Processor", "% Processor Time", "_Total"));
            
            _counters.Add(new PerfWrapper("Paging", 
                "Memory", "Pages/sec"));

            _counters.Add(new PerfWrapper("Disk", 
                "PhysicalDisk", "% Disk Time", "_Total"));
        }

        public dynamic GetResults()
        {
            return _counters.Select(c => new 
                    { name = c.Name, value = c.Value }
                );
        }

        List<PerfWrapper> _counters;
    }
}