using System.Globalization;
using ConsoleTables;
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
                // TODO: reorganiser ça ailleurs
                switch (args.Header)
                {
                    case "OrderId":
                        return args.Header.ToLower();
                    case "UserName":
                        return "userName";
                    case "NumberOfItems":
                        return "numberOfItems";
                    case "Total": 
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

    public static void DisplayCsvRawData(Csv sales) //TODO sortir ça d'ici
    {
        var table = new ConsoleTable(sales.Header);
        foreach (var sale in sales.Data)
        {
            table.AddRow(
                sale.OrderId.ToString(), 
                sale.UserName, 
                sale.NumberOfItems.ToString(),
                sale.Total.ToString(CultureInfo.InvariantCulture),
                sale.DateOfBuy.ToString("yyyy-MM-dd")
            );
        }

        Console.WriteLine();
        table.Write(Format.Alternative);
        Console.WriteLine();

    }

    public static void DisplayCsvReport(IEnumerable<SaleReportData> sales) //TODO sortir ça d'ici
    {
        // TODO pretty print 
        foreach (var sale in sales)
        {
            Console.Write(sale.NumberOfItems);
        }
    }
}

public class SaleReportData
{
    public int OrderId { get; set; }
    public string UserName { get; set; } = String.Empty;
    public int NumberOfItems { get; set; }
    public decimal Total { get; set; }
    public DateOnly DateOfBuy { get; set; }
}