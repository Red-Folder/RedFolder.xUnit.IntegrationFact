# RedFolder.xUnit.IntegrationFact
IntegrationFact attribute for xUnit.  Allows Integration Facts to appear based on environment variable

## Work in Progress
While it all seems to work, this is currently very much work in progress - thus the alpha state.

Feel free to use - I'd appreciate any feedback.

## Why would I use this
This custom xUnit attribute is intended to be used with integration tests.  By nature, integration test will be slower (and possible have side-effects) compared to unit tests.

Normally, for developer productivity, you will want to run you quick unit test very regulary.  Slower a test suite runs, less likely the tests are used.

As such, common practice is to keep integration (and over long running) tests separate.

IntegrationFact allows you to do this by selectively enabling/ disabling while still using the xUnit tool you are familar with.

## How it works
Simply set an environment variable XUNIT_INTERGRATION_FACT_ENABLED=true - this will enable the integration tests to be picked up by xUnit and Visual Studio Test Explorer.

Note that Visual Studio will need to be restarted to pick up the environment vaiable.

## Why an environment variable
The environment variable approach is not without friction.  Having to change the variable, restart Visual Studio can be a pain.

However, I wanted to avoid any situation in which a one developer could accidently enable it for another developer (for example, if I'd used app.config setting which could have been checked into source control and then propogated to all in the team).

I may look at enabling via some other method dependant on feedback.

## Know issues
Disabled Integration tests will still show in Resharper.  I believe this to be a problem with Resharper and how it discovered xUnit tests - see https://github.com/Red-Folder/RedFolder.xUnit.IntegrationFact/issues/1

## Credits
Credit for the code goes to the Octokit team and the IntegrationTestAttribute -> https://github.com/octokit/octokit.net/blob/c9b2c1260bc87b7782d4fd9645d43a8885203923/Octokit.Tests.Integration/Helpers/IntegrationTestAttribute.cs
