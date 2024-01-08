using System.CommandLine;
using System.CommandLine.Parsing;

namespace YVD;

internal sealed class DownloadFolderPathOption
{
    private const bool IsDefault = true;
    private const string Description = "The path for the download folder.";
    private const string Name = "--folder";

    private readonly ParseArgument<string> _parseArgument = result =>
    {
        // The value returned here will get shown in this option's description of the help output
        if (result.Tokens.Count == 0)
        {
            var userProfilePath = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);

            return Path.Combine(
                userProfilePath,
                @"Downloads\youtube_videos");
        }

        var path = result.Tokens.Single().Value;

        if (Path.Exists(path))
        {
            return path;
        }

        result.ErrorMessage =
            $"{path} folder does not exists. Please provide a path to a folder that exists.";
        return "";
    };

    public Option<string> Value => new(
        Name,
        _parseArgument,
        IsDefault,
        Description);
}
