using System.Text.RegularExpressions;

namespace YVD;

internal sealed class FileName
{
    private static readonly string _invalidCharsPattern =
        "[" +
        Regex.Escape(new string(Path.GetInvalidFileNameChars())) +
        "]";

    private readonly string _title;

    public FileName(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException(
                "Value can not be null, empty or only contains white spaces",
                nameof(title));
        }

        _title = title;
    }

    public string Value => Regex.Replace(
        input: _title,
        _invalidCharsPattern,
        replacement: "");
}
