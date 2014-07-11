using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokr.Core.Tests {
    public class TestService : ITestService {

        private string _testConfigurationFilename;

        private ITestFactory _testFactory;

        public TestService(string testConfigurationFilename, ITestFactory testFactory) {
            _testConfigurationFilename = testConfigurationFilename;
            _testFactory = testFactory;
        }

        public ICollection<ITestResult> Execute() {
            ICollection<ITestResult> testResults = new List<ITestResult>();

            using (var configurationReader = new Configuration.ConfigurationReader(_testConfigurationFilename)){
                JObject configuration = configurationReader.Read();
                JObject testsObject = configuration.GetValue(ConfigConsts.ConfigRoot).Value<JObject>();
                

                foreach (var testGroup in testsObject) {
                    Console.WriteLine("Executing Test: {0}", testGroup.Key);

                    foreach (JProperty testProperty in testGroup.Value) {
                        ITest test = _testFactory.Create(testProperty.Name, (JObject)testProperty.Value);
                        string name = (testProperty.Value as JObject).GetValue(ConfigConsts.TestName).Value<string>();

                        ITestResult testResult = test.Execute();
                        testResult.Name = name;

                        testResults.Add(testResult);
                    }
                }
            }

            return testResults;
        }

        public void Dispose() {
            _testConfigurationFilename = string.Empty;
        }
    }
}
