using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebAPI.Common.Settings;
using WebAPI.Persistence.Configuration;

namespace WebAPI.Persistence
{
    public class ContextConfigurationBuilder : IContextConfigurationBuilder
    {
        private IEnumerable<PropertyInfo> _tablesPropertyInfos;
        private Context _context;
        private IOptions<AppSettings> _appSettings;
        private string _historyTablesEnableQueryTemplate;

        public ContextConfigurationBuilder(Context context, IOptions<AppSettings> appSettings)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _appSettings = appSettings;
        }

        public void Build()
        {
            CreateHistoryTables();
        }

        public ContextConfigurationBuilder WithCustomContext(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            return this;
        }

        public ContextConfigurationBuilder WithHistoryTables()
        {
            InitializeTablesNames();
            GetHistoryTablesInsertQueryTemplate();
            return this;
        }

        private void InitializeTablesNames()
        {
            _tablesPropertyInfos = typeof(Context).GetProperties().Where(x =>
                x.PropertyType.Name == typeof(DbSet<>).Name);
        }

        private void GetHistoryTablesInsertQueryTemplate()
        {
            _historyTablesEnableQueryTemplate = _appSettings.Value.HistoryTablesEnableQueryTemplate;
        }

        private void CreateHistoryTables()
        {
            if (_tablesPropertyInfos != null && _tablesPropertyInfos.Any() && !string.IsNullOrWhiteSpace(_historyTablesEnableQueryTemplate))
            {
                foreach (var tablePropertyInfo in _tablesPropertyInfos)
                {
                    if (tablePropertyInfo.PropertyType.GenericTypeArguments.FirstOrDefault()?.GetInterface(typeof(IHistoryTrackingTableEnabled).Name) != null)
                    {
                        _context.Database.ExecuteSqlCommand(string.Format(_historyTablesEnableQueryTemplate, tablePropertyInfo.Name)); // TODO: change to procedure
                    }
                    else
                    {
                        // TODO: create procedure to off history
                    }
                }

            }
        }
    }
}
