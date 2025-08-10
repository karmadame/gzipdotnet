// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using gzip.benchmark;

BenchmarkRunner.Run<GzipVsDefault>();