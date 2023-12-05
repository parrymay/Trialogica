using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Trialogica;

BenchmarkRunner.Run<Test>();

public class Test
{
    [Benchmark]
    public void BenchMarkTest() => Trialoger.GetTriangleType(5.8385325, 2.932132, 5.421325325);
}


