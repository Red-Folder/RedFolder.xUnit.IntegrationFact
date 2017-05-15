using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace RedFolder.xUnit.IntegrationFact
{
    public class IntegrationFactDiscoverer : IXunitTestCaseDiscoverer
    {
        readonly IMessageSink diagnosticMessageSink;

        public IntegrationFactDiscoverer(IMessageSink diagnosticMessageSink)
        {
            this.diagnosticMessageSink = diagnosticMessageSink;
        }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            return Enabled
                ? new[] { new XunitTestCase(diagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), testMethod) }
                : Enumerable.Empty<IXunitTestCase>();
        }

        private bool Enabled
        {
            get
            {
                var enabled = Environment.GetEnvironmentVariable("XUNIT_INTERGRATION_FACT_ENABLED");
                return (enabled.ToLower() == "true");
            }
        }
    }

    [XunitTestCaseDiscoverer("RedFolder.xUnit.IntegrationFact.IntegrationFactDiscoverer", "RedFolder.xUnit.IntegrationFact")]
    public class IntegrationFactAttribute : FactAttribute
    {
    }
}
