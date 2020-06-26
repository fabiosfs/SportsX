namespace SportsX.Repository.Entities
{
    public class Telephone : BaseEntity<int>
    {
        public int IdClient { get; set; }
        public Client Client { get; set; }
        public string Number { get; set; }
    }
}
