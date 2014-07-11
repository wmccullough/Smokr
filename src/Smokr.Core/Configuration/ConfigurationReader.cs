using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokr.Core.Configuration {
    public sealed class ConfigurationReader : IConfigurationReader {

        private string _filename;

        public ConfigurationReader(string filename) {
            _filename = filename;
        }

        public JObject Read() {
            if (File.Exists(_filename)) {
                string json = File.ReadAllText(_filename);
                JObject configurationObject = JObject.Parse(json);
                return configurationObject;
            } else {
                throw new FileNotFoundException(_filename);
            }
        }

        public void Dispose() {
            _filename = string.Empty;
        }
    }
}
