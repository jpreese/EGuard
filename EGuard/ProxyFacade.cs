using EGuard.Data;
using System.Net;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

namespace EGuard
{
    public class ProxyFacade
    {
        private readonly ISiteInformationService _siteInformationService;

        public ProxyFacade(ISiteInformationService siteInformationService)
        {
            _siteInformationService = siteInformationService;
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

        private async void OnRequest(object sender, SessionEventArgs e)
        {
            var acceptHeader = e.ProxySession.Request.RequestHeaders.Find(h => h.Name == "Accept");
            if(acceptHeader != null && acceptHeader.Value.Contains("text/html"))
            {
                var info = await _siteInformationService.GetSiteInformation(e.ProxySession.Request.RequestUri.AbsoluteUri);
            }
        }
    }
}
