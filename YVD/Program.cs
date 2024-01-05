using System.CommandLine;
using YoutubeExplode;

namespace YVD;

internal static class Program
{
    private static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand(
            description: "YouTube video downloader");

        var client = new YoutubeClient();
        var downloader = new VideoDownloader(client);
        var videoDownloadCommand = new VideoDownloadCommand(downloader);

        rootCommand.AddCommand(videoDownloadCommand.Value);

        return await rootCommand.InvokeAsync(args);
    }
}
