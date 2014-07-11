using Newtonsoft.Json.Linq;
using System;
namespace Smokr.Core.Configuration {
    public interface IConfigurationReader : IDisposable {
        JObject Read();
    }
}
