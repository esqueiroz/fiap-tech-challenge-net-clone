using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Domain
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
        }
    }
}
