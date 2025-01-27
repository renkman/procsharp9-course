﻿using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace FunctionsImprovements
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        Collection<int> collection;

        [GlobalSetup]
        public void GlobalSetup()
        {
            collection = new Collection<int>(Enumerable.Range(1, 1000).ToArray());
        }

        [Benchmark(Baseline = true, OperationsPerInvoke = 4)]
        [ArgumentsSource(nameof(Values))]
        public int NonStatic_WithClosure(int value)
        {
            return collection.Find(i => i % value == 0) +
                   collection.Find(i => i % value == 0) +
                   collection.Find(i => i % value == 0) +
                   collection.Find(i => i % value == 0);

        }

        [Benchmark(OperationsPerInvoke = 4)]
        [ArgumentsSource(nameof(Values))]
        public int Static_WithoutClosure(int value)
        {
            return collection.Find(value, static (v, i) => i % v == 0) +
                   collection.Find(value, static (v, i) => i % v == 0) +
                   collection.Find(value, static (v, i) => i % v == 0) +
                   collection.Find(value, static (v, i) => i % v == 0);
        }

        public IEnumerable<int> Values()
        {
            yield return 513;
        }
    }
}