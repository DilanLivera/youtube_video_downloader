namespace YVD;

internal sealed class FilePath
{
    private readonly string _downloadFolderPath;
    private readonly string _extension;
    private readonly FileName _fileName;

    public FilePath(
        string downloadFolderPath,
        string extension,
        FileName fileName)
    {
        _downloadFolderPath = downloadFolderPath;

        if (string.IsNullOrWhiteSpace(extension))
        {
            throw new ArgumentException(
                "Value can not be null, empty or only contains white spaces",
                nameof(extension));
        }

        _extension = extension;

        _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
    }

    public string Value => CreateFilePath();

    private string CreateFilePath()
    {
        var fileNameWithExtension = $"{_fileName.Value}.{_extension}";

        if (Path.Exists(_downloadFolderPath))
        {
            return Path.Combine(
                _downloadFolderPath,
                fileNameWithExtension);
        }

        var userProfilePath = Environment.GetFolderPath(
            Environment.SpecialFolder.UserProfile);

        return Path.Combine(
            userProfilePath,
            @"Downloads\youtube_videos",
            fileNameWithExtension);
    }
}
