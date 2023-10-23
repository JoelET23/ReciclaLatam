using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models
{
    public class ZonasModels
    {
        public int zona_id { get; set; }
        public string campoO { get; set; }
        public string campoT { get; set; }
        public string diarecojo { get; set; }
        public string horarecojo { get; set; }
        public string latlong { get; set; }
        public int numzona { get; set; }

        public string NomZon => $"Zona\n{numzona}";
    }

    public class ZonasLista
    {
        public List<ZonasModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }
}
