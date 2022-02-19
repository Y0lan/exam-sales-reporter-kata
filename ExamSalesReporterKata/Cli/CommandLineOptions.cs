using System.ComponentModel;
using exam_sales_reporter_kata.CsvParser;

namespace exam_sales_reporter_kata.Cli;

using CommandLine;
using CsvParser;
using static DataPrinter;

public class CommandLineOptions
{
    [Option('i',
        "input",
        Required = false,
        HelpText = "Input csv file to be processed.")]
    public string InputFile { get; set; } = String.Empty;

    [Option('p',
        "print",
        Required = true,
        HelpText = "Show the content of the file to the screen",
        SetName = "printRaw")]
    public bool Print { get; set; }

    [Option('r',
        "report",
        Required = true,
        HelpText = "Show the content of the file to the screen",
        SetName = "printReport")]
    public bool Report { get; set; }


    public static void RunOptions(CommandLineOptions commandLineOptions)
    {
        string filename = Directory.GetCurrentDirectory() + "/Data/data.csv";
        if (commandLineOptions.InputFile != "")
        {
            filename = commandLineOptions.InputFile;
        }

        Csv saleReportData = csvParser.ParseCsv(filename);


        if (commandLineOptions.Print)
        {
            //print file
            DisplayRawData(saleReportData);
        }

        if (commandLineOptions.Report)
        {
            // report file
            DisplayReport(saleReportData);
        }
    }
}