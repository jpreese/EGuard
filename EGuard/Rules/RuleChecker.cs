using EGuard.Data.Models;
using StructureMap.TypeRules;
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
            var container = StructureMap.Container.For<MainRegistry>();

            var currentAssembly = GetType().GetTypeInfo().Assembly;
            var requirementRules = currentAssembly
                .DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(i => i == typeof(IRule)))
                .Select(type => (IRule)container.GetInstance(type))
                .OrderBy(rule => rule.Priority)
                .ToList();

            return requirementRules;
        }
    }
}
