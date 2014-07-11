using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Smokr.Core.Tests {
    public class HttpTest : ITest {

        private string _uri;

        public HttpTest(string uri) {
            _uri = uri;
        }

        public ITestResult Execute() {
            ITestResult testResult = new TestResult() { State = State.Failed };

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(_uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = client.GetAsync("").Result;
                if (response.IsSuccessStatusCode) {
                    testResult.State = State.Passed;
                }
            }

            return testResult;
        }

        public void Dispose() {
            _uri = string.Empty;
        }
    }
}
