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
        var handler = new VideoDownloadCommandHandler(client);
        var videoDownloadCommand = new VideoDownloadCommand(handler);

        rootCommand.AddCommand(videoDownloadCommand.Value);

        return await rootCommand.InvokeAsync(args);
    }
}
