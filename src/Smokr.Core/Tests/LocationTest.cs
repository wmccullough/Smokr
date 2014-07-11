using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokr.Core.Tests {
    public class LocationTest : ITest {

        private string _uri;

        public LocationTest(string uri) {
            _uri = uri;
        }

        public ITestResult Execute() {
            ITestResult testResult = new TestResult() { State = State.Failed };

            if (Directory.Exists(_uri)) {
                testResult.State = State.Passed;
            }

            return testResult;
        }

        public void Dispose() {
            _uri = string.Empty;
        }
    }
}
