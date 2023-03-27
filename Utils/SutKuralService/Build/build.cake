//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var nugetApiKey = Argument<string>("nugetApiKey", "atlas_nuget_server");
var nugetFeedSource = "http://X.X.X.X:5555/v3/index.json";

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./artifacts") + Directory(configuration);
var solutionPath = "../SutKuralService.sln";
var projectRuleCheckerInterface = "../RuleChecker.Interface/RuleChecker.Interface.csproj";
var projectRuleCheckerEngine = "../RuleChecker.Engine/RuleChecker.Engine.csproj";
var projectRuleCheckerService = "../RuleChecker.Service/RuleChecker.Service.csproj";

var projectList = new List<string>() {
projectRuleCheckerInterface, projectRuleCheckerEngine, projectRuleCheckerService
};

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solutionPath);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
      // Use MSBuild
      MSBuild(solutionPath, settings =>
        settings.SetConfiguration(configuration));
    }
    else
    {
      // Use XBuild
      XBuild(solutionPath, settings =>
        settings.SetConfiguration(configuration));
    }
});


Task("BuildNugetPackages")
    .IsDependentOn("Build")
    .Does(() =>
{
    var nuGetPackSettings = new NuGetPackSettings
	{
		OutputDirectory = buildDir,
		IncludeReferencedProjects = true,
        ArgumentCustomization = args => args.Append("-Exclude *.xml -Exclude **/Resources/** -Exclude *.xsd"),
		Properties = new Dictionary<string, string>
		{
			{ "Configuration", "Release" }
		}
	};

    foreach (var targetProject in projectList)
    {
        NuGetPack(targetProject, nuGetPackSettings);    
    }

});


Task("AddPackagesToPrivateNugetFeed")
    .IsDependentOn("BuildNugetPackages")
    .Does(() =>
{
    var nugetPackageFolder = buildDir.ToString() + "/*.nupkg";
    var nugetPackages = GetFiles(nugetPackageFolder);
    foreach(var nugetPackage in nugetPackages)
    {
        Information("Nuget package file: {0}", nugetPackage);
        NuGetPush(nugetPackage, new NuGetPushSettings {
                Source = nugetFeedSource,
                ApiKey = nugetApiKey
            });
    }

});



//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("AddPackagesToPrivateNugetFeed");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
