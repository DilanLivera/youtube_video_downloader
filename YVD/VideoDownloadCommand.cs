using System.CommandLine;

namespace YVD;

internal sealed class VideoDownloadCommand
{
    private readonly Option<string> _downloadFolderPathOption = new DownloadFolderPathOption()
        .Value;

    private readonly Option<string> _videoIdOption = new VideoIdOption()
        .Value;

    public VideoDownloadCommand(
        VideoDownloadCommandHandler handler)
    {
        var command = new Command(
            name: "download",
            description: "Download the video using the video id.")
        {
            _videoIdOption, _downloadFolderPathOption
        };

        command.SetHandler(
            handle: async (videoId, downloadFolderPath) =>
            {
                try
                {
                    await handler.HandleAsync(videoId, downloadFolderPath);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            },
            _videoIdOption,
            _downloadFolderPathOption);

        Value = command;
    }

    public Command Value { get; }
}
