using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marhaba.Models
{
    public class Reservation
    {
        public DateTime DateReservation { get; set; }
        public Aire aire { get; set; }
        public int AireId { get; set; }
        public Passager passager { get; set; }
        public int PassagerId { get; set; }
    }
}
