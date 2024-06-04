using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models
{
    public class SugerenciasModels
    {
        public string titulo_sugerencia { get; set; }
        public string resume_sugerencia { get; set; }
        public string usuario_sugerencia { get; set; }
        public string campoO { get; set; }
        public string campoT { get; set; }
        public string campoTh { get; set; }
        public string campoF { get; set; }
        public int id { get; set; }
    }

    public class SugerenciasLista
    {
        public List<SugerenciasModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }
}
