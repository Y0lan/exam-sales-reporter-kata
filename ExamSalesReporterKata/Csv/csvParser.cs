using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using exam_sales_reporter_kata.Structure;

namespace exam_sales_reporter_kata.CsvParser;

public class csvParser
{
    public static Csv ParseCsv(string csvFilePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args =>  FormatHeaders(args.Header)
            };
            
            using var reader = new StreamReader(csvFilePath);
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();
                return new Csv
                {
                    Header = csv.HeaderRecord,
                    Data = csv.GetRecords<SaleReport>().ToList()
                };
            }
            
        }
    public static string FormatHeaders(string headers)
    {
        switch (headers)
        {
            case "OrderId":
                return headers.ToLower();
            case "UserName":
                return "userName";
            case "NumberOfItems":
                return "numberOfItems";
            case "Total":
                return "totalOfBasket";
            case "DateOfBuy":
                return "dateOfBuy";
            default: return headers;
        }
    }
}