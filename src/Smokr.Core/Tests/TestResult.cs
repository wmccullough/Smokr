using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokr.Core.Tests {
    public sealed class TestResult : ITestResult {
        public State State { get; set; }
        public string Name { get; set; }
    }
}
