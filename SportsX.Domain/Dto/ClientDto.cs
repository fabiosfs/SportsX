namespace SportsX.Domain.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public int IdClassification { get; set; }
        public ClassificationDto Classification { get; set; }
        public int IdClientType { get; set; }
        public ClientTypeDto ClientType { get; set; }
    }
}
