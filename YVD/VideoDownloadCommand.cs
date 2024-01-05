using System.CommandLine;

namespace YVD;

internal sealed class VideoDownloadCommand
{
    private readonly VideoDownloader _downloader;

    private readonly Option<string> _downloadFolderPathOption = new(
        name: "--folder",
        description: "The path for the download folder.");

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
        string folderPath)
    {
        try
        {
            _downloader.DownloadVideoAsync(videoId, folderPath)
                .GetAwaiter()
                .GetResult();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}
