using Smokr.Core.Tests;
using Smokr.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokr {
    class Program {
        static void Main(string[] args) {

            try {
                ITestFactory testFactory = new TestFactory();

                using (ITestService testService = new TestService(Settings.Default.SmokrFile, testFactory)) {
                    ICollection<ITestResult> testResults = testService.Execute();

                    foreach (ITestResult testResult in testResults) {
                        if (testResult.State.Equals(State.Passed)) {
                            Console.ForegroundColor = ConsoleColor.Green;
                        } else {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write("[{0}] ", testResult.State.ToString());

                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("{0}\r\n", testResult.Name);
                    }
                }
                Console.Read();
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
        }
    }
}
