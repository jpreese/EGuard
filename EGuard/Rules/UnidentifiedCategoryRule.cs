using EGuard.Data.Models;
using EGuard.Data.Repositories;
using EGuard.Data.Services;
using EGuard.Emailing;

namespace EGuard.Rules
{
    public class UnidentifiedCategoryRule : IRule
    {
        private readonly ISiteInformationService _siteInformationService;
        private readonly UnidentifiedCategoryMailer _unidentifiedCategoryMailer;
        private readonly ISiteCategoryRepository _siteCategoryRepository;

        public int Priority { get; } = 3;

        public UnidentifiedCategoryRule(ISiteInformationService siteInformationService, UnidentifiedCategoryMailer unidentifiedCategoryMailer, ISiteCategoryRepository siteCategoryRepository)
        {
            _siteInformationService = siteInformationService;
            _unidentifiedCategoryMailer = unidentifiedCategoryMailer;
            _siteCategoryRepository = siteCategoryRepository;
        }

        public bool Check(Site site)
        {
            var category = _siteInformationService.GetSiteInformationAsync(site.Url).Result;
            if(category.Categorization.Equals("Uncategorized"))
            {
                _unidentifiedCategoryMailer.SendMail();
                MainWindow.ViewModel.PendingUrls.Add(site.Url);
                return false;
            }

            return true;
        }
    }
}
