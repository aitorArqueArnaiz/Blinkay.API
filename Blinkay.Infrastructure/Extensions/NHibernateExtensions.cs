using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;

public static class NHibernateExtensions
{
    private static Configuration _configuration = new Configuration();
    public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
    {
        var mapper = new ModelMapper();
        mapper.AddMappings(typeof(NHibernateExtensions).Assembly.ExportedTypes);
        HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
        // Add table mapping
        _configuration.AddMapping(domainMapping);

        // MySql configuration
        _configuration.DataBaseIntegration(c =>
        {
            c.Dialect<MySQLDialect>();
            c.ConnectionString = connectionString;
            c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
            c.LogFormattedSql = true;
            c.LogSqlInConsole = true;
        });


        // create session factory
        var sessionFactory = _configuration.BuildSessionFactory();
        services.AddSingleton(sessionFactory);

        // open session to DB configuration
        services.AddSingleton(factory => sessionFactory.OpenSession());
        services.AddSingleton<IMapperSession, NHibernateMapperSession>();

        return services;
    }
}