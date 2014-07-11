using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokr.Core.Tests {
    public sealed class TestFactory : ITestFactory {
        public ITest Create(string testName, JObject testContext) {
            ITest test = null;

            if (testName.Equals("Http", StringComparison.CurrentCultureIgnoreCase)) {
                string uri = testContext.GetValue("Uri", StringComparison.CurrentCultureIgnoreCase).Value<string>();
                test = new HttpTest(uri);
            }
            if (testName.Equals("Location", StringComparison.CurrentCultureIgnoreCase)) {
                string uri = testContext.GetValue("Uri", StringComparison.CurrentCultureIgnoreCase).Value<string>();
                test = new LocationTest(uri);
            }
            if (testName.Equals("AppSetting", StringComparison.CurrentCultureIgnoreCase)) {
                string uri = testContext.GetValue("Uri", StringComparison.CurrentCultureIgnoreCase).Value<string>();
                string key = testContext.GetValue("Key", StringComparison.CurrentCultureIgnoreCase).Value<string>();
                string expectedValue = testContext.GetValue("ExpectedValue", StringComparison.CurrentCultureIgnoreCase).Value<string>();

                test = new AppSettingsTest(uri, key, expectedValue);
            }

            return test;
        }
    }
}
