using EGuard.Data;
using EGuard.Emailing;
using StructureMap;
using StructureMap.Graph;

namespace EGuard
{
    public class MainRegistry : Registry
    {
        public MainRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.LookForRegistries();
                s.WithDefaultConventions();

                s.AssemblyContainingType<DataRegistry>();
            });

            For<IMessageBuilder>().Use<UnidentifiedCategoryMessageBuilder>();
        }
    }
}
