using System.Globalization;

namespace exam_sales_reporter_kata.CsvParser;

using CsvHelper;

public class CsvParser
{
    static SalesReportData ParseCsv(string csvFilePath)
    {
        using var reader = new StreamReader(csvFilePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecord<SalesReportData>();
    }

    static void DisplayCsvRawData(string filepath)
    {
        SalesReportData csvData = ParseCsv(filepath);
        // TODO pretty print
        
    }

    static void DisplayCsvReport(string csvFilePath)
    {
       // TODO pretty print 
    }
}

public class SalesReportData
{
    public int OrderId { get; set; }
    public string UserName { get; set; }
    public int NumberOfItems { get; set; }
    public decimal Price { get; set; }
    public DateOnly DateOfBuy { get; set; }
}