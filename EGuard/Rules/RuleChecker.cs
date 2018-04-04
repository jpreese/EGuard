using EGuard.Data.Models;
using EGuard.Data.Repositories;
using EGuard.Data.Services;
using EGuard.Emailing;
using System.Collections.Generic;
using System.Linq;

namespace EGuard.Rules
{
    public class RuleChecker
    {
        private readonly ISiteInformationService _siteInformationService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly UnidentifiedCategoryMailer _unidentifiedCategoryMailer;
        private readonly ISiteCategoryRepository _siteCategoryRepository;

        public RuleChecker(ISiteInformationService siteInformationService, 
            ICategoryRepository categoryRepository, 
            UnidentifiedCategoryMailer unidentifiedCategoryMailer, 
            ISiteCategoryRepository siteCategoryRepository)
        {
            _siteInformationService = siteInformationService;
            _categoryRepository = categoryRepository;
            _unidentifiedCategoryMailer = unidentifiedCategoryMailer;
            _siteCategoryRepository = siteCategoryRepository;
        }

        public bool CheckRules(Site site)
        {
            return GetRules().All(r => r.Check(site));
        }

        private IList<IRule> GetRules()
        {
            var rules = new List<IRule>();
            rules.Add(new TimeRule());
            rules.Add(new BlockedCategoryRule(_siteInformationService, _categoryRepository));
            rules.Add(new UnidentifiedCategoryRule(_siteInformationService, _unidentifiedCategoryMailer, _siteCategoryRepository));

            return rules;
        }
    }
}
