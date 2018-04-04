using EGuard.Data.Models;
using EGuard.Data.Services;
using EGuard.Data.Repositories;
using System.Linq;

namespace EGuard.Rules
{
    public class BlockedCategoryRule : IRule
    {
        private readonly ISiteInformationService _siteInformationService;
        private readonly ICategoryRepository _categoryRepository;

        public BlockedCategoryRule(ISiteInformationService siteInformationService, ICategoryRepository categoryRepository)
        {
            _siteInformationService = siteInformationService;
            _categoryRepository = categoryRepository;
        }

        public bool Check(Site site)
        {
            var siteCategory = _siteInformationService.GetSiteInformationAsync(site.Url).Result;
            var blockedCategores = _categoryRepository.GetBlockedCategories();

            return blockedCategores.Any(c => c.Name == siteCategory.Categorization) == false;
        }
    }
}
