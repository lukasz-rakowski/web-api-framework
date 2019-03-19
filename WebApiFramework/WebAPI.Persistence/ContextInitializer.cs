using WebAPI.Persistence.Configuration;

namespace WebAPI.Persistence
{
    public class ContextInitializer
    {
        public static void Initialize(Context context, IContextConfigurationBuilder contextConfigurationProvider)
        {
            var initializer = new ContextInitializer();
            initializer.Seed(context);
            contextConfigurationProvider.WithCustomContext(context).WithHistoryTables().Build();
        }

        private void Seed(Context context)
        {
            
        }
    }
}
