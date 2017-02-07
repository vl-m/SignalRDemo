using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRDemo.Models;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using SignalRDemo.Services;

namespace SignalRDemo.Hubs
{
    [HubName("stockTicker")]
    public class StockTickerHub : Hub
    {
        public static ConcurrentDictionary<string, string> connectionIds = new ConcurrentDictionary<string, string>();

        private readonly StockTicker _stockTicker;

        public StockTickerHub() : this(StockTicker.Instance) { }

        public StockTickerHub(StockTicker stockTicker)
        {
            _stockTicker = stockTicker;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return _stockTicker.GetAllStocks();
        }

        public string GetMarketState()
        {
            return _stockTicker.MarketState.ToString();
        }

        public void OpenMarket()
        {
            _stockTicker.OpenMarket();
        }

        public void CloseMarket()
        {
            _stockTicker.CloseMarket();
        }

        public void Reset()
        {
            _stockTicker.Reset();
        }

        public override Task OnConnected()
        {
            connectionIds.TryAdd(Context.ConnectionId, Context.ConnectionId);
            
            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            string connectionId;
            connectionIds.TryRemove(Context.ConnectionId, out connectionId);
            if(connectionIds.IsEmpty)
            {
                CloseMarket();
                Reset();
            }
            
            return base.OnDisconnected();
        }
    }
}