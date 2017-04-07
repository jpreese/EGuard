using EGuard.Data.Services;
using EGuard.Data.Models;
using EGuard.Data;
using System.Net;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;
using EGuard.Rules;
using System;

namespace EGuard
{
    public class ProxyFacade
    {
        private readonly SiteLogger _siteLogger;
        private readonly RuleChecker _ruleChecker;
        private readonly BlockedSiteHtmlGenerator _blockedSiteHtmlGenerator;

        public ProxyFacade(SiteLogger siteLogger, RuleChecker ruleChecker, BlockedSiteHtmlGenerator blockedSiteHtmlGenerator)
        {
            _siteLogger = siteLogger;
            _ruleChecker = ruleChecker;
            _blockedSiteHtmlGenerator = blockedSiteHtmlGenerator;
        }

        public void Start()
        {
            const int DEFAULT_PORT = 8000;
            var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, DEFAULT_PORT, true);

            ProxyServer.AddEndPoint(explicitEndPoint);

            ProxyServer.BeforeRequest += OnRequest;

            ProxyServer.Start();
            ProxyServer.SetAsSystemHttpProxy(explicitEndPoint);
            ProxyServer.SetAsSystemHttpsProxy(explicitEndPoint);
        }

        private void OnRequest(object sender, SessionEventArgs e)
        {
            if(IsValidRequest(e) == false)
            {
                return;
            }

            var site = new Site
            {
                Url = e.ProxySession.Request.RequestUri.AbsoluteUri.ToString(),
                Date = DateTime.Now.TimeOfDay.ToString()
            };

            _siteLogger.Log(site);

            if(_ruleChecker.CheckRules(site) == false)
            {
                e.Ok(_blockedSiteHtmlGenerator.GetHtml());
            }
        }

        private bool IsValidRequest(SessionEventArgs e)
        {
            var acceptHeader = e.ProxySession.Request.RequestHeaders.Find(h => h.Name == "Accept");
            var referer = e.ProxySession.Request.RequestHeaders.Find(h => h.Name == "Referer");

            if (referer != null)
            {
                return false;
            }

            if (acceptHeader == null || acceptHeader.Value.Contains("text/html") == false)
            {
                return false;
            }

            return true;
        }
    }
}
