﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace UI.Tests.FeaturesFiles
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class BusheyHospitalPageFeature : Xunit.IClassFixture<BusheyHospitalPageFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Page.feature"
#line hidden
        
        public BusheyHospitalPageFeature(BusheyHospitalPageFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Bushey Hospital Page", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.TheoryAttribute(DisplayName="Verify top menu links exists on page")]
        [Xunit.TraitAttribute("FeatureTitle", "Bushey Hospital Page")]
        [Xunit.TraitAttribute("Description", "Verify top menu links exists on page")]
        [Xunit.TraitAttribute("Category", "Browser_Chrome")]
        [Xunit.TraitAttribute("Category", "Hosp")]
        [Xunit.InlineDataAttribute("homepage", "spire-bushey-hospital/", new string[0])]
        public virtual void VerifyTopMenuLinksExistsOnPage(string page, string hospital, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Browser_Chrome",
                    "Hosp"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify top menu links exists on page", null, @__tags);
#line 5
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
testRunner.Given(string.Format("I navigated to {0} {1}", page, hospital), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Menu",
                        "Count",
                        "Find",
                        "TestCase"});
            table1.AddRow(new string[] {
                        "Book an appointment",
                        "6",
                        "a[href*=book-an-appointment]",
                        "0"});
            table1.AddRow(new string[] {
                        "Treatments",
                        "34",
                        "a[href*=treatments]",
                        "1"});
            table1.AddRow(new string[] {
                        "Consultants",
                        "3",
                        "a[href*=consultants]",
                        "2"});
            table1.AddRow(new string[] {
                        "Patient information",
                        "9",
                        "a[href*=patient-information]",
                        "3"});
            table1.AddRow(new string[] {
                        "Find us",
                        "3",
                        "a[href*=find-us]",
                        "4"});
            table1.AddRow(new string[] {
                        "GP info",
                        "2",
                        "a[href*=gp-info]",
                        "5"});
            table1.AddRow(new string[] {
                        "Prices",
                        "0",
                        "a[href*=prices]",
                        "6"});
#line 7
testRunner.When("I count the number of links", ((string)(null)), table1, "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                BusheyHospitalPageFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                BusheyHospitalPageFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion