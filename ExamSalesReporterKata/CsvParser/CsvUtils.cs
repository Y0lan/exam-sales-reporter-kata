using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper.Configuration;

namespace exam_sales_reporter_kata.CsvParser;

using CsvHelper;

public class CsvUtils
{
    public static Csv ParseCsv(string csvFilePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args =>
            {
                // TODO: reorganiser ça
                switch (args.Header)
                {
                    case "OrderId":
                        return args.Header.ToLower();
                    case "UserName":
                        return "userName";
                    case "NumberOfItems":
                        return "numberOfItems";
                    case "Price": 
                        return "totalOfBasket";
                    case  "DateOfBuy":
                        return "dateOfBuy";
                    default: return args.Header;
                }
            }
        };
        
        using var reader = new StreamReader(csvFilePath);
        using (var csv = new CsvReader(reader, config))
        {
            csv.Read();
            csv.ReadHeader();
            return new Csv
            {
                Header = csv.HeaderRecord,
                Data = csv.GetRecords<SaleReportData>().ToList()
            };
        }
        
    }

    public static void DisplayCsvRawData(Csv sales)
    {
        // HEADER
        foreach (var head in sales.Header)
        {
        }
        // BODY
        foreach (var sale in sales.Data)
        {
           Console.WriteLine(sale.Price); 
        }
    }

    public static void DisplayCsvReport(IEnumerable<SaleReportData> sales)
    {
        // TODO pretty print 
        foreach (var sale in sales)
        {
            Console.Write(sale.NumberOfItems);
        }
    }

    static void PrettyPrintCsvHeader()
    {
        // TODO get header type and print it pretty
    }
}

public class SaleReportData
{
    public int OrderId { get; set; }
    public string UserName { get; set; }
    public int NumberOfItems { get; set; }
    public decimal Price { get; set; }
    public DateOnly DateOfBuy { get; set; }
}