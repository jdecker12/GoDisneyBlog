namespace GoDisneyBlog.Data.Entities
{
    public interface ICard
    {
        int Id { get; set; }
        string? Category { get; set; }
        string? CardTitle { get; set; }
        string? CardImg { get; set; }
        string? CardImg3 { get; set; }
        string? CardLink { get; set; }
        string? CardLinkName { get; set; }
        string? CardIcon { get; set; }
        ICollection<CardContent>? CardContents { get; set; }
        StoreUser? User { get; set; }
    }
}
