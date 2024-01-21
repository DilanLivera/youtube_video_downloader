# YouTube video downloader

## Description

YouTube Downloader is a Commandline application built using the
[System.CommandLine 2.0.0-beta4.22272.1 | NuGet Gallery](https://www.nuget.org/packages/System.CommandLine)
package. Please refer to the
[System.CommandLine overview - .NET | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/standard/commandline/)
document for more information about the System.CommandLine package. The application uses the
[Tyrrrz/YoutubeExplode: Abstraction layer over YouTube's internal API (github.com)](https://github.com/Tyrrrz/YoutubeExplode)
package to download the videos from YouTube.

## How to run the application

### With `dotnet run` command

Run
the `dotnet run --project .\YVD\YVD.csproj download -- --id 'video_id' --folder 'download_folder'`
command from the root folder or `dotnet run download -- --id 'video_id' --folder 'download_folder'`
command from the project folder with the appropriate values.

### With _exe_ file

- Publish the file using the `dotnet publish -o publish` command. This should create a folder inside
  the folder where you ran the command.
- Run
  the `.\YVD download --id 'video_id' --folder 'download_folder'` command within the _publish_
  folder with the appropriate arguments to run the application.

### With dotnet tool

#### Create the package

- Add the following to the **.csproj** file

```xml
  <PropertyGroup>
    <PackAsTool>true</PackAsTool>
    <Version>1.0.0</Version>
    <!--
      When the ToolCommandName isn't provided, the command name for the tool is the assembly name
     -->
    <ToolCommandName>youtubedownload</ToolCommandName>
    <!--
      PackageOutputPath determines where the NuGet package will be produced.
      The NuGet package is what the .NET CLI uses to install your tool.
     -->
    <PackageOutputPath>./nupkg</PackageOutputPath>
</PropertyGroup>
```

- Create the package (`dotnet pack`).

#### Install the package

- Create a tool manifest (`dotnet new tool-manifest`).
- Install the tool (`dotnet tool install --add-source ./YVD/nupkg YVD`. This command is to install
  the tool from a local nuget package folder).
    - When I had the package marked as a preview(`1.0.0-preview`), `install` command was throwing
      the _Unhandled exception:
      Microsoft.DotNet.Cli.NuGetPackageDownloader.NuGetPackageNotFoundException: yvd::[*, ) is not
      found in NuGet feeds C:\repos\other\youtube_video_downloader\YVD\nupkg\, C:
      \repos\other\youtube_video_downloader\YVD\nupkg"_
      exception.
    - When I removed the **-preview** from the version, tool got installed.

#### Run the tool

- Run the tool (`dotnet youtubedownload download --id 'video_id'`).

## Commands

### `download`

The `download` command downloads the video from YouTube. You can run one of
the `dotnet run download -- --help`, `dotnet run --project .\YVD\YVD.csproj download -- --help`, `.\YVD download --help`
or `dotnet youtubedownload --help` commands to discover the command options.
