using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using SignalRDemo.Services;

namespace SignalRDemo.Hubs
{
    public class PerfHub : Hub
    {
        public PerfHub()
        {
            StartCounterCollection();
        }

        private void StartCounterCollection()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                var perfService = new PerfService();
                while (true)
                {
                    var results = perfService.GetResults();
                    Clients.All.newCounters(results);
                    await Task.Delay(2000);
                }

            }, TaskCreationOptions.LongRunning);
        }
    }
}