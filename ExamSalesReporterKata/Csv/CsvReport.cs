using System.Runtime.CompilerServices;
using exam_sales_reporter_kata.Structure;

namespace exam_sales_reporter_kata.CsvParser;

//TODO iterate on csv.Data only ONCE and send back result
public class CsvReport //TODO rename
{
    private Csv csv;
    public int numberOfSales;
    private List<String> client;
    public int numberOfClient;
    public int totalItemsSold;
    public decimal totalSalesAmount;
    public decimal averageAmountPerSale;
    public decimal averageItemPrice;

    public CsvReport(Csv csv)
    {
        this.csv = csv;
        AggregateData();
        CalculateNumberOfSales();
        CalculateNumberOfClient();
        CalculateAverageAmountPerSale();
        CalculateAverageItemPrice();
    }

    private void AggregateData()
    {
        client = new List<string>();
        foreach (SaleReport saleReport in csv.Data)
        {
            client.Add(saleReport.UserName);
            totalItemsSold += saleReport.NumberOfItems;
            totalSalesAmount += saleReport.Total;
        }
    }

    public int GetNumberOfSales()
    {
        return numberOfSales;
    }

    private void CalculateNumberOfSales()
    {
        numberOfSales = csv.Data.Count();
    }

    public int GetNumberOfClient()
    {
        return numberOfClient;
    }


    void CalculateNumberOfClient()
    {
        numberOfClient = client.Distinct().Count();
    }

    public int GetTotalItemsSold()
    {
        return totalItemsSold;
    }

    public decimal GetTotalSalesAmount()
    {
        return totalSalesAmount;
    }

    void CalculateAverageAmountPerSale()
    {
        averageAmountPerSale = Math.Round(GetTotalSalesAmount() / GetNumberOfSales(), 2);
    }

    public decimal GetAverageAmountPerSale()
    {
        return averageAmountPerSale;
    }

    void CalculateAverageItemPrice()
    {
        averageItemPrice = Math.Round(GetTotalSalesAmount() / GetTotalItemsSold(), 2);
    }


    public decimal GetAverageItemPrice()
    {
        return averageItemPrice;
    }
}