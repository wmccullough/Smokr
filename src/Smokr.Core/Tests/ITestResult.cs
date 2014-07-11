using System;
namespace Smokr.Core.Tests {
    public interface ITestResult {
        State State { get; set; }
        string Name { get; set; }
    }
}
