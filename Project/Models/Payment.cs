namespace Project.Models
{
  public class Payment
  {
    public int Id { get; set; }
    public string? ClassName { get; set; }
    public decimal? FeesAmount { get; set; }
    public string? FeesCategory { get; set; }
    public string? PaymentStatus { get; set; }
    public string? RollNo { get; set; }
    public string? StudentName { get; set; }
  }
}
