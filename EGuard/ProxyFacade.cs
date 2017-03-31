using EGuard.Data;
using EGuard.Data.Models;
using System.Net;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

namespace EGuard
{
    public class ProxyFacade
    {
        private readonly ISiteVerificationService _siteVerificationService;
        private readonly SiteLogger _siteLogger;

        public ProxyFacade(ISiteVerificationService siteVerificationService, SiteLogger siteLogger)
        {
            _siteVerificationService = siteVerificationService;
            _siteLogger = siteLogger;
        }

        public void Start()
        {
            var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, 8000, true);
            ProxyServer.AddEndPoint(explicitEndPoint);

            ProxyServer.BeforeRequest += OnRequest;

            ProxyServer.Start();
            ProxyServer.SetAsSystemHttpProxy(explicitEndPoint);
            ProxyServer.SetAsSystemHttpsProxy(explicitEndPoint);
        }

        private void OnRequest(object sender, SessionEventArgs e)
        {
            var acceptHeader = e.ProxySession.Request.RequestHeaders.Find(h => h.Name == "Accept");
            var referer = e.ProxySession.Request.RequestHeaders.Find(h => h.Name == "Referer");

            if(referer != null)
            {
                return;
            }

            if (acceptHeader == null || acceptHeader.Value.Contains("text/html") == false)
            {
                return;
            }

            var site = new Site
            {
                Url = e.ProxySession.Request.RequestUri.AbsoluteUri.ToString()
            };

            _siteLogger.Log(site);
        }
    }
}
