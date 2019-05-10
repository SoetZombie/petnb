using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using petnb.DTL.Data.Models;

namespace petnb.Models
{
    public class petnbContext : DbContext
    {
        public petnbContext (DbContextOptions<petnbContext> options)
            : base(options)
        {
        }

        public DbSet<petnb.DTL.Data.Models.PetSitterOffer> PetSitterOffer { get; set; }
    }
}
