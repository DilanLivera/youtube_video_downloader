using Spectre.Console;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YVD;

internal sealed class VideoDownloadCommandHandler
{
    private readonly YoutubeClient _youtube;

    public VideoDownloadCommandHandler(
        YoutubeClient youtube) => _youtube = youtube;

    internal async Task HandleAsync(
        string videoId,
        string downloadFolderPath)
    {
        var videoUrl = $"https://youtube.com/watch?v={videoId}";

        await AnsiConsole.Status()
            .AutoRefresh(true)
            .Spinner(Spinner.Known.Star)
            .SpinnerStyle(Style.Parse("green bold"))
            .StartAsync(
                status: $"Downloading the video {videoId}...",
                async ctx =>
                {
                    ctx.Status("[yellow]Getting the stream manifest[/]");
                    var streamManifest = await _youtube.Videos
                        .Streams
                        .GetManifestAsync(videoUrl);

                    ctx.Status("[yellow]Getting the video stream info[/]");
                    var streamInfo = streamManifest
                        .GetMuxedStreams()
                        .Where(s => s.Container == Container.Mp4)
                        .GetWithHighestVideoQuality();

                    ctx.Status("[yellow]Getting the video details[/]");
                    var video = await _youtube.Videos
                        .GetAsync(videoUrl);
                    var fileName = new FileName(video.Title);
                    var filePath = new FilePath(
                        downloadFolderPath,
                        extension: streamInfo.Container.ToString(),
                        fileName);

                    ctx.Status("[yellow]Downloading the video[/]");
                    await _youtube.Videos
                        .Streams
                        .DownloadAsync(
                            streamInfo,
                            filePath.Value);

                    ctx.Status("[green]Downloading completed successfully.[/]");
                    AnsiConsole.MarkupLine($"[green]Please find the file @ {filePath.Value}[/]");
                });
    }
}
