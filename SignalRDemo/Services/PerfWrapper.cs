﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SignalRDemo.Services
{
    public class PerfWrapper
    {
        public PerfWrapper(string name, string category, 
                                string counter, string instance = "")
        {
            _counter = new PerformanceCounter(category, counter, 
                                            instance, readOnly: true);
            Name = name;
        }

        public string Name { get; set; }

        public float Value
        {
            get
            {
                return _counter.NextValue();
            }
        }

        PerformanceCounter _counter;
    }
}