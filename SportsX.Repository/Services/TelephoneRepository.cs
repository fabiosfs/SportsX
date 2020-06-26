using Microsoft.EntityFrameworkCore;
using SportsX.Repository.Entities;
using SportsX.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsX.Repository.Services
{
    public class TelephoneRepository : BaseRepository<Telephone, int>, ITelephoneRepository
    {
        public TelephoneRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Telephone>> UpdateAsync(IEnumerable<Telephone> telephones, int idClient)
        {
            // Busca os telefones do cliente na base de dados
            var telephonesDb = _dbSet.Where(x => x.IdClient == idClient).ToList();
            
            // Cria uma variavel que sera utilizada para trabalhar os dados
            var telephoneUpdate = telephonesDb;

            // Atualiza os telefones que não foram excluidos
            telephoneUpdate.Where(x => telephones.Any(y => y.Id == x.Id && y.Number != x.Number))
                .ToList().ForEach(telephone =>
            {
                telephone.Number = telephones
                    .Where(x => x.Id == telephone.Id)
                    .Select(x => x.Number)
                    .FirstOrDefault();
                telephone.IdClient = idClient;
                _dbContext.Entry(telephone).Property(x => x.Id).IsModified = false;
                _dbContext.Entry(telephone).CurrentValues.SetValues(telephone);
                _dbContext.SaveChanges();
            });

            // Busca todos os dados do cliente
            telephoneUpdate = telephonesDb;

            // Remove os telefones excluidos
            telephonesDb.Where(x => !telephones.Any(y => y.Id == x.Id))
                .ToList().ForEach(telephone =>
            {
                _dbContext.Attach(telephone);
                _dbContext.Remove(telephone);
                _dbContext.SaveChanges();
            });
            
            // Insere os registros que não existem na base
            telephones.Where(x => x.Id == 0)
                .ToList().ForEach(telephone =>
                {
                    telephone.IdClient = idClient;
                    _dbSet.Add(telephone);
                    _dbContext.SaveChanges();
                });

            // Busca os telefones do cliente para retornar
            telephonesDb = _dbSet.Where(x => x.IdClient == idClient).ToList();
            return telephonesDb;
        }
    }
}