namespace SportsX.Repository.Entities
{
    public class Client : BaseEntity<int>
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public int IdClassification { get; set; }
        public Classification Classification { get; set; }
        public int IdClientType { get; set; }
        public ClientType ClientType { get; set; }
    }
}
