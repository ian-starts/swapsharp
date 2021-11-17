using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SwapSharp.Exchanger.Providers;
using SwapSharp.Swap.Extensions;
using Xunit;

namespace SwapSharp.Swap.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        true.Should().Be(true);
    }
}