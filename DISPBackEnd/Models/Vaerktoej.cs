using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DISPBackEnd.Models
{
    public class Vaerktoej
    {
        public string Liggerlvtk { get; set; }
        public string VTAnskaffet { get; set; }
        public string VTFabrikat{ get; set; }
        public int VaerktoejId { get; set; }
        public string VTModel { get; set; }
        public string VTSerieNr { get; set; }
        public string VTType { get; set; }
        public int VaerktoejskasseId { get; set; }
        public Vaerktoejskasse vaerktoejskasse { get; set; }

    }
}
