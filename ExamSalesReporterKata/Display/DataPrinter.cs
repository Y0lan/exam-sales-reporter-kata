using System.Globalization;
using ConsoleTables;
using CsvHelper.Configuration;
using exam_sales_reporter_kata.Structure;

namespace exam_sales_reporter_kata.CsvParser;

using CsvHelper;

public class DataPrinter
{
    public static void DisplayRawData(Csv sales)
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

    public static void DisplayReport(Csv sales)
    {
        CsvReport report = new CsvReport(sales);

        // Number of sales 
        ConsoleTable table = new ConsoleTable(
            "Number of sales",
            report.GetNumberOfSales().ToString());

        // Number of clients
        table.AddRow("Number of clients", report.GetNumberOfClient().ToString());

        // Total items sold
        table.AddRow("Total items sold", report.GetTotalItemsSold().ToString());

        // Total sales amount
        table.AddRow("Total sales amount",
            report.GetTotalSalesAmount().ToString(CultureInfo.InvariantCulture));

        // Average amount per sale
        table.AddRow("Average amount/sale",
            report.GetAverageAmountPerSale().ToString(CultureInfo.InvariantCulture));

        // Average item price
        table.AddRow("Average item price",
            report.GetAverageItemPrice().ToString(CultureInfo.InvariantCulture));

        Console.WriteLine();
        table.Write(Format.Alternative);
        Console.WriteLine();
    }
}