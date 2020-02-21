using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemblableDataManager.Library.Models
{
    public class SemblableModel
    {
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Age { get; set; }
        public string Arme { get; set; }
        public int Physique { get; set; }
        public int Puissance { get; set; }
        public int Celerite { get; set; }
        public int Endurance { get; set; }

        public DateTime DateDeCreation { get; set; }

    }
}
