using System.CommandLine;

namespace YVD;

internal sealed class VideoDownloadCommand
{
    private readonly VideoDownloader _downloader;

    private readonly Option<string> _downloadFolderPathOption = new DownloadFolderPathOption()
        .Value;

    private readonly Option<string> _videoIdOption = new(
        name: "--id",
        description: "Id of the video.");

    public VideoDownloadCommand(
        VideoDownloader downloader)
    {
        _downloader = downloader;

        var command = new Command(
            name: "download",
            description: "Download the video using the video id.")
        {
            _videoIdOption, _downloadFolderPathOption
        };

        command.SetHandler(
            handle: Handle,
            _videoIdOption,
            _downloadFolderPathOption);

        Value = command;
    }

    public Command Value { get; }

    private void Handle(
        string videoId,
        string downloadFolderPath)
    {
        try
        {
            _downloader.DownloadVideoAsync(videoId, downloadFolderPath)
                .GetAwaiter()
                .GetResult();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}
