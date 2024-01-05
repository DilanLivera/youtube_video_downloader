using System.CommandLine;

namespace YVD;

internal static class Program
{
    private static async Task<int> Main(string[] args)
    {
        var helloWorldCommand = new RootCommand(
            description: "Hello world command build using System.CommandLine");

        var nameOption = new Option<string>(
            name: "--name",
            description: "Name of the user.");
        helloWorldCommand.AddOption(nameOption);

        var cityOption = new Option<string>(
            name: "--city",
            description: "City of the user.");
        helloWorldCommand.AddOption(cityOption);

        helloWorldCommand.SetHandler(
            (Action<string, string>)HelloWorldHandler,
            nameOption,
            cityOption);

        return await helloWorldCommand.InvokeAsync(args);
    }

    private static void HelloWorldHandler(
        string name,
        string city) => Console.WriteLine($"Hello {name} from {city}");
}
