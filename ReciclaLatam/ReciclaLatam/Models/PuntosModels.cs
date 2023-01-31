using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.Models
{
    public class PuntosModels
    {
        public int id_municipalidad { get; set; }
        public int puntos_recojo_id { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
    }

    public class PuntosLista
    {
        public List<PuntosModels> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
    }
}
