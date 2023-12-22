using CynkyHook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using TechTalk.SpecFlow;

[assembly: Parallelize(Workers = 100, Scope = ExecutionScope.ClassLevel)]
namespace DemoAutomation.Configuration
{
    [Binding]
    class Hooks
    {
        Config _Config;

        Hooks()
        {
            _Config = new Config();
        }

        [BeforeTestRun]
        static void InitializeReport()
        {
            Config.InitializeReport();
        }

        [BeforeScenario]
        void Launch(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _Config.Launch(featureContext, scenarioContext, ConfigManager.RS_User, ConfigManager.RS_Key);
        }

        [BeforeFeature]
        static void BeforeFeature(FeatureContext featureContext)
        {
            Config.BeforeFeature(featureContext);
        }

        [AfterScenario]
        void AfterScenario(ScenarioContext scenarioContext)
        {
            _Config.AfterScenario(scenarioContext);
        }

        [AfterStep]
        void Steps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _Config.Steps(featureContext, scenarioContext);
        }

        [AfterTestRun]
        static void TearDownReport()
        {
            Config.TearDownReport();
        }
    }
}
