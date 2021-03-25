using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DISPBackEnd.Models
{
    public class Vaerktoejskasse
    {
        public int VaerktoejskasseId { get; set; }
        public string VTKanskaffet { get; set; }
        public string VTKEjesAf { get; set; }
        public string VTKFabrikat { get; set; }
        public string VTKFarve { get; set; }
        public string VTKModel { get; set; }
        public string VTKSerieNummer { get; set; }
        public List<Vaerktoej> Vaerktoejs { get; set; }
        public int HaandVaerkerId { get; set; }
    }
}
