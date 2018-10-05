﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TCC.Lib.Benchmark;
using TCC.Lib.Dependencies;
using TCC.Lib.Helpers;
using TCC.Lib.Options;
using Xunit;

namespace TCC.Tests
{
    public class Benchmark
    {
        [Fact]
        public async Task SimpleBench()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTcc();

            IServiceProvider provider = serviceCollection.BuildServiceProvider();

            await provider.GetRequiredService<ExternalDependencies>().EnsureAllDependenciesPresent();

            var op = await provider
                .GetRequiredService<BenchmarkHelper>()
                .RunBenchmark(new BenchmarkOption()
                {
                    Content = BenchmarkContent.Both,
                    Algorithm = BenchmarkCompressionAlgo.All,
                    FileSize = 1,
                    NumberOfFiles = 1,
                    Ratio = 1
                });
            foreach (var result in op.CommandResults)
            {
                result.ThrowOnError();
            }
        }
    }
}
