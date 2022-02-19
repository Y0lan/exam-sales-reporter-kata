using exam_sales_reporter_kata.Structure;

namespace exam_sales_reporter_kata.CsvParser;

public struct Csv
{
    public Csv(string[] header, IEnumerable<SaleReport> data)
    {
        Header = header;
        Data = data;
    }

    public string[] Header { get; set; }
    public IEnumerable<SaleReport> Data { get; set; }
    public override string ToString() => $"({Header}, {Data})";
}
