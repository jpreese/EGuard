using System;
using System.Net;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

namespace EGuard
{
    public class ProxyFacade
    {
        public static void Start()
        {
            var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, 8000, true);
            ProxyServer.AddEndPoint(explicitEndPoint);

            ProxyServer.BeforeRequest += OnRequest;

            ProxyServer.Start();
            ProxyServer.SetAsSystemHttpProxy(explicitEndPoint);
            ProxyServer.SetAsSystemHttpsProxy(explicitEndPoint);
        }

        private static void OnRequest(object sender, SessionEventArgs e)
        {
            var acceptHeader = e.ProxySession.Request.RequestHeaders.Find(h => h.Name == "Accept");
            if(acceptHeader != null && acceptHeader.Value.Contains("text/html"))
            {
                Console.WriteLine(e.ProxySession.Request.Url);
            }
        }

        private bool ShouldBlockWebsite(string url)
        {
            // send POST request to blue coat
            // receive JSON
            // parse/structure JSON
            // get the category of website

            // 1) check system time vs. time restriction in database
            // 2) if category not found, block it
            // 3) check blocked categories in database
            // 4) if none of the above, allow

            return false;
        }
    }
}
