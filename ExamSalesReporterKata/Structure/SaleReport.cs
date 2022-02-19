namespace exam_sales_reporter_kata.Structure;

public class SaleReport
{
    public int OrderId { get; set; }
    public string UserName { get; set; } = String.Empty;
    public int NumberOfItems { get; set; }
    public decimal Total { get; set; }
    public DateOnly DateOfBuy { get; set; }
}