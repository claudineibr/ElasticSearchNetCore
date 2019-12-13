using System;
using Elasticsearch.Net;
using ElasticSearch.Domain.Classes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace ElasticSearch.WebApi.Utilities
{
    public static class ElasticsearchExtensions
    {
        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["elasticsearch:url"];
            var defaultIndex = configuration["elasticsearch:index"];
            var userName = configuration["elasticsearch:user"];
            var password = configuration["elasticsearch:password"];
            var cloudId = configuration["elasticsearch:cloudId"];

            var credentials = new BasicAuthenticationCredentials(userName, password);
            var pool = new CloudConnectionPool(cloudId, credentials);

            var settings = new ConnectionSettings(pool)
                .DefaultIndex(defaultIndex)
                .MaximumRetries(3)
                .DisablePing(false)
                .EnableDebugMode()
                .DefaultMappingFor<Realties>(m => m
                .IdProperty(i => i.Reference)
            );

            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);
            CreateIndex(client, defaultIndex);
        }

        private static async void CreateIndex(IElasticClient client, string indexName)
        {
           // client.Indices.Delete(indexName);
            await client.Indices.CreateAsync(indexName, c => c
                 .Settings(s => s
                     .Analysis(a => a
                         .Analyzers(an => an
                             .Custom("Reference", ca => ca
                                 .Tokenizer("standard")
                                 .Filters("standard", "lowercase")
                             )
                         )
                     )
                 )
                 .Map<Realties>(m => m
                         .Properties(p => p
                             .Text(t => t
                                 .Name(n => n.Reference)
                                 .Analyzer("Reference")
                             )
                         )
                     )
             );
        }
    }
}
