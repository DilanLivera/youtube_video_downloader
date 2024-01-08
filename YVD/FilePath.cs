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

        _fileName = fileName;
    }

    public string Value => Path.Combine(
        _downloadFolderPath,
        $"{_fileName.Value}.{_extension}");
}
