using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YVD;

internal sealed class VideoDownloader
{
    private readonly YoutubeClient _youtube;

    public VideoDownloader(
        YoutubeClient youtube) => _youtube = youtube;

    internal async Task DownloadVideoAsync(
        string videoId,
        string downloadFolderPath)
    {
        var videoUrl = $"https://youtube.com/watch?v={videoId}";

        Console.WriteLine("Getting the video details");
        var video = await _youtube.Videos
            .GetAsync(videoUrl);

        Console.WriteLine("Getting the stream manifest");
        var streamManifest = await _youtube.Videos
            .Streams
            .GetManifestAsync(videoUrl);

        Console.WriteLine("Getting the video stream info");
        var streamInfo = streamManifest
            .GetMuxedStreams()
            .Where(s => s.Container == Container.Mp4)
            .GetWithHighestVideoQuality();

        var fileName = new FileName(video.Title);
        var filePath = new FilePath(
            downloadFolderPath,
            extension: streamInfo.Container.ToString(),
            fileName);

        Console.WriteLine("Downloading the video");
        await _youtube.Videos
            .Streams
            .DownloadAsync(
                streamInfo,
                filePath.Value);

        Console.WriteLine($"Downloading completed successfully. File path: {filePath.Value}");
    }
}
