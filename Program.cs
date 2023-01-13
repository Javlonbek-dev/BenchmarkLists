using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkList
{
    public class Program
    {
        static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<BenchmarkLists>();

            Console.WriteLine(summary);
        }
    }

    public class BenchmarkLists
    {
        private readonly List<int> number;

        public BenchmarkLists()
        {
            this.number = Enumerable.Range(0, 1000).ToList();
        }

        [Benchmark]
        public bool UsingAny()
        {
            return this.number.Any();
        }

        [Benchmark]
        public bool UsingCountProperty()
        {
            return this.number.Count > 0;
        }
        [Benchmark]
        public bool UsingCountFunction()
        {
            return this.number.Count() > 0;
        }
    }
}
