using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Persistence.Configuration
{
    public interface IContextConfigurationBuilder
    {
        void Build();

        ContextConfigurationBuilder WithCustomContext(Context context);

        ContextConfigurationBuilder WithHistoryTables();
    }
}
