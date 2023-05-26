using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marhaba.Models
{
    public class Aire
    {
        public int Id{ get; set; }
        public String Nom { get; set; }

        public Ville ville { get; set; }
        public int VilleId { get; set; }
        public List<Reservation> reservations { get; set; }
        [NotMapped]
        public int TotalReservations { get; set; }
    }
}
