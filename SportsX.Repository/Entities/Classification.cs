using System.Collections.Generic;

namespace SportsX.Repository.Entities
{
    public class Classification : BaseEntity<int>
    {
        public string Name { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}
