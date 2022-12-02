namespace Domain.Dto;
public class GetBooks
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BookName { get; set; }
    public int Author_id { get; set; }
}