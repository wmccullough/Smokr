using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Smokr.Core.Tests {
    public class AppSettingsTest : ITest {

        private string _uri;
        private string _key;
        private string _expectedValue;

        public AppSettingsTest(string uri, string key, string expectedValue) {
            _uri = uri;
            _key = key;
            _expectedValue = expectedValue;
        }

        public ITestResult Execute() {
            if (!File.Exists(_uri)) {
                throw new FileNotFoundException(_uri);
            }

            ITestResult testResult = new TestResult() { State = State.Failed };

            XDocument xmlDocument = XDocument.Load(_uri);

            IEnumerable<XElement> appSettings = xmlDocument.Descendants("appSettings");

            foreach (XElement element in appSettings.Descendants()) {
                var key = element.Attribute("key");
                var value = element.Attribute("value");

                if (key.Value.Equals(_key, StringComparison.CurrentCultureIgnoreCase)) {
                    if (value.Value.Equals(_expectedValue)) {
                        testResult.State = State.Passed;
                    }
                }
            }

            return testResult;
        }

        public void Dispose() {
            throw new NotImplementedException();
        }
    }
}
