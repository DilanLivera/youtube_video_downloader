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

**Using the `dotnet run` command**

Run
the `dotnet run --project .\YVD\YVD.csproj download -- --id 'video_id' --folder 'download_folder'`
command from the root folder or `dotnet run download -- --id 'video_id' --folder 'download_folder'`
command from the project folder with the appropriate values.

**Using the exe file**

- Publish the file using the `dotnet publish -o publish` command. This should create a folder inside
  the folder where you ran the command.
- Run
  the `.\YVD download --id 'video_id' --folder 'download_folder'` command within the _publish_
  folder with the appropriate arguments to run the application.

## Commands

### `download`

The `download` command downloads the video from YouTube. You can run one of
the `dotnet run download -- --help`, `dotnet run --project .\YVD\YVD.csproj download -- --help`
or `.\YVD download --help` commands to discover the command options.
