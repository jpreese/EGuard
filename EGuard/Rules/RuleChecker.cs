using EGuard.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace EGuard.Rules
{
    public class RuleChecker
    {
        public bool CheckRules(Site site)
        {
            return GetRules().All(r => r.Check(site));
        }

        private IList<IRule> GetRules()
        {
            var rules = new List<IRule>();
            rules.Add(new TimeRule());

            return rules;
        }
    }
}
