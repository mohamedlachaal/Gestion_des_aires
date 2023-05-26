using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marhaba.Models
{
    public class Passager
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Tel { get; set; }
        public String Password { get; set; }
        public List<Reservation> reservations{ get; set; }
    }
}
