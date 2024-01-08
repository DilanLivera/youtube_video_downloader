using System.CommandLine;
using System.CommandLine.Parsing;

namespace YVD;

internal sealed class VideoIdOption
{
    private const bool IsDefault = false;
    private const string Description = "Id of the video.";
    private const string Name = "--id";

    private readonly ParseArgument<string> _parseArgument = result =>
    {
        var videoId = result.Tokens.Single().Value;
        if (string.IsNullOrWhiteSpace(videoId))
        {
            result.ErrorMessage =
                "The value for the --id option can not be empty, or only contains whitespaces.";
            return "";
        }

        return videoId;
    };

    public Option<string> Value => new(
        Name,
        _parseArgument,
        IsDefault,
        Description)
    {
        IsRequired = true
    };
}
