namespace exam_sales_reporter_kata.CsvParser;

public struct Csv
{
    public Csv(string[] header, IEnumerable<SaleReportData> data)
    {
        Header = header;
        Data = data;
    }

    public string[] Header { get; set; }
    public IEnumerable<SaleReportData> Data { get; set; }
    public override string ToString() => $"({Header}, {Data})";
}