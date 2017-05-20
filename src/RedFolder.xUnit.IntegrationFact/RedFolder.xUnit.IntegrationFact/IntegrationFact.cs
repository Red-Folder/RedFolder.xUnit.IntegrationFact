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
            return IntegrationFactAttribute.Enabled
                ? new[] { new XunitTestCase(diagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), testMethod) }
                : Enumerable.Empty<IXunitTestCase>();
        }
    }

    [XunitTestCaseDiscoverer("RedFolder.xUnit.IntegrationFact.IntegrationFactDiscoverer", "RedFolder.xUnit.IntegrationFact")]
    public class IntegrationFactAttribute : FactAttribute
    {
        public override string Skip
        {
            get
            {
                if (base.Skip != null && base.Skip.Length > 0)
                {
                    return base.Skip;
                }

                if (Enabled)
                {
                    return base.Skip;
                }

                return "Integration Fact not enabled (Resharper workaround - see https://github.com/Red-Folder/RedFolder.xUnit.IntegrationFact/issues/1");
            }

            set
            {
                base.Skip = value;
            }
        }

        public static bool Enabled
        {
            get
            {
                var enabled = Environment.GetEnvironmentVariable("XUNIT_INTERGRATION_FACT_ENABLED");
                return (enabled.ToLower() == "true");
            }
        }
    }
}
