using System;
using System.Threading;
using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using MongoDB.Driver;

namespace hangfireconsoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to hangfire Console demo *****\n\n");

            var mongoUrlBuilder = new MongoUrlBuilder("mongodb://localhost:27017/hangfire");
            var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());

            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseColouredConsoleLogProvider()
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMongoStorage(mongoClient, mongoUrlBuilder.DatabaseName, new MongoStorageOptions
                {
                    MigrationOptions = new MongoMigrationOptions
                    {
                        MigrationStrategy = new MigrateMongoMigrationStrategy(),
                        BackupStrategy = new CollectionMongoBackupStrategy()
                    },
                    Prefix = "hangfire.mongo",
                    CheckConnection = true
                });

            BackgroundJob.Enqueue(() => Console.WriteLine($"Background Demo Executed - Thread Id: {Thread.CurrentThread.ManagedThreadId}"));

            using (var server = new BackgroundJobServer())
            {
               Console.ReadLine();
            }
        }
    }
}
