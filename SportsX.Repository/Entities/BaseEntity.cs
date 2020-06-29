using System;
using System.ComponentModel.DataAnnotations;

namespace SportsX.Repository.Entities
{

    // Classe base facilitação de replicação dos campos de controle das tabelas
    public abstract class BaseEntity<TId> where TId : struct
    {
        [Key]
        public TId Id { get; set; }
        public DateTime DtCriation { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool Excluded { get; set; }
    }
}
