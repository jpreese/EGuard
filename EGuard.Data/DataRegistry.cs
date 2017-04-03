using StructureMap;
using StructureMap.Graph;
using System.Data;
using System.Data.SQLite;

namespace EGuard.Data
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
            });

            For<IDbConnection>().Use(new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString));
        }
    }
}
