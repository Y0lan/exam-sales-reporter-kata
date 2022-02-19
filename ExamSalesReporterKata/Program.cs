using System.Diagnostics.SymbolStore;
using exam_sales_reporter_kata.Cli;

namespace exam_sales_reporter_kata;

using CommandLine;
using static Console;
using static CommandLineOptions; // Static keyword only available in v6

public class Program
{
    public static void Main(string[] args)
    {
        Start();
        Parser.Default.ParseArguments<CommandLineOptions>(args)
            .WithParsed(RunOptions);
    }

    static void Start()
    {
        //TODO probablement à réfléchir encore !
        WriteLine("=== Sales Viewer ===");
        // Add more little things needed at the start of the program here
    }
}