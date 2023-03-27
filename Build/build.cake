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
var solutionPath = "../AtlasAssembly.sln";
var projectAtlasEnums = "../AtlasEnums/AtlasEnums.csproj";
var projectAtlasModel = "../AtlasModel/AtlasModel.csproj";
var projectAtlasDataModel = "../AtlasDataModel/AtlasDataModel.csproj";

var projectList = new List<string>() {
    projectAtlasEnums
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

public void BuildNugetPackageForProject(string projectPath, string packageVersion) 
{
    var nuGetPackSettings = new NuGetPackSettings
	{
		OutputDirectory = buildDir,
        Version = packageVersion,
		IncludeReferencedProjects = true,
        ArgumentCustomization = args => args.Append("-Exclude *.xml -Exclude **/Resources/** -Exclude *.xsd"),
		Properties = new Dictionary<string, string>
		{
			{ "Configuration", "Release" }
		}
	};
   
    NuGetPack(projectPath, nuGetPackSettings);    
}

public void PushNugetPackageToServer(string packageName, string packageVersion)
{
    var nugetPackageFolder = buildDir.ToString() + $"/{packageName}.{packageVersion}.nupkg";
    var nugetPackages = GetFiles(nugetPackageFolder);
    foreach(var nugetPackage in nugetPackages)
    {
        Information("Nuget package file: {0}", nugetPackage);
        NuGetPush(nugetPackage, new NuGetPushSettings {
                Source = nugetFeedSource,
                ApiKey = nugetApiKey
            });
    }
}


//////////////////////////////////////////////////////////////////////
// nuget package build and publish 
//////////////////////////////////////////////////////////////////////

Task("BuildNugetPackageForAtlasEnums")
    .IsDependentOn("Build")
    .Does(() =>
{
    BuildNugetPackageForProject(projectAtlasEnums, "1.0.0");
});

Task("AddAtlasEnumsPackageToPrivateNugetFeed")
    .IsDependentOn("BuildNugetPackageForAtlasEnums")
    .Does(() =>
{
    PushNugetPackageToServer(projectAtlasEnums, "1.0.0");
});

Task("BuildNugetPackageForAtlasModel")
    .IsDependentOn("Build")
    .Does(() =>
{
    BuildNugetPackageForProject(projectAtlasModel, "1.0.0");
});

Task("AddAtlasModelPackageToPrivateNugetFeed")
    .IsDependentOn("BuildNugetPackageForAtlasModel")
    .Does(() =>
{
    PushNugetPackageToServer(projectAtlasModel, "1.0.0");
});

Task("BuildNugetPackageForAtlasDataModel")
    .IsDependentOn("Build")
    .Does(() =>
{
    BuildNugetPackageForProject(projectAtlasDataModel, "1.0.0");
});


//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
