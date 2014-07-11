using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokr.Core.Tests {
    public interface ITestFactory {
        ITest Create(string testName, JObject testContext);
    }
}
